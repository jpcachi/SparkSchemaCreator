using System.ComponentModel;

namespace SparkSchemaCreator.Converters
{
    internal class StructFieldConverter : ExpandableObjectConverter
    {
        public override bool GetPropertiesSupported(ITypeDescriptorContext? context)
        {
            return base.GetPropertiesSupported(context);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext? context, object value, Attribute[]? attributes)
        {
            PropertyDescriptorCollection result = base.GetProperties(context, value, attributes).Sort(["Name", "DataType", "IsNullable", "Metadata"]);
            result.RemoveAt(0);
            result.Insert(0, new StructFieldPropertyDescriptor());
            
            return result;
        }
    }
}
