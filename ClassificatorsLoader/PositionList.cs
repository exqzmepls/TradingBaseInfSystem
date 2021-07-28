using DbConnection;
using System;
using System.Collections.Generic;

namespace ClassificatorsLoader
{
    class PositionList
    {
        static List<Position> positions = new List<Position>()
        {
            new Position() { Id = 10, Name = "Администратор" },
            new Position() { Id = 20, Name = "Продавец" },
            new Position() { Id = 21, Name = "Старший продавец" }
        };

        public static void Load()
        {
            try
            {
                using (InfSystemContext db = new InfSystemContext())
                {
                    db.Positions.AddRange(positions);
                    db.SaveChanges();
                }
                Console.WriteLine("Должности добавлены");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
