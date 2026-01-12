using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    internal class IntervalTypeRangeTypesConverter : TypeConverter
    {
        internal static readonly string[] yearMonthIntervals = ["interval year", "interval year to month", "interval month"];
        internal static readonly string[] dayTimeIntervals = ["interval day", "interval day to hour", "interval day to minute", "interval day to second",
            "interval hour", "interval hour to minute", "interval hour to second", "interval minute", "interval minute to second", "interval second"];

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
            if (context?.Instance is YearMonthIntervalType)
                return new StandardValuesCollection(yearMonthIntervals);
            
            else if (context?.Instance is DayTimeIntervalType)
                return new StandardValuesCollection(dayTimeIntervals);
            
            return base.GetStandardValues(context);
        }
    }
}
