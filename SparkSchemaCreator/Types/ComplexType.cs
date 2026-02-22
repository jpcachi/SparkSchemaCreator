using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal abstract class ComplexType : DataType
    {
        [Browsable(false)]
        public StructField? FieldOfWhichItIsType { get; internal set; }

        public StructField? GetClosestParent()
        {
            if (FieldOfWhichItIsType != null)
                return FieldOfWhichItIsType;

            if (ArrayParent != null)
                return ArrayParent.GetClosestParent();

            if(MapParent != null)
                return MapParent.GetClosestParent();

            return null;
        }

        public override string GetJsonPath()
        {
            if (FieldOfWhichItIsType != null)
                return FieldOfWhichItIsType.GetJsonPath();

            return base.GetJsonPath();
        }

        public override string GetJsonPathExpanded()
        {
            if (FieldOfWhichItIsType != null)
                return FieldOfWhichItIsType.Name;

            return base.GetJsonPathExpanded();
        }
    }
}
