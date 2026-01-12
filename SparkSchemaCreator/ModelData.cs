using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator
{
    internal class ModelData
    {
        public StructType Root { get; private set; }

        public ModelData() 
        { 
            Root = new StructType();
        }

        public void SetRoot(StructType root)
        {
            Root = root;
        }
    }
}
