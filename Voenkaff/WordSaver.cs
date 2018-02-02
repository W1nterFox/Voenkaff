using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Voenkaff.Wrappers;
using Word = Microsoft.Office.Interop.Word;

namespace Voenkaff
{
    class WordSaver
    {
        public static void createDoc(Test test)
        {
            object missing = System.Reflection.Missing.Value;
            WordSaver ws = new WordSaver();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (*.docx)|*.docx";
            sfd.FileName = "Тест " + test.TestName + ".docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {


                Word.Document doc = null;
                try
                {
                    // Создаём объект приложения
                    Word.Application app = new Word.Application();
                    // Путь до шаблона документа
                    File.Delete(Environment.CurrentDirectory + @"\Word\" + test.TestName + ".docx");
                    File.Copy(Environment.CurrentDirectory + @"\Word\WordTest.docx",
                        Environment.CurrentDirectory + @"\Word\" + test.TestName + ".docx");
                    string source = Environment.CurrentDirectory + @"\Word\" + test.TestName + ".docx";
                    // Открываем
                    doc = app.Documents.Open(source);
                    doc.Activate();

                    // Добавляем информацию
                    // wBookmarks содержит все закладки
                    Word.Bookmarks wBookmarks = doc.Bookmarks;

                    //string[] data = new string[3] { "27", "Alex", "Gulynin" };



                    foreach (Word.Bookmark mark in wBookmarks)
                    {
                        if (mark.Name == "testName")
                        {
                            mark.Range.Text = test.TestName;
                        }

                        if (mark.Name == "markExcellent")
                        {
                            mark.Range.Text = test.ListMarks[0].ToString();
                        }

                        if (mark.Name == "markGood")
                        {
                            mark.Range.Text = test.ListMarks[1].ToString();
                        }

                        if (mark.Name == "markSatisfactory")
                        {
                            mark.Range.Text = test.ListMarks[2].ToString();
                        }

                        if (mark.Name == "tasksStartHere")
                        {


                            string textForInsert = "";
                            int count = 0;
                            foreach (KeyValuePair<LinkLabel, PanelWrapper> keyValue in test.ListPanelsTasks)
                            {

                                string taskUslovie = "";
                                List<TextBox> bufListTB = new List<TextBox> { };
                                //List<PictureBox> listPB = new List<PictureBox> { };
                                textForInsert += "\n\n\n\nЗадание №" + (count + 1) + "\n";
                                for (int i = 0; i < keyValue.Value.Entity.Controls[0].Controls.Count; i++)
                                {
                                    if (keyValue.Value.Entity.Controls[0].Controls[i] is RichTextBox)
                                    {
                                        taskUslovie = keyValue.Value.Entity.Controls[0].Controls[i].Text;

                                    }

                                }

                                textForInsert += "Условие: " + taskUslovie + "\n";




                                for (int i = 0; i < keyValue.Value.Entity.Controls[0].Controls.Count; i++)
                                {
                                    if (keyValue.Value.Entity.Controls[0].Controls[i] is PictureBox)
                                    {
                                        Clipboard.SetImage(
                                            ((PictureBox) (keyValue.Value.Entity.Controls[0].Controls[i]))
                                            .Image);
                                        mark.Range.Paste();

                                    }

                                }


                                for (int i = keyValue.Value.Entity.Controls[0].Controls.Count; i > 0; i--)
                                {

                                    if (keyValue.Value.Entity.Controls[0].Controls[i - 1] is TextBox)
                                    {
                                        bufListTB.Add((TextBox)keyValue.Value.Entity.Controls[0].Controls[i - 1]);

                                    }

                                }

                                for (int i = 0; i < bufListTB.Count; i++)
                                {
                                    textForInsert += "Ответ №" + (i + 1) + ": ";
                                    textForInsert += bufListTB[i].Text + "\n";
                                }

                                count++;
                            }

                            mark.Range.Text = textForInsert;
                        }
                    }

                    doc.SaveAs2000(sfd.FileName);
                    File.Delete(source);
                    // Закрываем документ
                    doc.Close(/*ref missing, ref missing, ref missing*/);
                }

                catch (IOException e)
                {
                    MessageBox.Show("Не удалось сохранить файл, возможно он уже существует "+e.Message,
                        "Не удалось сохранить файл",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
