using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Voenkaff.Creators;
using Voenkaff.Entity;
using Voenkaff.Properties;
using Voenkaff.Wrappers;

namespace Voenkaff
{
    public partial class Test : Form
    {
        public List<PanelWrapper> ListPanelsTasks { get; set; }

        public PanelWrapper _currentTask = new PanelWrapper();
        public PanelWrapper _currentPanelQuestion = new PanelWrapper();
        //private readonly PanelWrapper _currentPanelAnswer = new PanelWrapper();
        
        string _testOperationsName;
        int _indexTest;

        public string TestName { get; set; }
        public List<int> ListMarks { get; set; }
        public string Course { get; set; }
        public void setTestName(string testName)
        {
            TestName = testName;
            this.Text = TestName;
        }

        public void setTesListMarks(List<int> listMarks)
        {
            ListMarks = listMarks;
        }

        public Test(FormHello formHello, string testName, List<int> listMarks, string course)
        {
            InitializeComponent();

            _testOperationsName = formHello.TestOperations.Name;
            _indexTest = formHello.ListPanelsTestsOnPanel.Count - 1;

            TestName = testName;
            ListMarks = listMarks;
            Course = course;

            this.Text = TestName;

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            
            panelMiddle.Controls.Add(panelTaskStart);
            ListPanelsTasks = new List<PanelWrapper> {new PanelWrapper(panelTaskStart, 1)};
            panelQuestion.Text = "Задание №1";
            panelTaskStart.Controls.Add(panelQuestion);
            _currentTask.Entity = panelTaskStart;
            _currentTask.Identifier = 1;
            _currentPanelQuestion.Entity = panelQuestion;

            panelListOfTasks.Controls.Add(createLinkLabel(0));

            this.FormClosing += Test_Closing;
        }

        public LinkLabel createLinkLabel(int indexPanel)
        {
            LinkLabel ll = new LinkLabel
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Century Gothic", 11.25F),
                LinkColor = Color.Black,
                Location = new Point(15, 95 + indexPanel * 30),
                Name = "linkLabel" + indexPanel,
                Size = new Size(96, 16),
                TabIndex = 0,
                TabStop = true,
                Text = "Задание №" + (indexPanel + 1),
                VisitedLinkColor = Color.Black,
                Tag = indexPanel
            };

            
            ll.Click += clickTaskLinkLabel;
            

            return ll;
        }

