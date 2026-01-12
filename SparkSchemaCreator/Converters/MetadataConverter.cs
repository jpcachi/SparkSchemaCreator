using SparkSchemaCreator.Types;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    internal class MetadataConverter : ExpandableObjectConverter
    {

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is Metadata)
                return "(Metadata)";

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext? context, object value, Attribute[]? attributes)
        {
            if(value is Metadata metadata)
            {
                ArrayList properties = [];
                foreach (KeyValuePair<string, object?> e in metadata.Map)
                {
                    properties.Add(new MetadataPropertyDescriptor(metadata, e.Key));
                }

                PropertyDescriptor[] props =
                    (PropertyDescriptor[])properties.ToArray(typeof(MetadataPropertyDescriptor));

                return new PropertyDescriptorCollection(props);
            }

            return base.GetProperties(context, value, attributes);
        }

        public override object? CreateInstance(ITypeDescriptorContext? context, IDictionary propertyValues)
        {

            if (propertyValues is Dictionary<string, object?> dict)
                return new Metadata(dict);

            return base.CreateInstance(context, propertyValues);
        }
    }
}
