using SparkSchemaCreator.Controls.FastColoredTextBox;
using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SparkSchemaCreator.Utils
{
    internal class SyntaxHighlightning
    {

        private readonly string scalaObjectsRegexp = $"\\s*({DataType.TypeNamesApi}|MetadataBuilder)|(\\s+Array)|(\\s+Seq)|(\\s+List)|(\\s+Nil)|(org.apache.spark.sql.types._)";
        
        private readonly TextStyle scalaKeyword = new(new SolidBrush(Color.FromArgb(208, 37, 45)), null, FontStyle.Regular);
        private readonly TextStyle scalaIdentifierObject = new(new SolidBrush(Color.FromArgb(131, 85, 218)), null, FontStyle.Regular);
        private readonly TextStyle scalaLiteral = new(new SolidBrush(Color.FromArgb(10, 50, 103)), null, FontStyle.Regular);
        private readonly TextStyle scalaLangObject = new(new SolidBrush(Color.FromArgb(149, 56, 7)), null, FontStyle.Regular);
        private readonly TextStyle scalaNumbersLiterals = new(new SolidBrush(Color.FromArgb(5, 80, 174)), null, FontStyle.Regular);


        public void HighlightScalaCode(object sender, TextChangedEventArgs e)
        {

            e.ChangedRange.ClearStyle(scalaKeyword);
            e.ChangedRange.ClearStyle(scalaIdentifierObject);
            e.ChangedRange.ClearStyle(scalaLiteral);
            e.ChangedRange.ClearStyle(scalaLangObject);

            e.ChangedRange.SetStyle(scalaLiteral, "\"[^\"]*\"");
            e.ChangedRange.SetStyle(scalaNumbersLiterals, "true|false|\\d+");

            e.ChangedRange.SetStyle(scalaIdentifierObject, scalaObjectsRegexp);
            e.ChangedRange.SetStyle(scalaLangObject, "schemaObject");

            e.ChangedRange.SetStyle(scalaKeyword, "import|val |new|=|::");
        }

        public void HighlightPythonCode(object sender, TextChangedEventArgs e)
        {

            e.ChangedRange.ClearStyle(scalaKeyword);
            e.ChangedRange.ClearStyle(scalaIdentifierObject);
            e.ChangedRange.ClearStyle(scalaLiteral);
            e.ChangedRange.ClearStyle(scalaLangObject);

            e.ChangedRange.SetStyle(scalaLiteral, "'[^']*'");
            e.ChangedRange.SetStyle(scalaNumbersLiterals, "True|False|true|false|\\*|\\d+");

            e.ChangedRange.SetStyle(scalaIdentifierObject, scalaObjectsRegexp);

            e.ChangedRange.SetStyle(scalaKeyword, "from|import|new|=");
        }

        public void HighlightPrintedSchema(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(scalaKeyword);
            e.ChangedRange.ClearStyle(scalaIdentifierObject);
            e.ChangedRange.ClearStyle(scalaLangObject);

            e.ChangedRange.SetStyle(scalaKeyword, " \\||-- ");
            e.ChangedRange.SetStyle(scalaLangObject, DataType.TypeNamesWithSpaces);
            e.ChangedRange.SetStyle(scalaLiteral, "\\(nullable = (True|False)\\)|\\(containsNull = (True|False)\\)|\\(valueContainsNull = (True|False)\\)");
        }
    }
}
