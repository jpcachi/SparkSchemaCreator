using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Controls
{
    internal class DrawablePanel : Panel
    {
        public DrawablePanel() : base()
        {
            base.DoubleBuffered = true;

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UpdateStyles();
        }
    }
}
