using SerializablePicutre;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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


        public List<TextBox> TBList { get; set; } = new List<TextBox> { };
        public List<Label> LabelList { get; set; } = new List<Label> { };
        public Dictionary<TextBox, Label> TBAndLabel { get; set; } = new Dictionary<TextBox, Label> { };

        public List<string> listOfCourses = new List<string>(){};

        

        public FormHello()
        {
            InitializeComponent();
            
            new TestInizializator().Initialize(this);

            //Courses.Get().Add("<Без предмета>");

            comboBoxCourseFilter.Items.AddRange(Courses.Get().ToArray());

            ListPanelsTestsOnPanel = new List<Panel> { };

            try
            {
                //Подгрузка тестов
                var testLoader = new TestLoader();

                listOfLoadTests = testLoader.LoadTestsFromFolder(new DynamicParams().GetPath());

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
                    TestOperations.Controls.Add(_buttonTestDeleteNew);
                    TestOperations.Name = "panelTestInTestsList" + ListTestsRef.Count;
                    TestOperations.Size = new System.Drawing.Size(1200, 51);
                    TestOperations.Tag = "panelTestInTests";

                    FormChooseTestName formChooseTestName = new FormChooseTestName(this, ListPanelsTestsOnPanel.Count);
                    formChooseTestName.Controls.Find("textBoxUserChooseTestName", true)[0].Text = test.Name;
                    formChooseTestName.Controls.Find("comboBoxCourse", true)[0].Text = test.Course;
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
                    _linkLabelTestNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    _buttonTestOpenNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    _buttonTestOpenNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                    _buttonTestOpenNew.Location = new System.Drawing.Point(500, 5);
                    _buttonTestOpenNew.Name = "buttonTestOpen" + ListPanelsTestsOnPanel.Count;
                    _buttonTestOpenNew.Size = new System.Drawing.Size(255, 40);
                    _buttonTestOpenNew.Text = "Просмотр/редактирование";
                    _buttonTestOpenNew.UseVisualStyleBackColor = true;
                    _buttonTestOpenNew.Tag = ListPanelsTestsOnPanel.Count;
                    _buttonTestOpenNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    _buttonTestMarksNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    _buttonTestMarksNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                    _buttonTestMarksNew.Location = new System.Drawing.Point(477, 5);
                    _buttonTestMarksNew.Name = "buttonTestMarks" + ListPanelsTestsOnPanel.Count;
                    _buttonTestMarksNew.Size = new System.Drawing.Size(146, 40);
                    _buttonTestMarksNew.Text = "Параметры";
                    _buttonTestMarksNew.UseVisualStyleBackColor = true;
                    _buttonTestMarksNew.Tag = ListPanelsTestsOnPanel.Count;
                    _buttonTestMarksNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    _buttonTestDownloadNew.FlatStyle = FlatStyle.Flat;
                    _buttonTestDownloadNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                    _buttonTestDownloadNew.Location = new System.Drawing.Point(635, 5);
                    _buttonTestDownloadNew.Name = "buttonTestDownload" + ListPanelsTestsOnPanel.Count;
                    _buttonTestDownloadNew.Size = new System.Drawing.Size(80, 40);
                    _buttonTestDownloadNew.Text = "Скачать";
                    _buttonTestDownloadNew.UseVisualStyleBackColor = true;
                    _buttonTestDownloadNew.Tag = ListPanelsTestsOnPanel.Count;
                    _buttonTestDownloadNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    _buttonTestDownloadDoc.FlatStyle = FlatStyle.Flat;
                    _buttonTestDownloadDoc.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                    _buttonTestDownloadDoc.Location = new System.Drawing.Point(728, 5);
                    _buttonTestDownloadDoc.Name = "buttonTestDownloadDoc" + ListPanelsTestsOnPanel.Count;
                    _buttonTestDownloadDoc.Size = new System.Drawing.Size(150, 40);
                    _buttonTestDownloadDoc.Text = "Скачать в Word";
                    _buttonTestDownloadDoc.UseVisualStyleBackColor = true;
                    _buttonTestDownloadDoc.Enabled = true;
                    _buttonTestDownloadDoc.Tag = ListPanelsTestsOnPanel.Count;
                    _buttonTestDownloadDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    _buttonTestDeleteNew.FlatStyle = FlatStyle.Flat;
                    _buttonTestDeleteNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                    _buttonTestDeleteNew.Location = new System.Drawing.Point(892, 5);
                    _buttonTestDeleteNew.Name = "buttonTestDelete" + ListPanelsTestsOnPanel.Count;
                    _buttonTestDeleteNew.Size = new System.Drawing.Size(150, 40);
                    _buttonTestDeleteNew.Text = "Удалить";
                    _buttonTestDeleteNew.UseVisualStyleBackColor = true;
                    _buttonTestDeleteNew.Enabled = true;
                    _buttonTestDeleteNew.Tag = ListPanelsTestsOnPanel.Count;


                    TestNameAndMarks.Add(test.Name,
                        new List<int> {test.Marks.Excellent, test.Marks.Good, test.Marks.Satisfactory});

                    Test peremTest = new Test(this, test.Name,
                        TestNameAndMarks[test.Name], VzvodAndLs.Get());
                    Test peremTest = new Test(this, test.Name, TestNameAndMarks["linkLabelTest" + ListPanelsTestsOnPanel.Count], test.Course);
                    ListTests.Add(peremTest);



                    ListPanelsTestsOnPanel.Add(TestOperations);
                    panelMain.Controls.Add(TestOperations);


                    _buttonTestOpenNew.Click += openCurrentTest;
                    _buttonTestMarksNew.Click += testCurrentMarks;
                    _buttonTestDownloadNew.Click += testCurrentDownload;
                    _buttonTestDownloadDoc.Click += testCurrentDownloadDoc;
                    _buttonTestDeleteNew.Click += testCurrentDelete;

                    if (ListPanelsTestsOnPanel.Count > 0)
                    {
                        ListTests[ListPanelsTestsOnPanel.Count - 1].Controls.Find("panelMiddle", true)[0].Controls
                            .Remove(
                                ListTests[ListPanelsTestsOnPanel.Count - 1].Controls.Find("panelTaskStart", true)[0]);
                    }

                    //Добавление элементов в тест
                    initTest(ListTestsRef[ListPanelsTestsOnPanel.Count - 1],
                        ListTests[ListPanelsTestsOnPanel.Count - 1]);

                }
                Redistribution();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            TestOperations.Controls.Add(_buttonTestDeleteNew);
            TestOperations.Name = "panelTestInTestsList" + ListPanelsTestsOnPanel.Count;
            TestOperations.Size = new System.Drawing.Size(1200, 51);
            TestOperations.Tag = "panelTestInTests";

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
            _linkLabelTestNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            _buttonTestDownloadDoc.FlatStyle = FlatStyle.Flat;
            _buttonTestDownloadDoc.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestDownloadDoc.Location = new System.Drawing.Point(728, 5);
            _buttonTestDownloadDoc.Name = "buttonTestDelete" + ListPanelsTestsOnPanel.Count;
            _buttonTestDownloadDoc.Size = new System.Drawing.Size(150, 40);
            _buttonTestDownloadDoc.TabIndex = 6;
            _buttonTestDownloadDoc.Text = "Скачать в Word";
            _buttonTestDownloadDoc.UseVisualStyleBackColor = true;
            _buttonTestDownloadDoc.Enabled = true;
            _buttonTestDownloadDoc.Tag = ListPanelsTestsOnPanel.Count;
            _buttonTestDownloadDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            _buttonTestOpenNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _buttonTestOpenNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestOpenNew.Location = new System.Drawing.Point(250, 5);
            _buttonTestOpenNew.Name = "buttonTestOpen" + ListPanelsTestsOnPanel.Count;
            _buttonTestOpenNew.Size = new System.Drawing.Size(215, 40);
            _buttonTestOpenNew.TabIndex = 2;
            _buttonTestOpenNew.Text = "Просмотр/редактирование";
            _buttonTestOpenNew.UseVisualStyleBackColor = true;
            _buttonTestOpenNew.Tag = ListPanelsTestsOnPanel.Count;
            _buttonTestOpenNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            _buttonTestDownloadNew.FlatStyle = FlatStyle.Flat;
            _buttonTestDownloadNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestDownloadNew.Location = new System.Drawing.Point(635, 5);
            _buttonTestDownloadNew.Name = "buttonTestDownload" + ListPanelsTestsOnPanel.Count;
            _buttonTestDownloadNew.Size = new System.Drawing.Size(80, 40);
            _buttonTestDownloadNew.TabIndex = 5;
            _buttonTestDownloadNew.Text = "Скачать";
            _buttonTestDownloadNew.UseVisualStyleBackColor = true;
            _buttonTestDownloadNew.Tag = ListPanelsTestsOnPanel.Count;
            _buttonTestDownloadNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            _buttonTestMarksNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _buttonTestMarksNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestMarksNew.Location = new System.Drawing.Point(477, 5);
            _buttonTestMarksNew.Name = "buttonTestMarks" + ListPanelsTestsOnPanel.Count;
            _buttonTestMarksNew.Size = new System.Drawing.Size(146, 40);
            _buttonTestMarksNew.TabIndex = 4;
            _buttonTestMarksNew.Text = "Параметры";
            _buttonTestMarksNew.UseVisualStyleBackColor = true;
            _buttonTestMarksNew.Tag = ListPanelsTestsOnPanel.Count;
            _buttonTestMarksNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            _buttonTestDeleteNew.FlatStyle = FlatStyle.Flat;
            _buttonTestDeleteNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestDeleteNew.Location = new System.Drawing.Point(892, 5);
            _buttonTestDeleteNew.Name = "buttonTestDelete" + ListPanelsTestsOnPanel.Count;
            _buttonTestDeleteNew.Size = new System.Drawing.Size(150, 40);
            _buttonTestDeleteNew.Text = "Удалить";
            _buttonTestDeleteNew.UseVisualStyleBackColor = true;
            _buttonTestDeleteNew.Enabled = true;
            _buttonTestDeleteNew.Tag = ListPanelsTestsOnPanel.Count;

            ListPanelsTestsOnPanel.Add(TestOperations);
            panelMain.Controls.Add(TestOperations);

            buttonCreateTest.Location = new System.Drawing.Point(662, 81 + 70 * ListPanelsTestsOnPanel.Count);


            _buttonTestOpenNew.Click += openCurrentTest;
            _buttonTestMarksNew.Click += testCurrentMarks;
            _buttonTestDownloadNew.Click += testCurrentDownload;
            _buttonTestDownloadDoc.Click += testCurrentDownloadDoc;
            _buttonTestDeleteNew.Click += testCurrentDelete;
            Redistribution();
        }

        private void testCurrentDownloadDoc(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Control)sender).Tag.ToString());

            WordSaver.createDoc(ListTests[index]);
        }

        public void Redistribution()
        {
            for (int i = 0; i < ListPanelsTestsOnPanel.Count; i++)
            {
                ListPanelsTestsOnPanel[i].Location = new System.Drawing.Point(28, 78 + 70 * i+panelMain.AutoScrollPosition.Y);
            }
            buttonCreateTest.Location = new System.Drawing.Point(662, 81 + 70 * ListPanelsTestsOnPanel.Count + panelMain.AutoScrollPosition.Y);
        }

        private void testCurrentDelete(object sender, EventArgs e)
        {
            foreach (var panel in ListPanelsTestsOnPanel)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control.Name == ((Control) sender).Name)
                    {
                        panelMain.Controls.Remove(panel);
                        ListPanelsTestsOnPanel.Remove(panel);
                        ListTests.Remove(ListTests.Find(p=>p.TestName== panel.Controls[0].Text));
                        Redistribution();
                        File.Delete(new DynamicParams().GetPath()+"\\"+ panel.Controls[0].Text+".test");
                        return;
                    }
                }
            }
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

            foreach (var test in ListTests)
            {
                string filename = new DynamicParams().GetPath() + "\\"+test.TestName+".test";
                string testJson = new JsonCreator().CreateTestCollection(new List<Test>{test});
                // сохраняем текст в файл
                File.WriteAllText(filename, testJson);
            }

            var picureCreator = new PictureCreator();
            foreach (var test in ListTests)
            {
                picureCreator.CreatePictures(test, new DynamicParams().GetPath());
            }
            
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
                        using (var stream = File.Open(new  DynamicParams().GetPath()+"/" + taskElem.Media, FileMode.Open))
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
                            Location = new Point(taskElem.Point.X, taskElem.Point.Y - 30),
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
                
                
                foreach (Label label in _listTBLabels[task])
                {
                    panelQestionFoo.Controls.Add(label);
                    label.BringToFront();
                    LabelList.Add(label);

                    label.Location = new Point();
                }
                for (int i = 0; i < _TBInTask[task].Count; i++)
                {
                    var taskObj = _TBInTask[task]["System.Windows.Forms.TextBox, Text: " + (i + 1)];
                    panelQestionFoo.Controls.Add(taskObj);
                    taskObj.BringToFront();
                    ControlMover.Add(taskObj);
                    //_TBInTask[task]["System.Windows.Forms.TextBox, Text: " + (i + 1)].Move += moveTBWithLB;
                    indexLabel++;

                    TBList.Add(taskObj);
                }
                foreach (RichTextBox rtb in _RTBInTask[task])
                {
                    
                    panelQestionFoo.Controls.Add(rtb);
                    ControlMover.Add(rtb);
                    rtb.BringToFront();
                }
                for (int i = 0; i < _TBInTask[task].Count; i++)
                {
                    var obj = _TBInTask[task]["System.Windows.Forms.TextBox, Text: " + (i + 1)];
                    TBAndLabel.Add(obj, _listTBLabels[task][i]);
                    TBAndLabel[obj].Location = new Point(obj.Location.X, obj.Location.Y - 30);
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

            foreach (TextBox tb in TBList)
            {
                tb.Move += moveTBWithLB;
            }

        }

        

        private void moveTBWithLB(object sender, EventArgs e)
        {
            TextBox currentTB = (TextBox)sender;
            TBAndLabel[currentTB].Location = new Point(currentTB.Location.X, currentTB.Location.Y - 30);
        }

        private void предметыToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormCourse formCourse = formCourse = new FormCourse(this);
            var listBox = ((ListBox)(formCourse.Controls.Find("listBoxCourse", true)[0]));
            listBox.Items.Clear();
            listBox.Items.AddRange(Courses.Get().ToArray());
            //this.Visible = false;
            formCourse.Visible = true;

        }

        private void comboBoxCourseFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Panel> listPanelWithFilter = new List<Panel> { };
            ComboBox comboBox = (ComboBox)sender;


            if (comboBox.SelectedItem != null)
            {
                string selectedCourse = comboBox.SelectedItem.ToString();
                for (int i = 0; i < ListPanelsTestsOnPanel.Count; i++)
                {
                    if (ListTests[i].Course == selectedCourse)
                    {
                        listPanelWithFilter.Add(ListPanelsTestsOnPanel[i]);
                    }
                    ListPanelsTestsOnPanel[i].Visible = false;
                }

                int koef = 0;
                foreach (Panel pnl in listPanelWithFilter)
                {

                    pnl.Location = new Point(28, 78 + 70 * koef);
                    pnl.Visible = true;
                    koef++;
                }

                panelMain.Controls.Find("buttonCreateTest", true)[0].Location = new Point(580, 81 + 70 * listPanelWithFilter.Count);
            }
            
        }

        public void buttonFilterOff_Click(object sender, EventArgs e)
        {
            comboBoxCourseFilter.SelectedItem = null;
            int koef = 0;
            foreach (Panel pnl in ListPanelsTestsOnPanel)
            {
                pnl.Visible = true;
                pnl.Location = new Point(28, 78 + 70 * koef);
                pnl.Visible = true;
                koef++;
            }
            panelMain.Controls.Find("buttonCreateTest", true)[0].Location = new Point(580, 81 + 70 * ListPanelsTestsOnPanel.Count);
        }
    }
}