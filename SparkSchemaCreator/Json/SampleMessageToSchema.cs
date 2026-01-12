using SparkSchemaCreator.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SparkSchemaCreator.Json
{
    public class SampleMessageToSchema
    {
        private static SampleMessageToSchema? instance;
        public static SampleMessageToSchema Instance => instance ??= new SampleMessageToSchema();

        internal IEnumerable<StructField> ParseToStructFieldSequence(string json, bool integersAsLongs = false, bool checkValidName = true) => ParseSimpleJsonObject(JObject.Parse(json), integersAsLongs, checkValidName);
        internal StructType ParseToStructType(string json, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true) => new([.. ParseSimpleJsonObject(JObject.Parse(json), integersAsLongs, sortFields, checkValidName)]);
        public string ParseToJsonSchema(string json, Formatting? format, bool integersAsLongs = false, bool checkValidName = true) =>
          JsonConvert.SerializeObject(JsonConvert.DeserializeObject(ParseToStructType(json, integersAsLongs, checkValidName).ToJsonString()), format ?? Formatting.None);

        private static DataType ParseSimpleType(JValue jvalue, bool integersAsLongs = false, bool forceString = false)
        {
            if (jvalue.Value == null)
                return new VoidType();

            string value = jvalue.ToString(Formatting.None);

            if (!forceString) {

                //check if value is double
                if (double.TryParse(value, out _) && value.Contains('.'))
                    return new DoubleType();

                //check if value is long
                if (long.TryParse(value, out _))
                    return new LongType();

                //check if value is integer
                if (int.TryParse(value, out _))
                    return integersAsLongs ? new LongType() : new IntegerType();

                //check if value is boolean
                if (bool.TryParse(value, out _))
                    return new BooleanType();
            }

            return new StringType();

        }

        private StructType ParseStructType(JObject obj, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            StructType structType = new();
            IEnumerable<StructField> rawFields = ParseSimpleJsonObject(obj, integersAsLongs, sortFields, checkValidName);
            IEnumerable<StructField> fields = sortFields ? rawFields.OrderBy(x => x.Name) : rawFields;
            structType.AddFields(fields);

            return structType;
        }

        private static JObject MergeObjects(JObject first, JObject second)
        {
            JsonMergeSettings mergeSettings = new()
            {
                MergeArrayHandling = MergeArrayHandling.Merge,
                MergeNullValueHandling = MergeNullValueHandling.Ignore
            };

            first.Merge(second, mergeSettings);

            return first;

        }

        private ArrayType ParseArrayType(JArray obj, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            IEnumerable<JToken> arrayTokens = obj.Children();

            //Comprobamos que haya elementos
            if(arrayTokens.Any())
            {
                //Comprobamos que todos los elementos del array son del mismo tipo
                if (arrayTokens.All(x => x is JValue))
                {
                    DataType dataType = ParseSimpleType((JValue)arrayTokens.First(), integersAsLongs);
                    ArrayType arr = new(dataType);

                    return arr;
                }

                //Comprobamos que todos los elementos del array son del mismo tipo
                if (arrayTokens.All(x => x is JObject))
                {
                    JObject mergedObject = (JObject)arrayTokens.Aggregate((x, y) => MergeObjects((JObject)x, (JObject)y));
                    DataType dataType = ParseStructType(mergedObject, integersAsLongs, sortFields, checkValidName);
                    ArrayType arr = new(dataType);

                    return arr;
                }
                throw new Exception("Invalid json array elementType");
            }
            return new ArrayType(new StructType());
        }

        private IEnumerable<StructField> ParseSimpleJsonObject(JToken currentNode, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            if (currentNode is JObject jObject)
            {
                foreach (KeyValuePair<string, JToken?> objValue in jObject)
                {
                    if (checkValidName && " ,;{}()\n\t=".Intersect(objValue.Key).Any())
                        throw new ArgumentException($"Attribute name \"{objValue.Key}\" contains invalid character(s) among \" ,;{{}}()\\n\\t=\".");

                    if (objValue.Value is JValue jValue)
                    {
                        yield return new StructField(objValue.Key, ParseSimpleType(jValue, integersAsLongs));
                    }
                    else if (objValue.Value is JObject jObject2)
                    {
                        yield return new StructField(objValue.Key, ParseStructType(jObject2, integersAsLongs, sortFields, checkValidName));
                    }
                    else if (objValue.Value is JArray jArray)
                    {
                        yield return new StructField(objValue.Key, ParseArrayType(jArray, integersAsLongs, sortFields, checkValidName));
                    }
                }
            }
        }
    }
}