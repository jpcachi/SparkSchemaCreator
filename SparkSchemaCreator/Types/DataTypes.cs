using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SparkSchemaCreator.Types
{
    internal static class DataTypes
    {
        public static string TypeNamesApi => "(ArrayType|StructType|MapType|StringType|BooleanType|ShortType|LongType|FloatType|DoubleType|BinaryType|ByteType|CharType|VarcharType|DecimalType|DateType|TimestampNTZType|TimestampType|" +
                "TimestampNTZType|YearMonthIntervalType|DayTimeIntervalType|CalendarIntervalType|IntegerType|VoidType)";

        public static string TypeNames => "(struct|array|map|string|boolean|short|long|float|double|binary|byte|char|varchar|decimal|date|timestamp_ntz|timestamp|" +
                "interval year to month|interval month to month|interval month|interval year to year|interval year|interval day to day|" +
                "interval day to hour|interval day to minute|interval day to second|interval day|interval hour to hour|interval hour to minute|" +
                "interval hour to second|interval hour|interval minute to minute|interval minute to second|interval minute|" +
                "interval second to second|interval second|interval|integer|int|void)";

        private static Regex GetDataTypeRegex(string typeNames, bool spaces = false) =>
            new((spaces ? @"\s" : string.Empty) + typeNames + @"(\s*\(\s*(\d+)\s*(,\s*(\-?\d+)\s*)?\))?" + (spaces ? @"(\s|\r\n)" : string.Empty));

        private static Regex TypeNamesRegex => GetDataTypeRegex(TypeNames);
        public static Regex TypeNamesWithSpaces => GetDataTypeRegex(TypeNames, true);
        private static Regex TypeNamesApiRegex => GetDataTypeRegex(TypeNamesApi);

        internal static Match CheckDataType(string dataType)
        {
            return TypeNamesRegex.Match(dataType);
        }

        internal static Match CheckDataTypeApi(string dataType)
        {
            return TypeNamesApiRegex.Match(dataType);
        }

        public static bool IsValidDataType(string dataType)
        {
            return CheckDataType(dataType).Success;
        }

        internal static DataType[] All =>
        [
            new StringType(),
            new BooleanType(),
            new IntegerType(),
            new ShortType(),
            new LongType(),
            new FloatType(),
            new DoubleType(),
            new BinaryType(),
            new ByteType(),
            new CharType(10),
            new VarcharType(10),
            new DecimalType(10, 0),
            new DateType(),
            new TimestampType(),
            new TimestampNTZType(),
            new CalendarIntervalType(),
            new YearMonthIntervalType(0, 0),
            new DayTimeIntervalType(0, 0),
            new StructType(),
            new ArrayType(new StringType()),
            new MapType(new StringType(), new StringType()),
            new VoidType()
        ];

        internal static string[] DataTypesNames =>
        [
            "string",
            "boolean",
            "integer",
            "short",
            "long",
            "float",
            "double",
            "binary",
            "byte",
            "char",
            "varchar",
            "decimal",
            "date",
            "timestamp",
            "timestamp_ntz",
            "inteval",
            "interval year",
            "interval day",
            "struct",
            "array",
            "map",
            "void"
        ];

        internal static string[] DataTypesApiNames =>
        [
            "StringType",
            "BooleanType",
            "IntegerType",
            "ShortType",
            "LongType",
            "FloatType",
            "DoubleType",
            "BinaryType",
            "ByteType",
            "CharType",
            "VarcharType",
            "DecimalType",
            "DateType",
            "TimestampType",
            "TimestampNTZType",
            "CalendarIntervalType",
            "YearMonthIntervalType",
            "DayTimeIntervalType",
            "StructType",
            "ArrayType",
            "MapType",
            "VoidType"
        ];

        private static string[] IntervalNames =>
        [
            "interval year to year",
            "interval year to month",
            "interval month",
            "interval month to month",
            "interval day to day",
            "interval day to hour",
            "interval day to minute",
            "interval day to second",
            "interval hour",
            "interval hour to hour",
            "interval hour to minute",
            "interval hour to second",
            "interval minute",
            "interval minute to minute",
            "interval minute to second",
            "interval second",
            "interval second to second"
        ];

        private static DataType[] IntervalTypes =>
        [
            new YearMonthIntervalType(0, 0),
            new YearMonthIntervalType(0, 1),
            new YearMonthIntervalType(1, 1),
            new YearMonthIntervalType(1, 1),
            new DayTimeIntervalType(0, 0),
            new DayTimeIntervalType(0, 1),
            new DayTimeIntervalType(0, 2),
            new DayTimeIntervalType(0, 3),
            new DayTimeIntervalType(1, 1),
            new DayTimeIntervalType(1, 1),
            new DayTimeIntervalType(1, 2),
            new DayTimeIntervalType(1, 3),
            new DayTimeIntervalType(2, 2),
            new DayTimeIntervalType(2, 2),
            new DayTimeIntervalType(2, 3),
            new DayTimeIntervalType(3, 3),
            new DayTimeIntervalType(3, 3),
        ];


        internal static Dictionary<string, DataType> AllDataTypes => 
            DataTypesNames.Zip(All).Concat(IntervalNames.Zip(IntervalTypes)).Append(("int", new IntegerType())).ToDictionary();
        internal static Dictionary<string, DataType> AllDataTypesApi => 
            DataTypesApiNames.Zip(All).ToDictionary();

        private static DataType FromApiOrNotApiString(Dictionary<string, DataType> types, string str, string? arg1, string? arg2)
        {
            DataType result = types[str];

            if (result is CharBaseType charType)
            {
                int length = int.Parse(arg1 ?? throw new ArgumentNullException(nameof(arg1)));
                charType.Length = length;
            }
            else if (result is DecimalType decimalType)
            {

                int precission = int.Parse(arg1 ?? throw new ArgumentNullException(nameof(arg1)));
                int scale = int.Parse(arg2 ?? "0");

                decimalType.Precission = precission;
                decimalType.Scale = scale;
            }
            else if (result is IntervalType intervalType)
            {
                intervalType.StartField = byte.Parse(arg1 ?? throw new ArgumentNullException(nameof(arg1)));
                intervalType.EndField = byte.Parse(arg2 ?? throw new ArgumentNullException(nameof(arg2)));
            }

            return result;
        }

        internal static DataType FromString(string str, string? arg1 = null, string? arg2 = null) 
        {
            return FromApiOrNotApiString(AllDataTypes, str, arg1, arg2);
        }

        internal static DataType FromApiString(string str, string? arg1 = null, string? arg2 = null)
        {
            return FromApiOrNotApiString(AllDataTypesApi, str, arg1, arg2);
        }
    }
}
