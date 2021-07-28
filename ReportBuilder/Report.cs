using DbConnection;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ReportBuilder
{
    public class Report
    {
        private FileInfo _file;
        private List<EntityProperty> _properties;
        private IList _entities;
        private Type _entityType;
        private string _reportName;

        const int _headerRowIndex = 1;
        const int _startRowIndex = _headerRowIndex + 1;

        public Report(string name, FileInfo file, List<EntityProperty> properties, IList entities, Type entityType)
        {
            _reportName = name;
            _file = file;
            _properties = properties;
            _entities = entities;
            _entityType = entityType;
        }

        public void Create()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(_file))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add(_reportName);
                ws.Select();

                PrintHeaders(ws);

                PrintData(ws);

                ExcelAddress field = new ExcelAddress(_headerRowIndex, 1, _headerRowIndex + _entities.Count, _properties.Count);
                ws.Cells[field.Address].AutoFitColumns();
                ws.Select(field);

                package.Save();
            }
        }

        private void PrintHeaders(ExcelWorksheet sheet)
        {
            int colIndex = 1;
            foreach (EntityProperty property in _properties)
            {
                ExcelRange cell = sheet.Cells[_headerRowIndex, colIndex++];
                cell.Value = property.HeaderText;
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            }
        }

        private void PrintData(ExcelWorksheet sheet)
        {
            int rowIndex = _startRowIndex;
            foreach (object obj in _entities)
            {
                int colIndex = 1;
                foreach (EntityProperty property in _properties)
                {
                    PropertyInfo propertyInfo = _entityType.GetProperty(property.Name);
                    sheet.Cells[rowIndex, colIndex++].Value = propertyInfo.GetValue(obj)?.ToString();
                }
                rowIndex++;
            }
        }
    }
}
