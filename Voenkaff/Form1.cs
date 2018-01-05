using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Voenkaff
{
    public partial class Form1 : Form
    {
        private int _identifier = 1;
        private const int Popravka = 15;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {      
        }

        private void AddAnswerTitle(TextBox objectEntity,int index)
        {
            Label topTitle = new Label();
            topTitle.Text = "Текстовое поле: " + index;
            topTitle.Location = new Point(objectEntity.Location.X , objectEntity.Location.Y - Popravka);
            panel2.Controls.Add(topTitle);

            Panel panel = new Panel
            {
                Dock = DockStyle.Left,
                Name = objectEntity.ToString() + index
            };
            TextBox answer = new TextBox {Dock = DockStyle.Top};
            answer.BringToFront();
            Label label = new Label {Dock = DockStyle.Top};
            label.BringToFront();
            label.Text = "Текстовое поле: " + index;
            panel.Controls.Add(answer);
            panel.Controls.Add(label);
            panel4.Controls.Add(panel);
        }

        private void ObjectCreator<T>(T objectEntity,int index) where T : Control
        {
            objectEntity.Parent = panel2;
            objectEntity.Name = objectEntity.ToString() + index;
            objectEntity.Location = new Point(10, 10);
            panel2.Controls.Add(objectEntity);
            objectEntity.MouseMove += IdentifierMove<T>;
            objectEntity.BringToFront();

            ContextMenu cmu = new ContextMenu();
            MenuItem menuItemDelete = new MenuItem
            {
                Index = 0,
                Text = "Удалить",
                Shortcut = Shortcut.CtrlDel
            };
            menuItemDelete.Click += RemoveTextBox;
            menuItemDelete.Name = objectEntity.ToString() + index;
            cmu.MenuItems.Add(menuItemDelete);
            objectEntity.ContextMenu = cmu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityWrapper<TextBox> tb = new EntityWrapper<TextBox>(new TextBox(), _identifier);
            ObjectCreator(tb.Entity,tb.Identifier);
            AddAnswerTitle(tb.Entity,tb.Identifier);
            _identifier++;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RemoveTextBox(object sender, EventArgs e)
        {
            Control currentObject = panel2.Controls.Find(((MenuItem)sender).Name, false)[0];
            panel2.Controls.Remove(currentObject);
            if (panel4.Controls.Find(((MenuItem)sender).Name, false).Length!=0)
            {
                Control answer = panel4.Controls.Find(((MenuItem)sender).Name, false)[0];
                panel4.Controls.Remove(answer);
            }
        }

        private void IdentifierMove<T>(object sender,MouseEventArgs e) where T : Control
        {
            T currentObject = ((T)sender);
            if (MouseButtons.Left == e.Button)
            {
                Point point = PointToClient(Cursor.Position); 
                currentObject.Location = new Point(point.X-currentObject.Size.Width/2,point.Y - currentObject.Size.Height / 2);
                foreach (Label title in panel2.Controls.OfType<Label>())
                {
                    if( Regex.Match(title.Text,"[0-9]+").Value==Regex.Match(currentObject.Name, "[0-9]+").Value)
                    {
                        title.Location = new Point(currentObject.Location.X , currentObject.Location.Y - Popravka);
                    }
                }
            }
            if (MouseButtons.Right == e.Button)
            {
                currentObject.ContextMenu.Show(currentObject, new Point(e.X, e.Y));
            }

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
            EntityWrapper<RichTextBox> tb = new EntityWrapper<RichTextBox>(new RichTextBox(), _identifier);
            ObjectCreator(tb.Entity, tb.Identifier);
            _identifier++;
            tb.Entity.BackColor = Color.Cyan;
            tb.Entity.Font = new Font("Times New Roman",14f);
            tb.Entity.Width=500;
        }


    }
}
