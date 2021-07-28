using System.Reflection;

namespace QueryBuilder
{
    public class SubstringFinder<TEntity>
    {
        private PropertyInfo _propertyInfo;

        public SubstringFinder(string propertyName)
        {
            // поиск свойства с заданным именем
            _propertyInfo = typeof(TEntity).GetProperty(propertyName, typeof(string));
        }

        // Поиск подстроки
        public bool Find(TEntity entity, string substring)
        {
            // поиск вхождения подстроки в свойстве переденного экземпляра сущности
            return (_propertyInfo.GetValue(entity) as string).Contains(substring);
        }
    }
}
