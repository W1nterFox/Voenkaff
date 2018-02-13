using SerializablePicutre;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Voenkaff.Creators;
using Voenkaff.Entity;
using Voenkaff.Properties;
using Voenkaff.Wrappers;

namespace Voenkaff
{
    public partial class FormHello : Form
    {
        public Dictionary<Panel, Test> ListTests { get; set; } = new Dictionary<Panel, Test> { };


        public List<Panel> ListPanelsTestsOnPanel { get; set; }
        public List<Panel> listPanelWithFilter { get; set; }


        public Dictionary<string, List<int>> TestNameAndMarks { get; set; } = new Dictionary<string, List<int>> { };

        private readonly FormChooseVzvod _formChooseVzvod;
        private FormSettings _formSettings;

        //public Panel TestOperations { get; set; }
        Label _linkLabelTestNew;
        Button _buttonTestDeleteNew;
        Button _buttonTestOpenNew;
        //Button _buttonTestDownloadNew;
        Button _buttonTestMarksNew;
        Button _buttonTestDownloadDoc;
        //Button buttonTestVzvodaNew;

        //РЕФАТОРИНГ
        Tests listOfLoadTests;
        public List<Wrappers.Test> ListTestsRef { get; set; } = new List<Wrappers.Test> { };
        public Panel TestOperations { get; set; }
        public Dictionary<Panel, FormChooseTestName> ListMarksAndName { get; set; } = new Dictionary<Panel, FormChooseTestName> { };


        public List<TextBox> TBList { get; set; } = new List<TextBox> { };
        public List<Label> LabelList { get; set; } = new List<Label> { };
        public Dictionary<TextBox, Label> TBAndLabel { get; set; } = new Dictionary<TextBox, Label> { };

        public List<string> listOfCourses = new List<string>(){};

        

