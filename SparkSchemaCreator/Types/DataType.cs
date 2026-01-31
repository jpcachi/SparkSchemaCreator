using Newtonsoft.Json.Linq;
using SparkSchemaCreator.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

namespace SparkSchemaCreator.Types
{
    [TypeConverter(typeof(DataTypeConverter))]
    [Editor(typeof(DataTypeEditor), typeof(UITypeEditor))]
    internal abstract class DataType : JsonSparkElement
    {
        [Browsable(false)]
        public MapType? MapParent { get; set; } = null;
        [Browsable(false)]
        public bool IsKeyOfMapParent { get; set; } = false;

        [Browsable(false)]
        public ArrayType? ArrayParent { get; set; } = null;
        [Browsable(false)]
        public abstract string TypeName { get; }
        [Browsable(false)]
        public abstract string TypeNameApi { get; }
        [Browsable(false)]
        public virtual string TypeNameSimple => TypeName;
        
        [Browsable(false)]
        public DataType? DefaultType { get; set; } = null;

        public DataType() 
        {
            DefaultType = this;
        }

        public static string TypeNamesApi => "(ArrayType|StructType|MapType|StringType|BooleanType|ShortType|LongType|FloatType|DoubleType|BinaryType|ByteType|CharType|VarcharType|DecimalType|DateType|TimestampNTZType|TimestampType|" +
                "TimestampNTZType|YearMonthIntervalType|DayTimeIntervalType|CalendarIntervalType|IntegerType|VoidType)";

        public static string TypeNames => "(struct|array|map|string|boolean|short|long|float|double|binary|byte|char|varchar|decimal|date|timestamp_ntz|timestamp|" +
                "interval year to month|interval month to month|interval month|interval year to year|interval year|interval day to day|" +
                "interval day to hour|interval day to minute|interval day to second|interval day|interval hour to hour|interval hour to minute|" +
                "interval hour to second|interval hour|interval minute to minute|interval minute to second|interval minute|" +
                "interval second to second|interval second|interval|integer|int|void)";

        private static Regex GetDataTypeRegex(string typeNames, bool spaces = false) => 
            new((spaces ? @"\s" : string.Empty) + typeNames + @"(\s*\(\s*(\d+)\s*(,\s*(\-?\d+)\s*)?\))?" + (spaces ? @"(\s|\r\n)" : string.Empty));

        public static Regex TypeNamesRegex => GetDataTypeRegex(TypeNames);
        public static Regex TypeNamesWithSpaces => GetDataTypeRegex(TypeNames, true);
        public static Regex TypeNamesApiRegex => GetDataTypeRegex(TypeNamesApi);

        private static Match CheckDataType(string dataType)
        {
            return TypeNamesRegex.Match(dataType);
        }

        private static Match CheckDataTypeApi(string dataType)
        {
            return TypeNamesApiRegex.Match(dataType);
        }

        public static bool IsValidDataType(string dataType)
        {
            return CheckDataType(dataType).Success;
        }

        public static DataType Copy(DataType dataType)
        {
            if (dataType is ArrayType array)
                return new ArrayType(Copy(array.ElementType), array.ContainsNull);

            if (dataType is StructType structType)
                return new StructType(structType);

            if (dataType is MapType mapType)
                return new MapType(Copy(mapType.KeyType), Copy(mapType.ValueType), mapType.ValueContainsNull);

            DataType resul = FromString(dataType.TypeName);

            return resul;

        }

        public static DataType[] DataTypes =>
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

