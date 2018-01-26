using System;
using System.Drawing;
using System.Windows.Forms;

namespace Voenkaff.Entity
{
    class Title:Entity<RichTextBox>
    {
        private Panel _parent;
        private readonly int _index;
        private readonly Test _form;

        public void setParent(Panel parent)
        {
            _parent = parent;
        }

        public Title(Panel parent, Test form, int index)
        {
            _parent = parent;
            _index = index;
            _form = form;

            Instance = new RichTextBox {Parent = _parent};
            Instance.Name = Instance.ToString() + _index;
            Instance.Location = new Point(10, 20);
            Instance.ScrollBars = RichTextBoxScrollBars.None;
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
            menuItemDelete.Click += RemoveObject;
            menuItemDelete.Name = Instance.ToString() + _index;
            cmu.MenuItems.Add(menuItemDelete);
            Instance.ContextMenu = cmu;
        }

        public Title(string name)
        {
            Instance = new RichTextBox { Parent = _parent };
            Instance.Name = name;
            Instance.Location = new Point(10, 20);
            Instance.ScrollBars = RichTextBoxScrollBars.None;
            Instance.MouseMove += IdentifierMove;
            Instance.BringToFront();

            ContextMenu cmu = new ContextMenu();
            MenuItem menuItemDelete = new MenuItem
            {
                Index = 0,
                Text = "Удалить",
                Shortcut = Shortcut.CtrlDel
            };
            menuItemDelete.Click += RemoveObject;
            menuItemDelete.Name = Instance.ToString() + _index;
            cmu.MenuItems.Add(menuItemDelete);
            Instance.ContextMenu = cmu;
        }

        private void RemoveObject(object sender, EventArgs e)
        {
            _parent.Controls.Remove(Instance);
        }

        private void IdentifierMove(object sender, MouseEventArgs e)
        {
            RichTextBox currentObject = ((RichTextBox)sender);
            
            if (MouseButtons.Right == e.Button)
            {
                currentObject.ContextMenu.Show(currentObject, new Point(e.X, e.Y));
            }

        }
    }
}
