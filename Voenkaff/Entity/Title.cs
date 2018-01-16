using System;
using System.Drawing;
using System.Windows.Forms;

namespace Voenkaff.Entity
{
    class Title:Entity<RichTextBox>
    {
        private readonly Panel _parent;
        private readonly int _index;
        private readonly Test _form;

        public Title(Panel parent, Test form, int index)
        {
            _parent = parent;
            _index = index;
            _form = form;

            Instance = new RichTextBox {Parent = _parent};
            Instance.Name = Instance.ToString() + _index;
            Instance.Location = new Point(10, 10);
            _parent.Controls.Add(Instance);
            Instance.MouseMove += IdentifierMove;
            Instance.BringToFront();

            ContextMenu cmu = new ContextMenu();
            MenuItem menuItemDelete = new MenuItem
            {
                Index = 0,
                Text = "Удалить",
                Shortcut = Shortcut.CtrlDel
            };
            menuItemDelete.Click += RemoveTextBox;
            menuItemDelete.Name = Instance.ToString() + _index;
            cmu.MenuItems.Add(menuItemDelete);
            Instance.ContextMenu = cmu;
        }

        private void RemoveTextBox(object sender, EventArgs e)
        {
            Control currentObject = _parent.Controls.Find(((MenuItem)sender).Name, false)[0];
            _parent.Controls.Remove(currentObject);
        }

        private void IdentifierMove(object sender, MouseEventArgs e)
        {
            RichTextBox currentObject = ((RichTextBox)sender);
            //if (MouseButtons.Left == e.Button)
            //{
            //    Point point = _form.PointToClient(Cursor.Position);
            //    currentObject.Location = new Point(point.X - currentObject.Size.Width / 2, point.Y - currentObject.Size.Height / 2);
            //}
            if (MouseButtons.Right == e.Button)
            {
                currentObject.ContextMenu.Show(currentObject, new Point(e.X, e.Y));
            }

        }
    }
}
