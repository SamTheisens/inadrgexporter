using System;

namespace InadrgExporter
{
    public struct FieldMapping : IEquatable<FieldMapping>
    {
        public int Number { get; set; }
        public string ExcelColumn { get; set; }
        public string DictionaryColumn { get; set; }
        public int ColumnNumber { get; set; }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (FieldMapping)) return false;
            return Equals((FieldMapping) obj);
        }

        public bool Equals(FieldMapping obj)
        {
            return obj.Number == Number && Equals(obj.ExcelColumn, ExcelColumn) && Equals(obj.DictionaryColumn, DictionaryColumn) && obj.ColumnNumber == ColumnNumber;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Number;
                result = (result*397) ^ (ExcelColumn != null ? ExcelColumn.GetHashCode() : 0);
                result = (result*397) ^ (DictionaryColumn != null ? DictionaryColumn.GetHashCode() : 0);
                result = (result*397) ^ ColumnNumber;
                return result;
            }
        }

        public static bool operator ==(FieldMapping left, FieldMapping right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FieldMapping left, FieldMapping right)
        {
            return !left.Equals(right);
        }
    }
}