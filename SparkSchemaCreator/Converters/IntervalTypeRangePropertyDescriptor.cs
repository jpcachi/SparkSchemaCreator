using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    internal class IntervalTypeRangePropertyDescriptor(bool startField) : PropertyDescriptor(startField ? "StartField" : "EndField", null)
    {

        public override TypeConverter Converter => new IntervalTypeRangeFieldsConverter();

        public override Type ComponentType => typeof(IntervalType);

        public override bool IsReadOnly => false;

        public override Type PropertyType => typeof(byte);

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object? GetValue(object? component)
        {

            if(component is IntervalType interval)
                return startField ? interval.StartField : interval.EndField;

            return null;
        }

        public override void ResetValue(object component)
        {
            if (component is IntervalType interval)
            {
                if (startField)
                    interval.StartField = 0;
                else
                    interval.EndField = 0;
            }
        }

        public override void SetValue(object? component, object? value)
        {
            if (value is byte number && component is IntervalType interval)
            {

                if (startField)
                {
                    if (number > interval.EndField)
                        interval.EndField = number;

                    interval.StartField = number;
                }
                else
                    interval.EndField = number >= interval.StartField ? number : interval.StartField;
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
    }
}
