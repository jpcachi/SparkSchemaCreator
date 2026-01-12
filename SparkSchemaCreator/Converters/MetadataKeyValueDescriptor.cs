using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    internal class MetadataKeyValueDescriptor(MetadataKeyValuePair keyValue, bool key) : PropertyDescriptor(key ? "Key" : "Value", null)
    {
        public override Type ComponentType => typeof(MetadataKeyValuePair);

        public override bool IsReadOnly => false;

        public override Type PropertyType => key ? typeof(string) : keyValue.Type;

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override object? GetValue(object? component)
        {
            return key ? keyValue.Key : keyValue.Value;
        }

        public override void ResetValue(object component)
        {
            
        }

        public override void SetValue(object? component, object? value)
        {
            if(key)
            {
                if (value is string svalue && !keyValue.Keys.Contains(svalue))
                {
                    keyValue.Keys.Remove(keyValue.Key);
                    keyValue.Key = svalue;
                    keyValue.Keys.Add(svalue);
                }
            }
            else
            {
                keyValue.Value = value;
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
