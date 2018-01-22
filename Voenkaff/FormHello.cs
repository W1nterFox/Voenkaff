using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Voenkaff.Creators;
using Voenkaff.Properties;
using Voenkaff.Wrappers;

namespace Voenkaff
{
    public partial class FormHello : Form
    {
        public List<Test> ListTests { get; set; } = new List<Test> { };
        public List<FormChooseTestName> ListMarksAndName { get; set; } = new List<FormChooseTestName> { };


        public List<Panel> ListPanelsTestsOnPanel { get; set; }
        
        public Dictionary<string, List<int>> TestNameAndMarks { get; set; } = new Dictionary<string, List<int>> { };

        private readonly FormChooseVzvod _formChooseVzvod;

        public Panel TestOperations { get; set; }
        Label _linkLabelTestNew;
        Button _buttonTestDeleteNew;
        Button _buttonTestOpenNew;
        Button _buttonTestDownloadNew;
        Button _buttonTestMarksNew;
        //Button buttonTestVzvodaNew;

        public FormHello()
        {
            InitializeComponent();
            ListPanelsTestsOnPanel = new List<Panel> { };


            _formChooseVzvod = new FormChooseVzvod(this);

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
            //buttonTestVzvodaNew = new Button();

            TestOperations.BackColor = System.Drawing.SystemColors.ControlLight;
            TestOperations.Controls.Add(_linkLabelTestNew);
            TestOperations.Controls.Add(_buttonTestDeleteNew);
            TestOperations.Controls.Add(_buttonTestOpenNew);
            TestOperations.Controls.Add(_buttonTestDownloadNew);
            TestOperations.Controls.Add(_buttonTestMarksNew);
            //testOperations.Controls.Add(buttonTestVzvodaNew);
            TestOperations.Location = new System.Drawing.Point(28, 78 + 70 * ListPanelsTestsOnPanel.Count);
            TestOperations.Name = "panelTestInTestsList" + ListPanelsTestsOnPanel.Count;
            TestOperations.Size = new System.Drawing.Size(808, 51);
            TestOperations.TabIndex = 7;


            FormChooseTestName formChooseTestName = new FormChooseTestName(this, ListPanelsTestsOnPanel.Count);
            Visible = false;
            formChooseTestName.Visible = true;
            ListMarksAndName.Add(formChooseTestName);


            _linkLabelTestNew.AutoSize = true;
            _linkLabelTestNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _linkLabelTestNew.Location = new System.Drawing.Point(3, 15);
            _linkLabelTestNew.Name = "linkLabelTest" + ListPanelsTestsOnPanel.Count;
            _linkLabelTestNew.Size = new System.Drawing.Size(146, 20);
            _linkLabelTestNew.TabIndex = 1;
            _linkLabelTestNew.TabStop = true;

            _buttonTestDeleteNew.FlatStyle = FlatStyle.Flat;
            _buttonTestDeleteNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestDeleteNew.Location = new System.Drawing.Point(720, 5);
            _buttonTestDeleteNew.Name = "buttonTestDelete" + ListPanelsTestsOnPanel.Count;
            _buttonTestDeleteNew.Size = new System.Drawing.Size(80, 40);
            _buttonTestDeleteNew.TabIndex = 6;
            _buttonTestDeleteNew.Text = "Удалить";
            //buttonTestDeleteNew.Click=
            _buttonTestDeleteNew.UseVisualStyleBackColor = true;
            _buttonTestDeleteNew.Enabled = false;


            _buttonTestOpenNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _buttonTestOpenNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestOpenNew.Location = new System.Drawing.Point(260, 5);
            _buttonTestOpenNew.Name = "buttonTestOpen" + ListPanelsTestsOnPanel.Count;
            _buttonTestOpenNew.Size = new System.Drawing.Size(215, 40);
            _buttonTestOpenNew.TabIndex = 2;
            _buttonTestOpenNew.Text = "Просмотр/редактирование";
            _buttonTestOpenNew.UseVisualStyleBackColor = true;

            _buttonTestDownloadNew.FlatStyle = FlatStyle.Flat;
            _buttonTestDownloadNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestDownloadNew.Location = new System.Drawing.Point(634, 5);
            _buttonTestDownloadNew.Name = "buttonTestDownload" + ListPanelsTestsOnPanel.Count;
            _buttonTestDownloadNew.Size = new System.Drawing.Size(80, 40);
            _buttonTestDownloadNew.TabIndex = 5;
            _buttonTestDownloadNew.Text = "Скачать";
            _buttonTestDownloadNew.UseVisualStyleBackColor = true;

            //buttonTestVzvodaNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //buttonTestVzvodaNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            //buttonTestVzvodaNew.Location = new System.Drawing.Point(528, 5);
            //buttonTestVzvodaNew.Name = "buttonTestVzvoda" + _listPanelsTestsOnPanel.Count;
            //buttonTestVzvodaNew.Size = new System.Drawing.Size(100, 40);
            //buttonTestVzvodaNew.TabIndex = 3;
            //buttonTestVzvodaNew.Text = "Взвода";
            //buttonTestVzvodaNew.UseVisualStyleBackColor = true;

            _buttonTestMarksNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _buttonTestMarksNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            _buttonTestMarksNew.Location = new System.Drawing.Point(480, 5);
            _buttonTestMarksNew.Name = "buttonTestMarks" + ListPanelsTestsOnPanel.Count;
            _buttonTestMarksNew.Size = new System.Drawing.Size(146, 40);
            _buttonTestMarksNew.TabIndex = 4;
            _buttonTestMarksNew.Text = "Критерии оценки";
            _buttonTestMarksNew.UseVisualStyleBackColor = true;

            ListPanelsTestsOnPanel.Add(TestOperations);
            panelMain.Controls.Add(TestOperations);

            buttonCreateTest.Location = new System.Drawing.Point(365, 81 + 70 * ListPanelsTestsOnPanel.Count);


            _buttonTestOpenNew.Click += openCurrentTest;
            //buttonTestVzvodaNew.Click += testCurrentVzvoda;
            _buttonTestMarksNew.Click += testCurrentMarks;
            _buttonTestDeleteNew.Click += testCurrentDelete;
            _buttonTestDownloadNew.Click += testCurrentDownload;
        }

