using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    public class QuantitativeComparer<TEntity>
    {
        PropertyInfo _propertyInfo;

        public QuantitativeComparer(string propertyName)
        {
            _propertyInfo = typeof(TEntity).GetProperty(propertyName);
        }

        public bool Compare(TEntity entity, IComparable value, OperatorType operatorType)
        {
            IComparable propertyValue = (IComparable)_propertyInfo.GetValue(entity);
            if (propertyValue == null) return true;
            int result = propertyValue.CompareTo(value);
            switch (operatorType)
            {
                case OperatorType.EQUAL:
                    return result == 0;

                case OperatorType.NOT_EQUAL:
                    return result != 0;

                case OperatorType.GREATER_THAN:
                    return result > 0;

                case OperatorType.LESS_THAN:
                    return result < 0;

                case OperatorType.NOT_LESS_THAN:
                    return result >= 0;

                case OperatorType.NOT_GREATER_THAN:
                    return result <= 0;

                case OperatorType.ANY:
                    return true;
            }
            return false;
        }
    }
}
