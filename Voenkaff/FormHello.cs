using SerializablePicutre;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Voenkaff.Creators;
using Voenkaff.Entity;
using Voenkaff.Properties;
using Voenkaff.Wrappers;

namespace Voenkaff
{
    public partial class FormHello : Form
    {
        public List<Test> ListTests { get; set; } = new List<Test> { };
        //public List<FormChooseTestName> ListMarksAndName { get; set; } = new List<FormChooseTestName> { };


        public List<Panel> ListPanelsTestsOnPanel { get; set; }
        
        public Dictionary<string, List<int>> TestNameAndMarks { get; set; } = new Dictionary<string, List<int>> { };

        private readonly FormChooseVzvod _formChooseVzvod;
        private FormSettings _formSettings;

        //public Panel TestOperations { get; set; }
        Label _linkLabelTestNew;
        Button _buttonTestDeleteNew;
        Button _buttonTestOpenNew;
        Button _buttonTestDownloadNew;
        Button _buttonTestMarksNew;
        Button _buttonTestDownloadDoc;
        //Button buttonTestVzvodaNew;

        //РЕФАТОРИНГ
        Tests listOfLoadTests;
        public List<Wrappers.Test> ListTestsRef { get; set; } = new List<Wrappers.Test> { };
        public Panel TestOperations { get; set; }
        public List<FormChooseTestName> ListMarksAndName { get; set; } = new List<FormChooseTestName> { };


        