        public FormHello()
        {
            InitializeComponent();
            
            new TestInizializator().Initialize(this);

            if (!Courses.Get().Contains("<Без предмета>"))
            {
                Courses.Get().Add("<Без предмета>");
            }

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
                    //_buttonTestDownloadNew = new Button();
                    _buttonTestMarksNew = new Button();
                    _buttonTestDownloadDoc = new Button();

                    TestOperations.BackColor = SystemColors.ControlLight;
                    TestOperations.Controls.Add(_linkLabelTestNew);
                    TestOperations.Controls.Add(_buttonTestOpenNew);
                    //TestOperations.Controls.Add(_buttonTestDownloadNew);
                    TestOperations.Controls.Add(_buttonTestMarksNew);
                    TestOperations.Controls.Add(_buttonTestDownloadDoc);
                    TestOperations.Controls.Add(_buttonTestDeleteNew);
                    TestOperations.Name = "panelTestInTestsList" + ListTestsRef.Count;
                    TestOperations.Size = new System.Drawing.Size(1100, 51);
                    TestOperations.Tag = "panelTestInTests";


                    FormChooseTestName formChooseTestName = new FormChooseTestName(this, ListPanelsTestsOnPanel.Count);
                    formChooseTestName.startName = test.Name;
                    formChooseTestName.Controls.Find("textBoxUserChooseTestName", true)[0].Text = test.Name;
                    formChooseTestName.Controls.Find("comboBoxCourse", true)[0].Text = test.Course;
                    formChooseTestName.Controls.Find("textBoxMark5", true)[0].Text = test.Marks.Excellent.ToString();
                    formChooseTestName.Controls.Find("textBoxMark4", true)[0].Text = test.Marks.Good.ToString();
                    formChooseTestName.Controls.Find("textBoxMark3", true)[0].Text = test.Marks.Satisfactory.ToString();
                    formChooseTestName.Tag = ListPanelsTestsOnPanel.Count;
                    ListMarksAndName[TestOperations] = formChooseTestName;

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
                    _buttonTestOpenNew.Location = new System.Drawing.Point(485, 5);
                    _buttonTestOpenNew.Name = "buttonTestOpen" + ListPanelsTestsOnPanel.Count;
                    _buttonTestOpenNew.Size = new System.Drawing.Size(150, 40);
                    _buttonTestOpenNew.Text = "Открыть тест";
                    _buttonTestOpenNew.UseVisualStyleBackColor = true;
                    _buttonTestOpenNew.Tag = ListPanelsTestsOnPanel.Count;
                    _buttonTestOpenNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    _buttonTestMarksNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    _buttonTestMarksNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                    _buttonTestMarksNew.Location = new System.Drawing.Point(640, 5);
                    _buttonTestMarksNew.Name = "buttonTestMarks" + ListPanelsTestsOnPanel.Count;
                    _buttonTestMarksNew.Size = new System.Drawing.Size(140, 40);
                    _buttonTestMarksNew.Text = "Параметры";
                    _buttonTestMarksNew.UseVisualStyleBackColor = true;
                    _buttonTestMarksNew.Tag = ListPanelsTestsOnPanel.Count;
                    _buttonTestMarksNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    //_buttonTestDownloadNew.FlatStyle = FlatStyle.Flat;
                    //_buttonTestDownloadNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                    //_buttonTestDownloadNew.Location = new System.Drawing.Point(860, 5);
                    //_buttonTestDownloadNew.Name = "buttonTestDownload" + ListPanelsTestsOnPanel.Count;
                    //_buttonTestDownloadNew.Size = new System.Drawing.Size(80, 40);
                    //_buttonTestDownloadNew.Text = "Скачать";
                    //_buttonTestDownloadNew.UseVisualStyleBackColor = true;
                    //_buttonTestDownloadNew.Tag = ListPanelsTestsOnPanel.Count;
                    //_buttonTestDownloadNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    _buttonTestDownloadDoc.FlatStyle = FlatStyle.Flat;
                    _buttonTestDownloadDoc.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                    _buttonTestDownloadDoc.Location = new System.Drawing.Point(785, 5);
                    _buttonTestDownloadDoc.Name = "buttonTestDownloadDoc" + ListPanelsTestsOnPanel.Count;
                    _buttonTestDownloadDoc.Size = new System.Drawing.Size(150, 40);
                    _buttonTestDownloadDoc.Text = "Скачать в Word";
                    _buttonTestDownloadDoc.UseVisualStyleBackColor = true;
                    _buttonTestDownloadDoc.Enabled = true;
                    _buttonTestDownloadDoc.Tag = ListPanelsTestsOnPanel.Count;
                    _buttonTestDownloadDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    _buttonTestDeleteNew.FlatStyle = FlatStyle.Flat;
                    _buttonTestDeleteNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
                    _buttonTestDeleteNew.Location = new System.Drawing.Point(940, 5);
                    _buttonTestDeleteNew.Name = "buttonTestDelete" + ListPanelsTestsOnPanel.Count;
                    _buttonTestDeleteNew.Size = new System.Drawing.Size(150, 40);
                    _buttonTestDeleteNew.Text = "Удалить";
                    _buttonTestDeleteNew.UseVisualStyleBackColor = true;
                    _buttonTestDeleteNew.Enabled = true;
                    _buttonTestDeleteNew.Tag = ListPanelsTestsOnPanel.Count;


                    TestNameAndMarks.Add(test.Name,
                        new List<int> {test.Marks.Excellent, test.Marks.Good, test.Marks.Satisfactory});

                    Test peremTest = new Test(this, test.Name, TestNameAndMarks[test.Name], test.Course);
                    //Test peremTest = new Test(this, test.Name, TestNameAndMarks["linkLabelTest" + ListPanelsTestsOnPanel.Count], test.Course);
                    ListTests[TestOperations] = peremTest;


                    ListPanelsTestsOnPanel.Add(TestOperations);
                    panelMain.Controls.Add(TestOperations);


                    _buttonTestOpenNew.Click += openCurrentTest;
                    _buttonTestMarksNew.Click += testCurrentMarks;
                    //_buttonTestDownloadNew.Click += testCurrentDownload;
                    _buttonTestDownloadDoc.Click += testCurrentDownloadDoc;
                    _buttonTestDeleteNew.Click += testCurrentDelete;

                    if (ListPanelsTestsOnPanel.Count > 0)
                    {
                        ListTests[TestOperations].Controls.Find("panelMiddle", true)[0].Controls
                            .Remove(
                                ListTests[TestOperations].Controls.Find("Задание №1", true)[0]);
                    }
                    //Добавление элементов в тест
                    initTest(ListTestsRef[ListPanelsTestsOnPanel.Count - 1],
                        ListTests[TestOperations]);
                }
                Redistribution(ListPanelsTestsOnPanel);
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
            //_buttonTestDownloadNew = new Button();
            _buttonTestMarksNew = new Button();
            _buttonTestDownloadDoc = new Button();

