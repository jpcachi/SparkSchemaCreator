using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator
{
    internal class SchemaSettings
    {
        private SchemaSettings() { }

        private static SchemaSettings? instance;
        internal static SchemaSettings Instance => instance ??= new SchemaSettings();

        internal enum ScalaCollection
        {
            Array, List, Seq, DoubleColon
        }

        internal bool IntegersAsLongs { get; set; } = true;
        internal bool IncludeEmptyStructAndArrayTypes { get; set; } = true;
        internal bool CheckIllegalCharactersInNames { get; set; } = true;
        internal ScalaCollection WrapFieldsIn { get; set; } = ScalaCollection.Array;

        internal string WrapFieldsInAsString 
        { 
            get 
            {
                return WrapFieldsIn switch
                {
                    ScalaCollection.Array => "Array",
                    ScalaCollection.List => "List",
                    ScalaCollection.Seq => "Seq",
                    ScalaCollection.DoubleColon => "::",
                    _ => "Array",
                };
            } 
        }
    }
}
