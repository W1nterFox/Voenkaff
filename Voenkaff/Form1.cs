using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voenkaff
{
    public partial class Form1 : Form
    {
        private int Identifier = 1;
        private const int popravka = 50;
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
            topTitle.Location = new Point(objectEntity.Location.X - popravka, objectEntity.Location.Y);
            panel2.Controls.Add(topTitle);

            Panel panel = new Panel();
            panel.Dock = DockStyle.Left;
            panel.Name = objectEntity.ToString() + index;
            TextBox answer = new TextBox();
            answer.Dock = DockStyle.Top;
            answer.BringToFront();
            Label label = new Label();
            label.Dock = DockStyle.Top;
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
            MenuItem menuItemDelete = new MenuItem();
            menuItemDelete.Index = 0;
            menuItemDelete.Text = "Удалить";
            menuItemDelete.Shortcut = Shortcut.CtrlDel;
            menuItemDelete.Click += new EventHandler(RemoveTextBox);
            menuItemDelete.Name = objectEntity.ToString() + index;
            cmu.MenuItems.Add(menuItemDelete);
            objectEntity.ContextMenu = cmu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityWrapper<TextBox> tb = new EntityWrapper<TextBox>(new TextBox(), Identifier);
            ObjectCreator<TextBox>(tb.Entity,tb.Identifier);
            AddAnswerTitle(tb.Entity,tb.Identifier);
            Identifier++;
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
                var test = panel2.Controls.OfType<Label>();
                foreach (Label title in panel2.Controls.OfType<Label>())
                {
                    if( Regex.Match(title.Text,"[0-9]+").Value==Regex.Match(currentObject.Name, "[0-9]+").Value)
                    {
                        title.Location = new Point(currentObject.Location.X - popravka, currentObject.Location.Y);
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
            EntityWrapper<PictureBox> pb = new EntityWrapper<PictureBox>(new PictureBox(), Identifier);
            ObjectCreator<PictureBox>(pb.Entity, pb.Identifier);
            Identifier++;


            Bitmap image; //Bitmap для открываемого изображения
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (OFD.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(OFD.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    pb.Entity.Size = image.Size;
                    pb.Entity.Image = image;
                    pb.Entity.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadNewPict(PictureBox pb) {
            pb.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+@"\image.gif");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EntityWrapper<RichTextBox> tb = new EntityWrapper<RichTextBox>(new RichTextBox(), Identifier);
            ObjectCreator<RichTextBox>(tb.Entity, tb.Identifier);
            Identifier++;
            tb.Entity.BackColor = Color.Cyan;
            tb.Entity.Font = new Font("Times New Roman",14f);
            tb.Entity.Width=500;
        }
    }
}
