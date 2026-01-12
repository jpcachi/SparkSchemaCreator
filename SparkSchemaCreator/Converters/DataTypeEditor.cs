using SparkSchemaCreator.Controls;
using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms.Design;
using static System.ComponentModel.TypeConverter;

namespace SparkSchemaCreator.Converters
{
    internal class DataTypeEditor : ObjectSelectorEditor
    {
        public override object? EditValue(ITypeDescriptorContext? context, IServiceProvider provider, object? value)
        {
            IWindowsFormsEditorService? edSvc = (IWindowsFormsEditorService?)provider.GetService(typeof(IWindowsFormsEditorService));

            DataType dataType = value as DataType ?? DataType.FromString("void");

            if (edSvc != null)
            {
                ListBoxEditor dropdown = new(dataType.DefaultType ?? dataType, dataType, edSvc);

                dropdown.Items.AddRange(DataType.DataTypes);

                edSvc.DropDownControl(dropdown);
                return dropdown.Selection;
            }

            return base.EditValue(context, provider, value);
        }
    }
}
