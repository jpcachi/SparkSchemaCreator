using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal abstract class JsonSparkElement
    {
        public abstract JToken ToJsonObject();
        public virtual void BuildFormattedString(string prefix, StringConcat stringConcat, int maxDepth) { }
        public virtual string ToJsonString(bool sortFields = false, bool includeEmpty = true, bool pretty = false) => ToJsonObject().ToString(pretty ? Formatting.Indented : Formatting.None);
        public abstract string ToScalaObjectString(bool sortFields = false, bool includeEmpty = true, string wrap = "Array");
        public abstract string ToPythonString(bool sortFields = false, bool includeEmpty = true);
        public abstract string GetJsonPath();
        public abstract string GetJsonPathExpanded();

        public abstract JsonSparkElement Clone();
        public abstract void UpdateFrom(JsonSparkElement newValue);

    }
}
