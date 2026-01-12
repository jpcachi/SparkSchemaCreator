using SparkSchemaCreator.Controls.FastColoredTextBox;
using SparkSchemaCreator.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace SparkSchemaCreator.Controls
{
    public partial class TabTextControl : UserControl
    {

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool CheckBoxesVisible
        {
            get
            {
                return panel2.Visible;
            }
            set
            {
                panel2.Visible = value;
            }
        }

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
        public string[] TabTexts { get; set; } = [];

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Language[] TabLanguages { get; set; } = [];


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

                _tabs = value;
                TabTexts = new string[_tabs?.Length ?? 0];
                TabLanguages = new Language[_tabs?.Length ?? 0];

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

                        buttonsPanel.Controls.Add(newTab);


                        if (first)
                        {
                            SelectedTab = 0;
                            first = false;
                        }
                    }
                }
            }
        }

        public event EventHandler PrettyJsonCheckboxChanged
        {
            add { checkBox1.CheckedChanged += value; }
            remove { checkBox1.CheckedChanged -= value; }
        }

        public event EventHandler EscapeQuotesCheckboxChanged
        {
            add { checkBox2.CheckedChanged += value; }
            remove { checkBox2.CheckedChanged -= value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool PrettyJsonCheckboxEnabled
        {
            get
            {
                return checkBox1.Enabled;
            }
            set
            {
                checkBox1.Enabled = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool EscapeQuotesCheckboxEnabled
        {
            get
            {
                return checkBox2.Enabled;
            }
            set
            {
                checkBox2.Enabled = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool PrettyJsonChecked => checkBox1.Checked;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool EscapeQuotesChecked => checkBox2.Checked;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event EventHandler? SelectedTabChanged;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event EventHandler<TextChangedEventArgs> EditorTextChanged
        {
            add { fastColoredTextBox1.TextChanged += value; }
            remove { fastColoredTextBox1.TextChanged -= value; }
        }

        public void SetErrorToolTip(ToolTip toolTip1, string errorText)
        {
            toolTip1.SetToolTip(checkBox1, errorText);
        }

        public TabTextControl()
        {
            InitializeComponent();
        }

        private void NewTab_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is ButtonWithNoCue tab)
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
        public int SelectedTab
        {
            get
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

        protected virtual void OnSelectedTabChanged(EventArgs e)
        {
            contentsPanel.Invalidate();
            SelectedTabChanged?.Invoke(this, e);
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
            if (SelectedTab != -1)
            {
                TabTexts[SelectedTab] = fastColoredTextBox1.Text;
                TabLanguages[SelectedTab] = fastColoredTextBox1.Language;
            }

            if (sender is ButtonWithNoCue tabButton)
            {
                SelectedTab = ButtonsAsTabControl(tabButton, buttonsPanel.Controls.Cast<ButtonWithNoCue>());
                RefreshEditorTextAndLanguage();
            }
        }

        public void RefreshEditorTextAndLanguage()
        {
            if (SelectedTab != -1)
            {
                fastColoredTextBox1.Language = TabLanguages[SelectedTab];
                fastColoredTextBox1.Text = TabTexts[SelectedTab];
            }
        }

        private void ContentsPanel_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine(e.ClipRectangle);

            using Pen p = new(SelectedTabBorderColor);
            Point location = contentsPanel.ClientRectangle.Location;
            Point location2 = contentsPanel.ClientRectangle.Location;

            location.Offset(0, -1);
            location2.Offset(8, 8);

            Rectangle rectangle = new(location, contentsPanel.ClientRectangle.Size - new Size(1, 0));
            e.Graphics.DrawRectangle(p, rectangle);


            e.Graphics.DrawLine(p, 0, 0, 75 * selectedTab, 0);
            e.Graphics.DrawLine(p, 75 * (selectedTab + 1) - 1, 0, contentsPanel.ClientRectangle.Width, 0);

            Rectangle rectangle2 = new(location2, contentsPanel.ClientRectangle.Size - new Size(17, 48));
            e.Graphics.DrawRectangle(p, rectangle2);
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(fastColoredTextBox1.Text);
            if (!copiedToClipboardLabel.Visible)
            {
                timer1.Enabled = true;
                timer1.Start();
                copiedToClipboardLabel.Visible = true;
                copiedToClipboardLabel.Focus();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            copiedToClipboardLabel.Visible = false;
        }

        private void fastColoredTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            copyToClipboardButton.Enabled = !string.IsNullOrEmpty(fastColoredTextBox1.Text);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string EditorText
        {
            get
            {
                return fastColoredTextBox1.Text;
            }
            set
            {
                fastColoredTextBox1.Text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Language EditorLanguage
        {
            get
            {
                return fastColoredTextBox1.Language;
            }
            set
            {
                fastColoredTextBox1.Language = value;
            }
        }
    }
}
