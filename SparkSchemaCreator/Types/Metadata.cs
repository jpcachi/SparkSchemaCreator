using SparkSchemaCreator.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;

namespace SparkSchemaCreator.Types
{

    [TypeConverter(typeof(MetadataConverter))]
    [Editor(typeof(MetadataEditor), typeof(UITypeEditor))]
    internal class Metadata : JsonSparkElement
    {

        public Dictionary<string, object?> Map { get; private set; }

        public Metadata()
        {
            Map = [];
        }

        internal Metadata(Dictionary<string, object?> map) 
        { 
            Map = new Dictionary<string, object?>(map) ?? [];
        }


        private static readonly Metadata empty = new();
        internal static Metadata Empty = empty;


        public override bool Equals(object? other)
        {
            return other is Metadata otherMetadata && Map.Count == otherMetadata.Map.Count && !Map.Except(otherMetadata.Map).Any();
        }

        public override int GetHashCode()
        {
            int resul = "<empty>".GetHashCode();

            foreach(var kvp in Map)
                resul = HashCode.Combine(resul, kvp.Key, kvp.Value);

            return resul;
        }

        public override JToken ToJsonObject()
        {
            JObject jsonMap = [];

            foreach (KeyValuePair<string, object?> kvp in Map)
            {
                if (kvp.Value == null)
                    jsonMap.Add(kvp.Key);
                else if (kvp.Value is Metadata metadata)
                    jsonMap.Add(kvp.Key, metadata.ToJsonObject());
                else if (kvp.Value is Metadata[] metadataArray)
                {
                    jsonMap.Add(kvp.Key, new JArray(metadataArray.Select(elem => elem.ToJsonObject())));
                }
                else if (kvp.Value is Array array)
                {
                    jsonMap.Add(kvp.Key, new JArray(array));
                }
                else if (kvp.Value is string str)
                    jsonMap.Add(kvp.Key, JToken.Parse($"\"{str}\""));
                else
                {
                    string? parsed = kvp.Value.ToString();

                    if (parsed != null)
                        jsonMap.Add(kvp.Key, JToken.Parse(parsed));
                    else
                        jsonMap.Add(kvp.Key);
                }
            }

            return jsonMap;
        }

        public override string GetJsonPath()
        {
            return string.Empty;
        }

        public override string GetJsonPathExpanded()
        {
            return string.Empty;
        }

        public override string ToScalaObjectString(bool sortFields = false, bool includeEmpty = true, string wrap = "Array")
        {
            string builderConstructor = "new MetadataBuilder()";
            string putCommand = string.Empty;

            foreach (KeyValuePair<string, object?> kvp in Map)
            {
                
                if(kvp.Value == null)
                    putCommand += $".putNull(\"{kvp.Key}\")";
                else if (kvp.Value is bool)
                    putCommand += $".putBoolean(\"{kvp.Key}\", {kvp.Value})";
                else if (kvp.Value is bool[] boolArray)
                    putCommand += $".putBooleanArray(\"{kvp.Key}\", Array({string.Join(", ", boolArray)}))";
                else if (kvp.Value is double)
                    putCommand += $".putDouble(\"{kvp.Key}\", {kvp.Value})";
                else if (kvp.Value is double[] doubleArray)
                    putCommand += $".putDoubleArray(\"{kvp.Key}\", Array({string.Join(", ", doubleArray)}))";
                else if (kvp.Value is long)
                    putCommand += $".putLong(\"{kvp.Key}\", {kvp.Value})";
                else if (kvp.Value is long[] longArray)
                    putCommand += $".putLongArray(\"{kvp.Key}\", Array({string.Join(", ", longArray)}))";
                else if (kvp.Value is string)
                    putCommand += $".putString(\"{kvp.Key}\", \"{kvp.Value}\")";
                else if (kvp.Value is string[] stringArray)
                    putCommand += $".putStringArray(\"{kvp.Key}\", Array({string.Join(", ", stringArray.Select(s => $"\"{s}\""))}))";
                else if (kvp.Value is Metadata metadata)
                    putCommand += $".putMetadata(\"{kvp.Key}\", {metadata.ToScalaObjectString(sortFields, includeEmpty, wrap)})";
                else if (kvp.Value is Metadata[] metadataArray)
                    putCommand += $".putMetadataArray(\"{kvp.Key}\", Array({string.Join(", ", metadataArray.Select(m => m.ToScalaObjectString(sortFields, includeEmpty, wrap)))}))";

            }

            return builderConstructor + putCommand + ".build()";
        }

        public override string ToPythonString(bool sortFields = false, bool includeEmpty = true)
        {
            return ToJsonObject().ToString(Formatting.None).Replace('\"', '\'');
        }

        public override JsonSparkElement Clone()
        {
            return new Metadata(Map);
        }

        public override void UpdateFrom(JsonSparkElement newValue)
        {
            if (newValue is not Metadata newMetadata)
                return;

            Map.Clear();
            foreach (var kvp in newMetadata.Map)
                Map.Add(kvp.Key, kvp.Value);
        }

        internal class Builder
        {
            private readonly Dictionary<string, object?> builderMap;

            internal Builder(Metadata? metadata = null)
            {
                if(metadata == null)
                    builderMap = [];
                else
                    builderMap = new Dictionary<string, object?>(metadata.Map);
            }

            internal Builder Put(string key, object? value)
            {
                builderMap.Add(key, value);
                return this;
            }

            internal Metadata Build()
            {
                return new Metadata(builderMap);
            }
        }

    }
}