        private void clickTaskLinkLabel(object sender, EventArgs e)
        {
            LinkLabel currentLL = (LinkLabel) sender;

            foreach (PanelWrapper index in ListPanelsTasks)
            {
                index.Entity.Visible = false;
            }

            //textBox1.Text = currentLL.Text;
            ListPanelsTasks[(int) currentLL.Tag].Entity.Visible = true;

            ListPanelsTasks.Find(p => p.Entity.Name == _currentTask.Entity.Name).Identifier = _currentTask.Identifier;
            _currentTask = ListPanelsTasks[(int) currentLL.Tag];

            _currentPanelQuestion.Entity =  (Panel)_currentTask.Entity.Controls.Find("panelQuestion", true)[0];
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextContainer tc = new TextContainer(_currentPanelQuestion.Entity, /*_currentPanelAnswer.Entity,*/ this,
                _currentTask.Identifier);
            ControlMover.Add(tc.Instance);
            _currentTask.Identifier++;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _currentTask.PictureIndex++;
            var pictureBoxScalable =
                new PictureBoxScalable(_currentTask.PictureIndex, this, _currentPanelQuestion.Entity)
                {
                    Instance = {Parent = _currentPanelQuestion.Entity, SizeMode = PictureBoxSizeMode.StretchImage}
                };
            ControlMover.Add(pictureBoxScalable.Instance);
            


            using (var openFileDialog = new OpenFileDialog {Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"})
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var image = new Bitmap(openFileDialog.FileName); //Bitmap для открываемого изображения

                    pictureBoxScalable.Instance.Size = image.Size;
                    pictureBoxScalable.Instance.Size = new Size(pictureBoxScalable.Instance.Size.Width > 600 ? 600 : pictureBoxScalable.Instance.Size.Width,
                        pictureBoxScalable.Instance.Size.Height > 400 ? 400 : pictureBoxScalable.Instance.Size.Height);
                    pictureBoxScalable.Instance.Image = image;
                    pictureBoxScalable.Instance.Location= new Point(new Size(-80,-80));
                    pictureBoxScalable.Instance.Invalidate();
                }
                catch
                {
                    var result = MessageBox.Show("Невозможно открыть выбранный файл",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Title ttl = new Title(_currentPanelQuestion.Entity, this, _currentTask.Identifier);
            ControlMover.Add(ttl.Instance);
            //_currentTask.Identifier++;
            ttl.Instance.BackColor = Color.White;
            ttl.Instance.Font = new Font("Times New Roman", 14f);
            ttl.Instance.Width = 500;
        }

        private void buttonTaskCreate_Click(object sender, EventArgs e)
        {
            ListPanelsTasks[ListPanelsTasks.Count - 1].Entity.Visible = false;

            Panel newPanelTask = new Panel();

            panelMiddle.Controls.Add(newPanelTask);
            newPanelTask.BackColor = SystemColors.ControlDark;

            Panel panelQuestion = new Panel
            {
                AutoScroll = true,
                BackColor = SystemColors.GradientInactiveCaption,
                Location = new Point(5, 5),
                Size = new Size(761, 610 ),
                Name = "panelQuestion",
                Text = "Задание №" + (ListPanelsTasks.Count + 1)
                
            };

            

            newPanelTask.Controls.Add(panelQuestion);
            newPanelTask.Dock = DockStyle.Fill;
            newPanelTask.Location = new Point(133, 0);
            newPanelTask.Margin = new Padding(10);
            newPanelTask.Padding = new Padding(5);
            newPanelTask.Size = new Size(1142, 642);


            ListPanelsTasks.Add(new PanelWrapper(newPanelTask, 1));
            newPanelTask.Name = "" + (ListPanelsTasks.Count - 1);
            foreach (PanelWrapper index in ListPanelsTasks)
            {
                index.Entity.Visible = false;
            }

            ListPanelsTasks[ListPanelsTasks.Count - 1].Entity.Visible = true;


            _currentTask = ListPanelsTasks[ListPanelsTasks.Count - 1];
            _currentPanelQuestion.Entity = (Panel) _currentTask.Entity.Controls.Find("panelQuestion", false)[0];

            panelListOfTasks.Controls.Add(createLinkLabel(ListPanelsTasks.Count - 1));
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.FormHello.Visible = true;
            //Application.Exit();
        }

        private void открытьТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void новыйТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

            InitializeComponent();
            this.MinimumSize = new Size(1080, 750);
            panelMiddle.Controls.Add(panelTaskStart);
            ListPanelsTasks = new List<PanelWrapper> {new PanelWrapper(panelTaskStart, 1)};

            panelTaskStart.Controls.Add(panelQuestion);
            //panelTaskStart.Controls.Add(panelAnswer);

            //panelAnswer.BringToFront();
            //panelTask.Visible = false;

            _currentTask.Entity = panelTaskStart;
            _currentTask.Identifier = 1;
            _currentPanelQuestion.Entity = panelQuestion;
            //_currentPanelAnswer.Entity = panelAnswer;

            panelListOfTasks.Controls.Add(createLinkLabel(0));
        }

        private void сохранитьТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            // получаем выбранный файл
            string filename = new DynamicParams().GetPath() + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".test";

            string testJson = new JsonCreator().CreateTestCollection(new List<Test> {this});
            new PictureCreator().CreatePictures(this,filename.Substring(0,filename.LastIndexOf("\\", StringComparison.Ordinal)));
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, testJson);
            MessageBox.Show("Файл сохранен");
        }


        private void Test_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visible = false;
            Program.FormHello.Visible = true;
        }
    }
}