        public FormHello()
        {
            InitializeComponent();
            new TestInizializator().Initialize(this);
            ListPanelsTestsOnPanel = new List<Panel> { };

            //Подгрузка тестов
            var testLoader = new TestLoader();
            listOfLoadTests = testLoader.LoadTestsFromFolder(@"D:\\"/*new DynamicParams().Get().TestPath*/);


            foreach (Wrappers.Test test in listOfLoadTests.TestList)
            {
                ListTestsRef.Add(test);

                TestOperations = new Panel();

                _linkLabelTestNew = new Label();
                _buttonTestDeleteNew = new Button();
                _buttonTestOpenNew = new Button();
                _buttonTestDownloadNew = new Button();
                _buttonTestMarksNew = new Button();
                _buttonTestDownloadDoc = new Button();

                TestOperations.BackColor = System.Drawing.SystemColors.ControlLight;
                TestOperations.Controls.Add(_linkLabelTestNew);
                TestOperations.Controls.Add(_buttonTestOpenNew);
                TestOperations.Controls.Add(_buttonTestDownloadNew);
                TestOperations.Controls.Add(_buttonTestMarksNew);
                TestOperations.Controls.Add(_buttonTestDownloadDoc);
                TestOperations.Location = new System.Drawing.Point(28, 78 + 70 * (ListPanelsTestsOnPanel.Count));
                TestOperations.Name = "panelTestInTestsList" + ListTestsRef.Count;
                TestOperations.Size = new System.Drawing.Size(1200, 51);
                TestOperations.Tag = ListPanelsTestsOnPanel.Count;

                FormChooseTestName formChooseTestName = new FormChooseTestName(this, ListPanelsTestsOnPanel.Count);
                formChooseTestName.Controls.Find("textBoxUserChooseTestName", true)[0].Text = test.Name;
                formChooseTestName.Controls.Find("textBoxMark5", true)[0].Text = test.Marks.Excellent.ToString();
                formChooseTestName.Controls.Find("textBoxMark4", true)[0].Text = test.Marks.Good.ToString();
                formChooseTestName.Controls.Find("textBoxMark3", true)[0].Text = test.Marks.Satisfactory.ToString();
                formChooseTestName.Tag = ListPanelsTestsOnPanel.Count;
                ListMarksAndName.Add(formChooseTestName);

                _linkLabelTestNew.AutoSize = true;
                _linkLabelTestNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                _linkLabelTestNew.Location = new System.Drawing.Point(3, 15);
                _linkLabelTestNew.Name = "linkLabelTest" + ListPanelsTestsOnPanel.Count;
                _linkLabelTestNew.Size = new System.Drawing.Size(146, 20);
                _linkLabelTestNew.Text = test.Name;
                _linkLabelTestNew.TabStop = true;
                _linkLabelTestNew.Tag = ListPanelsTestsOnPanel.Count;

                _buttonTestOpenNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                _buttonTestOpenNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                _buttonTestOpenNew.Location = new System.Drawing.Point(540, 5);
                _buttonTestOpenNew.Name = "buttonTestOpen" + ListPanelsTestsOnPanel.Count;
                _buttonTestOpenNew.Size = new System.Drawing.Size(215, 40);
                _buttonTestOpenNew.Text = "Просмотр/редактирование";
                _buttonTestOpenNew.UseVisualStyleBackColor = true;
                _buttonTestOpenNew.Tag = ListPanelsTestsOnPanel.Count;

                _buttonTestMarksNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                _buttonTestMarksNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                _buttonTestMarksNew.Location = new System.Drawing.Point(760, 5);
                _buttonTestMarksNew.Name = "buttonTestMarks" + ListPanelsTestsOnPanel.Count;
                _buttonTestMarksNew.Size = new System.Drawing.Size(146, 40);
                _buttonTestMarksNew.Text = "Критерии оценки";
                _buttonTestMarksNew.UseVisualStyleBackColor = true;
                _buttonTestMarksNew.Tag = ListPanelsTestsOnPanel.Count;

                _buttonTestOpenNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                _buttonTestOpenNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                _buttonTestOpenNew.Location = new System.Drawing.Point(540, 5);
                _buttonTestOpenNew.Name = "buttonTestOpen" + ListPanelsTestsOnPanel.Count;
                _buttonTestOpenNew.Size = new System.Drawing.Size(215, 40);
                _buttonTestOpenNew.Text = "Просмотр/редактирование";
                _buttonTestOpenNew.UseVisualStyleBackColor = true;
                _buttonTestOpenNew.Tag = ListPanelsTestsOnPanel.Count;

                _buttonTestDownloadNew.FlatStyle = FlatStyle.Flat;
                _buttonTestDownloadNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                _buttonTestDownloadNew.Location = new System.Drawing.Point(915, 5);
                _buttonTestDownloadNew.Name = "buttonTestDownload" + ListPanelsTestsOnPanel.Count;
                _buttonTestDownloadNew.Size = new System.Drawing.Size(80, 40);
                _buttonTestDownloadNew.Text = "Скачать";
                _buttonTestDownloadNew.UseVisualStyleBackColor = true;
                _buttonTestDownloadNew.Tag = ListPanelsTestsOnPanel.Count;

                _buttonTestDownloadDoc.FlatStyle = FlatStyle.Flat;
                _buttonTestDownloadDoc.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                _buttonTestDownloadDoc.Location = new System.Drawing.Point(1000, 5);
                _buttonTestDownloadDoc.Name = "buttonTestDelete" + ListPanelsTestsOnPanel.Count;
                _buttonTestDownloadDoc.Size = new System.Drawing.Size(150, 40);
                _buttonTestDownloadDoc.Text = "Скачать в Word";
                _buttonTestDownloadDoc.UseVisualStyleBackColor = true;
                _buttonTestDownloadDoc.Enabled = true;
                _buttonTestDownloadDoc.Tag = ListPanelsTestsOnPanel.Count;



                TestNameAndMarks.Add("linkLabelTest" + ListPanelsTestsOnPanel.Count, new List<int> { test.Marks.Excellent, test.Marks.Good, test.Marks.Satisfactory });

                Test peremTest = new Test(this, test.Name, TestNameAndMarks["linkLabelTest" + ListPanelsTestsOnPanel.Count], VzvodAndLs.Get());
                ListTests.Add(peremTest);



                ListPanelsTestsOnPanel.Add(TestOperations);
                panelMain.Controls.Add(TestOperations);

                buttonCreateTest.Location = new System.Drawing.Point(580, 81 + 70 * ListPanelsTestsOnPanel.Count);


                _buttonTestOpenNew.Click += openCurrentTest;
                _buttonTestMarksNew.Click += testCurrentMarks;
                _buttonTestDownloadNew.Click += testCurrentDownload;
                _buttonTestDownloadDoc.Click += testCurrentDownloadDoc;

                if (ListPanelsTestsOnPanel.Count>0)
                {
                    ListTests[ListPanelsTestsOnPanel.Count - 1].Controls.Find("panelMiddle", true)[0].Controls.Remove(ListTests[ListPanelsTestsOnPanel.Count - 1].Controls.Find("panelTaskStart",true)[0]);
                }
                //Добавление элементов в тест
                initTest(ListTestsRef[ListPanelsTestsOnPanel.Count - 1], ListTests[ListPanelsTestsOnPanel.Count - 1]);
                
            }








            _formChooseVzvod = new FormChooseVzvod(this);
            _formSettings = new FormSettings();

            //_listmarks = new List<int[]> {};

            MinimumSize = Size;
            MaximumSize = Size;
        }

