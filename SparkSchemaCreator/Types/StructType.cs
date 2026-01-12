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
            int resul = TypeName.GetHashCode();

            foreach(StructField f in Fields)
                resul ^= f.GetHashCode();

            return resul;
        }

        public static StructType Merge(StructType str1, StructType str2)
        {
            IEnumerable<StructField> fieldsInStr1NotInStr2 = str1.Fields.Where(x => !str2.Fields.Any(y => y.Name == x.Name));
            IEnumerable<StructField> fieldsInStr2NotInStr1 = str2.Fields.Where(x => !str1.Fields.Any(y => y.Name == x.Name));
            IEnumerable<StructField> fieldsCommonToKeep = str1.Fields.Where(x => str1.Fields.Any(y => y == x));


            IEnumerable<string> fieldsInCommonToChange = str1.Fields.Where(x => str1.Fields.Any(y => y.Name == x.Name && x != y)).Select(x => x.Name);


            List<StructField> fields = [.. fieldsInStr1NotInStr2.Concat(fieldsInStr2NotInStr1).Concat(fieldsCommonToKeep)];

            foreach (string field in fieldsInCommonToChange)
            {
                StructField field1 = str1.Fields.Find(x => x.Name == field) ?? throw new Exception("Merge Exception");
                StructField field2 = str2.Fields.Find(x => x.Name == field) ?? throw new Exception("Merge Exception");

                Metadata metadata = field1.Metadata == Metadata.Empty ? field2.Metadata : field1.Metadata;

                //si ambos tipos son struct
                if(field1.DataType is StructType s1 && field2.DataType is StructType s2)
                {
                    bool nullable = field1.IsNullable || field2.IsNullable;
                    fields.Add(new StructField(field, Merge(s1,s2), nullable, metadata));
                }
                //si uno de los dos es struct y el otro no
                else if ((field1.DataType is StructType && field2.DataType is not StructType) || (field2.DataType is StructType && field1.DataType is not StructType))
                {
                    throw new Exception("Merge Exception");
                }
                //si ambos son array
                else if (field1.DataType is ArrayType a1 && field2.DataType is ArrayType a2)
                {

                    bool nullable = field1.IsNullable || field2.IsNullable;
                    bool containsNull = a1.ContainsNull || a2.ContainsNull;

                    //comparamos elementTypes de los array
                    if (a1.ElementType is StructType a1s && a2.ElementType is StructType a2s)
                    {
                        fields.Add(new StructField(field, new ArrayType(Merge(a1s, a2s), containsNull), nullable, metadata));

                    }
                    //si uno de los dos es struct y el otro no
                    else if ((a1.ElementType is StructType && a2.ElementType is not StructType) || (a2.ElementType is StructType && a1.ElementType is not StructType))
                    {
                        throw new Exception("Merge Exception");
                    }
                    //else solo puede ser SimpleType
                    else
                    {

                        if (a1.ElementType != a2.ElementType)
                        {
                            fields.Add(new StructField(field, new ArrayType(new StringType(), containsNull), nullable, metadata));
                        }
                        else
                        {
                            DataType element = a1.ElementType ?? throw new Exception("Merge Exception");
                            fields.Add(new StructField(field, new ArrayType(a1.ElementType, containsNull), nullable, metadata));
                        }
                        
                    }
                }
                //si uno de los dos es array y el otro no
                else if ((field1.DataType is ArrayType && field2.DataType is not ArrayType) || (field2.DataType is ArrayType && field1.DataType is not ArrayType))
                {
                    throw new Exception("Merge Exception");
                }
            }

            return new StructType([.. fields]);
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
            foreach (StructField f in structType.Fields)
                Fields.Add(f);
            
            ArrayParent = structType.ArrayParent;
            MapParent = structType.MapParent;
            IsKeyOfMapParent = structType.IsKeyOfMapParent;
        }
    }
}
