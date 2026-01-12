using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SparkSchemaCreator.Converters
{
    internal class StructFieldListEditor : CollectionEditor
    {
        public StructFieldListEditor() : base(typeof(StructField))
        {
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof(StructField);
        }

        protected override object CreateInstance(Type itemType)
        {
            object instance = base.CreateInstance(itemType);

            if (instance is StructField field && Context?.Instance is StructType parent)
                field.StructParent = parent;

            return instance;
        }

        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm form = base.CreateCollectionForm();

            PropertyInfo? pi = form.GetType().GetProperty("CollectionEditable", BindingFlags.NonPublic | BindingFlags.Instance);

            pi?.SetValue(form, true, null);
            return form;
        }
    }
}
