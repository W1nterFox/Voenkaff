using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Voenkaff.Creators;
using Voenkaff.Entity;
using Voenkaff.Initialization;
using Voenkaff.Properties;
using Voenkaff.Wrappers;

namespace Voenkaff
{
    public partial class FormHello : Form
    {
        public Dictionary<Panel, Test> ListTests { get; set; } = new Dictionary<Panel, Test>();


        public List<Panel> ListPanelsTestsOnPanel { get; set; }
        public List<Panel> ListPanelWithFilter { get; set; }


        public Dictionary<string, List<int>> TestNameAndMarks { get; set; } = new Dictionary<string, List<int>>();

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
        public List<Wrappers.Test> ListTestsRef { get; set; } = new List<Wrappers.Test>();
        public Panel TestOperations { get; set; }
        public Dictionary<Panel, FormChooseTestName> ListMarksAndName { get; set; } = new Dictionary<Panel, FormChooseTestName>();


        public List<TextBox> TbList { get; set; } = new List<TextBox>();
        public List<Label> LabelList { get; set; } = new List<Label>();
        public Dictionary<TextBox, Label> TbAndLabel { get; set; } = new Dictionary<TextBox, Label>();

        public List<string> ListOfCourses = new List<string>();

        

        public FormHello()
        {
            InitializeComponent();
            
            new TestInizializator().Initialize(this);

            if (!Courses.Get().Contains("<Без предмета>"))
            {
                Courses.Get().Add("<Без предмета>");
            }

            comboBoxCourseFilter.Items.AddRange(Courses.Get().ToArray());

            ListPanelsTestsOnPanel = new List<Panel>();

            try
            {
                //Подгрузка тестов
                var testLoader = new TestLoader();

                var listOfLoadTests = testLoader.LoadTestsFromFolder(new DynamicParams().GetPath());

                foreach (Wrappers.Test test in listOfLoadTests.TestList)
                {
                    ListTestsRef.Add(test);

                    TestOperations = new Panel();

                    _linkLabelTestNew = new Label();
                    _buttonTestDeleteNew = new Button();
                    _buttonTestOpenNew = new Button();
                    _buttonTestMarksNew = new Button();
                    _buttonTestDownloadDoc = new Button();

                    TestOperations.BackColor = SystemColors.ControlLight;
                    TestOperations.Controls.Add(_linkLabelTestNew);
                    TestOperations.Controls.Add(_buttonTestOpenNew);
                    TestOperations.Controls.Add(_buttonTestMarksNew);
                    TestOperations.Controls.Add(_buttonTestDownloadDoc);
                    TestOperations.Controls.Add(_buttonTestDeleteNew);
                    TestOperations.Name = "panelTestInTestsList" + ListTestsRef.Count;
                    TestOperations.Size = new Size(1100, 51);
                    TestOperations.Tag = "panelTestInTests";


                    FormChooseTestName formChooseTestName =
                        new FormChooseTestName(this, ListPanelsTestsOnPanel.Count) {startName = test.Name};
                    formChooseTestName.Controls.Find("textBoxUserChooseTestName", true)[0].Text = test.Name;
                    formChooseTestName.Controls.Find("comboBoxCourse", true)[0].Text = test.Course;
                    formChooseTestName.Controls.Find("textBoxMark5", true)[0].Text = test.Marks.Excellent.ToString();
                    formChooseTestName.Controls.Find("textBoxMark4", true)[0].Text = test.Marks.Good.ToString();
                    formChooseTestName.Controls.Find("textBoxMark3", true)[0].Text = test.Marks.Satisfactory.ToString();
                    formChooseTestName.Tag = ListPanelsTestsOnPanel.Count;
                    ListMarksAndName[TestOperations] = formChooseTestName;

                    _linkLabelTestNew.AutoSize = true;
                    _linkLabelTestNew.Font = new Font("Century Gothic", 11.25F);
                    _linkLabelTestNew.Location = new Point(3, 15);
                    _linkLabelTestNew.Name = "linkLabelTest" + ListPanelsTestsOnPanel.Count;
                    _linkLabelTestNew.Size = new Size(146, 20);
                    _linkLabelTestNew.Text = test.Name;
                    _linkLabelTestNew.TabStop = true;
                    _linkLabelTestNew.Tag = ListPanelsTestsOnPanel.Count;
                    _linkLabelTestNew.TextAlign = ContentAlignment.MiddleCenter;

                    _buttonTestOpenNew.FlatStyle = FlatStyle.Flat;
                    _buttonTestOpenNew.Font = new Font("Century Gothic", 11.25F);
                    _buttonTestOpenNew.Location = new Point(285, 5);
                    _buttonTestOpenNew.Name = "buttonTestOpen" + ListPanelsTestsOnPanel.Count;
                    _buttonTestOpenNew.Size = new Size(150, 40);
                    _buttonTestOpenNew.Text = "Открыть тест";
                    _buttonTestOpenNew.UseVisualStyleBackColor = true;
                    _buttonTestOpenNew.Tag = ListPanelsTestsOnPanel.Count;
                    _buttonTestOpenNew.TextAlign = ContentAlignment.MiddleCenter;

                    _buttonTestMarksNew.FlatStyle = FlatStyle.Flat;
                    _buttonTestMarksNew.Font = new Font("Century Gothic", 11.25F);
                    _buttonTestMarksNew.Location = new Point(440, 5);
                    _buttonTestMarksNew.Name = "buttonTestMarks" + ListPanelsTestsOnPanel.Count;
                    _buttonTestMarksNew.Size = new Size(140, 40);
                    _buttonTestMarksNew.Text = "Параметры";
                    _buttonTestMarksNew.UseVisualStyleBackColor = true;
                    _buttonTestMarksNew.Tag = ListPanelsTestsOnPanel.Count;
                    _buttonTestMarksNew.TextAlign = ContentAlignment.MiddleCenter;

                    _buttonTestDownloadDoc.FlatStyle = FlatStyle.Flat;
                    _buttonTestDownloadDoc.Font = new Font("Century Gothic", 11.25F);
                    _buttonTestDownloadDoc.Location = new Point(585, 5);
                    _buttonTestDownloadDoc.Name = "buttonTestDownloadDoc" + ListPanelsTestsOnPanel.Count;
                    _buttonTestDownloadDoc.Size = new Size(150, 40);
                    _buttonTestDownloadDoc.Text = "Скачать в Word";
                    _buttonTestDownloadDoc.UseVisualStyleBackColor = true;
                    _buttonTestDownloadDoc.Enabled = true;
                    _buttonTestDownloadDoc.Tag = ListPanelsTestsOnPanel.Count;
                    _buttonTestDownloadDoc.TextAlign = ContentAlignment.MiddleCenter;

                    _buttonTestDeleteNew.FlatStyle = FlatStyle.Flat;
                    _buttonTestDeleteNew.Font = new Font("Century Gothic", 11.25F);
                    _buttonTestDeleteNew.Location = new Point(740, 5);
                    _buttonTestDeleteNew.Name = "buttonTestDelete" + ListPanelsTestsOnPanel.Count;
                    _buttonTestDeleteNew.Size = new Size(150, 40);
                    _buttonTestDeleteNew.Text = "Удалить";
                    _buttonTestDeleteNew.UseVisualStyleBackColor = true;
                    _buttonTestDeleteNew.Enabled = true;
                    _buttonTestDeleteNew.Tag = ListPanelsTestsOnPanel.Count;


                    TestNameAndMarks.Add(test.Name,
                        new List<int> {test.Marks.Excellent, test.Marks.Good, test.Marks.Satisfactory});

                    var peremTest = new Test(this, test.Name, TestNameAndMarks[test.Name], test.Course);
                    ListTests[TestOperations] = peremTest;


                    ListPanelsTestsOnPanel.Add(TestOperations);
                    panelMain.Controls.Add(TestOperations);


                    _buttonTestOpenNew.Click += OpenCurrentTest;
                    _buttonTestMarksNew.Click += TestCurrentMarks;
                    _buttonTestDownloadDoc.Click += TestCurrentDownloadDoc;
                    _buttonTestDeleteNew.Click += TestCurrentDelete;

                    if (ListPanelsTestsOnPanel.Count > 0)
                    {
                        ListTests[TestOperations].Controls.Find("panelMiddle", true)[0].Controls
                            .Remove(
                                ListTests[TestOperations].Controls.Find("Задание №1", true)[0]);
                    }
                    //Добавление элементов в тест
                    InitTest(ListTestsRef[ListPanelsTestsOnPanel.Count - 1],
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


            MinimumSize = Size;
            MaximumSize = Size;
        }

        private void buttonCreateTest_Click(object sender, EventArgs e)
        {
            TestOperations = new Panel();
            _linkLabelTestNew = new Label();
            _buttonTestDeleteNew = new Button();
            _buttonTestOpenNew = new Button();
            _buttonTestMarksNew = new Button();
            _buttonTestDownloadDoc = new Button();

            TestOperations.BackColor = SystemColors.ControlLight;
            TestOperations.Controls.Add(_linkLabelTestNew);
            TestOperations.Controls.Add(_buttonTestOpenNew);
            TestOperations.Controls.Add(_buttonTestMarksNew);
            TestOperations.Controls.Add(_buttonTestDownloadDoc);
            TestOperations.Controls.Add(_buttonTestDeleteNew);
            TestOperations.Name = "panelTestInTestsList" + ListPanelsTestsOnPanel.Count;
            TestOperations.Size = new Size(1100, 51);
            TestOperations.Tag = "panelTestInTests";

            FormChooseTestName formChooseTestName =
                new FormChooseTestName(this, ListPanelsTestsOnPanel.Count) {startName = ""};
            Visible = false;
            formChooseTestName.Visible = true;
            ListMarksAndName[TestOperations] = formChooseTestName;
            ListMarksAndName[TestOperations].parentPanel = TestOperations;
            formChooseTestName.Tag = ListPanelsTestsOnPanel.Count;

            _linkLabelTestNew.AutoSize = true;
            _linkLabelTestNew.Font = new Font("Century Gothic", 11.25F);
            _linkLabelTestNew.Location = new Point(3, 15);
            _linkLabelTestNew.Name = "linkLabelTest" + ListPanelsTestsOnPanel.Count;
            _linkLabelTestNew.Size = new Size(146, 20);
            _linkLabelTestNew.TabIndex = 1;
            _linkLabelTestNew.TabStop = true;
            _linkLabelTestNew.Tag = ListPanelsTestsOnPanel.Count;
            _linkLabelTestNew.TextAlign = ContentAlignment.MiddleCenter;

            _buttonTestDownloadDoc.FlatStyle = FlatStyle.Flat;
            _buttonTestDownloadDoc.Font = new Font("Century Gothic", 11.25F);
            _buttonTestDownloadDoc.Location = new Point(585, 5);
            _buttonTestDownloadDoc.Name = "buttonTestDelete" + ListPanelsTestsOnPanel.Count;
            _buttonTestDownloadDoc.Size = new Size(150, 40);
            _buttonTestDownloadDoc.TabIndex = 6;
            _buttonTestDownloadDoc.Text = "Скачать в Word";
            _buttonTestDownloadDoc.UseVisualStyleBackColor = true;
            _buttonTestDownloadDoc.Enabled = true;
            _buttonTestDownloadDoc.Tag = ListPanelsTestsOnPanel.Count;
            _buttonTestDownloadDoc.TextAlign = ContentAlignment.MiddleCenter;

            _buttonTestOpenNew.FlatStyle = FlatStyle.Flat;
            _buttonTestOpenNew.Font = new Font("Century Gothic", 11.25F);
            _buttonTestOpenNew.Location = new Point(285, 5);
            _buttonTestOpenNew.Name = "buttonTestOpen" + ListPanelsTestsOnPanel.Count;
            _buttonTestOpenNew.Size = new Size(150, 40);
            _buttonTestOpenNew.TabIndex = 2;
            _buttonTestOpenNew.Text = "Открыть тест";
            _buttonTestOpenNew.UseVisualStyleBackColor = true;
            _buttonTestOpenNew.Tag = ListPanelsTestsOnPanel.Count;
            _buttonTestOpenNew.TextAlign = ContentAlignment.MiddleCenter;

            _buttonTestMarksNew.FlatStyle = FlatStyle.Flat;
            _buttonTestMarksNew.Font = new Font("Century Gothic", 11.25F);
            _buttonTestMarksNew.Location = new Point(440, 5);
            _buttonTestMarksNew.Name = "buttonTestMarks" + ListPanelsTestsOnPanel.Count;
            _buttonTestMarksNew.Size = new Size(140, 40);
            _buttonTestMarksNew.TabIndex = 4;
            _buttonTestMarksNew.Text = "Параметры";
            _buttonTestMarksNew.UseVisualStyleBackColor = true;
            _buttonTestMarksNew.Tag = ListPanelsTestsOnPanel.Count;
            _buttonTestMarksNew.TextAlign = ContentAlignment.MiddleCenter;

            _buttonTestDeleteNew.FlatStyle = FlatStyle.Flat;
            _buttonTestDeleteNew.Font = new Font("Century Gothic", 11.25F);
            _buttonTestDeleteNew.Location = new Point(740, 5);
            _buttonTestDeleteNew.Name = "buttonTestDelete" + ListPanelsTestsOnPanel.Count;
            _buttonTestDeleteNew.Size = new Size(150, 40);
            _buttonTestDeleteNew.Text = "Удалить";
            _buttonTestDeleteNew.UseVisualStyleBackColor = true;
            _buttonTestDeleteNew.Enabled = true;
            _buttonTestDeleteNew.Tag = ListPanelsTestsOnPanel.Count;

            ListPanelsTestsOnPanel.Add(TestOperations);
            panelMain.Controls.Add(TestOperations);


            _buttonTestOpenNew.Click += OpenCurrentTest;
            _buttonTestMarksNew.Click += TestCurrentMarks;
            //_buttonTestDownloadNew.Click += testCurrentDownload;
            _buttonTestDownloadDoc.Click += TestCurrentDownloadDoc;
            _buttonTestDeleteNew.Click += TestCurrentDelete;
            Redistribution(ListPanelsTestsOnPanel);
        }

        private void TestCurrentDownloadDoc(object sender, EventArgs e)
        {
            Panel parentPanel = (Panel)((Button)sender).Parent;

            WordSaver.createDoc(ListTests[parentPanel]);
        }

        public void Redistribution(List<Panel> panelList)
        {
            if (panelList != null)
            {
                for (int i = 0; i < panelList.Count; i++)
                {
                    panelList[i].Location = new Point(28, 78 + 70 * i + panelMain.AutoScrollPosition.Y);
                }
            }
            panelMain.AutoScrollMargin= new Size(panelMain.AutoScrollMargin.Width, (78 + 70 * panelList?.Count??0)/16);
        }

        private void TestCurrentDelete(object sender, EventArgs e)
        {

            var rz = MessageBox.Show("Удалить тест?", "Удаление", MessageBoxButtons.YesNo);

            if (rz == DialogResult.Yes)
            {
                Panel parentPanel = (Panel)((Button)sender).Parent;
                foreach (var panel in ListPanelsTestsOnPanel)
                {
                    foreach (Control control in panel.Controls)
                    {
                        if (control.Name != ((Control) sender).Name) continue;
                        panelMain.Controls.Remove(panel);
                        ListPanelsTestsOnPanel.Remove(panel);
                        TestNameAndMarks.Remove(ListTests[parentPanel].Text);
                        ListTests.Remove(parentPanel);

                        if (comboBoxCourseFilter.SelectedItem != null)
                        {
                            ListPanelWithFilter.Remove(panel);
                            Redistribution(ListPanelWithFilter);
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

        private void TestCurrentDownload(object sender, EventArgs e)
        {
            var parentPanel = (Panel)((Button)sender).Parent;

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


        private void OpenCurrentTest(object sender, EventArgs e)
        {
            var parentPanel = (Panel)((Button)sender).Parent;
            Visible = false;
            ListTests[parentPanel].Visible = true;
            ListTests[parentPanel].Editable = true;
            ListTests[parentPanel].Controls.Find("panelMiddle",false)[0].Controls[0].Visible = true;
        }

       

        private void TestCurrentMarks(object sender, EventArgs e)
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
            var editableTests = ListTests.Where(p => p.Value.Editable);
            var jsonCreator = new JsonCreator();
            foreach (var keyValue in editableTests)
            {
                var filename = new DynamicParams().GetPath() + "\\"+keyValue.Value.TestName+".test";
                var testJson = jsonCreator.CreateTestCollection(new List<Test>{ keyValue.Value });
                // сохраняем текст в файл
                File.WriteAllText(filename, testJson);
            }
            File.WriteAllText(new DynamicParams().GetPath() + "\\PlatoonAndCourses.test",jsonCreator.CreatePlatoonAndCourses());

            var picureCreator = new PictureCreator();
            foreach (var keyValue in editableTests)
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


        private void InitTest(Wrappers.Test fromLoadTest, Test toTest)
        {
             List<Task> listTasksInTest = new List<Task> ();
             Dictionary<Task, List<Title>> rtbInTask = new Dictionary<Task, List<Title>> ();
             Dictionary<Task, List<PictureBoxScalable>> pbInTask = new Dictionary<Task, List<PictureBoxScalable>> ();
             Dictionary<Task, List<TextContainer>> tbInTask = new Dictionary<Task, List<TextContainer>> ();
             List<Panel> listPanelTasks = new List<Panel> ();
             //Dictionary<Task, List<Label>> _listTBLabels = new Dictionary<Task, List<Label>> ();

            foreach (Task paneltask in fromLoadTest.Tasks)
            {
                //int textBoxNumber = 0;
                rtbInTask.Add(paneltask, new List<Title>());
                pbInTask.Add(paneltask, new List<PictureBoxScalable>());
                tbInTask.Add(paneltask, new List<TextContainer>());
                //_listTBLabels.Add(paneltask, new List<Label> ());

                listTasksInTest.Add(paneltask);

                foreach (TaskElement taskElem in paneltask.TaskElements)
                {
                    if (taskElem.Type.Equals("RichTextBox"))
                    {
                        
                        Title bufTitle = new Title (taskElem.Name)
                        {
                            Instance =
                            {
                                Height = taskElem.Height,
                                Width = taskElem.Width,
                                Location = taskElem.Point,
                                Text = taskElem.Text,
                                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204),
                            }
                        };
                        rtbInTask[paneltask].Add(bufTitle);
                    }

                    if (taskElem.Type.Equals("PictureBox"))
                    {
                        using (var stream = File.Open(new DynamicParams().GetPath() + "\\" + taskElem.Media, FileMode.Open))
                        {
                            var ms = new MemoryStream((int)stream.Length);
                            stream.CopyTo(ms);
                            ms.Position = 0;
                            PictureBoxScalable bufPbs = new PictureBoxScalable(taskElem.Name)
                            {
                                Instance =
                                {
                                    Size = new Size(taskElem.Width, taskElem.Height),
                                    Image = new Bitmap(ms),
                                    Location = taskElem.Point
                                }
                            };
                            pbInTask[paneltask].Add(bufPbs);
                        }
                    }

                    if (taskElem.Type.Equals("TextBox"))
                    {
                        TextContainer bufTc = new TextContainer(taskElem.Name)
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
                        tbInTask[paneltask].Insert(0, bufTc);
                       
                    }

                }
            }

            foreach (Task task in listTasksInTest)
            {
                var indexLabel = 1;
                var buf1 = new Panel
                {
                    BackColor = SystemColors.ControlDark,
                    Location = new Point(0, 0),
                    Name = task.Name,
                    Size = new Size(1110, 618),
                    TabIndex = 0
                };
                listPanelTasks.Add(buf1);

                //Добавление панели с заданием

                var panelQestionFoo = new Panel
                {
                    BackColor = SystemColors.GradientInactiveCaption,
                    Location = new Point(5, 5),
                    Name = "panelQuestion",
                    Size = new Size(666, 530),
                    TabIndex = 0,
                    AutoScroll = true,
                    AllowDrop = true
                };

                panelQestionFoo.DragEnter += toTest.panelQuestion_DragEnter;
                panelQestionFoo.DragDrop += toTest.panelQuestion_DragDrop;

                toTest.createPasteFunc(panelQestionFoo);

                foreach (var pb in pbInTask[task])
                {
                    pb.setParent(panelQestionFoo);
                    panelQestionFoo.Controls.Add(pb.Instance);
                    ControlMover.Add(pb.Instance);
                    pb.Instance.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                
                

                int j = tbInTask[task].Count;
                foreach (TextContainer tb in tbInTask[task])
                {
                    tb.Instance.Name = "TextBox, Text: " + j;
                    tb.setParent(panelQestionFoo);
                    tb.AddAnswerTitle(tb.Instance.TabIndex);
                    panelQestionFoo.Controls.Add(tb.Instance);
                    tb.Instance.BringToFront();
                    ControlMover.Add(tb.Instance);

                    indexLabel++;


                    TbList.Add(tb.Instance);
                    j--;
                }

                foreach (Title rtb in rtbInTask[task])
                {
                    rtb.setParent(panelQestionFoo);
                    panelQestionFoo.Controls.Add(rtb.Instance);
                    ControlMover.Add(rtb.Instance);
                    rtb.Instance.BringToFront();
                }

                
                

                listPanelTasks[listPanelTasks.Count - 1].Controls.Add(panelQestionFoo);
                toTest.Controls.Find("panelMiddle", true)[0].Controls.Add(listPanelTasks[listPanelTasks.Count - 1]);

                PanelWrapper bufPw = new PanelWrapper
                {
                    Entity = listPanelTasks[listPanelTasks.Count - 1],
                    Identifier = indexLabel,
                    PictureIndex = pbInTask[task].Count
                };
                indexLabel++;

                var bufLl = toTest.createLinkLabel(listPanelTasks.Count - 1);

                bufPw.Entity.Name = bufLl.Text;

                toTest.ListPanelsTasks.Add(bufLl, bufPw);
                toTest.LinkLabelButtonDel.Add(bufLl, toTest.createButtonDelTask(listPanelTasks.Count - 1));


                PanelWrapper bufPw2 = new PanelWrapper {Entity = panelQestionFoo};
                toTest._currentPanelQuestion = bufPw2;

            }

            
            Control currentPanelListOfTasks = toTest.Controls.Find("panelListOfTasks", true)[0];


            toTest.ListPanelsTasks.Remove((LinkLabel)currentPanelListOfTasks.Controls[1]);
            toTest.LinkLabelButtonDel.Remove((LinkLabel)currentPanelListOfTasks.Controls[1]);

            currentPanelListOfTasks.Controls.Remove(currentPanelListOfTasks.Controls[1]);
            currentPanelListOfTasks.Controls.Remove(currentPanelListOfTasks.Controls[1]);

            toTest._currentTask = toTest.ListPanelsTasks[(LinkLabel)(toTest.Controls.Find("panelListOfTasks", true)[0].Controls[1])];
            toTest._currentPanelQuestion.Entity = (Panel)toTest._currentTask.Entity.Controls.Find("panelQuestion", true)[0];

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
            ListPanelWithFilter = new List<Panel>();
            ComboBox comboBox = (ComboBox)sender;


            if (comboBox.SelectedItem != null)
            {
                string selectedCourse = comboBox.SelectedItem.ToString();

                foreach (KeyValuePair<Panel, Test> keyValue in ListTests)
                {
                    if (keyValue.Value.Course == selectedCourse)
                    {
                        ListPanelWithFilter.Add(keyValue.Key);
                    }
                    keyValue.Key.Visible = false;
                }


                

                int koef = 0;
                foreach (Panel pnl in ListPanelWithFilter)
                {

                    pnl.Location = new Point(28, 78 + 70 * koef);
                    pnl.Visible = true;
                    koef++;
                }

                panelMain.Controls.Find("buttonCreateTest", true)[0].Location = new Point(585, 81 + 70 * ListPanelWithFilter.Count);
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

        private void panelMain_VisibleChanged(object sender, EventArgs e)
        {
            Redistribution(ListPanelsTestsOnPanel);
        }
    }
}