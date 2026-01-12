using SparkSchemaCreator.Views;
using System.ComponentModel;
using System.Data;

namespace SparkSchemaCreator.Controls
{
    [Designer(typeof(MyUserControlDesigner))]
    public partial class PanelWithHeader : UserControl
    {
        

        public PanelWithHeader()
        {
            InitializeComponent();

            TypeDescriptor.AddAttributes(contentsPanel, 
                new DesignerAttribute(typeof(PanelWithHeaderDesigner)));

            TypeDescriptor.AddAttributes(titlePanel,
                new DesignerAttribute(typeof(PanelWithHeaderDesigner)));
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TitleBackColor
        {
            get { return titlePanel.BackColor; }
            set { titlePanel.BackColor = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TitleForeColor
        {
            get { return titlePanel.ForeColor; }
            set { titlePanel.ForeColor = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ContentPanelBackColor
        {
            get { return contentsPanel.BackColor; }
            set { contentsPanel.BackColor = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ContentPanelForeColor
        {
            get { return contentsPanel.ForeColor; }
            set { contentsPanel.ForeColor = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool MaximizeBox
        {
            get { return button1.Visible; }
            set { button1.Visible = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Maximize? maximizeForm = null;

        public Size ContentPanelSize => ContentsPanel.Size;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TitleDetailsColor { get; set; } = SystemColors.ControlDarkDark;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor { get; set; } = Color.Gainsboro;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ContentBorderColor { get; set; } = Color.LightGray;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color WindowBackColor { get; set; } = SystemColors.Window;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ContentsPanel
        {
            get { return contentsPanel; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Panel TitlePanel
        {
            get { return titlePanel; }
        }

        private void MyUserControl_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectangle = new(DisplayRectangle.Location, new Size(DisplayRectangle.Width - 1, DisplayRectangle.Height - 1));
            using Pen p = new(BorderColor);
            e.Graphics.DrawRectangle(p, rectangle);
        }

        private void ContentsPanel_Paint(object? sender, PaintEventArgs e)
        {
            Rectangle rectangle = new(contentsPanel.ClientRectangle.Location, new Size(contentsPanel.ClientRectangle.Width - 1, contentsPanel.ClientRectangle.Height - 1));
            using Pen p = new(ContentBorderColor);
            e.Graphics.DrawRectangle(p, rectangle);
        }

        private void TitlePanel_Paint(object sender, PaintEventArgs e)
        {
            using SolidBrush b = new(TitleDetailsColor);
            for (int i = titleLabel.Size.Width + 1; i < titlePanel.Width - 8 - (button1.Visible ? button1.Width : 0); i += 4)
            {
                e.Graphics.FillRectangle(b, new Rectangle(i, 8, 1, 1));
                e.Graphics.FillRectangle(b, new Rectangle(i + 2, 10, 1, 1));
                e.Graphics.FillRectangle(b, new Rectangle(i, 12, 1, 1));
            }
        }

        private void PanelWithHeader_Resize(object sender, EventArgs e)
        {
            titlePanel.Refresh();
            contentsPanel.Refresh();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            maximizeForm = new Maximize()
            {
                Text = Title,
                ClientSize = Size + new Size(0, 12),
                BackColor = WindowBackColor

            };

            maximizeForm.Shown += Form_Load;
            maximizeForm.FormClosed += Form_FormClosed;
            maximizeForm.Resize += MaximizeForm_Resize;
            maximizeForm.Show(this);
        }

        private void MaximizeForm_Resize(object? sender, EventArgs e)
        {
            if (sender is Maximize maximize && maximize.Controls.Count > 0)
            {
                IEnumerable<Control> tabPanelControls = maximize.Controls.Cast<Control>().Where(c => c.Tag is string tag && tag == "TabPanel");

                foreach (Control tabPanelControl in tabPanelControls)
                    tabPanelControl.Invalidate();
            }
        }

        private void Form_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (sender is Maximize maximize)
            {
                Visible = true;
                Enabled = true;
                ContentsPanel.Controls.AddRange([.. maximize.Controls.Cast<Control>()]);
                ContentsPanel.Location = new Point(1, 0);
                ContentsPanel.Size = new Size(ContentPanelSize.Width - 2, ContentPanelSize.Height - 1);
            }
        }

        private void Form_Load(object? sender, EventArgs e)
        {
            if(sender is Maximize maximize)
            {
                Visible = false;
                Enabled = false;
                maximize.Controls.AddRange([.. ContentsPanel.Controls.Cast<Control>()]);
                maximize.Location -= new Size(1, 0);
                maximize.Width -= 2;
                maximize.Height -= 32;
            }
        }

        private void Button1_Paint(object sender, PaintEventArgs e)
        {

            Point mousePoint = button1.PointToClient(MousePosition);

            Color backColor = button1.DisplayRectangle.Contains(mousePoint) ? Color.FromArgb(246, 248, 250) : Color.FromArgb(216, 222, 228);

            using (SolidBrush b = new(backColor))
                e.Graphics.FillRectangle(b, e.ClipRectangle);

            using (Pen p = new(Color.FromArgb(81, 90, 103)))
            {
                Rectangle rectangle1 = new(3, 8, 8, 7);
                Rectangle rectangle2 = new(7, 4, 8, 7);

                e.Graphics.DrawRectangle(p, rectangle1);
                e.Graphics.DrawLine(p, 3, 9, 11, 9);

                e.Graphics.DrawRectangle(p, rectangle2);
                e.Graphics.DrawLine(p, 7, 5, 15, 5);
            }

            using (SolidBrush b = new(backColor))
                e.Graphics.FillRectangle(b, new Rectangle(4, 10, 7, 5));
        }
    }
}
