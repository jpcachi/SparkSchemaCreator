using SparkSchemaCreator.Types;
using SparkSchemaCreator.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using static SparkSchemaCreator.Comparer.JsonSparkComparer;

namespace SparkSchemaCreator.Comparer
{
    internal class JsonSparkComparer
    {
        private (ComparisonResult, ComparisonNodeCollection?) CompareDataTypes(DataType dataType1, DataType dataType2)
        {
            ComparisonResult resul = ComparisonResult.Equal;
            ComparisonNodeCollection? children = null;

            if (dataType1.TypeName != dataType2.TypeName)
                resul |= ComparisonResult.TypeDifference;

            else if (dataType1 is StructType struct1 && dataType2 is StructType struct2)
            {
                children = CompareStructsToNodes(struct1, struct2);

                if (children.HasOnlyMissingFieldsDifference)
                    resul |= ComparisonResult.ChildMissingFieldDifference;

                else if (children.HasDifferences)
                    resul |= ComparisonResult.ChildDifference;

                if (children.HasMetadataDifferences)
                    resul |= ComparisonResult.ChildMetadataDifference;
            }
            else if (dataType1 is ArrayType array1 && dataType2 is ArrayType array2)
            {
                if (array1.ContainsNull != array2.ContainsNull)
                    resul |= ComparisonResult.ContainsNullDifference;

                children = CompareArraysToNode(array1, array2);

                if (children.HasOnlyMissingFieldsDifference)
                    resul |= ComparisonResult.ChildMissingFieldDifference;

                else if (children.HasDifferences)
                    resul |= ComparisonResult.ChildDifference;

                if (children.HasMetadataDifferences)
                    resul |= ComparisonResult.ChildMetadataDifference;

            }
            else if (dataType1 is MapType map1 && dataType2 is MapType map2)
            {
                if (map1.ValueContainsNull != map2.ValueContainsNull)
                    resul |= ComparisonResult.ContainsNullDifference;

                children = CompareMapsToNodes(map1, map2);

                if (children.HasOnlyMissingFieldsDifference)
                    resul |= ComparisonResult.ChildMissingFieldDifference;

                else if (children.HasDifferences)
                    resul |= ComparisonResult.ChildDifference;

                if (children.HasMetadataDifferences)
                    resul |= ComparisonResult.ChildMetadataDifference;
            }

            return (resul, children);
        }

        public ComparisonNode CompareFieldsToNode(StructField field1, StructField field2)
        {
            (ComparisonResult resul, ComparisonNodeCollection? children) = CompareDataTypes(field1.DataType, field2.DataType);

            if (field1.IsNullable != field2.IsNullable)
                resul |= ComparisonResult.NullableDifference;

            if(field1.Metadata.ToJsonString() != field2.Metadata.ToJsonString())
                resul |= ComparisonResult.MetadataDifference;

            return new ComparisonNode(field1, field2, resul, children);

        }

        private ComparisonNodeCollection CompareArraysToNode(ArrayType array1, ArrayType array2)
        {
            (ComparisonResult resul, ComparisonNodeCollection? children) = CompareDataTypes(array1.ElementType, array2.ElementType);

            return new ComparisonNodeCollection([new ComparisonNode(array1.ElementType, array2.ElementType, resul, children, "<element>")]);
        }

        private ComparisonNodeCollection CompareMapsToNodes(MapType map1, MapType map2)
        {
            (ComparisonResult keyResul, ComparisonNodeCollection? keyChildren) = CompareDataTypes(map1.KeyType, map2.KeyType);
            (ComparisonResult valueResul, ComparisonNodeCollection? valueChildren) = CompareDataTypes(map1.ValueType, map2.ValueType);

            return new ComparisonNodeCollection([new ComparisonNode(map1.KeyType, map2.KeyType, keyResul, keyChildren, "<key>"), new ComparisonNode(map1.ValueType, map2.ValueType, valueResul, valueChildren, "<value>")]);
        }


        public ComparisonNodeCollection CompareStructsToNodes(StructType struct1, StructType struct2)
        {
            IEnumerable<ComparisonNode> fieldsInStruct1NotInStruct2 = struct1.Fields.Where(x => !struct2.Fields.Select(y => y.Name).Contains(x.Name)).Select(x => new ComparisonNode(x, null, ComparisonResult.MissingField));
            IEnumerable<ComparisonNode> fieldsInStruct2NotInStruct1 = struct2.Fields.Where(x => !struct1.Fields.Select(y => y.Name).Contains(x.Name)).Select(x => new ComparisonNode(null, x, ComparisonResult.MissingField));

            IEnumerable<StructField> commonFieldsInStruct1 = struct1.Fields.Where(x => !fieldsInStruct1NotInStruct2.Select(y => y.Name).Contains(x.Name)).OrderBy(x => (x.Name, x.DataType.TypeName, x.IsNullable));
            IEnumerable<StructField> commonFieldsInStruct2 = struct2.Fields.Where(x => !fieldsInStruct2NotInStruct1.Select(y => y.Name).Contains(x.Name)).OrderBy(x => (x.Name, x.DataType.TypeName, x.IsNullable));

            IEnumerable<ComparisonNode> differentFieldsInCommon = commonFieldsInStruct1.Zip(commonFieldsInStruct2).Select(x => CompareFieldsToNode(x.First, x.Second));

            return [.. fieldsInStruct1NotInStruct2.Concat(fieldsInStruct2NotInStruct1).Concat(differentFieldsInCommon)];
        }
    }
}
