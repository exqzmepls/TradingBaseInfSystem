using System.Reflection;

namespace QueryBuilder
{
    class ForeignKeyFinder<TEntity>
    {
        PropertyInfo _propertyInfo;

        public ForeignKeyFinder(string propertyName)
        {
            _propertyInfo = typeof(TEntity).GetProperty(propertyName + "Id", typeof(int));
        }

        public bool Equal(TEntity entity, int value)
        {
            int propertyValue = (int)_propertyInfo.GetValue(entity);
            return propertyValue == value;
        }
    }
}
