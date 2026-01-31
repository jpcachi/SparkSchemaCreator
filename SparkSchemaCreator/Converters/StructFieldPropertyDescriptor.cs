using SparkSchemaCreator.Types;
using SparkSchemaCreator.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    internal class StructFieldPropertyDescriptor : PropertyDescriptor
    {
        public StructFieldPropertyDescriptor() : base("Name", [new CategoryAttribute("Field Info")]) { }

        public override Type ComponentType => typeof(StructField);

        public override bool IsReadOnly => false;

        public override Type PropertyType => typeof(string);

        public override bool CanResetValue(object component) => true;

        public override object? GetValue(object? component)
        {
            if (component is StructField structField)
                return structField.Name;

            return null;
        }

        public override void ResetValue(object component)
        {
            if (component is StructField structField)
                structField.Name = "New_Field";
        }

        public override void SetValue(object? component, object? value)
        {
            if (component is StructField structField && value is string valstr)
            {
                if (SchemaSettings.Instance.CheckIllegalCharactersInNames && StructFieldUtils.INVALID_CHARS.Intersect(valstr).Any())
                    return;

                structField.Name = valstr;
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
    }
}
