using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Voenkaff.Properties;
using Voenkaff.Wrappers;

namespace Voenkaff
{
    public partial class FormHello : Form
    {
        public List<Test> _listTests = new List<Test> { };
        public List<FormChooseVzvod> _listVzvodovAndLS = new List<FormChooseVzvod> { };
        public List<FormChooseTestName> _listMarksAndName = new List<FormChooseTestName> { };


        public List<Panel> _listPanelsTestsOnPanel;

        //public List<int[]> _listmarks;
        public Dictionary<string, List<int>> _testNameAndMarks = new Dictionary<string, List<int>> { };


        public Dictionary<string, List<string>> _vzvodAndLS = new Dictionary<string, List<string>> { };

        public Panel testOperations;
        Label linkLabelTestNew;
        Button buttonTestDeleteNew;
        Button buttonTestOpenNew;
        Button buttonTestDownloadNew;
        Button buttonTestMarksNew;
        Button buttonTestVzvodaNew;

        public FormHello()
        {
            InitializeComponent();
            _listPanelsTestsOnPanel = new List<Panel> { };

            //_listmarks = new List<int[]> {};

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void buttonCreateTest_Click(object sender, EventArgs e)
        {
            testOperations = new Panel();
            linkLabelTestNew = new Label();
            buttonTestDeleteNew = new Button();
            buttonTestOpenNew = new Button();
            buttonTestDownloadNew = new Button();
            buttonTestMarksNew = new Button();
            buttonTestVzvodaNew = new Button();

            testOperations.BackColor = System.Drawing.SystemColors.ControlLight;
            testOperations.Controls.Add(linkLabelTestNew);
            testOperations.Controls.Add(buttonTestDeleteNew);
            testOperations.Controls.Add(buttonTestOpenNew);
            testOperations.Controls.Add(buttonTestDownloadNew);
            testOperations.Controls.Add(buttonTestMarksNew);
            testOperations.Controls.Add(buttonTestVzvodaNew);
            testOperations.Location = new System.Drawing.Point(28, 78 + 70 * _listPanelsTestsOnPanel.Count);
            testOperations.Name = "panelTestInTestsList" + _listPanelsTestsOnPanel.Count;
            testOperations.Size = new System.Drawing.Size(808, 51);
            testOperations.TabIndex = 7;


            FormChooseTestName formChooseTestName = new FormChooseTestName(this, _listPanelsTestsOnPanel.Count);
            this.Visible = false;
            formChooseTestName.Visible = true;
            _listMarksAndName.Add(formChooseTestName);


            linkLabelTestNew.AutoSize = true;
            linkLabelTestNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            linkLabelTestNew.Location = new System.Drawing.Point(3, 15);
            linkLabelTestNew.Name = "linkLabelTest" + _listPanelsTestsOnPanel.Count;
            linkLabelTestNew.Size = new System.Drawing.Size(146, 20);
            linkLabelTestNew.TabIndex = 1;
            linkLabelTestNew.TabStop = true;

            buttonTestDeleteNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonTestDeleteNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            buttonTestDeleteNew.Location = new System.Drawing.Point(720, 5);
            buttonTestDeleteNew.Name = "buttonTestDelete" + _listPanelsTestsOnPanel.Count;
            buttonTestDeleteNew.Size = new System.Drawing.Size(80, 40);
            buttonTestDeleteNew.TabIndex = 6;
            buttonTestDeleteNew.Text = "Удалить";
            //buttonTestDeleteNew.Click=
            buttonTestDeleteNew.UseVisualStyleBackColor = true;


            buttonTestOpenNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonTestOpenNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            buttonTestOpenNew.Location = new System.Drawing.Point(155, 5);
            buttonTestOpenNew.Name = "buttonTestOpen" + _listPanelsTestsOnPanel.Count;
            buttonTestOpenNew.Size = new System.Drawing.Size(215, 40);
            buttonTestOpenNew.TabIndex = 2;
            buttonTestOpenNew.Text = "Просмотр/редактирование";
            buttonTestOpenNew.UseVisualStyleBackColor = true;

            buttonTestDownloadNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonTestDownloadNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            buttonTestDownloadNew.Location = new System.Drawing.Point(634, 5);
            buttonTestDownloadNew.Name = "buttonTestDownload" + _listPanelsTestsOnPanel.Count;
            buttonTestDownloadNew.Size = new System.Drawing.Size(80, 40);
            buttonTestDownloadNew.TabIndex = 5;
            buttonTestDownloadNew.Text = "Скачать";
            buttonTestDownloadNew.UseVisualStyleBackColor = true;

            buttonTestVzvodaNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonTestVzvodaNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            buttonTestVzvodaNew.Location = new System.Drawing.Point(528, 5);
            buttonTestVzvodaNew.Name = "buttonTestVzvoda" + _listPanelsTestsOnPanel.Count;
            buttonTestVzvodaNew.Size = new System.Drawing.Size(100, 40);
            buttonTestVzvodaNew.TabIndex = 3;
            buttonTestVzvodaNew.Text = "Взвода";
            buttonTestVzvodaNew.UseVisualStyleBackColor = true;

            buttonTestMarksNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonTestMarksNew.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            buttonTestMarksNew.Location = new System.Drawing.Point(376, 5);
            buttonTestMarksNew.Name = "buttonTestMarks" + _listPanelsTestsOnPanel.Count;
            buttonTestMarksNew.Size = new System.Drawing.Size(146, 40);
            buttonTestMarksNew.TabIndex = 4;
            buttonTestMarksNew.Text = "Критерии оценки";
            buttonTestMarksNew.UseVisualStyleBackColor = true;

            _listPanelsTestsOnPanel.Add(testOperations);
            panelMain.Controls.Add(testOperations);

            buttonCreateTest.Location = new System.Drawing.Point(365, 81 + 70 * _listPanelsTestsOnPanel.Count);


            buttonTestOpenNew.Click += openCurrentTest;
            buttonTestVzvodaNew.Click += testCurrentVzvoda;
            buttonTestMarksNew.Click += testCurrentMarks;

            buttonTestDownloadNew.Click += testCurrentDownload;
        }


        private void testCurrentDownload(object sender, EventArgs e)
        {
            string tempString = ((Control) sender).Parent.Name;
            string index = tempString.Substring(tempString.Length - 1);
            
            saveTests.Filter = Resources.SaveTestFilter;
            saveTests.FileName = _listTests[Int32.Parse(index)].TestName;
            if (saveTests.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveTests.FileName;

            string testJson = new JsonCreator().CreateTestCollection(new List<Test> {_listTests[Int32.Parse(index)]});
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, testJson);
            MessageBox.Show("Файл сохранен");
        }


        private void openCurrentTest(object sender, EventArgs e)
        {
            string tempString = ((Control) sender).Parent.Name;
            string index = tempString.Substring(tempString.Length - 1);


            this.Visible = false;
            _listTests[Int32.Parse(index)].Visible = true;
        }

        private void testCurrentVzvoda(object sender, EventArgs e)
        {
            string tempString = ((Control) sender).Parent.Name;
            string index = tempString.Substring(tempString.Length - 1);


            this.Visible = false;
            _listVzvodovAndLS[Int32.Parse(index)].Visible = true;
        }


        private void testCurrentMarks(object sender, EventArgs e)
        {
            string tempString = ((Control) sender).Parent.Name;
            string index = tempString.Substring(tempString.Length - 1);

            this.Visible = false;
            CheckBox fuck = (CheckBox) (_listMarksAndName[Int32.Parse(index)].Controls[0].Controls
                .Find("checkBoxIsFirstOpen", false)[0]);
            fuck.Checked = false;
            _listMarksAndName[Int32.Parse(index)].Visible = true;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rz = new DialogResult();
            rz = MessageBox.Show("Завершить программу?", "Завершение", MessageBoxButtons.YesNo);

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

            string testJson = new JsonCreator().CreateTestCollection(_listTests);
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, testJson);
            MessageBox.Show("Файл сохранен");
        }
    }
}