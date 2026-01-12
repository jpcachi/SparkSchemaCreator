using SparkSchemaCreator.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SparkSchemaCreator.Converters
{

    [DisplayName("Key-Value Simple Item")]
    internal class MetadataKeyValuePair(string key, object? value, Type type, HashSet<string> keys) : ICustomTypeDescriptor
    {
        public string Key { get; set; } = key;
        public object? Value { get; set; } = Convert.ChangeType(value, type);
        public Type Type { get; set; } = type;
        internal HashSet<string> Keys { get; } = keys;

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string? GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string? GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter? GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor? GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor? GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object? GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[]? attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            var properties = new List<PropertyDescriptor>();

            var keyDescriptor = new MetadataKeyValueDescriptor(this, true);
            properties.Add(keyDescriptor);

            var valueDescriptor = new MetadataKeyValueDescriptor(this, false);
            properties.Add(valueDescriptor);

            return new PropertyDescriptorCollection([.. properties]);
            
        }

        public PropertyDescriptorCollection GetProperties(Attribute[]? attributes)
        {
            return GetProperties();
        }

        public object? GetPropertyOwner(PropertyDescriptor? pd)
        {
            return this;
        }
    }
}
