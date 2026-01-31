using Newtonsoft.Json.Linq;
using SparkSchemaCreator.Controls;
using SparkSchemaCreator.Converters;
using SparkSchemaCreator.Utils;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Design;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    [TypeConverter(typeof(StructFieldConverter))]
    internal class StructField : JsonSparkElement
    {
        [Browsable(false)]
        public StructType? StructParent { get; set; } = null;

        [Category("Field Info")]
        [Description("Name of the StructField")]
        public string Name { get; set; }

        private DataType _dataType;

        [Category("Field Info")]
        [Description("Type of the StructField")]
        public DataType DataType { 
            get { return _dataType; } 
            set
            {
                _dataType = value;
                if (_dataType is ComplexType complex)
                    complex.FieldOfWhichItIsType = this;
            }
        }

        [Category("Field Info")]
        [Description("Indicates whether the StructField accepts a null value or not")]
        public bool IsNullable { get; set; } = true;

        [Browsable(false)]
        public int Index => StructParent != null ? StructParent.Fields.IndexOf(this) : -1;

        [Category("Metadata Info")]
        [Description("Metadata in JSON format associated with this field")]
        public Metadata Metadata { get; set; }

        [Browsable(false)]
        public StructField? FieldParent => GetClosestFieldParent(this);

        private static StructField? GetClosestFieldParent(JsonSparkElement field)
        {
            if (field is StructField structField && structField.StructParent != null)
                return GetClosestFieldParent(structField.StructParent);

            if(field is ComplexType complex)
            {
                if (complex.FieldOfWhichItIsType != null)
                    return complex.FieldOfWhichItIsType;

                if (complex.ArrayParent != null)
                    return GetClosestFieldParent(complex.ArrayParent);

                if(complex.MapParent != null)
                    return GetClosestFieldParent(complex.MapParent);

            }

            return null;
        }

        public StructField()
        {
            Name = "New_Field";
            _dataType = new StringType();
            Metadata = Metadata.Empty;
        }

        public override StructField Clone()
        {
            return new StructField(Name, DataType, IsNullable, Metadata)
            {
                StructParent = StructParent
            };
        }

        public StructField(string name, DataType dataType)
        {
            if (dataType is ComplexType complex)
                complex.FieldOfWhichItIsType = this;

            Name = name;
            _dataType = dataType;
            Metadata = Metadata.Empty;

        }

        public StructField(string name, DataType dataType, bool isNullable, Metadata metadata)
        {
            if (dataType is ComplexType complex)
                complex.FieldOfWhichItIsType = this;

            Name = name;
            _dataType = dataType;
            IsNullable = isNullable;
            Metadata = metadata;
        }

        public override void UpdateFrom(JsonSparkElement newValue)
        {
            if (newValue is not StructField other)
                return;

            Name = other.Name;
            DataType = other.DataType;
            IsNullable = other.IsNullable;
            Metadata = other.Metadata;
        }

        public override JToken ToJsonObject()
        {
            JObject resul = new()
            {
                { "name", Name },
                { "type", DataType.ToJsonObject() },
                { "nullable", IsNullable },
                { "metadata", Metadata.ToJsonObject() }
            };

            return resul;
        }

        public override string GetJsonPath()
        {
            string? parentJson = StructParent?.GetJsonPath();

            if(!string.IsNullOrEmpty(parentJson))
                return parentJson + "." + Name;

            return Name;
        }

        public override string GetJsonPathExpanded()
        {
            string? parentJson = StructParent?.GetJsonPathExpanded();

            if (!string.IsNullOrEmpty(parentJson))
                return parentJson + "." + Name;

            return Name;
        }

        public override void BuildFormattedString(string prefix, StringConcat stringConcat, int maxDepth)
        {
            if(maxDepth > 0)
            {
                stringConcat.Append($"{prefix}-- {Name}: {DataType.TypeName} (nullable = {IsNullable})\r\n");
                DataType.BuildFormattedString(DataType, $"{prefix}    |", stringConcat, maxDepth);
            }
        }

        public override string ToJsonString(bool sortFields = false, bool includeEmpty = true, bool pretty = false)
        {
            if (!includeEmpty && DataType is StructType structType && structType.Fields.Count == 0)
                return string.Empty;

            if (!includeEmpty && DataType is ArrayType arrayType && arrayType.ElementType is StructType elementStructType && elementStructType.Fields.Count == 0)
                return string.Empty;

            return base.ToJsonString(sortFields, includeEmpty, pretty);
        }

        public override string ToScalaObjectString(bool sortFields = false, bool includeEmpty = true, string wrap = "Array")
        {
            if (!includeEmpty && DataType is StructType structType && structType.Fields.Count == 0)
                return string.Empty;

            if (!includeEmpty && DataType is ArrayType arrayType && arrayType.ElementType is StructType elementStruct && elementStruct.Fields.Count == 0)
                return string.Empty;

            return $"StructField(\"{Name}\", {DataType.ToScalaObjectString(sortFields, includeEmpty, wrap)}, {IsNullable.ToString().ToLower()}" + (Metadata.Map.Count > 0 ? $", {Metadata.ToScalaObjectString()})" : ")");
        }

        public override string ToPythonString(bool sortFields = false, bool includeEmpty = true)
        {
            if (!includeEmpty && DataType is StructType structType && structType.Fields.Count == 0)
                return string.Empty;

            if (!includeEmpty && DataType is ArrayType arrayType && arrayType.ElementType is StructType elementStruct && elementStruct.Fields.Count == 0)
                return string.Empty;

            return $"StructField('{Name}', {DataType.ToPythonString(sortFields, includeEmpty)}, {IsNullable}" + (Metadata.Map.Count > 0 ? $", {Metadata.ToPythonString()})" : ")");
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, DataType, IsNullable, Metadata);
        }

        public override bool Equals(object? other)
        {
            return other is StructField field && field.Name == Name && field.DataType == DataType && field.IsNullable == IsNullable && field.Metadata == Metadata;
        }

        public static StructField FromJsonObject(JObject jsonObject, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            string? name = (jsonObject["name"]?.Value<string>()) ?? throw new ArgumentException("StructField name cannot be null");

            if (checkValidName && StructFieldUtils.INVALID_CHARS.Intersect(name).Any())
                throw new ArgumentException($"Attribute name \"{name}\" contains invalid character(s) among \"{StructFieldUtils.INVALID_CHARS}\".");

            bool nullable = jsonObject["nullable"]?.Value<bool>() ?? true;

            JToken typeJsonObject = jsonObject["type"] ?? throw new ArgumentException("StructField must define a non null type");
            JObject? metadataJsonObject = jsonObject["metadata"]?.Value<JObject>();

            DataType type = DataType.FromJsonToken(typeJsonObject, integersAsLongs, sortFields, checkValidName);
            Metadata metadata = Metadata.FromJsonObject(metadataJsonObject);

            return new StructField(name, type, nullable, metadata);
        }
    }
}
