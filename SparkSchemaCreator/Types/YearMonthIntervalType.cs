namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class YearMonthIntervalType : IntervalType
    {

        public override string TypeName
        {
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

        public override string TypeNameApi => $"YearMonthIntervalType({StartField}, {EndField})";

        public YearMonthIntervalType(byte startField, byte endField) : base(startField, endField) { }

        public YearMonthIntervalType() : base(0, 0) { }

        private static string FieldToString(byte field)
        {
            return field switch
            {
                0 => "year",
                1 => "month",
                _ => throw new Exception($"Invalid field id '{field}' in year-month interval.Supported interval fields: 0, 1."),
            };
        }
    }
}