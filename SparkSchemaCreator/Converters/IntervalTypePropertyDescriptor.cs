using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    internal class IntervalTypePropertyDescriptor : PropertyDescriptor
    {
        public IntervalTypePropertyDescriptor() : base("Interval", null) { }

        public override TypeConverter Converter => new IntervalTypeRangeTypesConverter();

        public override Type ComponentType => typeof(IntervalType);

        public override bool IsReadOnly => false;

        public override Type PropertyType => typeof(string);

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object? GetValue(object? component)
        {
            if (component is IntervalType interval)
                return interval.TypeName;

            return null;
        }

        public override void ResetValue(object component)
        {
            if (component is IntervalType interval)
            {
                interval.StartField = 0;
                interval.EndField = 0;
            }
        }

        public override void SetValue(object? component, object? value)
        {
            if (component is IntervalType interval && value is string intervalType)
            {
                switch (intervalType)
                {
                    case "interval year":
                    case "interval day":
                        interval.StartField = 0;
                        interval.EndField = 0;
                        break;

                    case "interval year to month":
                    case "interval day to hour":
                        interval.StartField = 0;
                        interval.EndField = 1;
                        break;

                    case "interval month":
                    case "interval hour":
                        interval.StartField = 1;
                        interval.EndField = 1;
                        break;

                    case "interval day to minute":
                        interval.StartField = 0;
                        interval.EndField = 2;
                        break;

                    case "interval day to second":
                        interval.StartField = 0;
                        interval.EndField = 3;
                        break;

                    case "interval hour to minute":
                        interval.StartField = 1;
                        interval.EndField = 2;
                        break;

                    case "interval hour to second":
                        interval.StartField = 1;
                        interval.EndField = 3;
                        break;

                    case "interval minute":
                        interval.StartField = 2;
                        interval.EndField = 2;
                        break;

                    case "interval minute to second":
                        interval.StartField = 2;
                        interval.EndField = 3;
                        break;

                    case "interval second":
                        interval.StartField = 3;
                        interval.EndField = 3;
                        break;
                }
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
    }
}
