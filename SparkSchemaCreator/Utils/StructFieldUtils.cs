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

        internal static string INVALID_CHARS = " ,;{}()\n\t=";

        internal static void CheckIfStructFieldHasValidName(string name)
        {
            if(INVALID_CHARS.Intersect(name).Any())
                throw new ArgumentException($"Attribute name \"{name}\" contains invalid character(s) among \"{INVALID_CHARS}\".");
        }

        internal static StructType? ParseStringToSchema(string text, bool isSample)
        {
            try
            {
                bool integersAsLongs = SchemaSettings.Instance.IntegersAsLongs;
                bool checkIllegalCharacters = SchemaSettings.Instance.CheckIllegalCharactersInNames;

                return isSample ?
                    SampleMessageToSchema.ParseToStructType(text, integersAsLongs, false, checkIllegalCharacters) :
                    JsonSchemaToSchema.ParseSchemaJson(text, integersAsLongs, false, checkIllegalCharacters);
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