            TestOperations.BackColor = System.Drawing.SystemColors.ControlLight;
            TestOperations.Controls.Add(_linkLabelTestNew);
            TestOperations.Controls.Add(_buttonTestOpenNew);
            //TestOperations.Controls.Add(_buttonTestDownloadNew);
            TestOperations.Controls.Add(_buttonTestMarksNew);
            TestOperations.Controls.Add(_buttonTestDownloadDoc);
            TestOperations.Controls.Add(_buttonTestDeleteNew);
            TestOperations.Name = "panelTestInTestsList" + ListPanelsTestsOnPanel.Count;
            TestOperations.Size = new System.Drawing.Size(1100, 51);
            TestOperations.Tag = "panelTestInTests";

            FormChooseTestName formChooseTestName = new FormChooseTestName(this, ListPanelsTestsOnPanel.Count);
            formChooseTestName.startName = "";
            Visible = false;
            formChooseTestName.Visible = true;
            ListMarksAndName[TestOperations] = formChooseTestName;
            ListMarksAndName[TestOperations].parentPanel = TestOperations;
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
            _buttonTestDownloadDoc.Location = new System.Drawing.Point(785, 5);
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
            _buttonTestOpenNew.Location = new System.Drawing.Point(485, 5);
            _buttonTestOpenNew.Name = "buttonTestOpen" + ListPanelsTestsOnPanel.Count;
            _buttonTestOpenNew.Size = new System.Drawing.Size(150, 40);
            _buttonTestOpenNew.TabIndex = 2;
            _buttonTestOpenNew.Text = "Открыть тест";
            _buttonTestOpenNew.UseVisualStyleBackColor = true;
            _buttonTestOpenNew.Tag = ListPanelsTestsOnPanel.Count;
            _buttonTestOpenNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //_buttonTestDownloadNew.FlatStyle = FlatStyle.Flat;
            //_buttonTestDownloadNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            //_buttonTestDownloadNew.Location = new System.Drawing.Point(860, 5);
            //_buttonTestDownloadNew.Name = "buttonTestDownload" + ListPanelsTestsOnPanel.Count;
            //_buttonTestDownloadNew.Size = new System.Drawing.Size(80, 40);
            //_buttonTestDownloadNew.TabIndex = 5;
            //_buttonTestDownloadNew.Text = "Скачать";
            //_buttonTestDownloadNew.UseVisualStyleBackColor = true;
            //_buttonTestDownloadNew.Tag = ListPanelsTestsOnPanel.Count;
            //_buttonTestDownloadNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            _buttonTestMarksNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _buttonTestMarksNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestMarksNew.Location = new System.Drawing.Point(640, 5);
            _buttonTestMarksNew.Name = "buttonTestMarks" + ListPanelsTestsOnPanel.Count;
            _buttonTestMarksNew.Size = new System.Drawing.Size(140, 40);
            _buttonTestMarksNew.TabIndex = 4;
            _buttonTestMarksNew.Text = "Параметры";
            _buttonTestMarksNew.UseVisualStyleBackColor = true;
            _buttonTestMarksNew.Tag = ListPanelsTestsOnPanel.Count;
            _buttonTestMarksNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            _buttonTestDeleteNew.FlatStyle = FlatStyle.Flat;
            _buttonTestDeleteNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestDeleteNew.Location = new System.Drawing.Point(940, 5);
            _buttonTestDeleteNew.Name = "buttonTestDelete" + ListPanelsTestsOnPanel.Count;
            _buttonTestDeleteNew.Size = new System.Drawing.Size(150, 40);
            _buttonTestDeleteNew.Text = "Удалить";
            _buttonTestDeleteNew.UseVisualStyleBackColor = true;
            _buttonTestDeleteNew.Enabled = true;
            _buttonTestDeleteNew.Tag = ListPanelsTestsOnPanel.Count;

            ListPanelsTestsOnPanel.Add(TestOperations);
            panelMain.Controls.Add(TestOperations);

            buttonCreateTest.Location = new System.Drawing.Point(585, 81 + 70 * ListPanelsTestsOnPanel.Count);


