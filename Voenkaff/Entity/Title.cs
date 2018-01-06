using System;
using System.Drawing;
using System.Windows.Forms;

namespace Voenkaff.Entity
{
    class Title
    {
        private readonly Panel _parent;
        private readonly int _index;
        private readonly Form1 _form;
        public RichTextBox ObjectEntity { get; set; }

        public Title(Panel parent, Form1 form, int index)
        {
            _parent = parent;
            _index = index;
            _form = form;

            ObjectEntity = new RichTextBox {Parent = _parent};
            ObjectEntity.Name = ObjectEntity.ToString() + _index;
            ObjectEntity.Location = new Point(10, 10);
            _parent.Controls.Add(ObjectEntity);
            ObjectEntity.MouseMove += IdentifierMove;
            ObjectEntity.BringToFront();

            ContextMenu cmu = new ContextMenu();
            MenuItem menuItemDelete = new MenuItem
            {
                Index = 0,
                Text = "Удалить",
                Shortcut = Shortcut.CtrlDel
            };
            menuItemDelete.Click += RemoveTextBox;
            menuItemDelete.Name = ObjectEntity.ToString() + _index;
            cmu.MenuItems.Add(menuItemDelete);
            ObjectEntity.ContextMenu = cmu;
        }

        private void RemoveTextBox(object sender, EventArgs e)
        {
            Control currentObject = _parent.Controls.Find(((MenuItem)sender).Name, false)[0];
            _parent.Controls.Remove(currentObject);
        }

        private void IdentifierMove(object sender, MouseEventArgs e)
        {
            RichTextBox currentObject = ((RichTextBox)sender);
            if (MouseButtons.Left == e.Button)
            {
                Point point = _form.PointToClient(Cursor.Position);
                currentObject.Location = new Point(point.X - currentObject.Size.Width / 2, point.Y - currentObject.Size.Height / 2);
            }
            if (MouseButtons.Right == e.Button)
            {
                currentObject.ContextMenu.Show(currentObject, new Point(e.X, e.Y));
            }

        }
    }
}
