using SparkSchemaCreator.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    internal class IntervalTypeRangeFieldsConverter : TypeConverter
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
            if (context?.Instance is YearMonthIntervalType ymi)
            {
                if (context?.PropertyDescriptor?.Name == "StartField")
                    return new StandardValuesCollection(Enumerable.Range(0, 2).ToArray());

                if (context?.PropertyDescriptor?.Name == "EndField")
                    return new StandardValuesCollection(Enumerable.Range(ymi.StartField, 2 - ymi.StartField).ToArray());
            }
            else if(context?.Instance is DayTimeIntervalType dti)
            {
                if (context?.PropertyDescriptor?.Name == "StartField")
                    return new StandardValuesCollection(Enumerable.Range(0, 4).ToArray());

                if (context?.PropertyDescriptor?.Name == "EndField")
                    return new StandardValuesCollection(Enumerable.Range(dti.StartField, 4 - dti.StartField).ToArray());
            }
            return base.GetStandardValues(context);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => true;

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string valStr)
                return byte.Parse(valStr);

            return base.ConvertFrom(context, culture, value);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType == typeof(string))
                return value?.ToString();

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
