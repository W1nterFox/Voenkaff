using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Voenkaff.Entity
{
    class TextContainer:Entity<TextBox>
    {
        private Panel _parent;
        //private readonly Panel _answerPanel;
        private readonly int _popravka = 25;
        private Test _form;
        private int _index;
        private Label _topTitle;

        public int indexLastTb = 1;

        public void setParent(Panel parent)
        {
            _parent = parent;
        }
        public void setTopTitle(Label topTitle)
        {
            _topTitle = topTitle;
        }
        public void setForm(Test form)
        {
            _form = form;
        }
        public TextContainer(Panel parent, Test form)
        {
            _parent = parent;
            _form = form;
            

            foreach (Control ctrl in _parent.Controls)
            {
                if (ctrl is TextBox)
                {
                    indexLastTb++;
                }
            }
            _index = indexLastTb;



            Instance = new TextBox();
            Instance.Parent = _parent;
            Instance.Name = "textBox" + _index;
            Instance.Location = new Point(10, 40);
            _parent.Controls.Add(Instance);
            Instance.MouseMove += IdentifierMove;
            Instance.TextChanged += IdentifierTextChange;
            Instance.BringToFront();
            Instance.Width = 150;
            

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
            AddAnswerTitle();

            Instance.TabIndex = _index;
        }

        public TextContainer(string name)
        {
            
            _index = indexLastTb;
            //indexLastTb++;

            Instance = new TextBox();
            Instance.Name = "textBox" + _index;
            Instance.Location = new Point(10, 40);
            Instance.MouseMove += IdentifierMove;
            Instance.TextChanged += IdentifierTextChange;
            Instance.BringToFront();
            Instance.Width = 150;
            Instance.TabIndex = _index;

            ContextMenu cmu = new ContextMenu();
            MenuItem menuItemDelete = new MenuItem
            {
                Index = 0,
                Text = "Удалить",
                Shortcut = Shortcut.CtrlDel
            };
            menuItemDelete.Click += RemoveTextBox;
            menuItemDelete.Name = Instance.ToString() + name;
            cmu.MenuItems.Add(menuItemDelete);
            Instance.ContextMenu = cmu;

            
        }



        public void AddAnswerTitle(int index)
        {
            _index = index;
            //indexLastTb++;

            _topTitle = new Label
            {
                Text = "Ответ № " + _index,
                Location = new Point(Instance.Location.X, Instance.Location.Y - _popravka),
                Width = 100,
                Name = "textBoxLabel" + _index,
                BackColor = System.Drawing.Color.Transparent
            };
            _parent.Controls.Add(_topTitle);
            _topTitle.BringToFront();

            
            
        }
        public void AddAnswerTitle()
        {
            _topTitle = new Label
            {
                Text = "Ответ № " + _index,
                Location = new Point(Instance.Location.X, Instance.Location.Y - _popravka),
                Width = 100,
                Name = "textBoxLabel" + _index,
                TabIndex = _index
            };
            _parent.Controls.Add(_topTitle);
            _topTitle.BringToFront();



        }

        private void IdentifierMove(object sender, MouseEventArgs e)
        {
            TextBox currentObject = ((TextBox) sender);
            if (MouseButtons.Left == e.Button)
            {
                _parent.Controls.Find("textBoxLabel" + currentObject.TabIndex, true)[0].Location = new Point(currentObject.Location.X, currentObject.Location.Y - _popravka);
                
            }

            if (MouseButtons.Right == e.Button)
            {
                currentObject.ContextMenu.Show(currentObject, new Point(e.X, e.Y));
            }
        }

        private void IdentifierTextChange(object sender, EventArgs e)
        {
            
        }


        private void RemoveTextBox(object sender, EventArgs e)
        {

            foreach (Control ctrl in _parent.Controls)
            {

                if (ctrl.TabIndex > Instance.TabIndex)
                {
                    if (ctrl is TextBox)
                    {
                        ctrl.TabIndex--;
                    }
                    if (ctrl is Label)
                    {
                        ctrl.TabIndex--;
                        ctrl.Name = "textBoxLabel" + ctrl.TabIndex;
                        ctrl.Text = "Ответ № " + ctrl.TabIndex;
                    }
                }



            }

            _parent.Controls.Remove(Instance);
            _parent.Controls.Remove(_topTitle);

            //indexLastTb--;
            
            
            

        }
    }
}
