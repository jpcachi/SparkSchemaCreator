using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    internal class MetadataTypeDelegator(Type delegatingType) : TypeDelegator(delegatingType)
    {
        public override string Name
        {
            get
            {
                var dna = typeImpl.GetCustomAttribute<DisplayNameAttribute>();
                return dna != null ? dna.DisplayName : typeImpl.Name;
            }
        }
    }
}
