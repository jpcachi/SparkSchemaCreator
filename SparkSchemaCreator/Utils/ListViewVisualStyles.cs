using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SparkSchemaCreator.Utils
{
    /// <summary>
    /// Front-end. Dibuja las tablas, cabeceras y colores de los diferentes controles de tipo ListView
    /// </summary>
    static class ListViewVisualStyles
    {

        public const int LEFT_MARGIN = 2;
        public const int BOTTOM_MARGIN = 1;
        public const int MARGEN_EXTERIOR_IZQUIERDO_ARRASTRAR = -50;
        public const int MARGEN_EXTERIOR_BAJO_ARRASTRAR = -12;
        public const int MARGEN_EXTERIOR_BAJO_COMENZAR_ARRASTRAR = 0;
        public const int MARGEN_IZQUIERDO_CABECERA = 3;
        public const int MARGEN_ABAJO_CABECERA = 5;
        public const int MARGEN_TEXTO_RESALTADO_IZQUIERDO = 3;
        public const int MARGEN_TEXTO_RESALTADO_IZQUIERDO_AL_FINAL = 10;

        public static List<ListView> Listas { get; } = [];

       

        public static Color ColorCabecera { get; set; } = Color.FromArgb(216, 222, 228);

        public static Color ColorBackgroundItem { get; set; } = SystemColors.ButtonHighlight;

        public static Color ColorBackgroundAlternateItem { get; set; } = Color.FromArgb(246, 248, 250);
        public static Color ColorBackgroundSelectedItem { get; set; } = Color.FromArgb(84, 180, 210);

        public static Color ColorTextoCabecera { get; set; } = Color.Black;

        public static Color ColorTextoItem { get; set; } = Color.Black;

        public static Font FuenteCabecera { get; set; } = SystemFonts.DefaultFont;

        public static Font FuenteItem { get; set; } = SystemFonts.DefaultFont;


        public static void DibujarSubItemListView(object sender, DrawListViewSubItemEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Color backgroundColor = (e.Item?.Selected ?? false) ? ColorBackgroundSelectedItem : e.ItemIndex % 2 != 0 ? ColorBackgroundItem : ColorBackgroundAlternateItem;
            Rectangle bounds = new(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - BOTTOM_MARGIN);


            Color foregroundColor = ColorTextoItem;

            using (SolidBrush sb = new(backgroundColor))
                e.Graphics.FillRectangle(sb, bounds);

            string[] textSplitted = e.SubItem?.Text.Split('<', '>') ?? [];

            int position = 0;
            for (int i = 0; i < textSplitted.Length; i++)
            {
                Font fuente = i % 2 == 0 ? FuenteItem : new Font(FuenteItem, FontStyle.Bold);

                TextRenderer.DrawText(e.Graphics, textSplitted[i], fuente, new Rectangle(new Point(position + e.Bounds.Location.X + LEFT_MARGIN, e.Bounds.Location.Y + BOTTOM_MARGIN), new Size(e.Bounds.Width - LEFT_MARGIN, e.Bounds.Height - BOTTOM_MARGIN)), foregroundColor, TextFormatFlags.ExpandTabs);
                position += TextRenderer.MeasureText(textSplitted[i], fuente).Width;
            }
        }

        public static void DibujarSubItemListView(DrawListViewSubItemEventArgs e, Color backColor, Color foreColor)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle bounds = new(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - BOTTOM_MARGIN);

            using (SolidBrush sb = new(backColor))
                e.Graphics.FillRectangle(sb, bounds);

            TextRenderer.DrawText(e.Graphics, e.SubItem?.Text, FuenteItem, new Rectangle(new Point(e.Bounds.Location.X + LEFT_MARGIN, e.Bounds.Location.Y + BOTTOM_MARGIN), new Size(e.Bounds.Width - LEFT_MARGIN, e.Bounds.Height - BOTTOM_MARGIN)), foreColor, /*backColor, */TextFormatFlags.ExpandTabs);

        }

        /// <summary>
        /// Método encargado de la renderización de los titulos de cabecera de un listView en modo OwnerDraw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DibujarCabeceras(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (Application.VisualStyleState == VisualStyleState.NonClientAreaEnabled) e.DrawDefault = true;
            else
            {
                using (SolidBrush sb = new(ColorCabecera))
                    e.Graphics.FillRectangle(sb, e.Bounds);

                Color colorTextoCabecera = ColorTextoCabecera;
                TextRenderer.DrawText(e.Graphics, e.Header?.Text, FuenteCabecera, new Rectangle(new Point(e.Bounds.Location.X + MARGEN_IZQUIERDO_CABECERA, e.Bounds.Location.Y + MARGEN_ABAJO_CABECERA), new Size(e.Bounds.Width - MARGEN_IZQUIERDO_CABECERA, e.Bounds.Height - MARGEN_ABAJO_CABECERA)), colorTextoCabecera, TextFormatFlags.ExpandTabs);
            }
        }

        public static void CambiarColorFondo()
        {
            foreach (ListView vista in Listas)
                vista.BackColor = ColorBackgroundItem;
        }
    }
}
