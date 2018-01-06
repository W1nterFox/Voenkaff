using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextContainer tc = new TextContainer(panel2,panel4,this,_identifier);
            _identifier++;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PictureBoxScalable pb = new PictureBoxScalable(_identifier, this, panel2) {Pb = {Parent = panel2,SizeMode = PictureBoxSizeMode.StretchImage}};
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
            Title ttl = new Title(panel2,this,_identifier);
            _identifier++;
            ttl.ObjectEntity.BackColor = Color.Cyan;
            ttl.ObjectEntity.Font = new Font("Times New Roman",14f);
            ttl.ObjectEntity.Width=500;
        }


    }
}
