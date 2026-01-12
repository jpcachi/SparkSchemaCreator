using SparkSchemaCreator.Controls.FastColoredTextBox;
using SparkSchemaCreator.Json;
using SparkSchemaCreator.Types;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace SparkSchemaCreator.Utils
{
    internal static class StructFieldUtils
    {
        internal static StructType? ParseStringToSchema(string text, bool isSample)
        {
            try
            {
                bool integersAsLongs = SchemaSettings.Instance.IntegersAsLongs;
                bool checkIllegalCharacters = SchemaSettings.Instance.CheckIllegalCharactersInNames;

                return isSample ?
                    SampleMessageToSchema.Instance.ParseToStructType(text, integersAsLongs, false, checkIllegalCharacters) :
                    JsonSchemaToSchema.Instance.ParseSchemaJson(text, integersAsLongs, false, checkIllegalCharacters);
            }
            catch (Exception ex)
            {
                string msg = "The current json is not a valid " + (isSample ? "sample json" : "Spark schema json") + ":\n\n{0}";
                MessageBox.Show(string.Format(msg, ex.Message), "Import Json", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
    }
}
