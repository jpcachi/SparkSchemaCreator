using SparkSchemaCreator.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    internal class MetadataPropertyDescriptor : PropertyDescriptor
    {
        private readonly Metadata _metadata;
        private readonly string _key;

        internal MetadataPropertyDescriptor(Metadata metadata, string key): base(key, null)
        {
            _metadata = metadata;
            _key = key;
        }
        
        public override Type ComponentType => typeof(Metadata);

        public override bool IsReadOnly => false;

        public override Type PropertyType => _metadata.Map[_key]?.GetType() ?? typeof(string);

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override object? GetValue(object? component)
        {
            _metadata.Map.TryGetValue(_key, out object? resul);
            return resul;
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object? component, object? value)
        {
            _metadata.Map[_key] = value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
