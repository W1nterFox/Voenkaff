using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Voenkaff.Creators;
using Voenkaff.Entity;
using Voenkaff.Properties;
using Voenkaff.Wrappers;

namespace Voenkaff
{
    public partial class Test : Form
    {
        //public List<PanelWrapper> ListPanelsTasks { get; set; }
        public Dictionary<LinkLabel, PanelWrapper> ListPanelsTasks;
        public Dictionary<LinkLabel, Button> LinkLabelButtonDel;

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
            LinkLabel firstLL = createLinkLabel(0);

            ListPanelsTasks = new Dictionary<LinkLabel, PanelWrapper> { { firstLL , new PanelWrapper(panelTaskStart, 1) } };
            LinkLabelButtonDel = new Dictionary<LinkLabel, Button> { { firstLL, createButtonDelTask(0)} };

            ListPanelsTasks[firstLL].Entity.Name = firstLL.Text;
            panelQuestion.Text = "Задание №1";
            panelTaskStart.Controls.Add(panelQuestion);
            _currentTask.Entity = panelTaskStart;
            _currentTask.Identifier = 1;
            _currentPanelQuestion.Entity = panelQuestion;

            panelQuestion.AllowDrop = true;
            panelQuestion.DragEnter += new DragEventHandler(panelQuestion_DragEnter);
            panelQuestion.DragDrop += new DragEventHandler(panelQuestion_DragDrop);

            createPasteFunc(panelQuestion);




            this.FormClosing += Test_Closing;
        }

        public void createPasteFunc(Panel panel)
        {
            ContextMenu cmu = new ContextMenu();
            MenuItem menuItemPaste = new MenuItem
            {
                Index = 0,
                Text = "Вставить изображение",
                Shortcut = Shortcut.CtrlDel
            };
            menuItemPaste.Click += pastePic;
            menuItemPaste.Name = "menuItemPaste_" + panel.Name;
            cmu.MenuItems.Add(menuItemPaste);
            panel.ContextMenu = cmu;
        }

        public void pastePic(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsImage()) return;

            _currentTask.PictureIndex++;
            var pictureBoxScalable = new PictureBoxScalable(_currentTask.PictureIndex, this, _currentPanelQuestion.Entity)
            {
                Instance = { Parent = _currentPanelQuestion.Entity, SizeMode = PictureBoxSizeMode.StretchImage }
            };
            ControlMover.Add(pictureBoxScalable.Instance);

            Image clipboard_image = Clipboard.GetImage();

            var image = new Bitmap(clipboard_image); //Bitmap для открываемого изображения

