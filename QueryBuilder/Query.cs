using System.Collections.Generic;
using System.Linq;
using DbConnection;

namespace QueryBuilder
{
    public class Query<T>
    {
        private List<EntityProperty> _properties;

        private List<List<Condition>> _conditions;

        private List<T> _set;

        public Query(List<T> set, List<EntityProperty> properties, List<List<Condition>> conditions)
        {
            _properties = properties;
            _conditions = conditions;
            _set = set;
        }

        public List<T> Execute()
        {
            return GetResult(_set);
        }

        private List<T> Copy(List<T> list)
        {
            List<T> result = new List<T>();
            foreach (T item in list) result.Add(item);
            return result;
        }

        private List<T> GetResult(List<T> initall)
        {
            List<T> result = new List<T>(); // результат запроса
            for (int i = 0; i < _conditions.Count; i++) // внешний цикл для прохода по строкам
            {
                List<T> part = Copy(initall); // копия исходного источника данных
                List<Condition> row = _conditions[i]; // текущая строка условий
                for (int j = 0; j < row.Count; j++) // внутренний цикл для прохода по столбцам
                {
                    if (row[j] == null) continue; // если условие отсутствует, то пропускаем
                    EntityProperty property = _properties[j]; // получаем свойство сущности для проверки в условии
                    switch (property.Specimen) // определяем тип свойства
                    {
                        case PropertySpecimen.STRING: // свойство является обычной строкой
                            string substring = (row[j] as Condition<string>).Value; // получаем значение искомой подстроки
                            SubstringFinder<T> substringFinder = new SubstringFinder<T>(property.Name); // создаем экземпляр класса для поиска подстроки
                            part = part.Where(x => substringFinder.Find(x, substring)).ToList(); // отбираем объекты, свойство которых содержат искомую подстроку
                            break;

                        case PropertySpecimen.QUANTITATIVE: // свойство является количественным 
                            CompareCondition compareCondition = row[j] as CompareCondition;
                            QuantitativeComparer<T> quantitativeComparer = 
                                new QuantitativeComparer<T>(property.Name); // экземпляр класса для проверки сравнения
                            part = part.Where(x => quantitativeComparer.Compare(x, compareCondition.Value, compareCondition.Operator.Type)).ToList(); // отбор объектов
                            break;

                        case PropertySpecimen.FOREIGN_KEY: // свойство является внешним ключом
                            int fk = (row[j] as Condition<int>).Value; // получаем искомое значение внешнего ключа
                            ForeignKeyFinder<T> foreignKeyFinder = new ForeignKeyFinder<T>(property.Name); // экземпляр класса посика внешнего ключа
                            part = part.Where(x => foreignKeyFinder.Equal(x, fk)).ToList(); // отбор значений по внешнему ключу
                            break;
                    }
                }
                result = result.Union(part).ToList(); // объединение результатов с предыдущими результатами (result OR part)
            }
            return result; // возврат результата
        }
    }
}
