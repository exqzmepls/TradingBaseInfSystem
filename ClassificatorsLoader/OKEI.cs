using DbConnection;
using OfficeOpenXml;
using System;
using System.IO;

namespace ClassificatorsLoader
{
    class OKEI
    {
        static string fileName = @"okei.xlsx";

        public static void Load()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var pack = new ExcelPackage(new FileInfo(fileName)))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets[0];

                int currentRow = 8;
                while (true)
                {
                    int id = int.Parse(ws.Cells[$"B{currentRow}"].Text);
                    string name = ws.Cells[$"C{currentRow}"].Text;
                    string shortName = ws.Cells[$"D{currentRow}"].Text;
                    if (string.IsNullOrEmpty(shortName) || string.IsNullOrWhiteSpace(shortName))
                    {
                        break;
                    }
                    else
                    {
                        //AddUnit(id, name, shortName);
                        try
                        {
                            AddUnit(id, name, shortName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    currentRow++;
                }
            }
        }

        static void AddUnit(int id, string name, string shortName)
        {
            Unit unit = new Unit() { Id = id, Name = name, ShortName = shortName };
            using (InfSystemContext db = new InfSystemContext())
            {
                db.Units.Add(unit);
                db.SaveChanges();
            }
            Console.WriteLine($"Единица измерения \"{unit.Name}\" (id={unit.Id}) добавлена");
        }
    }
}
