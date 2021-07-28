using System;

namespace QueryBuilder
{
    public abstract class Condition { }

    public class Condition<TValue> : Condition
    {
        public TValue Value { get; set; }

        public Condition(TValue value)
        {
            Value = value;
        }
    }

    public class CompareCondition: Condition<IComparable>
    {
        public Operator Operator { get; set; }
        
        public CompareCondition(IComparable value, Operator op) : base(value)
        {
            Operator = op;
        }

        public override string ToString()
        {
            return $"{Operator} {Value}";
        }
    }
}
