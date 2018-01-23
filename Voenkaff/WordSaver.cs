using System;
using System.Collections.Generic;
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
        public static void createDoc (Test test)
        {
            Word.Document doc = null;
            //try
            {
                // Создаём объект приложения
                Word.Application app = new Word.Application();
                // Путь до шаблона документа
                string source = @"D:\\Новая папка (3)\Тест9.docx";
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
                        foreach (PanelWrapper panelWrapperTask in test.ListPanelsTasks)
                        {
                            
                            string taskUslovie = "";
                            List<TextBox> bufListTB = new List<TextBox> { };
                            //List<PictureBox> listPB = new List<PictureBox> { };
                            textForInsert += "\n\n\n\nЗадание №" + (count + 1) + "\n";
                            for (int i = 0; i < panelWrapperTask.Entity.Controls[0].Controls.Count; i++)
                            {
                                if (panelWrapperTask.Entity.Controls[0].Controls[i] is RichTextBox)
                                {
                                    //string asdasd = panelWrapperTask.Entity.Controls[0].Controls[i].Name.Substring(0, 32);
                                    //if (asdasd == "System.Windows.Forms.RichTextBox")
                                    {
                                        taskUslovie = panelWrapperTask.Entity.Controls[0].Controls[i].Text;
                                    }
                                }
                                
                            }
                            textForInsert += "Условие: " + taskUslovie + "\n";

                            
                            

                            for (int i = 0; i < panelWrapperTask.Entity.Controls[0].Controls.Count; i++)
                            {
                                if (panelWrapperTask.Entity.Controls[0].Controls[i] is PictureBox)
                                {
                                    //string asdasd = panelWrapperTask.Entity.Controls[0].Controls[i].Name.Substring(0, 31);
                                    //if (asdasd == "System.Windows.Forms.PictureBox")
                                    {
                                        Clipboard.SetImage(((PictureBox)(panelWrapperTask.Entity.Controls[0].Controls[i])).Image);
                                        mark.Range.Paste();
                                    }
                                }

                            }


                            for (int i = panelWrapperTask.Entity.Controls[0].Controls.Count; i > 0; i--)
                            {
                                
                                if (panelWrapperTask.Entity.Controls[0].Controls[i - 1] is TextBox)
                                {
                                    //string asdasd = panelWrapperTask.Entity.Controls[0].Controls[i - 1].Name.Substring(0, 28);
                                    //if (asdasd == "System.Windows.Forms.TextBox")
                                    {
                                        bufListTB.Add((TextBox)panelWrapperTask.Entity.Controls[0].Controls[i - 1]);
                                    }
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

                // Закрываем документ
                doc.Close();
                doc = null;
            }
            //catch (Exception ex)
            //{
            //    // Если произошла ошибка, то
            //    // закрываем документ и выводим информацию
            //    doc.Close();
            //    doc = null;
            //    Console.WriteLine("Во время выполнения произошла ошибка!");
            //    Console.ReadLine();
            //}
        }
    }
}
