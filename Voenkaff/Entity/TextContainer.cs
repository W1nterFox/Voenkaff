using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Voenkaff.Entity
{
    class TextContainer:Entity<TextBox>
    {
        private readonly Panel _parent;
        private readonly Panel _answerPanel;
        private readonly int _popravka = 15;
        private readonly Test _form;
        private readonly int _index;
        private Label _topTitle;
        private Panel _panel;

        public TextContainer(Panel parent, Panel answerPanel, Test form,int index)
        {
            _parent = parent;
            _answerPanel = answerPanel;
            _form = form;
            _index = index;
            Instance = new TextBox();
            Instance.Name = Instance.ToString() + index;
            Instance.Location = new Point(10, 10);
            _parent.Controls.Add(Instance);
            Instance.MouseMove += IdentifierMove;
            Instance.TextChanged += IdentifierTextChange;
            Instance.BringToFront();

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

        


        private void AddAnswerTitle()
        {
            _topTitle = new Label
            {
                Text = "Текстовое поле: " + _index,
                Location = new Point(Instance.Location.X, Instance.Location.Y + _popravka)
            };
            _parent.Controls.Add(_topTitle);
            _topTitle.BringToFront();

            _panel = new Panel
            {
                Dock = DockStyle.Left,
                Name = Instance.ToString() + _index
            };
            TextBox answer = new TextBox {Dock = DockStyle.Top};
            answer.BringToFront();
            Label label = new Label {Dock = DockStyle.Top};
            label.BringToFront();
            label.Text = "Текстовое поле: " + _index;
            _panel.Controls.Add(answer);
            _panel.Controls.Add(label);
            _answerPanel.Controls.Add(_panel);
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
            //Label currentTitle = new Label();
            //TextBox currentObject = ((TextBox)sender);
            //foreach (Label title in _parent.Controls.OfType<Label>())
            //{
            //    if (Regex.Match(title.Text, "[0-9]+").Value == Regex.Match(currentObject.Name, "[0-9]+").Value)
            //    {
            //        currentTitle = title;
            //    }
            //}
            //_panel.Controls.Find(currentTitle.Text, false);

            //ТУТ ДОЛЖЕН БЫТЬ КОД, С ПОМОЩЬЮ КОТОРОГО ТЕКСТ ИЗ ОТВЕТА ИЗ ПАНЕЛИ answers ДОЛЖЕН БЫТЬ РАВЕН ТЕКСТУ ИЗ ПАНЕЛИ question
        }


        private void RemoveTextBox(object sender, EventArgs e)
        {
            _parent.Controls.Remove(Instance);
            _parent.Controls.Remove(_topTitle);
            _answerPanel.Controls.Remove(_panel);
        }
    }
}
