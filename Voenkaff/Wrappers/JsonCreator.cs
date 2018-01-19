using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Voenkaff.Wrappers
{
    class JsonCreator
    {
        public string CreateTestCollection(List<Voenkaff.Test> tests)
        {
            var json = "[";
            foreach (var test in tests)
            {
                json += CreateTestJsonMessage(test) + ",";
            }

            return json.Substring(0, json.Length - 1) + "]";
        }

        public string CreateTestJsonMessage(Voenkaff.Test testObj)
        {
            var test = new Test
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
                        element.Media = "picture/" + ((PictureBox) taskElement).Name;
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

            return JsonConvert.SerializeObject(test, Formatting.Indented);
        }
    }
}