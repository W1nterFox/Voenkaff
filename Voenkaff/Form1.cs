using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Voenkaff.Entity;

namespace Voenkaff
{
    public partial class Form1 : Form
    {
        private int _identifier = 1;
        List<Panel> listPanelsTasks;

        Panel currentTask = new Panel();
        Panel currentPanelQuestion = new Panel();
        Panel currentPanelAnswer = new Panel();

        public Form1()
        {
            InitializeComponent();

            panelMiddle.Controls.Add(panelTaskStart);
            listPanelsTasks = new List<Panel>();
            listPanelsTasks.Add(panelTaskStart);

            panelTaskStart.Controls.Add(panelQuestionStart);
            panelTaskStart.Controls.Add(panelAnswerStart);
            
            panelAnswerStart.BringToFront();
            //panelTask.Visible = false;

            currentPanelQuestion = panelQuestionStart;
            currentPanelAnswer = panelAnswerStart;

            panelListOfTasks.Controls.Add(createLinkLabel(0));
            

        }

        private LinkLabel createLinkLabel(int indexPanel)
        {
            LinkLabel LL = new LinkLabel();
            

            LL.AutoSize = true;
            LL.Font = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            LL.LinkColor = Color.Black;
            LL.Location = new Point(10, 57 + indexPanel * 30);
            LL.Name = "linkLabel" + indexPanel;
            LL.Size = new Size(96, 16);
            LL.TabIndex = 0;
            LL.TabStop = true;
            LL.Text = "Задание №" + (indexPanel + 1);
            LL.VisitedLinkColor = Color.Black;
            LL.Click += clickTaskLinkLabel;
            LL.Tag = indexPanel;

            return LL;
        }

        private void clickTaskLinkLabel(object sender, EventArgs e)
        {
            LinkLabel currentLL = (LinkLabel)sender;
            
            foreach (Panel index in listPanelsTasks)
            {
                index.Visible = false;
            }
            textBox1.Text = currentLL.Text;
            listPanelsTasks[(int)currentLL.Tag].Visible = true;


            currentTask = listPanelsTasks[(int)currentLL.Tag];
            currentPanelQuestion = (Panel)currentTask.Controls.Find("panelQuestion", false)[0];
            currentPanelAnswer = (Panel)currentTask.Controls.Find("panelAnswer", false)[0];

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextContainer tc = new TextContainer(currentPanelQuestion, currentPanelAnswer, this,_identifier);
            _identifier++;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PictureBoxScalable pb = new PictureBoxScalable(_identifier, this, currentPanelQuestion) {Pb = {Parent = currentPanelQuestion, SizeMode = PictureBoxSizeMode.StretchImage}};
            _identifier++;


            Bitmap image; //Bitmap для открываемого изображения
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"
            };
            //формат загружаемого файла
            if (ofd.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(ofd.FileName);

                    pb.Pb.Size = image.Size;
                    pb.Pb.Image = image;
                    pb.Pb.Invalidate();
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Title ttl = new Title(currentPanelQuestion, this,_identifier);
            _identifier++;
            ttl.ObjectEntity.BackColor = Color.Cyan;
            ttl.ObjectEntity.Font = new Font("Times New Roman",14f);
            ttl.ObjectEntity.Width=500;
        }

        private void buttonTaskCreate_Click(object sender, EventArgs e)
        {
            listPanelsTasks[listPanelsTasks.Count - 1].Visible = false;

            Panel newPanelTask = new Panel();

            panelMiddle.Controls.Add(newPanelTask);
            newPanelTask.BackColor = SystemColors.ControlLight;

            Panel panelQuestion = new Panel();
            panelQuestion.AutoScroll = true;
            panelQuestion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            panelQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            panelQuestion.Location = new System.Drawing.Point(5, 5);
            panelQuestion.Size = new System.Drawing.Size(1132, 632);
            panelQuestion.Name = "panelQuestion";

            Panel panelAnswer = new Panel();
            panelAnswer.AutoScroll = true;
            panelAnswer.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            panelAnswer.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelAnswer.Location = new System.Drawing.Point(133, 524);
            panelAnswer.Size = new System.Drawing.Size(1142, 118);
            panelAnswer.Name = "panelAnswer";

            newPanelTask.Controls.Add(panelQuestion);
            newPanelTask.Controls.Add(panelAnswer);
            newPanelTask.Dock = DockStyle.Fill;
            newPanelTask.Location = new Point(133, 0);
            newPanelTask.Margin = new Padding(10);
            newPanelTask.Padding = new Padding(5);
            newPanelTask.Size = new Size(1142, 642);

            
            listPanelsTasks.Add(newPanelTask);
            
            listPanelsTasks[listPanelsTasks.Count - 1].Visible = true;


            currentTask = listPanelsTasks[listPanelsTasks.Count - 1];
            currentPanelQuestion = (Panel)currentTask.Controls.Find("panelQuestion", false)[0];
            currentPanelAnswer = (Panel)currentTask.Controls.Find("panelAnswer", false)[0];

            panelListOfTasks.Controls.Add(createLinkLabel(listPanelsTasks.Count - 1));


        }
    }
}
