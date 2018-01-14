using System;
using System.Drawing;
using System.Windows.Forms;

namespace Voenkaff.Entity
{
    public static class ControlMover
    {
        public static bool ChangeCursor { get; set; }
        public static bool AllowMove { get; set; }
        public static bool AllowResize { get; set; }
        public static bool BringToFront { get; set; }
        public static int ResizingMargin { get; set; }
        public static int MinSize { get; set; }

        private static Point _startMouse;
        private static Point _startLocation;
        private static Size _startSize;
        private static bool _resizing;
        static Cursor _oldCursor;

        static ControlMover()
        {
            ResizingMargin = 20;
            MinSize = 10;
            ChangeCursor = false;
            AllowMove = true;
            AllowResize = true;
            BringToFront = true;
        }

        public static void Add(Control ctrl)
        {
            ctrl.MouseDown += ctrl_MouseDown;
            ctrl.MouseUp += ctrl_MouseUp;
            ctrl.MouseMove += ctrl_MouseMove;
        }

        private static void ctrl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (sender is Control)
            {
                var ctrl = (sender as Control);
                ctrl.Cursor = _oldCursor;
            }
        }

        public static void Remove(Control ctrl)
        {
            ctrl.MouseDown -= ctrl_MouseDown;
            ctrl.MouseUp -= ctrl_MouseUp;
            ctrl.MouseMove -= ctrl_MouseMove;
        }

        static void ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;

            if (ctrl != null && ChangeCursor)
            {
                if ( ((e.X >= ctrl.Width - ResizingMargin) && (e.Y >= ctrl.Height - ResizingMargin) && AllowResize))
                    ctrl.Cursor = Cursors.SizeNWSE;
                else
                if (AllowMove)
                    ctrl.Cursor = Cursors.SizeAll;
                else
                    ctrl.Cursor = Cursors.Default;
            }

            if (e.Button != MouseButtons.Left)
                return;

            if (ctrl != null)
            {
                var l = ctrl.PointToScreen(e.Location);
                var dx = l.X - _startMouse.X;
                var dy = l.Y - _startMouse.Y;

                if (Math.Max(Math.Abs(dx), Math.Abs(dy)) > 1)
                {
                    if (_resizing)
                    {
                        if (AllowResize)
                        {
                            ctrl.Size = new Size(Math.Max(MinSize, _startSize.Width + dx), Math.Max(MinSize, _startSize.Height + dy));
                            ctrl.Cursor = Cursors.SizeNWSE;
                            if (BringToFront && !(sender is PictureBox)) ctrl.BringToFront();
                        }
                    }
                    else
                    {
                        if (AllowMove)
                        {
                            Point newLoc = _startLocation + new Size(dx, dy);
                            if (newLoc.X < 0) newLoc = new Point(0, newLoc.Y);
                            if (newLoc.Y < 0) newLoc = new Point(newLoc.X, 0);
                            ctrl.Location = newLoc;
                            ctrl.Cursor = Cursors.SizeAll;
                            if (BringToFront && !(sender is PictureBox)) ctrl.BringToFront();
                        }
                    }
                }
            }
        }

        static void ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;



            if (sender is Control)
            {
                var ctrl = (Control) sender;
                _resizing = (e.X >= ctrl.Width - ResizingMargin) && (e.Y >= ctrl.Height - ResizingMargin) &&
                            AllowResize;
                _startSize = ctrl.Size;
                _startMouse = ctrl.PointToScreen(e.Location);
                _startLocation = ctrl.Location;
                _oldCursor = ctrl.Cursor;
            }
        }
    }
}
