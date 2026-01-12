using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Json
{
    public static class JsonUtils
    {
        public static string FormatJson(string json, Formatting formating)
        {
            using var stringReader = new StringReader(json);
            using var stringWriter = new StringWriter();
            var jsonReader = new JsonTextReader(stringReader);
            var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = formating };
            jsonWriter.WriteToken(jsonReader);
            return stringWriter.ToString();
        }
        
    }
}
