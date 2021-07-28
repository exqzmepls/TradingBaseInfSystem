using DbConnection;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace ClassificatorsLoader
{
    class OKPD
    {
        static string fileName = @"okpd.xlsx";

        public static void Load()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var pack = new ExcelPackage(new FileInfo(fileName)))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets[0];

                int iRow = 0;
                string[] sa;
                List<int> ids;

                //Console.WriteLine("Удаление...");
                //using (InfSystemContext db = new InfSystemContext())
                //{
                //    db.ProductClasses.RemoveRange(db.ProductClasses);
                //    db.SaveChanges();
                //}

                while (true)
                {
                    iRow++;

                    try
                    {
                        string s = ws.Cells[$"B{iRow}"].Text;
                        sa = ws.Cells[$"B{iRow}"].Text.Split('.', ',');
                        Console.WriteLine(ws.Cells[$"B{iRow}"].Text);
                        ids = GetIds(ws.Cells[$"B{iRow}"].Text);
                    }
                    catch
                    {
                        continue;
                    }
                    if (ids[0] > 33)
                    {
                        break;
                    }
                    switch (ids.Count)
                    {
                        case 1:
                            //AddClass(GetId(sa), ws.Cells[$"C{iRow}"].Text);
                            try
                            {
                                AddClass(GetId(sa), ws.Cells[$"C{iRow}"].Text);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 2:
                            if (sa[1].Length > 1)
                            {
                                //AddGroup(GetId(sa), ws.Cells[$"C{iRow}"].Text, GetId(sa[0], sa[1].Substring(0, 1)));
                                try
                                {
                                    AddGroup(GetId(sa), ws.Cells[$"C{iRow}"].Text, GetId(sa[0], sa[1].Substring(0, 1)));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                //AddSubClass(GetId(sa), ws.Cells[$"C{iRow}"].Text, GetId(sa[0]));
                                try
                                {
                                    AddSubClass(GetId(sa), ws.Cells[$"C{iRow}"].Text, GetId(sa[0]));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;

                        case 3:
                            if (sa[2].Length > 1)
                            {
                                //AddKind(GetId(sa), ws.Cells[$"C{iRow}"].Text, GetId(sa[0], sa[1], sa[2].Substring(0, 1)));
                                try
                                {
                                    AddKind(GetId(sa), ws.Cells[$"C{iRow}"].Text, GetId(sa[0], sa[1], sa[2].Substring(0, 1)));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                //AddSubGroup(GetId(sa), ws.Cells[$"C{iRow}"].Text, GetId(sa[0], sa[1]));
                                try
                                {
                                    AddSubGroup(GetId(sa), ws.Cells[$"C{iRow}"].Text, GetId(sa[0], sa[1]));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;

                        case 4:
                            if (ids[3] % 10 == 0)
                            {
                                //AddCategory(GetId(sa), ws.Cells[$"C{iRow}"].Text, GetId(sa[0], sa[1], sa[2]));
                                try
                                {
                                    AddCategory(GetId(sa), ws.Cells[$"C{iRow}"].Text, GetId(sa[0], sa[1], sa[2]));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                            }
                            break;
                    }
                }
            }
        }

        static void AddClass(int id, string name)
        {
            ProductClass productClass = new ProductClass() { Id = id, Name = name };
            using (InfSystemContext db = new InfSystemContext())
            {
                db.ProductClasses.Add(productClass);
                db.SaveChanges();
            }
            Console.WriteLine($"Класс \"{productClass.Name}\" (id={productClass.Id}) добавлен");
        }

        static void AddSubClass(int id, string name, int classId)
        {
            ProductSubclass productSubClass = new ProductSubclass() { Id = id, Name = name, ClassId = classId };
            using (InfSystemContext db = new InfSystemContext())
            {
                db.ProductSubClasses.Add(productSubClass);
                db.SaveChanges();
            }
            Console.WriteLine($"Подкласс \"{productSubClass.Name}\" (id={productSubClass.Id}) добавлен");
        }

        static void AddGroup(int id, string name, int subclassId)
        {
            ProductGroup productGroup = new ProductGroup() { Id = id, Name = name, SubclassId = subclassId };
            using (InfSystemContext db = new InfSystemContext())
            {
                db.ProductGroups.Add(productGroup);
                db.SaveChanges();
            }
            Console.WriteLine($"Группа \"{productGroup.Name}\" (id={productGroup.Id}) добавлена");
        }

        static void AddSubGroup(int id, string name, int groupId)
        {
            ProductSubgroup productSubGroup = new ProductSubgroup() { Id = id, Name = name, GroupId = groupId };
            using (InfSystemContext db = new InfSystemContext())
            {
                db.ProductSubGroups.Add(productSubGroup);
                db.SaveChanges();
            }
            Console.WriteLine($"Подгруппа \"{productSubGroup.Name}\" (id={productSubGroup.Id}) добавлена");
        }

        static void AddKind(int id, string name, int subgroupId)
        {
            ProductKind productKind = new ProductKind() { Id = id, Name = name, SubgroupId = subgroupId };
            using (InfSystemContext db = new InfSystemContext())
            {
                db.ProductKinds.Add(productKind);
                db.SaveChanges();
            }
            Console.WriteLine($"Вид \"{productKind.Name}\" (id={productKind.Id}) добавлен");
        }

        static void AddCategory(int id, string name, int kindId)
        {
            ProductCategory productCategory = new ProductCategory() { Id = id, Name = name, KindId = kindId };
            using (InfSystemContext db = new InfSystemContext())
            {
                db.ProductCategories.Add(productCategory);
                db.SaveChanges();
            }
            Console.WriteLine($"Категория \"{productCategory.Name}\" (id={productCategory.Id}) добавлена");
        }

        static List<int> GetIds(string code)
        {
            List<int> result = new List<int>();
            foreach (var c in code.Split('.', ','))
            {
                result.Add(int.Parse(c));
            }
            return result;
        }

        static int GetId(params string[] ids)
        {
            string result = "";
            foreach (var i in ids)
            {
                result += i;
            }
            return int.Parse(result);
        }
    }
}