        private void buttonCreateTest_Click(object sender, EventArgs e)
        {
            TestOperations = new Panel();
            _linkLabelTestNew = new Label();
            _buttonTestDeleteNew = new Button();
            _buttonTestOpenNew = new Button();
            _buttonTestDownloadNew = new Button();
            _buttonTestMarksNew = new Button();
            _buttonTestDownloadDoc = new Button();

            TestOperations.BackColor = System.Drawing.SystemColors.ControlLight;
            TestOperations.Controls.Add(_linkLabelTestNew);
            TestOperations.Controls.Add(_buttonTestOpenNew);
            TestOperations.Controls.Add(_buttonTestDownloadNew);
            TestOperations.Controls.Add(_buttonTestMarksNew);
            TestOperations.Controls.Add(_buttonTestDownloadDoc);
            TestOperations.Location = new System.Drawing.Point(28, 78 + 70 * ListPanelsTestsOnPanel.Count);
            TestOperations.Name = "panelTestInTestsList" + ListPanelsTestsOnPanel.Count;
            TestOperations.Size = new System.Drawing.Size(1200, 51);
            TestOperations.Tag = ListPanelsTestsOnPanel.Count;

            FormChooseTestName formChooseTestName = new FormChooseTestName(this, ListPanelsTestsOnPanel.Count);
            Visible = false;
            formChooseTestName.Visible = true;
            ListMarksAndName.Add(formChooseTestName);
            formChooseTestName.Tag = ListPanelsTestsOnPanel.Count;

            _linkLabelTestNew.AutoSize = true;
            _linkLabelTestNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _linkLabelTestNew.Location = new System.Drawing.Point(3, 15);
            _linkLabelTestNew.Name = "linkLabelTest" + ListPanelsTestsOnPanel.Count;
            _linkLabelTestNew.Size = new System.Drawing.Size(146, 20);
            _linkLabelTestNew.TabIndex = 1;
            _linkLabelTestNew.TabStop = true;
            _linkLabelTestNew.Tag = ListPanelsTestsOnPanel.Count;

            _buttonTestDownloadDoc.FlatStyle = FlatStyle.Flat;
            _buttonTestDownloadDoc.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestDownloadDoc.Location = new System.Drawing.Point(1000, 5);
            _buttonTestDownloadDoc.Name = "buttonTestDelete" + ListPanelsTestsOnPanel.Count;
            _buttonTestDownloadDoc.Size = new System.Drawing.Size(150, 40);
            _buttonTestDownloadDoc.TabIndex = 6;
            _buttonTestDownloadDoc.Text = "Скачать в Word";
            _buttonTestDownloadDoc.UseVisualStyleBackColor = true;
            _buttonTestDownloadDoc.Enabled = true;
            _buttonTestDownloadDoc.Tag = ListPanelsTestsOnPanel.Count;


            _buttonTestOpenNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _buttonTestOpenNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestOpenNew.Location = new System.Drawing.Point(540, 5);
            _buttonTestOpenNew.Name = "buttonTestOpen" + ListPanelsTestsOnPanel.Count;
            _buttonTestOpenNew.Size = new System.Drawing.Size(215, 40);
            _buttonTestOpenNew.TabIndex = 2;
            _buttonTestOpenNew.Text = "Просмотр/редактирование";
            _buttonTestOpenNew.UseVisualStyleBackColor = true;
            _buttonTestOpenNew.Tag = ListPanelsTestsOnPanel.Count;

            _buttonTestDownloadNew.FlatStyle = FlatStyle.Flat;
            _buttonTestDownloadNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestDownloadNew.Location = new System.Drawing.Point(915, 5);
            _buttonTestDownloadNew.Name = "buttonTestDownload" + ListPanelsTestsOnPanel.Count;
            _buttonTestDownloadNew.Size = new System.Drawing.Size(80, 40);
            _buttonTestDownloadNew.TabIndex = 5;
            _buttonTestDownloadNew.Text = "Скачать";
            _buttonTestDownloadNew.UseVisualStyleBackColor = true;
            _buttonTestDownloadNew.Tag = ListPanelsTestsOnPanel.Count;

            _buttonTestMarksNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _buttonTestMarksNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestMarksNew.Location = new System.Drawing.Point(760, 5);
            _buttonTestMarksNew.Name = "buttonTestMarks" + ListPanelsTestsOnPanel.Count;
            _buttonTestMarksNew.Size = new System.Drawing.Size(146, 40);
            _buttonTestMarksNew.TabIndex = 4;
            _buttonTestMarksNew.Text = "Критерии оценки";
            _buttonTestMarksNew.UseVisualStyleBackColor = true;
            _buttonTestMarksNew.Tag = ListPanelsTestsOnPanel.Count;

            ListPanelsTestsOnPanel.Add(TestOperations);
            panelMain.Controls.Add(TestOperations);

            buttonCreateTest.Location = new System.Drawing.Point(580, 81 + 70 * ListPanelsTestsOnPanel.Count);


            _buttonTestOpenNew.Click += openCurrentTest;
            _buttonTestMarksNew.Click += testCurrentMarks;
            _buttonTestDeleteNew.Click += testCurrentDelete;
            _buttonTestDownloadNew.Click += testCurrentDownload;
            _buttonTestDownloadDoc.Click += testCurrentDownloadDoc;
        }

