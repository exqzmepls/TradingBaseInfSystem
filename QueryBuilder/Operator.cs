using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    public enum OperatorType : int
    {
        EQUAL,
        NOT_EQUAL,
        LESS_THAN,
        GREATER_THAN,
        NOT_LESS_THAN,
        NOT_GREATER_THAN,
        ANY
    }

    public class Operator
    {
        public static readonly List<string> signs = new List<string>() { "=", "!=", "<", ">", ">=", "<=" };

        //public static List<Operator> operators = new List<Operator>
        //{
        //    new Operator("="),
        //    new Operator("!="),
        //    new Operator("<"),
        //    new Operator("<="),
        //    new Operator(">"),
        //    new Operator(">=")
        //};

        public Operator(string sign)
        {
            for (int i=0; i < signs.Count; i++)
            {
                if (signs[i] == sign)
                {
                    Sign = sign;
                    Type = (OperatorType)i;
                    break;
                }
            }
            if (Sign == null)
            {
                Type = OperatorType.ANY;
            }
        }

        //static Operator _equal = new Operator(OperatorType.EQUAL);
        //static Operator _notEqual = new Operator(OperatorType.NOT_EQUAL);
        //static Operator _lessThan = new Operator(OperatorType.LESS_THAN);
        //static Operator _greaterThan = new Operator(OperatorType.GREATER_THAN);
        //static Operator _notLessThan = new Operator(OperatorType.NOT_LESS_THAN);
        //static Operator _notGreaterThan = new Operator(OperatorType.NOT_GREATER_THAN);

        public OperatorType Type { get; private set; }

        public string Sign { get; private set; }

        public override string ToString()
        {
            return Sign;
        }
    }
}