            pictureBoxScalable.Instance.Size = image.Size;
            pictureBoxScalable.Instance.Size = new Size(pictureBoxScalable.Instance.Size.Width > 600 ? 600 : pictureBoxScalable.Instance.Size.Width,
                pictureBoxScalable.Instance.Size.Height > 400 ? 400 : pictureBoxScalable.Instance.Size.Height);
            pictureBoxScalable.Instance.Image = image;
            pictureBoxScalable.Instance.Location = new Point(new Size(80, 80));
            pictureBoxScalable.Instance.Invalidate();

        }

        public void panelQuestion_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        public void panelQuestion_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                _currentTask.PictureIndex++;
                var pictureBoxScalable = new PictureBoxScalable(_currentTask.PictureIndex, this, _currentPanelQuestion.Entity)
                {
                    Instance = { Parent = _currentPanelQuestion.Entity, SizeMode = PictureBoxSizeMode.StretchImage }
                };
                ControlMover.Add(pictureBoxScalable.Instance);

                try
                {
                    var image = new Bitmap(file); //Bitmap для открываемого изображения

                    pictureBoxScalable.Instance.Size = image.Size;
                    pictureBoxScalable.Instance.Size = new Size(pictureBoxScalable.Instance.Size.Width > 600 ? 600 : pictureBoxScalable.Instance.Size.Width,
                        pictureBoxScalable.Instance.Size.Height > 400 ? 400 : pictureBoxScalable.Instance.Size.Height);
                    pictureBoxScalable.Instance.Image = image;
                    pictureBoxScalable.Instance.Location = new Point(new Size(80, 80));
                    pictureBoxScalable.Instance.Invalidate();
                }
                catch
                {
                    var result = MessageBox.Show("Невозможно добавить файл " + file, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public Button createButtonDelTask(int indexPanel)
        {
            Button buttonDelTask = new Button
            {
                BackgroundImage = Resources.x_button_256_tCwoi,
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new Point(127, 95 + indexPanel * 30),
                Name = "buttonDelTask" + indexPanel,
                Size = new Size(0, 0),
                TabIndex = 3,
                Enabled = false
            };

            buttonDelTask.Click += clickButtonDelTask;

            panelListOfTasks.Controls.Add(buttonDelTask);
            return buttonDelTask;
        }

        private void clickButtonDelTask(object sender, EventArgs e)
        {
            Button curButton = (Button)sender;
            foreach (KeyValuePair<LinkLabel, Button> keyValue in LinkLabelButtonDel)
            {
                if (keyValue.Value.Name == curButton.Name)
                {
                    if (LinkLabelButtonDel.Count > 1)
                    {
                        panelListOfTasks.Controls.Remove(panelListOfTasks.Controls.Find(keyValue.Key.Name, true)[0]);
                        panelListOfTasks.Controls.Remove(panelListOfTasks.Controls.Find(keyValue.Value.Name, true)[0]);
                        LinkLabelButtonDel.Remove(keyValue.Key);
                        ListPanelsTasks.Remove(keyValue.Key);
                        int koef = 0;
                        foreach (KeyValuePair<LinkLabel, Button> keyValue2nd in LinkLabelButtonDel)
                        {
                            keyValue2nd.Key.Text = "Задание №" + (koef + 1);
                            keyValue2nd.Key.Location = new Point(15, 95 + koef * 30);
                            keyValue2nd.Value.Location = new Point(127, 95 + koef * 30);
                            koef++;
                        }

                        break;
                    }

                    else
                    {
                        MessageBox.Show("Нельзя удалить все задания!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    
                }
            }
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

            panelListOfTasks.Controls.Add(ll);
            return ll;
        }

        private void clickTaskLinkLabel(object sender, EventArgs e)
        {
            LinkLabel currentLL = (LinkLabel) sender;

            foreach (KeyValuePair<LinkLabel, PanelWrapper> keyValue in ListPanelsTasks)
            {
                keyValue.Value.Entity.Visible = false;
            }
            
            _currentTask = ListPanelsTasks[currentLL];
            _currentTask.Entity.Visible = true;
            _currentPanelQuestion.Entity =  (Panel)_currentTask.Entity.Controls.Find("panelQuestion", true)[0];

            foreach (Control ctrl in _currentPanelQuestion.Entity.Controls)
            {
                if (ctrl is Label && ctrl.Visible == false)
                {
                    panel1.Controls.Find("buttonShowTBLabels", true)[0].Text = "Сделать видимыми";
                    panel1.Controls.Find("buttonShowTBLabels", true)[0].BackColor = Color.LightGreen; 
                }
                if (ctrl is Label && ctrl.Visible == true)
                {
                    panel1.Controls.Find("buttonShowTBLabels", true)[0].Text = "Сделать невидимыми";
                    panel1.Controls.Find("buttonShowTBLabels", true)[0].BackColor = Color.LightBlue;
                }
            }


        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextContainer tc = new TextContainer(_currentPanelQuestion.Entity, this);
            ControlMover.Add(tc.Instance);
           // _currentTask.Identifier++;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            


            using (var openFileDialog = new OpenFileDialog {Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"})
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                _currentTask.PictureIndex++;
                var pictureBoxScalable =
                    new PictureBoxScalable(_currentTask.PictureIndex, this, _currentPanelQuestion.Entity)
                    {
                        Instance = { Parent = _currentPanelQuestion.Entity, SizeMode = PictureBoxSizeMode.StretchImage }
                    };
                ControlMover.Add(pictureBoxScalable.Instance);

                try
                {
                    var image = new Bitmap(openFileDialog.FileName); //Bitmap для открываемого изображения

                    pictureBoxScalable.Instance.Size = image.Size;
                    pictureBoxScalable.Instance.Size = new Size(pictureBoxScalable.Instance.Size.Width > 600 ? 600 : pictureBoxScalable.Instance.Size.Width,
                        pictureBoxScalable.Instance.Size.Height > 400 ? 400 : pictureBoxScalable.Instance.Size.Height);
                    pictureBoxScalable.Instance.Image = image;
                    pictureBoxScalable.Instance.Location= new Point(new Size(80,80));
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
            foreach (KeyValuePair<LinkLabel, PanelWrapper> keyValue in ListPanelsTasks)
            {
                keyValue.Value.Entity.Visible = false;
            }
            

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
            
            panelQuestion.AllowDrop = true;
            panelQuestion.DragEnter += new DragEventHandler(panelQuestion_DragEnter);
            panelQuestion.DragDrop += new DragEventHandler(panelQuestion_DragDrop);

            createPasteFunc(panelQuestion);

            newPanelTask.Controls.Add(panelQuestion);
            newPanelTask.Dock = DockStyle.Fill;
            newPanelTask.Location = new Point(133, 0);
            newPanelTask.Margin = new Padding(10);
            newPanelTask.Padding = new Padding(5);
            newPanelTask.Size = new Size(1142, 642);

            LinkLabel bufLL = createLinkLabel(ListPanelsTasks.Count);
            ListPanelsTasks.Add(bufLL, new PanelWrapper(newPanelTask, 1));
            LinkLabelButtonDel.Add(bufLL, createButtonDelTask(ListPanelsTasks.Count - 1));

            newPanelTask.Name = "" + (ListPanelsTasks.Count - 1);
            
            ListPanelsTasks[bufLL].Entity.Name = bufLL.Text;
            
            _currentTask = ListPanelsTasks[bufLL];
            _currentTask.Entity.Visible = true;

            _currentPanelQuestion.Entity = (Panel) _currentTask.Entity.Controls.Find("panelQuestion", false)[0];

            //panelListOfTasks.Controls.Add(createLinkLabel(ListPanelsTasks.Count));
        }

        private void buttonShowTBLabels_Click(object sender, EventArgs e)
        {
            Boolean ctrlsAreVis;
            if (buttonShowTBLabels.Text == "Сделать невидимыми") ctrlsAreVis = true; else ctrlsAreVis = false;
            if (ctrlsAreVis)
            {
                foreach (Control ctrl in _currentPanelQuestion.Entity.Controls)
                {
                    if (ctrl is Label)
                    {
                        ctrl.Visible = false;
                    }
                }
                buttonShowTBLabels.Text = "Сделать видимыми";
                buttonShowTBLabels.BackColor = Color.LightGreen; 
            }
            else
            {
                foreach (Control ctrl in _currentPanelQuestion.Entity.Controls)
                {
                    if (ctrl is Label)
                    {
                        ctrl.Visible = true;
                    }
                }
                buttonShowTBLabels.Text = "Сделать невидимыми";
                buttonShowTBLabels.BackColor = Color.LightBlue;
            }
            
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

            LinkLabel firstLL = createLinkLabel(0);
            ListPanelsTasks = new Dictionary<LinkLabel, PanelWrapper> { { firstLL, new PanelWrapper(panelTaskStart, 1) } };
            //LinkLabelButtonDel = new Dictionary<LinkLabel, Button> { { firstLL, createButtonDelTask(0) } };

            panelTaskStart.Controls.Add(panelQuestion);
            //panelTaskStart.Controls.Add(panelAnswer);

            //panelAnswer.BringToFront();
            //panelTask.Visible = false;

            _currentTask.Entity = panelTaskStart;
            _currentTask.Identifier = 1;
            _currentPanelQuestion.Entity = panelQuestion;
            //_currentPanelAnswer.Entity = panelAnswer;
            
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