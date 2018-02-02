using System;
using System.Drawing;
using System.Windows.Forms;

namespace Voenkaff.Entity
{
    class PictureBoxScalable:Entity<PictureBox>
    {
        private Rectangle _rectProposedSize = Rectangle.Empty;
        private readonly Test _form;
        private Panel _parent;
        

        public void setParent(Panel parent)
        {
            _parent = parent;
        }

        public PictureBoxScalable(int index,Test panel,Panel parent)
        {
            
            _form = panel;
            _parent = parent;
            Instance = new PictureBox
            {
                Name = panel.TestName + "_" + parent.Parent.Name + "_" + index,
                Location = new Point(10, 10)
            };

            ContextMenu cmu = new ContextMenu();
            MenuItem menuItemDelete = new MenuItem
            {
                Index = 0,
                Text = "Удалить",
                Shortcut = Shortcut.CtrlDel
            };
            menuItemDelete.Click += Remove;
            menuItemDelete.Name = Instance.Name;
            cmu.MenuItems.Add(menuItemDelete);
            Instance.ContextMenu = cmu;
        }

        public PictureBoxScalable(string name)
        {
            


            Instance = new PictureBox
            {
                Name = name,
                Location = new Point(10, 10)
            };

            ContextMenu cmu = new ContextMenu();
            MenuItem menuItemDelete = new MenuItem
            {
                Index = 0,
                Text = "Удалить",
                Shortcut = Shortcut.CtrlDel
            };
            menuItemDelete.Click += Remove;
            menuItemDelete.Name = Instance.Name;
            cmu.MenuItems.Add(menuItemDelete);
            Instance.ContextMenu = cmu;
        }

        private void Remove(object sender, EventArgs e)
        {
            _parent.Controls.Remove(Instance);
        }
    }
}
