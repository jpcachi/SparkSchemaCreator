using Newtonsoft.Json.Linq;
using SparkSchemaCreator.Types;
using SparkSchemaCreator.Utils;

namespace SparkSchemaCreator.Json
{
    public static class JsonSchemaToSchema
    {
        internal static StructField ParseSchemaField(string json, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            JObject field = JObject.Parse(json);

            return StructField.FromJsonObject(field, integersAsLongs, sortFields, checkValidName);
        }

        internal static StructType ParseSchemaJson(string json, bool integersAsLongs = false, bool sortFields = false, bool checkValidName = true)
        {
            StructType schema = new();

            if (string.IsNullOrWhiteSpace(json))
                return schema;

            JObject root = JObject.Parse(json);
            return StructType.FromJsonObject(root, integersAsLongs, sortFields, checkValidName);
        }

        internal static Metadata ParseMetadata(string json)
        {
            JObject root = JObject.Parse(json);
            return Metadata.FromJsonObject(root);
        }

    }
}
