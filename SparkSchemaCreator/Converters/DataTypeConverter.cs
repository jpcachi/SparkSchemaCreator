using SparkSchemaCreator.Types;
using System.ComponentModel;
using System.Globalization;

namespace SparkSchemaCreator.Converters
{
    internal class DataTypeConverter : ExpandableObjectConverter
    {
        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is DataType dataType)
                return dataType.TypeNameApi;
            

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext? context)
        {
            object? propertyValue = context?.PropertyDescriptor?.GetValue(context?.Instance);

            return propertyValue is ComplexType || propertyValue is DecimalType || propertyValue is CharBaseType ||
                propertyValue is IntervalType;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext? context, object value, Attribute[]? attributes)
        {
            if (context?.Instance is StructField structField && structField.DataType is DecimalType)
                return new PropertyDescriptorCollection([
                    new DecimalTypePrecissionScalePropertyDescriptor(true),
                    new DecimalTypePrecissionScalePropertyDescriptor(false)
                    ]);

            if (context?.Instance is StructField structField2 && structField2.DataType is IntervalType)
                return new PropertyDescriptorCollection([
                    new IntervalTypePropertyDescriptor(),
                    new IntervalTypeRangePropertyDescriptor(true),
                    new IntervalTypeRangePropertyDescriptor(false)
                    ]).Sort(["Interval", "StartField", "EndField"]);

            return base.GetProperties(context, value, attributes).Sort(["KeyType", "ValueType", "ValueContainsNull", "ElementType", "ContainsNull", "StartField", "EndField"]);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext? context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext? context)
        {
            return new StandardValuesCollection(DataTypes.All);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if(value is string str)
            {
                if (str == "StructType")
                    return new StructType();

                if (str == "ArrayType")
                    return new ArrayType(new StringType());

                if (str == "MapType")
                    return new MapType(new StringType(), new StringType());

                try
                {
                    return DataType.FromApiString(str);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
