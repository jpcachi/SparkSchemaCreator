using SparkSchemaCreator.Types;
using Newtonsoft.Json.Linq;

namespace SparkSchemaCreator.Json
{
    public class JsonSchemaToSchema
    {
        private static JsonSchemaToSchema? instance;
        public static JsonSchemaToSchema Instance => instance ??= new JsonSchemaToSchema();


        internal StructField ParseSchemaField(string json, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            JObject field = JObject.Parse(json);

            return ParseSchemaField(field, integersAsLongs, sortFields, checkValidName);
        }

        private StructField ParseSchemaField(JObject currentNode, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            string? name = currentNode["name"]?.Value<string>();

            if (name == null || (checkValidName && " ,;{}()\n\t=".Intersect(name).Any()))
                throw new ArgumentException($"Attribute name \"{name}\" contains invalid character(s) among \" ,;{{}}()\\n\\t=\".");

            bool nullable = currentNode["nullable"]?.Value<bool>() ?? true;

            JObject? metadata = currentNode["metadata"]?.Value<JObject>();

            DataType? type = (currentNode["type"]?.Type == JTokenType.Object ? 
                ParseSchemaDataType(currentNode["type"]?.Value<JObject>() ?? throw new ArgumentException("Invalid JObject"), integersAsLongs, sortFields, checkValidName) : 
                DataType.FromString(currentNode["type"]?.Value<string>())) ?? throw new ArgumentException("Type cannot be null");
            StructField structField = new(name, type, nullable, ParseMetadata(metadata));

            return structField;
        }

        internal DataType? ParseSchemaDataType(JObject currentNode, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            string? type = currentNode["type"]?.Value<string>();

            if (type == "struct")
            {
                JArray fields = currentNode["fields"]?.Value<JArray>() ?? throw new ArgumentException("StructType must define fields element");

                if (fields.Children<JToken>().Any(x => x is not JObject))
                    throw new ArgumentException("StructType fields only admits StructField objects");
                
                StructType structType = new();
                IEnumerable<StructField> rawFields = fields.Children<JObject>().Select(x => ParseSchemaField(x, integersAsLongs, sortFields, checkValidName));
                IEnumerable<StructField> fieldsToAdd = sortFields ? rawFields.OrderBy(x => x.Name) : rawFields;
                structType.AddFields(fieldsToAdd);

                return structType;
            }

            if (type == "array")
            {
                bool containsNull = currentNode["containsNull"]?.Value<bool>() ?? true;
                DataType? elementType = (currentNode["elementType"]?.Type == JTokenType.Object ? 
                    ParseSchemaDataType(currentNode["elementType"]?.Value<JObject>() ?? throw new ArgumentException("Invalid JObject"), integersAsLongs, sortFields, checkValidName) : 
                    DataType.FromString(currentNode["elementType"]?.Value<string>())) ?? throw new ArgumentException("Element Type cannot be null");
                ArrayType arrayType = new(elementType, containsNull);

                return arrayType;
            }

            if (type == "map")
            {
                bool valueContainsNull = currentNode["valueContainsNull"]?.Value<bool>() ?? true;
                
                DataType? keyType = (currentNode["keyType"]?.Type == JTokenType.Object ? ParseSchemaDataType(currentNode["keyType"]?.Value<JObject>() ?? throw new ArgumentException("Invalid JObject"), integersAsLongs, sortFields, checkValidName) : DataType.FromString(currentNode["keyType"]?.Value<string>())) ?? throw new ArgumentException("Key Type cannot be null");
                DataType? valueType = (currentNode["valueType"]?.Type == JTokenType.Object ? ParseSchemaDataType(currentNode["valueType"]?.Value<JObject>() ?? throw new ArgumentException("Invalid JObject"), integersAsLongs, sortFields, checkValidName) : DataType.FromString(currentNode["valueType"]?.Value<string>())) ?? throw new ArgumentException("Value Type cannot be null");
                MapType mapType = new(keyType, valueType, valueContainsNull);

                return mapType;
            }

            throw new ArgumentException($"Invalid Type '{type}'");
        }

        internal StructType ParseSchemaJson(string json, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            StructType schema = new();

            if (string.IsNullOrWhiteSpace(json))
                return schema;

            JObject root = JObject.Parse(json);
            return ParseSchemaDataType(root, integersAsLongs, sortFields, checkValidName) as StructType ?? schema;
        }

        internal static Metadata ParseMetadata(string json)
        {
            JObject root = JObject.Parse(json);
            return ParseMetadata(root);
        }

        private static Metadata ParseMetadata(JObject? jsonObject)
        {
            if(jsonObject == null)
                return Metadata.Empty;

            Metadata.Builder metadataBuilder = new();

            foreach (KeyValuePair<string, JToken?> objValue in jsonObject)
            {
                if (objValue.Value is JValue jValue)
                {
                    metadataBuilder.Put(objValue.Key, jValue.Value);
                }
                if(objValue.Value is JObject jObject)
                    metadataBuilder.Put(objValue.Key, ParseMetadata(jObject));
                if (objValue.Value is JArray jArray)
                {
                    if (jArray.HasValues)
                    {
                        JToken head = jArray[0];

                        if (head is JValue arrayValue)
                        {
                            switch (arrayValue.Type)
                            {
                                case JTokenType.Integer:
                                    metadataBuilder.Put(objValue.Key, jArray.ToObject<long[]>());
                                    break;
                                case JTokenType.Float:
                                    metadataBuilder.Put(objValue.Key, jArray.ToObject<double[]>());
                                    break;
                                default:
                                    metadataBuilder.Put(objValue.Key, jArray.ToObject<string[]>());
                                    break;
                            }
                        }
                            

                        if (head is JObject objectValue)
                            metadataBuilder.Put(objValue.Key, jArray.Select(elem => ParseMetadata(elem as JObject)).ToArray());

                    }
                    else
                        metadataBuilder.Put(objValue.Key, jArray.ToObject<string[]>());
                }
            }

            return metadataBuilder.Build();
        }
    }
}
