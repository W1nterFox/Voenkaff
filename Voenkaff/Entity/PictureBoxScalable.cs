using System;
using System.Drawing;
using System.Windows.Forms;

namespace Voenkaff
{
    class PictureBoxScalable
    {

        Control _draggedPiece;
        bool _resizing;
        private Point _startDraggingPoint;
        private Size _startSize;
        Rectangle _rectProposedSize = Rectangle.Empty;
        public PictureBox Pb { get; set; }
        private readonly Form1 _form;
        private readonly Panel _parent;

        int resizingMargin = 5;

        public PictureBoxScalable(int index,Form1 panel,Panel parent)
        {
            _form = panel;
            _parent = parent;
            Pb= new PictureBox();
            Pb.Name = Pb.ToString() + index;
            Pb.Location = new Point(10, 10);
            Pb.MouseMove += MouseMove;
            Pb.MouseDown += MouseDown;
            Pb.MouseUp += MouseUp;
            Pb.BringToFront();

            ContextMenu cmu = new ContextMenu();
            MenuItem menuItemDelete = new MenuItem
            {
                Index = 0,
                Text = "Удалить",
                Shortcut = Shortcut.CtrlDel
            };
            menuItemDelete.Click += Remove;
            menuItemDelete.Name = Pb.ToString() + index;
            cmu.MenuItems.Add(menuItemDelete);
            Pb.ContextMenu = cmu;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            _draggedPiece = sender as Control;

            if (_draggedPiece != null && ((e.X <= resizingMargin) || (e.X >= _draggedPiece.Width - resizingMargin) ||
                                          (e.Y <= resizingMargin) || (e.Y >= _draggedPiece.Height - resizingMargin)))
            {
                _resizing = true;

                _form.Cursor = Cursors.SizeNWSE;

                _startSize = new Size(e.X, e.Y);
                Point pt = _form.PointToScreen(_draggedPiece.Location);
                _rectProposedSize = new Rectangle(pt, _startSize);

                ControlPaint.DrawReversibleFrame(_rectProposedSize, _form.ForeColor, FrameStyle.Dashed);
            }
            else
            {
                _resizing = false;
                _form.Cursor = Cursors.SizeAll;
            }

            _startDraggingPoint = e.Location;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (_draggedPiece != null)
            {
                if (_resizing)
                {
                    _rectProposedSize.Width = e.X;
                    _rectProposedSize.Height = e.Y;
                    _draggedPiece.Size = new Size(Math.Max(20, e.X), Math.Max(10, e.Y));
                }
                else
                {
                    Point pt;
                    if (_draggedPiece == sender)
                        pt = new Point(e.X, e.Y);
                    else
                        pt = _draggedPiece.PointToClient(((Control) sender).PointToScreen(new Point(e.X, e.Y)));

                    _draggedPiece.Left += pt.X - _startDraggingPoint.X;
                    _draggedPiece.Top += pt.Y - _startDraggingPoint.Y;
                }
            }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (_resizing)
            {
                if (_rectProposedSize.Width > 0 && _rectProposedSize.Height > 0)
                {
                    ControlPaint.DrawReversibleFrame(_rectProposedSize, _form.ForeColor, FrameStyle.Dashed);
                }
                if (_rectProposedSize.Width > 20 && _rectProposedSize.Height > 10)
                {
                    _draggedPiece.Size = _rectProposedSize.Size;
                }
                else
                {
                    _draggedPiece.Size = new Size(Math.Max(10, e.X), Math.Max(10, e.Y));
                }
            }

            _draggedPiece = null;
            _startDraggingPoint = Point.Empty;
            _form.Cursor = Cursors.Default;
        }

        private void Remove(object sender, EventArgs e)
        {
            Control currentObject = _parent.Controls.Find(((MenuItem)sender).Name, false)[0];
            _parent.Controls.Remove(currentObject);
        }
    }
}
