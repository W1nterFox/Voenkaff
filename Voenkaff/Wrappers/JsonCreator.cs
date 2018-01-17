using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Voenkaff.Wrappers
{
    class JsonCreator
    {
        public string CreateTestCollection(List<Test> tests)
        {
            var json = "[";
            foreach (var test in tests)
            {
                json += CreateTestJsonMessage(test) + ",";
            }

            return json.Substring(1, json.Length - 1) + "]";
        }
        public string CreateTestJsonMessage(Test testObj)
        {
            var test = new JsonTestWrapper { Name = testObj.TestName, listMarks = testObj.ListMarks.ToArray() };


            foreach (var task in testObj.ListPanelsTasks)
            {
                var tasks = new List<JsonTaskWrapper>();
                var questions = task.Entity.Controls.Find("panelQuestion", false)[0];
                var answers = task.Entity.Controls.Find("panelAnswer", false)[0];
                var taskElements = new List<string>();
                foreach (Control taskElement in questions.Controls)
                {
                    if (!(taskElement is TextBox) && !(taskElement is PictureBox) &&
                        !(taskElement is RichTextBox)) continue;
                    var element = new JsonObjectWrapper
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
                        element.Media = "picture/" + ((PictureBox)taskElement).Name;
                    }

                    if (taskElement is RichTextBox)
                    {
                        element.Text = taskElement.Text;
                    }
                    taskElements.Add(JsonConvert.SerializeObject(element, Formatting.None).Replace("\\", ""));
                }
                tasks.Add(new JsonTaskWrapper { TaskElements = taskElements, Name = questions.Text });
                test.Tasks.Add(JsonConvert.SerializeObject(tasks, Formatting.None).Replace("\\", ""));
            }
            return JsonConvert.SerializeObject(test, Formatting.Indented).Replace("\\", "").Replace("\"[", "").Replace("]\"", "").Replace("\"{", "{").Replace("\"}", "}").Replace("\"]", "]").Replace("}\",{", "},{");
        }
    }
}
