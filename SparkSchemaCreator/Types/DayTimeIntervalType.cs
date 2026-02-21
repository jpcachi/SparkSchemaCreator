namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class DayTimeIntervalType : IntervalType
    {

        public override string TypeName { 
            get
            {
                string startFieldName = FieldToString(StartField);
                string endFieldName = FieldToString(EndField);

                if (startFieldName == endFieldName)
                    return $"interval {startFieldName}";
                
                if (StartField < EndField)
                    return $"interval {startFieldName} to {endFieldName}";
                
                throw new Exception($"interval {startFieldName} to {endFieldName} is invalid.");
            } 
        }

        public override string TypeNameApi => $"DayTimeIntervalType({StartField}, {EndField})";


        public DayTimeIntervalType(byte startField, byte endField) : base(startField, endField) { }

        public DayTimeIntervalType() : base(0, 0) { }

        private static string FieldToString(byte field)
        {
            return field switch
            {
                0 => "day",
                1 => "hour",
                2 => "minute",
                3 => "second",
                _ => throw new Exception($"Invalid field id '{field}' in day-time interval. Supported interval fields: 0, 1, 2, 3."),
            };
        }
    }
}
