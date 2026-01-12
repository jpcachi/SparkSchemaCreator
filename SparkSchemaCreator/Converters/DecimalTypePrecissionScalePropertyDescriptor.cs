using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    internal class DecimalTypePrecissionScalePropertyDescriptor(bool precission) : PropertyDescriptor(precission ? "Precission" : "Scale", null)
    {

        public override TypeConverter Converter => new DecimalTypePrecissionScaleConverter();

        public override Type ComponentType => typeof(DecimalType);

        public override bool IsReadOnly => false;

        public override Type PropertyType => typeof(int);

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object? GetValue(object? component)
        {
            if(component is DecimalType decimalType)
                return precission ? decimalType.Precission : decimalType.Scale;

            return null;
        }

        public override void ResetValue(object component)
        {
            if(component is DecimalType decimalType)
            {
                if (precission)
                    decimalType.Precission = 10;
                else
                    decimalType.Scale = 0;
            }
        }

        public override void SetValue(object? component, object? value)
        {
            if(component is DecimalType decimalType && value is int number)
            {

                if (precission)
                {
                    if(number < decimalType.Scale)
                        decimalType.Scale = number;

                    decimalType.Precission = number;
                }
                else
                    decimalType.Scale = number > decimalType.Precission ? decimalType.Precission : number;
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
    }
}
