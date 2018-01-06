﻿using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Voenkaff.Entity
{
    class TextContainer
    {
        private readonly Panel _parent;
        private readonly Panel _answerPanel;
        private readonly int _popravka = 15;
        private readonly Form1 _form;
        private readonly int _index;
        public TextBox ObjectEntity { get; set; }
        private Label _topTitle;
        private Panel _panel;

        public TextContainer(Panel parent, Panel answerPanel, Form1 form,int index)
        {
            _parent = parent;
            _answerPanel = answerPanel;
            _form = form;
            _index = index;
            ObjectEntity = new TextBox();
            ObjectEntity.Name = ObjectEntity.ToString() + index;
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
            menuItemDelete.Name = ObjectEntity.ToString() + index;
            cmu.MenuItems.Add(menuItemDelete);
            ObjectEntity.ContextMenu = cmu;
            AddAnswerTitle();
        }

        private void AddAnswerTitle()
        {
            _topTitle = new Label();
            _topTitle.Text = "Текстовое поле: " + _index;
            _topTitle.Location = new Point(ObjectEntity.Location.X, ObjectEntity.Location.Y - _popravka);
            _parent.Controls.Add(_topTitle);

            _panel = new Panel
            {
                Dock = DockStyle.Left,
                Name = ObjectEntity.ToString() + _index
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
                Point point = _form.PointToClient(Cursor.Position);
                currentObject.Location = new Point(point.X - currentObject.Size.Width / 2,
                    point.Y - currentObject.Size.Height / 2);
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

        private void RemoveTextBox(object sender, EventArgs e)
        {
            _parent.Controls.Remove(ObjectEntity);
            _parent.Controls.Remove(_topTitle);
            _answerPanel.Controls.Remove(_panel);
        }
    }
}