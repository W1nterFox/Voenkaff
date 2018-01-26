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
        private readonly int _popravka = 15;
        private readonly Test _form;
        private readonly int _index;
        private Label _topTitle;

        public void setParent(Panel parent)
        {
            _parent = parent;
        }
        public TextContainer(Panel parent, /*Panel answerPanel,*/ Test form,int index)
        {
            _parent = parent;
            //_answerPanel = answerPanel;
            _form = form;
            _index = index;
            Instance = new TextBox();
            Instance.Name = Instance.ToString() + index;
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
            menuItemDelete.Name = Instance.ToString() + index;
            cmu.MenuItems.Add(menuItemDelete);
            Instance.ContextMenu = cmu;
            AddAnswerTitle();
        }

        public TextContainer(Panel parent, string name)
        {
            _parent = parent;
            Instance = new TextBox();
            Instance.Name = name;
            Instance.Location = new Point(10, 40);
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
            menuItemDelete.Name = name;
            cmu.MenuItems.Add(menuItemDelete);
            Instance.ContextMenu = cmu;


        }



        private void AddAnswerTitle()
        {
            _topTitle = new Label
            {
                Text = "Поле для ввода ответа № " + _index,
                Location = new Point(Instance.Location.X, Instance.Location.Y - _popravka),
                Width = 150
            };
            _parent.Controls.Add(_topTitle);
            _topTitle.BringToFront();

            
            
        }

        private void IdentifierMove(object sender, MouseEventArgs e)
        {
            TextBox currentObject = ((TextBox) sender);
            if (MouseButtons.Left == e.Button)
            {
                _form.PointToClient(Cursor.Position);
                //currentObject.Location = new Point(point.X - currentObject.Size.Width / 2, point.Y - currentObject.Size.Height / 2);
                foreach (Label title in _parent.Controls.OfType<Label>())
                {
                    if (Regex.Match(title.Text, "[0-9]+").Value == Regex.Match(currentObject.Name, "[0-9]+").Value)
                    {
                        title.Location = new Point(currentObject.Location.X, currentObject.Location.Y - _popravka);
                    }
                }
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
            _parent.Controls.Remove(Instance);
            _parent.Controls.Remove(_topTitle);
        }
    }
}