        private void testCurrentDelete(object sender, EventArgs e)
        {
            //string tempString = ((Control)sender).Parent.Name;
            //string index = tempString.Substring(tempString.Length - 1);
            //ListPanelsTestsOnPanel[Int32.Parse(index)].Dispose();
            ////ListPanelsTestsOnPanel.Remove(ListPanelsTestsOnPanel[Int32.Parse(index)]);
            ////panelMain.Controls[Int32.Parse(index)].Dispose();
            ////panelMain.Controls.Remove(panelMain.Controls[Int32.Parse(index)]);
            ////ListTests.Remove(ListTests[Int32.Parse(index)]);

            //foreach (Panel pnl in ListPanelsTestsOnPanel)
            //{
            //    pnl.Location = new System.Drawing.Point(28, 78 + 70 * ListPanelsTestsOnPanel.Count);
            //}
            //buttonCreateTest.Location = new System.Drawing.Point(365, 81 + 70 * ListPanelsTestsOnPanel.Count);
        }

        private void testCurrentDownload(object sender, EventArgs e)
        {
            string tempString = ((Control) sender).Parent.Name;
            string index = tempString.Substring(tempString.Length - 1);
            
            saveTests.Filter = Resources.SaveTestFilter;
            saveTests.FileName = ListTests[Int32.Parse(index)].TestName;
            if (saveTests.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveTests.FileName;

            string testJson = new JsonCreator().CreateTestCollection(new List<Test> {ListTests[Int32.Parse(index)]});
            new PictureCreator().CreatePictures(ListTests[Int32.Parse(index)], filename.Substring(0, filename.LastIndexOf("\\", StringComparison.Ordinal)));
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, testJson);
            MessageBox.Show("Файл сохранен");
        }


        private void openCurrentTest(object sender, EventArgs e)
        {
            string tempString = ((Control) sender).Parent.Name;
            string index = tempString.Substring(tempString.Length - 1);


            this.Visible = false;
            ListTests[Int32.Parse(index)].Visible = true;
        }

        //private void testCurrentVzvoda(object sender, EventArgs e)
        //{
        //    string tempString = ((Control) sender).Parent.Name;
        //    string index = tempString.Substring(tempString.Length - 1);


        //    this.Visible = false;
        //    //_listVzvodovAndLS[Int32.Parse(index)].Visible = true;
        //}


        private void testCurrentMarks(object sender, EventArgs e)
        {
            string tempString = ((Control) sender).Parent.Name;
            string index = tempString.Substring(tempString.Length - 1);

            Visible = false;
            CheckBox fuck = (CheckBox) (ListMarksAndName[Int32.Parse(index)].Controls[0].Controls
                .Find("checkBoxIsFirstOpen", false)[0]);
            fuck.Checked = false;
            ListMarksAndName[Int32.Parse(index)].Visible = true;
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
            saveTests.Filter = Resources.SaveTestFilter;

            if (saveTests.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveTests.FileName;

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
    }
}