        private void testCurrentDownloadDoc(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Control)sender).Tag.ToString());

            WordSaver.createDoc(ListTests[index]);
        }

        private void testCurrentDelete(object sender, EventArgs e)
        {
            
        }

        private void testCurrentDownload(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Control)sender).Tag.ToString());

            saveTests.Filter = Resources.SaveTestFilter;
            saveTests.FileName = ListTests[index].TestName;
            if (saveTests.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveTests.FileName;

            string testJson = new JsonCreator().CreateTestCollection(new List<Test> {ListTests[index]});
            new PictureCreator().CreatePictures(ListTests[index], filename.Substring(0, filename.LastIndexOf("\\", StringComparison.Ordinal)));
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, testJson);
            MessageBox.Show("Файл сохранен");
        }


        private void openCurrentTest(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Control)sender).Tag.ToString());


            this.Visible = false;
            ListTests[index].Visible = true;
            ListTests[index].Controls.Find("panelMiddle",false)[0].Controls[0].Visible = true;
        }

       

        private void testCurrentMarks(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Control)sender).Tag.ToString());

            Visible = false;
            CheckBox fuck = (CheckBox) (ListMarksAndName[index].Controls[0].Controls
                .Find("checkBoxIsFirstOpen", false)[0]);
            fuck.Checked = false;
            ListMarksAndName[index].Visible = true;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rz = MessageBox.Show("Завершить программу?", "Завершение", MessageBoxButtons.YesNo);

            if (rz == DialogResult.Yes)
            {
                Close();
            }
        }

        private void сохранитьТестыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = new DynamicParams().Get().TestPath+"\\"+DateTime.Now.ToString("yyyyMMddHHmmss") +".test";

            string testJson = new JsonCreator().CreateTestCollection(ListTests);

            var picureCreator = new PictureCreator();
            foreach (var test in ListTests)
            {
                picureCreator.CreatePictures(test, filename.Substring(0, filename.LastIndexOf("\\", StringComparison.Ordinal)));
            }
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, testJson);
            MessageBox.Show("Файл сохранен");
        }

        private void взводаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = false;
            _formChooseVzvod.Visible = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_formSettings.IsDisposed)
            {
                _formSettings=new FormSettings();
            }
            _formSettings.Visible = true;
        }











        private void initTest(Wrappers.Test fromLoadTest, Test toTest)
        {
             List<Task> _listTasksInTest = new List<Task> { };
             Dictionary<Task, List<RichTextBox>> _RTBInTask = new Dictionary<Task, List<RichTextBox>> { };
             Dictionary<Task, List<PictureBox>> _PBInTask = new Dictionary<Task, List<PictureBox>> { };
             Dictionary<Task, Dictionary<string, TextBox>> _TBInTask = new Dictionary<Task, Dictionary<string, TextBox>> { };
             List<Panel> _listPanelTasks = new List<Panel> { };
             Dictionary<Task, List<Label>> _listTBLabels = new Dictionary<Task, List<Label>> { };

            foreach (Task paneltask in fromLoadTest.Tasks)
            {
                int textBoxNumber = 1;
                _RTBInTask.Add(paneltask, new List<RichTextBox> { });
                _PBInTask.Add(paneltask, new List<PictureBox> { });
                _TBInTask.Add(paneltask, new Dictionary<string, TextBox> { });
                _listTBLabels.Add(paneltask, new List<Label> { });

                _listTasksInTest.Add(paneltask);

                foreach (TaskElement taskElem in paneltask.TaskElements)
                {
                    if (taskElem.Type.Equals("System.Windows.Forms.RichTextBox"))
                    {
                        _RTBInTask[paneltask].Add(new RichTextBox
                        {
                            Height = taskElem.Height,
                            Width = taskElem.Width,
                            Name = taskElem.Name,
                            Location = taskElem.Point,
                            Text = taskElem.Text,
                            Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))),

                        });
                    }

                    if (taskElem.Type.Equals("System.Windows.Forms.PictureBox"))
                    {
                        using (var stream = File.Open(@"D:\\" + @"\" + taskElem.Media, FileMode.Open))
                        {
                            var binaryFormatter = new BinaryFormatter();
                            var image = ((SerializablePicture)binaryFormatter.Deserialize(stream)).Picture;
                            _PBInTask[paneltask].Add(new PictureBox
                            {
                                Size = image.Size,
                                Image = image,
                                //Height = taskElem.Height,
                                //Width = taskElem.Width,
                                Name = taskElem.Name,
                                Location = taskElem.Point
                            });
                        }

                    }

                    if (taskElem.Type.Equals("System.Windows.Forms.TextBox"))
                    {
                        _TBInTask[paneltask][taskElem.Name] = (new TextBox
                        {
                            Height = taskElem.Height,
                            Width = taskElem.Width,
                            Name = taskElem.Name,
                            Location = taskElem.Point,
                            Text = taskElem.Answer,

                        });
                        _listTBLabels[paneltask].Add(new Label
                        {
                            Location = new Point(taskElem.Point.X, taskElem.Point.Y - 20),
                            Text = "Поле для ввода ответа №" + textBoxNumber,
                            Width = 150
                        });

                        textBoxNumber++;

                    }

                }
            }

            foreach (Task task in _listTasksInTest)
            {
                int indexLabel = 1;
                Panel buf1 = new Panel();
                buf1.BackColor = System.Drawing.SystemColors.ControlDark;
                buf1.Location = new System.Drawing.Point(0, 0);
                buf1.Name = task.Name;
                buf1.Size = new System.Drawing.Size(1110, 618);
                buf1.TabIndex = 0;
                _listPanelTasks.Add(buf1);

                //Добавление панели с заданием

                Panel panelQestionFoo = new Panel();
                panelQestionFoo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                panelQestionFoo.Location = new System.Drawing.Point(5, 5);
                panelQestionFoo.Name = "panelQuestion";
                panelQestionFoo.Size = new System.Drawing.Size(1100, 610);
                panelQestionFoo.TabIndex = 0;
                panelQestionFoo.AutoScroll = true;






                foreach (PictureBox pb in _PBInTask[task])
                {
                    panelQestionFoo.Controls.Add(pb);
                    ControlMover.Add(pb);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                foreach (RichTextBox rtb in _RTBInTask[task])
                {
                    panelQestionFoo.Controls.Add(rtb);
                    rtb.BringToFront();
                    ControlMover.Add(rtb);
                }
                for (int i = 0; i < _TBInTask[task].Count; i++)
                {
                    panelQestionFoo.Controls.Add(_TBInTask[task]["System.Windows.Forms.TextBox, Text: " + (i + 1)]);
                    _TBInTask[task]["System.Windows.Forms.TextBox, Text: " + (i + 1)].BringToFront();
                    ControlMover.Add(_TBInTask[task]["System.Windows.Forms.TextBox, Text: " + (i + 1)]);
                    _TBInTask[task]["System.Windows.Forms.TextBox, Text: " + (i + 1)].Move += moveTBWithLB;
                    indexLabel++;
                }
                foreach (Label label in _listTBLabels[task])
                {

                    panelQestionFoo.Controls.Add(label);
                }

                _listPanelTasks[_listPanelTasks.Count - 1].Controls.Add(panelQestionFoo);
                toTest.Controls.Find("panelMiddle", true)[0].Controls.Add(_listPanelTasks[_listPanelTasks.Count - 1]);

                PanelWrapper bufPW = new PanelWrapper();
                bufPW.Entity = _listPanelTasks[_listPanelTasks.Count - 1];
                bufPW.Identifier = indexLabel;
                indexLabel++;
                toTest.ListPanelsTasks.Add(bufPW);

                PanelWrapper bufPW2 = new PanelWrapper();
                bufPW2.Entity = panelQestionFoo;
                toTest._currentPanelQuestion = bufPW2;

            }

            toTest.ListPanelsTasks.RemoveAt(0);
            
            toTest._currentTask = toTest.ListPanelsTasks[0];
            toTest._currentPanelQuestion.Entity = (Panel)toTest._currentTask.Entity.Controls.Find("panelQuestion", true)[0];

            for (int i = 1; i < toTest.ListPanelsTasks.Count; i++)
            {
                toTest.Controls.Find("panelListOfTasks",true)[0].Controls.Add(toTest.createLinkLabel(i));
            }
            

        }

        private void moveTBWithLB(object sender, EventArgs e)
        {
            TextBox currentTB = (TextBox)sender;
            //Label label = currentTB.Parent
        }

    }
}