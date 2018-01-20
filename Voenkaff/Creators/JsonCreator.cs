using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using Voenkaff.Wrappers;

namespace Voenkaff.Creators
{
    public class JsonCreator
    {

        public string CreateTestCollection(List<Test> tests)
        {
            var jsonTests = new List<Wrappers.Test>();
            foreach (var test in tests)
            {
                jsonTests.Add(CreateTestJsonMessage(test));
            }

            return JsonConvert.SerializeObject(new Tests{PlatoonList = VzvodAndLs.Get(),TestList = jsonTests},Formatting.Indented);
        }
        

        private Wrappers.Test CreateTestJsonMessage(Test testObj)
        {
            var test = new Wrappers.Test
            {
                Name = testObj.TestName,
                Marks = new Marks
                {
                    Excellent = testObj.ListMarks[0],
                    Good = testObj.ListMarks[1],
                    Satisfactory = testObj.ListMarks[2]
                }
            };

            foreach (var task in testObj.ListPanelsTasks)
            {
                var questions = task.Entity.Controls.Find("panelQuestion", false)[0];
                var answers = task.Entity.Controls.Find("panelAnswer", false)[0];
                var taskElements = new List<TaskElement>();
                foreach (Control taskElement in questions.Controls)
                {
                    if (!(taskElement is TextBox) && !(taskElement is PictureBox) &&
                        !(taskElement is RichTextBox)) continue;
                    var element = new TaskElement
                    {
                        Name = taskElement.Name,
                        Type = taskElement.GetType().ToString(),
                        Width = taskElement.Width,
                        Height = taskElement.Height,
                        Point = taskElement.Location,
                    };
                    if (taskElement is TextBox)
                    {
                        element.Answer = answers.Controls.Find(taskElement.Name, false)[0].Controls[0].Text;
                    }

                    if (taskElement is PictureBox)
                    {
                        element.Media = "picture\\" + ((PictureBox) taskElement).Name+".bin";
                    }

                    if (taskElement is RichTextBox)
                    {
                        element.Text = taskElement.Text;
                    }

                    taskElements.Add(element);
                }

                var tasks = new Task {TaskElements = taskElements, Name = questions.Text};
                test.Tasks.Add(tasks);
            }

            
            return test;
        }
    }
}