        public static DataType FromString(string? dataType)
        {

            if (dataType == null)
                throw new Exception("Invalid Data Type null");

            Match match = CheckDataType(dataType);

            if (match.Success)
            {
                string type = match.Groups[1].Value;
                switch (type)
                {
                    case "string": return new StringType();
                    case "boolean": return new BooleanType();
                    case "int":
                    case "integer": return new IntegerType();
                    case "short": return new ShortType();
                    case "long": return new LongType();
                    case "float": return new FloatType();
                    case "double": return new DoubleType();
                    case "binary": return new BinaryType();
                    case "byte": return new ByteType();
                    case "char": return new CharType(int.Parse(match.Groups[3].Value));
                    case "varchar": return new VarcharType(int.Parse(match.Groups[3].Value));
                    case "decimal": return new DecimalType(int.Parse(match.Groups[3].Value), int.Parse(match.Groups[5].Value));
                    case "date": return new DateType();
                    case "timestamp": return new TimestampType();
                    case "timestamp_ntz": return new TimestampNTZType();
                    case "interval": return new CalendarIntervalType();
                    case "interval year to month": return new YearMonthIntervalType(0, 1);
                    case "interval month to month":
                    case "interval month": return new YearMonthIntervalType(1, 1);
                    case "interval year to year":
                    case "interval year": return new YearMonthIntervalType(0, 0);
                    case "interval day to day":
                    case "interval day": return new DayTimeIntervalType(0, 0);
                    case "interval day to hour": return new DayTimeIntervalType(0, 1);
                    case "interval day to minute": return new DayTimeIntervalType(0, 2);
                    case "interval day to second": return new DayTimeIntervalType(0, 3);
                    case "interval hour to hour":
                    case "interval hour": return new DayTimeIntervalType(1, 1);
                    case "interval hour to minute": return new DayTimeIntervalType(1, 2);
                    case "interval hour to second": return new DayTimeIntervalType(1, 3);
                    case "interval minute to minute":
                    case "interval minute": return new DayTimeIntervalType(2, 2);
                    case "interval minute to second": return new DayTimeIntervalType(2, 3);
                    case "interval second to second":
                    case "interval second": return new DayTimeIntervalType(3, 3);
                    case "void": return new VoidType();

                }
            }
            throw new Exception("Invalid data type encountered: " + dataType);
        }

        public static DataType FromStringApi(string? dataType)
        {

            if (dataType == null)
                throw new Exception("Invalid Data Type null");

            Match match = CheckDataTypeApi(dataType);

            if (match.Success)
            {
                string type = match.Groups[1].Value;
                switch (type)
                {
                    case "StringType": return new StringType();
                    case "BooleanType": return new BooleanType();
                    case "IntegerType": return new IntegerType();
                    case "ShortType": return new ShortType();
                    case "LongType": return new LongType();
                    case "FloatType": return new FloatType();
                    case "DoubleType": return new DoubleType();
                    case "BinaryType": return new BinaryType();
                    case "ByteType": return new ByteType();
                    case "CharType": return new CharType(int.Parse(match.Groups[3].Value));
                    case "VarcharType": return new VarcharType(int.Parse(match.Groups[3].Value));
                    case "DecimalType": return new DecimalType(int.Parse(match.Groups[3].Value), int.Parse(match.Groups[5].Value));
                    case "DateType": return new DateType();
                    case "TimestampType": return new TimestampType();
                    case "TimestampNTZType": return new TimestampNTZType();
                    case "YearMonthIntervalType": return new YearMonthIntervalType(byte.Parse(match.Groups[3].Value), byte.Parse(match.Groups[5].Value));
                    case "DayTimeIntervalType": return new DayTimeIntervalType(byte.Parse(match.Groups[3].Value), byte.Parse(match.Groups[5].Value));
                    case "CalendarIntervalType": return new CalendarIntervalType();
                    case "VoidType": return new VoidType();

                }
            }
            throw new Exception("Invalid data type encountered: " + dataType);
        }

        public static DataType FromJsonToken(JToken jsonToken, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            if (jsonToken is JObject jsonObject)
            {
                string? type = jsonObject["type"]?.Value<string>();

                return type switch
                {
                    "struct" => StructType.FromJsonObject(jsonObject, integersAsLongs, sortFields, checkValidName),
                    "array" => ArrayType.FromJsonObject(jsonObject, integersAsLongs, sortFields, checkValidName),
                    "map" => MapType.FromJsonObject(jsonObject, integersAsLongs, sortFields, checkValidName),
                    _ => throw new ArgumentException($"Invalid Type '{type}'")
                };
            }
            else return FromString(jsonToken.Value<string>());
        }

        internal static void BuildFormattedString(DataType dataType, string prefix, StringConcat stringConcat, int maxDepth)
        {
            dataType.BuildFormattedString(prefix, stringConcat, maxDepth - 1);
        }

        public override string GetJsonPath()
        {
            if (ArrayParent != null)
                return ArrayParent.GetJsonPath();

            if (MapParent != null)
                return MapParent.GetJsonPath() + (IsKeyOfMapParent ? "[key]" : "[value]");

            return string.Empty;
        }

        public override string GetJsonPathExpanded()
        {
            if (ArrayParent != null)
                return ArrayParent.GetJsonPathExpanded() + ".element";

            if (MapParent != null)
                return MapParent.GetJsonPathExpanded() + (IsKeyOfMapParent ? ".key" : ".value");

            return string.Empty;
        }

        public override DataType Clone()
        {
            return Copy(this);
        }
    }
}
