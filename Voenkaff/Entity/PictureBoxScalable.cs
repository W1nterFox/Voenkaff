﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Voenkaff.Entity
{
    class PictureBoxScalable:Entity<PictureBox>
    {
        private Rectangle _rectProposedSize = Rectangle.Empty;
        private readonly Test _form;
        private readonly Panel _parent;

        

        public PictureBoxScalable(int index,Test panel,Panel parent)
        {
            _form = panel;
            _parent = parent;
            Instance = new PictureBox
            {
                Name = panel.TestName + "_" + parent.Text + "_" + index,
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
            Control currentObject = _parent.Controls.Find(((MenuItem)sender).Name, false)[0];
            _parent.Controls.Remove(currentObject);
        }
    }
}
