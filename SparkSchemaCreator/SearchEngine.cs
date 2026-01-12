using SparkSchemaCreator.Controls;
using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SparkSchemaCreator
{
    internal class SearchEngine
    {

        private readonly ModelData model;
        private readonly Action<StructField>[] onMatchActions;


        private List<StructField>? matches;
        private int indexMatch;
        private StructField? CurrentMatch => matches?[indexMatch];

        internal SearchEngine(ModelData model, params Action<StructField>[] onMatchActions)
        {
            this.model = model;
            this.onMatchActions = onMatchActions;
        }

        private static List<StructField> SearchFieldsRecursively(StructType node, string text, string? dataType, bool metadata, bool caseSensitive)
        {
            List<StructField> matches = [];

            foreach (StructField field in node.Fields)
            {
                if (caseSensitive && text.Split('.').Any(x => field.Name.Contains(x)))
                    matches.Add(field);

                else if (!caseSensitive && text.Split('.').Any(x => field.Name.Contains(x, StringComparison.InvariantCultureIgnoreCase)))
                    matches.Add(field);

                else if (metadata && caseSensitive && text.Split('.').Any(x => field.Metadata.ToJsonString(false, true, false).Contains(x)))
                    matches.Add(field);

                else if (metadata && !caseSensitive && text.Split('.').Any(x => field.Metadata.ToJsonString(false, true, false).Contains(x, StringComparison.InvariantCultureIgnoreCase)))
                    matches.Add(field);


                if (field.DataType is StructType struct1)
                    matches.AddRange(SearchFieldsRecursively(struct1, text, dataType, metadata, caseSensitive));

                else if (field.DataType is ArrayType array)
                    matches.AddRange(SearchFieldsRecursivelyInArray(array, text, dataType, metadata, caseSensitive));

                else if (field.DataType is MapType map)
                    matches.AddRange(SearchFieldsRecursivelyInMap(map, text, dataType, metadata, caseSensitive));

            }

            return matches;
        }

        private static List<StructField> SearchFieldsRecursivelyInArray(ArrayType node, string text, string? dataType, bool metadata, bool caseSensitive)
        {
            if(node.ElementType is StructType structType)
                return SearchFieldsRecursively(structType, text, dataType, metadata, caseSensitive);

            if(node.ElementType is ArrayType arrayType)
                return SearchFieldsRecursivelyInArray(arrayType, text, dataType, metadata, caseSensitive);

            if(node.ElementType is MapType mapType)
                return SearchFieldsRecursivelyInMap(mapType, text, dataType, metadata, caseSensitive);

            return [];
        }

        private static List<StructField> SearchFieldsRecursivelyInMap(MapType node, string text, string? dataType, bool metadata, bool caseSensitive)
        {
            List<StructField> matches = [];

            if (node.KeyType is StructType keyStructType)
                matches.AddRange(SearchFieldsRecursively(keyStructType, text, dataType, metadata, caseSensitive));

            else if (node.KeyType is ArrayType keyArrayType)
                matches.AddRange(SearchFieldsRecursivelyInArray(keyArrayType, text, dataType, metadata, caseSensitive));

            else if (node.KeyType is MapType keyMapType)
                matches.AddRange(SearchFieldsRecursivelyInMap(keyMapType, text, dataType, metadata, caseSensitive));


            if (node.ValueType is StructType valueStructType)
                matches.AddRange(SearchFieldsRecursively(valueStructType, text, dataType, metadata, caseSensitive));

            else if (node.ValueType is ArrayType valueArrayType)
                matches.AddRange(SearchFieldsRecursivelyInArray(valueArrayType, text, dataType, metadata, caseSensitive));

            else if (node.ValueType is MapType valueMapType)
                matches.AddRange(SearchFieldsRecursivelyInMap(valueMapType, text, dataType, metadata, caseSensitive));

            return matches;
        }

        public void ClearSearch()
        {
            matches = null;
            indexMatch = 0;
        }

        public void GetNextSearch(string text, string? dataType, bool metadata, bool caseSensitive, bool backwards)
        {
            if (matches == null)
            {
                matches = [.. SearchFieldsRecursively(model.Root, text, dataType, metadata, caseSensitive)];
                if (matches.Count == 0)
                {
                    MessageBox.Show("Connot find '" + text + "'.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearSearch();
                    return;
                }
            }

            if (matches != null)
            {
                if (indexMatch < matches.Count && indexMatch >= 0 && CurrentMatch != null)
                    Array.ForEach(onMatchActions, (action) => action.Invoke(CurrentMatch));
                

                if (!backwards)
                {
                    if (++indexMatch >= matches.Count)
                    {
                        MessageBox.Show("Found the last ocurrence of '" + text + "' from the top.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        indexMatch = matches.Count > 0 ? matches.Count - 1 : 0;
                    }

                }
                else
                {
                    if (--indexMatch < 0)
                    {
                        MessageBox.Show("Found the last ocurrence of '" + text + "' from the bottom.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        indexMatch = 0;
                    }
                }
            }
        }
    }
}
