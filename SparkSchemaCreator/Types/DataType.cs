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

        private static DataType FromApiOrNotApiString(string? dataType, Func<string, Match> matchFunction, Func<string, string?, string?, DataType> getDataTypeFunction)
        {
            ArgumentNullException.ThrowIfNull(dataType);

            Match match = matchFunction(dataType);

            if (match.Success)
            {
                string type = match.Groups[1].Value;
                return getDataTypeFunction(type,  match.Groups[3].Value, match.Groups[5].Value);
            }
            throw new Exception("Invalid data type encountered: " + dataType);
        }

        public static DataType FromString(string? dataType)
        {
            return FromApiOrNotApiString(dataType, DataTypes.CheckDataType, DataTypes.FromString);
        }

        public static DataType FromApiString(string? dataType)
        {
            return FromApiOrNotApiString(dataType, DataTypes.CheckDataTypeApi, DataTypes.FromApiString);
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
