using SparkSchemaCreator.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparkSchemaCreator.Utils;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class StructType : ComplexType
    {
        public override string TypeName => "struct";
        public override string TypeNameApi => "StructType";

        public StructField this[int i]
        {
            get { return Fields[i]; }
            set { value.StructParent = this; Fields[i] = value; }
        }

        public StructField this[string fieldName]
        {
            get { return Fields.Find(x => x.Name == fieldName) ?? throw new ArgumentException($"{fieldName} is not a member of current struct"); }
            set { Fields = [.. Fields.Where(x => x.Name != fieldName)]; AddField(value);  }
        }

        [Category("Root")]
        [Description("List of fields contained in this StructType")]
        [Editor(typeof(StructFieldListEditor), typeof(UITypeEditor))]
        public List<StructField> Fields { get; set; }

        public StructType(StructType clone)
        {
            Fields = [];
            foreach(StructField field in clone.Fields)
            {
                StructField fieldToAdd = field.Clone();
                fieldToAdd.StructParent = this;
                Fields.Add(fieldToAdd);
            }
        }
        public StructType()
        {
            Fields = [];
        }

        public StructType(params StructField[] fields)
        {
            Fields = [];
            Array.ForEach(fields, f => f.StructParent = this);
            Fields.AddRange(fields);
        }

        public override JToken ToJsonObject()
        {
            JArray fields = [];

            foreach(StructField field in Fields)
                fields.Add(field.ToJsonObject());

            JObject result = new()
            {
                {"type", TypeName },
                {"fields", fields}
            };

            return result;
        }

        public static StructType FromJsonObject(JObject jsonObject, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            JArray fields = jsonObject["fields"]?.Value<JArray>() ?? throw new ArgumentException("StructType must define a valid fields array");

            if (fields.Children<JToken>().Any(x => x is not JObject))
                throw new ArgumentException("StructType fields element only admits StructField objects");

            StructType structType = new();
            IEnumerable<StructField> rawFields = fields.Children<JObject>().Select(x => StructField.FromJsonObject(x, integersAsLongs, sortFields, checkValidName));
            IEnumerable<StructField> fieldsToAdd = sortFields ? rawFields.OrderBy(x => x.Name) : rawFields;
            structType.AddFields(fieldsToAdd);

            return structType;
        }

        public void AddField(StructField field)
        {
            field.StructParent = this;
            Fields.Add(field); 
        }

        public void InsertField(int index, StructField field)
        {
            field.StructParent = this;
            Fields.Insert(index, field);
        }

        public void AddFields(IEnumerable<StructField> fields)
        {
            foreach (StructField field in fields)
            {
                AddField(field);
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is StructType other)
                return other.Fields.SequenceEqual(Fields);

            return false;
        }

        public override int GetHashCode()
        {
            HashCode resul = new();
            resul.Add(TypeName);

            foreach(StructField field in Fields)
                resul.Add(field);

            return resul.ToHashCode();
        }

        public override void BuildFormattedString(string prefix, StringConcat stringConcat, int maxDepth)
        {
            Fields.ForEach(field => field.BuildFormattedString(prefix, stringConcat, maxDepth));
        }

        public string TreeString(int maxDepth = int.MaxValue)
        {
            StringConcat stringConcat = new();
            stringConcat.Append("root\r\n");
            int depth = maxDepth > 0 ? maxDepth : int.MaxValue;
            Fields.ForEach(field => field.BuildFormattedString(" |", stringConcat, depth));

            return stringConcat.ToString();
        }

        public override string ToScalaObjectString(bool sortFields = false, bool includeEmpty = true, string wrap = "Array")
        {
            string[] validWrapValues = ["Array", "List", "Seq", "::"];
            
            if (!validWrapValues.Contains(wrap))
                throw new ArgumentException("Wrap value has to be Array, List, Seq or ::");

            string resul = string.Empty;
            IEnumerable<string> fields = sortFields ? Fields.OrderBy(x => x.Name).Select(x => x.ToScalaObjectString(sortFields, includeEmpty, wrap)).Where(x => x != "") : Fields.Select(x => x.ToScalaObjectString(sortFields, includeEmpty, wrap)).Where(x => x != "");

            if (wrap != "::")
            {
                string wrapWithType = !fields.Any() ? wrap + "[StructField]" : wrap;
                resul = $"{TypeNameApi}(\r\n\t{wrapWithType}({string.Join(",\r\n\t", fields)}))";
            }
            else
                resul = $"{TypeNameApi}({fields.Aggregate(string.Empty, (text, field) => text + "\r\n\t" + field + " :: ")}Nil)";

            return resul;
        }

        public override string ToPythonString(bool sortFields = false, bool includeEmpty = true)
        {
            string resul = string.Empty;
            IEnumerable<string> fields = sortFields ? 
                Fields.OrderBy(x => x.Name).Select(x => x.ToPythonString(sortFields, includeEmpty)).Where(x => x != "") : 
                Fields.Select(x => x.ToPythonString(sortFields, includeEmpty)).Where(x => x != "");

            return $"{TypeNameApi}(\r\n\t[{string.Join(",\r\n\t", fields)}])";
        }

        public bool IsEqualsTo(StructType other)
        {
            return other.ToJsonString().Equals(ToJsonString());
        }

        public override void UpdateFrom(JsonSparkElement newValue)
        {
            if (newValue is not StructType structType)
                return;

            Fields.Clear();
            AddFields(structType.Fields);
            
            ArrayParent = structType.ArrayParent;
            MapParent = structType.MapParent;
            IsKeyOfMapParent = structType.IsKeyOfMapParent;
        }
    }
}
