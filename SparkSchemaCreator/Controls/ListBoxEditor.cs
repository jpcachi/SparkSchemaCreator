using SparkSchemaCreator.Types;
using System.Windows.Forms.Design;

namespace SparkSchemaCreator.Controls
{
    internal class ListBoxEditor : ListBox
    {
        private readonly DataType _defaultSelection;

        protected DataType m_oSelection;
        protected IWindowsFormsEditorService m_iwsService;

        public ListBoxEditor(DataType defaultSelection, DataType oSelection, IWindowsFormsEditorService iwsService)
        {
            _defaultSelection = defaultSelection;

            m_oSelection = oSelection;
            SelectionMode = SelectionMode.One;
            BorderStyle = BorderStyle.None;
            m_iwsService = iwsService;

            Items.Add(defaultSelection);
            FormattingEnabled = true;
        }

        public object Selection => m_oSelection;

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if(SelectedItem is DataType dataType)
            {
                m_oSelection = dataType;
                m_oSelection.DefaultType = _defaultSelection;

            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            m_iwsService?.CloseDropDown();
        }

        protected override void OnFormat(ListControlConvertEventArgs e)
        {
            base.OnFormat(e);
            if (e.ListItem == _defaultSelection)
                e.Value = $"<Restablecer>";
            else if (e.ListItem is DataType dataType)
                e.Value = dataType.TypeNameApi;
        }
    }
}
