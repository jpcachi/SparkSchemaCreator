using SparkSchemaCreator.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    internal class DecimalTypePrecissionScaleConverter : TypeConverter
    {

        public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext? context)
        {
            return true;
        }

        public override StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? context)
        {
            if(context?.Instance is DecimalType decimalType)
            {
                if(context?.PropertyDescriptor?.Name == "Precission")
                    return new StandardValuesCollection(Enumerable.Range(0, 39).ToArray());

                if(context?.PropertyDescriptor?.Name == "Scale")
                    return new StandardValuesCollection(Enumerable.Range(0, decimalType.Precission + 1).ToArray());
            }
                
            return base.GetStandardValues(context);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => true;

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string valStr)
                return int.Parse(valStr);

            return base.ConvertFrom(context, culture, value);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if(destinationType == typeof(string))
                return value?.ToString();

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
