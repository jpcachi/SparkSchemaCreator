using System.ComponentModel;
using System.Data;

namespace SparkSchemaCreator.Controls
{
    public partial class CustomTabControl : UserControl
    {

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectedTabBackColor { get; set; }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectedTabForeColor { get; set; }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TabBackColor { get; set; }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TabForeColor { get; set; }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectedTabMouseOverBackColor { get; set; }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectedTabMouseDownBackColor { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectedTabBorderColor { get; set; }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TabMouseOverBackColor { get; set; }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TabMouseDownBackColor { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Dictionary<string, Panel> TabPanels { get; } = [];

        private string[]? _tabs;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string[]? Tabs
        {
            get
            {
                return _tabs;
            }
            set
            {
                buttonsPanel.Controls.Clear();
                contentPanel.Controls.Clear();
                TabPanels.Clear();

                _tabs = value;

                if (_tabs != null)
                {
                    bool first = true;
                    foreach (string tab in _tabs)
                    {

                        ButtonWithNoCue newTab = new()
                        {
                            AutoSize = true,
                            BackColor = first ? SelectedTabBackColor : TabBackColor,
                            ForeColor = first ? SelectedTabForeColor : TabForeColor,
                            FlatStyle = FlatStyle.Flat,
                            Margin = new Padding(0, 0, 0, 0),
                            Name = tab + "Button",
                            Size = new Size(75, 23),
                            Text = tab,
                            UseVisualStyleBackColor = false

                        };

                        newTab.FlatAppearance.BorderSize = 0;
                        newTab.FlatAppearance.MouseDownBackColor = TabMouseDownBackColor;
                        newTab.FlatAppearance.MouseOverBackColor = TabMouseOverBackColor;
                        newTab.Click += Tab_Click;
                        newTab.Paint += NewTab_Paint;

                        Panel tabContentPanel = new()
                        {
                            Dock = DockStyle.Fill,
                            BackColor = Color.White,
                            Name = tab + "Content",
                            Padding = new Padding(1, 1, 1, 1),
                            Visible = first
                        };

                        tabContentPanel.Paint += TabContentPanel_Paint;

                        buttonsPanel.Controls.Add(newTab);
                        contentPanel.Controls.Add(tabContentPanel);

                        TabPanels.Add(tab, tabContentPanel);


                        if (first)
                        {
                            SelectedTab = 0;
                            first = false;
                        }
                    }
                }
            }
        }

        private void TabContentPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel tabContent && tabContent == contentPanel.Controls[SelectedTab])
            {
                using Pen p = new(SelectedTabBorderColor);
                Point location = tabContent.ClientRectangle.Location;
                location.Offset(0, -1);

                Rectangle rectangle = new(location, tabContent.ClientRectangle.Size - new Size(1, 0));
                e.Graphics.DrawRectangle(p, rectangle);


                e.Graphics.DrawLine(p, 0, 0, 75 * selectedTab, 0);
                e.Graphics.DrawLine(p, 75 * (selectedTab + 1) - 1, 0, tabContent.ClientRectangle.Width, 0);
            }
        }

        private void NewTab_Paint(object? sender, PaintEventArgs e)
        {
            if(sender is ButtonWithNoCue tab)
            {
                if (tab == buttonsPanel.Controls[SelectedTab])
                    using (Pen p = new(SelectedTabBorderColor))
                    {
                        Rectangle rectangle = new(tab.DisplayRectangle.Location, tab.DisplayRectangle.Size - new Size(1, 0));
                        e.Graphics.DrawRectangle(p, rectangle);

                    }
                else
                {
                    Color penColor = (BackColor == Color.Transparent ? Parent?.BackColor : BackColor) ?? BackColor;
                    using Pen p = new(penColor);
                    e.Graphics.DrawLine(p, tab.DisplayRectangle.X, 0, tab.DisplayRectangle.Right, 0);
                    e.Graphics.DrawLine(p, tab.DisplayRectangle.X, 1, tab.DisplayRectangle.Right, 1);

                    if (tab == buttonsPanel.Controls[buttonsPanel.Controls.Count - 1])
                    {
                        e.Graphics.DrawLine(p, tab.DisplayRectangle.Right - 1, 0, tab.DisplayRectangle.Right - 1, tab.DisplayRectangle.Bottom);
                        e.Graphics.DrawLine(p, tab.DisplayRectangle.Right - 2, 0, tab.DisplayRectangle.Right - 2, tab.DisplayRectangle.Bottom);
                    }
                }

            }
        }

        private int selectedTab;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int SelectedTab { get
            {
                return selectedTab;
            }
            private set
            {
                if (selectedTab != value)
                {
                    selectedTab = value;
                    OnSelectedTabChanged(EventArgs.Empty);
                }
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event EventHandler? SelectedTabChanged;

        protected virtual void OnSelectedTabChanged(EventArgs e)
        {
            SelectedTabChanged?.Invoke(this, e);
        }


        public CustomTabControl()
        {
            InitializeComponent();
        }

        private int ButtonsAsTabControl(ButtonWithNoCue sender, IEnumerable<ButtonWithNoCue> allButtons)
        {
            int loop = 0;
            int tabSelected = -1;

            foreach (ButtonWithNoCue button in allButtons)
            {
                if (sender == button)
                    tabSelected = loop;

                button.BackColor = TabBackColor;
                button.ForeColor = TabForeColor;
                button.FlatAppearance.MouseOverBackColor = TabMouseOverBackColor;
                button.FlatAppearance.MouseDownBackColor = TabMouseDownBackColor;

                if (tabSelected == -1)
                    loop++;
            }

            sender.BackColor = SelectedTabBackColor;
            sender.ForeColor = SelectedTabForeColor;
            sender.FlatAppearance.MouseOverBackColor = SelectedTabMouseOverBackColor;
            sender.FlatAppearance.MouseDownBackColor = SelectedTabMouseDownBackColor;

            return tabSelected;
        }

        private void Tab_Click(object? sender, EventArgs? e)
        {
            if (sender is ButtonWithNoCue tabButton)
            {
                SelectedTab = ButtonsAsTabControl(tabButton, buttonsPanel.Controls.Cast<ButtonWithNoCue>());

                foreach (Control tabContent in contentPanel.Controls)
                {
                    tabContent.Visible = false;
                }

                if (SelectedTab != -1)
                    contentPanel.Controls[SelectedTab].Visible = true;
            }
        }
    }
}