            _buttonTestOpenNew.Click += openCurrentTest;
            _buttonTestMarksNew.Click += testCurrentMarks;
            //_buttonTestDownloadNew.Click += testCurrentDownload;
            _buttonTestDownloadDoc.Click += testCurrentDownloadDoc;
            _buttonTestDeleteNew.Click += testCurrentDelete;
            Redistribution(ListPanelsTestsOnPanel);
        }

        private void testCurrentDownloadDoc(object sender, EventArgs e)
        {
            Panel parentPanel = (Panel)((Button)sender).Parent;

            WordSaver.createDoc(ListTests[parentPanel]);
        }

        public void Redistribution(List<Panel> panelList)
        {
            for (int i = 0; i < panelList.Count; i++)
            {
                panelList[i].Location = new System.Drawing.Point(28, 78 + 70 * i+panelMain.AutoScrollPosition.Y);
            }
            buttonCreateTest.Location = new System.Drawing.Point(585, 81 + 70 * panelList.Count + panelMain.AutoScrollPosition.Y);
        }

        private void testCurrentDelete(object sender, EventArgs e)
        {

            var rz = MessageBox.Show("Удалить тест?", "Удаление", MessageBoxButtons.YesNo);

            if (rz == DialogResult.Yes)
            {
                Panel parentPanel = (Panel)((Button)sender).Parent;
                foreach (var panel in ListPanelsTestsOnPanel)
                {
                    foreach (Control control in panel.Controls)
                    {
                        if (control.Name == ((Control)sender).Name)
                        {
                            panelMain.Controls.Remove(panel);
                            ListPanelsTestsOnPanel.Remove(panel);
                            TestNameAndMarks.Remove(ListTests[parentPanel].Text);
                            ListTests.Remove(parentPanel);

                            if (comboBoxCourseFilter.SelectedItem != null)
                            {
                                listPanelWithFilter.Remove(panel);
                                Redistribution(listPanelWithFilter);
                            }
                            else
                            {

                                Redistribution(ListPanelsTestsOnPanel);
                            }

                            File.Delete(new DynamicParams().GetPath() + "\\" + panel.Controls[0].Text + ".test");
                            return;
                        }
                    }

                }
            }
        }

        private void testCurrentDownload(object sender, EventArgs e)
        {
            Panel parentPanel = (Panel)((Button)sender).Parent;

            saveTests.Filter = Resources.SaveTestFilter;
            saveTests.FileName = ListTests[parentPanel].TestName;
            if (saveTests.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveTests.FileName;

            string testJson = new JsonCreator().CreateTestCollection(new List<Test> {ListTests[parentPanel] });
            new PictureCreator().CreatePictures(ListTests[parentPanel], filename.Substring(0, filename.LastIndexOf("\\", StringComparison.Ordinal)));
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, testJson);
            MessageBox.Show("Файл сохранен");
        }


        private void openCurrentTest(object sender, EventArgs e)
        {
            Panel parentPanel = (Panel)((Button)sender).Parent;


            this.Visible = false;
            ListTests[parentPanel].Visible = true;
            ListTests[parentPanel].Controls.Find("panelMiddle",false)[0].Controls[0].Visible = true;
        }

       

