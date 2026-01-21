using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SparkSchemaCreator.Controls.FastColoredTextBox
{
    public class VisualMarker(Rectangle rectangle)
    {
        public readonly Rectangle rectangle = rectangle;

        public virtual void Draw(Graphics gr, Pen pen)
        {
        }

        public virtual Cursor Cursor
        {
            get { return Cursors.Hand; }
        }
    }

    public class CollapseFoldingMarker(int iLine, Rectangle rectangle) : VisualMarker(rectangle)
    {
        public readonly int iLine = iLine;

        public void Draw(Graphics gr, Pen pen, Brush backgroundBrush, Pen forePen)
        {
            //draw minus
            gr.FillRectangle(backgroundBrush, rectangle);
            gr.DrawRectangle(pen, rectangle);
            gr.DrawLine(forePen, rectangle.Left + 2, rectangle.Top + rectangle.Height / 2, rectangle.Right - 2, rectangle.Top + rectangle.Height / 2);
        }
    }

    public class ExpandFoldingMarker(int iLine, Rectangle rectangle) : VisualMarker(rectangle)
    {
        public readonly int iLine = iLine;

        public void Draw(Graphics gr, Pen pen,  Brush backgroundBrush, Pen forePen)
        {
            //draw plus
            gr.FillRectangle(backgroundBrush, rectangle);
            gr.DrawRectangle(pen, rectangle);
            gr.DrawLine(forePen, rectangle.Left + 2, rectangle.Top + rectangle.Height / 2, rectangle.Right - 2, rectangle.Top + rectangle.Height / 2);
            gr.DrawLine(forePen, rectangle.Left + rectangle.Width / 2, rectangle.Top + 2, rectangle.Left + rectangle.Width / 2, rectangle.Bottom - 2);
        }
    }

    public class FoldedAreaMarker(int iLine, Rectangle rectangle) : VisualMarker(rectangle)
    {
        public readonly int iLine = iLine;

        public override void Draw(Graphics gr, Pen pen)
        {
            gr.DrawRectangle(pen, rectangle);
        }
    }

    public class StyleVisualMarker(Rectangle rectangle, Style style) : VisualMarker(rectangle)
    {
        public Style Style { get; private set; } = style;
    }

    public class VisualMarkerEventArgs(Style style, StyleVisualMarker marker, MouseEventArgs args) : MouseEventArgs(args.Button, args.Clicks, args.X, args.Y, args.Delta)
    {
        public Style Style { get; private set; } = style;
        public StyleVisualMarker Marker { get; private set; } = marker;
    }
}