        private void testCurrentMarks(object sender, EventArgs e)
        {
            Panel parentPanel = (Panel)((Button)sender).Parent;

            Visible = false;
            CheckBox fuck = (CheckBox) (ListMarksAndName[parentPanel].Controls[0].Controls.Find("checkBoxIsFirstOpen", false)[0]);
            fuck.Checked = false;
            ListMarksAndName[parentPanel].parentPanel = parentPanel;
            ListMarksAndName[parentPanel].Visible = true;
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
            //Directory.Delete(new DynamicParams().GetPath(), true);

            DirectoryInfo dirTests = new DirectoryInfo(new DynamicParams().GetPath());
            DirectoryInfo dirPics = new DirectoryInfo(new DynamicParams().GetPath() + "\\" + "picture");

            foreach (var keyValue in ListTests)
            {
                var filename = new DynamicParams().GetPath() + "\\"+keyValue.Value.TestName+".test";
                var testJson = new JsonCreator().CreateTestCollection(new List<Test>{ keyValue.Value });
                // сохраняем текст в файл
                File.WriteAllText(filename, testJson);
            }

            var picureCreator = new PictureCreator();
            foreach (var keyValue in ListTests)
            {
                picureCreator.CreatePictures(keyValue.Value, new DynamicParams().GetPath());
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
             Dictionary<Task, List<Title>> _RTBInTask = new Dictionary<Task, List<Title>> { };
             Dictionary<Task, List<PictureBoxScalable>> _PBInTask = new Dictionary<Task, List<PictureBoxScalable>> { };
             Dictionary<Task, List<TextContainer>> _TBInTask = new Dictionary<Task, List<TextContainer>> { };
             List<Panel> _listPanelTasks = new List<Panel> { };
             //Dictionary<Task, List<Label>> _listTBLabels = new Dictionary<Task, List<Label>> { };

            foreach (Task paneltask in fromLoadTest.Tasks)
            {
                //int textBoxNumber = 0;
                _RTBInTask.Add(paneltask, new List<Title> { });
                _PBInTask.Add(paneltask, new List<PictureBoxScalable> { });
                _TBInTask.Add(paneltask, new List<TextContainer> { });
                //_listTBLabels.Add(paneltask, new List<Label> { });

                _listTasksInTest.Add(paneltask);


                //foreach (TaskElement taskElem in paneltask.TaskElements)
                //{
                //    if (taskElem.Type.Equals("System.Windows.Forms.TextBox"))
                //    {
                        
                //        textBoxNumber++;

                //    }
                //}

                foreach (TaskElement taskElem in paneltask.TaskElements)
                {
                    if (taskElem.Type.Equals("System.Windows.Forms.RichTextBox"))
                    {
                        
                        Title bufTitle = new Title (taskElem.Name)
                        {
                            Instance =
                            {
                                Height = taskElem.Height,
                                Width = taskElem.Width,
                                Location = taskElem.Point,
                                Text = taskElem.Text,
                                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204))),
                            }
                        };
                        _RTBInTask[paneltask].Add(bufTitle);
                    }

                    if (taskElem.Type.Equals("System.Windows.Forms.PictureBox"))
                    {
                        using (var stream = File.Open(new DynamicParams().GetPath() + "\\" + taskElem.Media,
                            FileMode.Open))
                        {
                            PictureBoxScalable bufPBS = new PictureBoxScalable(taskElem.Name)
                            {
                                Instance =
                                {
                                    Size = new Size(taskElem.Width, taskElem.Height),
                                    Image = new Bitmap(stream),
                                    Location = taskElem.Point
                                }
                            };
                            _PBInTask[paneltask].Add(bufPBS);
                        }
                    }

                    if (taskElem.Type.Equals("System.Windows.Forms.TextBox"))
                    {
                        TextContainer bufTC = new TextContainer(taskElem.Name)
                        {
                            Instance =
                            {
                                Height = taskElem.Height,
                                Width = taskElem.Width,
                                Location = taskElem.Point,
                                Text = taskElem.Answer,
                                TabIndex = taskElem.Index
                            }
                        };
                        _TBInTask[paneltask].Insert(0, bufTC);
                       

                        //textBoxNumber--;

                    }

                }
            }

            foreach (Task task in _listTasksInTest)
            {
                var indexLabel = 1;
                var buf1 = new Panel
                {
                    BackColor = System.Drawing.SystemColors.ControlDark,
                    Location = new System.Drawing.Point(0, 0),
                    Name = task.Name,
                    Size = new System.Drawing.Size(1110, 618),
                    TabIndex = 0
                };
                _listPanelTasks.Add(buf1);

                //Добавление панели с заданием

                var panelQestionFoo = new Panel();
                panelQestionFoo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                panelQestionFoo.Location = new System.Drawing.Point(5, 5);
                panelQestionFoo.Name = "panelQuestion";
                panelQestionFoo.Size = new System.Drawing.Size(761, 610 );
                panelQestionFoo.TabIndex = 0;
                panelQestionFoo.AutoScroll = true;

                panelQestionFoo.AllowDrop = true;
                panelQestionFoo.DragEnter += new DragEventHandler(toTest.panelQuestion_DragEnter);
                panelQestionFoo.DragDrop += new DragEventHandler(toTest.panelQuestion_DragDrop);

                toTest.createPasteFunc(panelQestionFoo);

                foreach (PictureBoxScalable pb in _PBInTask[task])
                {
                    pb.setParent(panelQestionFoo);
                    panelQestionFoo.Controls.Add(pb.Instance);
                    ControlMover.Add(pb.Instance);
                    pb.Instance.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                
                

                int j = _TBInTask[task].Count;
                foreach (TextContainer tb in _TBInTask[task])
                {
                    tb.Instance.Name = "System.Windows.Forms.TextBox, Text: " + j;
                    tb.setParent(panelQestionFoo);
                    tb.AddAnswerTitle(tb.Instance.TabIndex);
                    panelQestionFoo.Controls.Add(tb.Instance);
                    tb.Instance.BringToFront();
                    ControlMover.Add(tb.Instance);

                    indexLabel++;


                    TBList.Add(tb.Instance);
                    j--;
                }

                foreach (Title rtb in _RTBInTask[task])
                {
                    rtb.setParent(panelQestionFoo);
                    panelQestionFoo.Controls.Add(rtb.Instance);
                    ControlMover.Add(rtb.Instance);
                    rtb.Instance.BringToFront();
                }

                
                

                _listPanelTasks[_listPanelTasks.Count - 1].Controls.Add(panelQestionFoo);
                toTest.Controls.Find("panelMiddle", true)[0].Controls.Add(_listPanelTasks[_listPanelTasks.Count - 1]);

                PanelWrapper bufPW = new PanelWrapper();
                bufPW.Entity = _listPanelTasks[_listPanelTasks.Count - 1];
                bufPW.Identifier = indexLabel;
                bufPW.PictureIndex = _PBInTask[task].Count;
                indexLabel++;

                LinkLabel bufLL = toTest.createLinkLabel(_listPanelTasks.Count - 1);

                bufPW.Entity.Name = bufLL.Text;

                toTest.ListPanelsTasks.Add(bufLL, bufPW);
                toTest.LinkLabelButtonDel.Add(bufLL, toTest.createButtonDelTask(_listPanelTasks.Count - 1));


                PanelWrapper bufPW2 = new PanelWrapper();
                bufPW2.Entity = panelQestionFoo;
                toTest._currentPanelQuestion = bufPW2;

            }

            
            Control currentPanelListOfTasks = toTest.Controls.Find("panelListOfTasks", true)[0];


            toTest.ListPanelsTasks.Remove((LinkLabel)currentPanelListOfTasks.Controls[1]);
            toTest.LinkLabelButtonDel.Remove((LinkLabel)currentPanelListOfTasks.Controls[1]);

            currentPanelListOfTasks.Controls.Remove(currentPanelListOfTasks.Controls[1]);
            currentPanelListOfTasks.Controls.Remove(currentPanelListOfTasks.Controls[1]);

            //toTest.ListPanelsTasks.Remove((LinkLabel)currentPanelListOfTasks.Controls[1]);


            toTest._currentTask = toTest.ListPanelsTasks[(LinkLabel)(toTest.Controls.Find("panelListOfTasks", true)[0].Controls[1])];
            toTest._currentPanelQuestion.Entity = (Panel)toTest._currentTask.Entity.Controls.Find("panelQuestion", true)[0];

            

            //foreach (TextBox tb in TBList)
            //{
            //    tb.Move += moveTBWithLB;
            //}

        }

        

        //private void moveTBWithLB(object sender, EventArgs e)
        //{
        //    TextBox currentTB = (TextBox)sender;
        //    TBAndLabel[currentTB].Location = new Point(currentTB.Location.X, currentTB.Location.Y - 30);
        //}

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
            listPanelWithFilter = new List<Panel> { };
            ComboBox comboBox = (ComboBox)sender;


            if (comboBox.SelectedItem != null)
            {
                string selectedCourse = comboBox.SelectedItem.ToString();

                foreach (KeyValuePair<Panel, Test> keyValue in ListTests)
                {
                    if (keyValue.Value.Course == selectedCourse)
                    {
                        listPanelWithFilter.Add(keyValue.Key);
                    }
                    keyValue.Key.Visible = false;
                }


                

                int koef = 0;
                foreach (Panel pnl in listPanelWithFilter)
                {

                    pnl.Location = new Point(28, 78 + 70 * koef);
                    pnl.Visible = true;
                    koef++;
                }

                panelMain.Controls.Find("buttonCreateTest", true)[0].Location = new Point(585, 81 + 70 * listPanelWithFilter.Count);
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
            panelMain.Controls.Find("buttonCreateTest", true)[0].Location = new Point(585, 81 + 70 * ListPanelsTestsOnPanel.Count);
            Redistribution(ListPanelsTestsOnPanel);
        }

        
    }
}