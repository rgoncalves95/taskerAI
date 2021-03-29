namespace TaskerAI.Common
{
    namespace TaskerAI.Common
    {
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Text.RegularExpressions;
        using DocumentFormat.OpenXml.Packaging;
        using DocumentFormat.OpenXml.Spreadsheet;

        public class SpreadsheetParser<T> : IContentParser<IEnumerable<T>>
        {
            private static readonly Regex regex = new Regex("[A-Za-z]+", RegexOptions.Compiled);

            private readonly IMapper<Dictionary<string, string>, T> mapper;

            public string ContentType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            public SpreadsheetParser(IMapper<Dictionary<string, string>, T> mapper) => this.mapper = mapper;

            public IEnumerable<T> Parse(byte[] content)
            {
                var parsedObjects = new List<T>();

                using (var spreadsheetDocument = SpreadsheetDocument.Open(new MemoryStream(content), false))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    SharedStringTablePart stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();

                    foreach (Row row in worksheetPart.Worksheet.Descendants<Row>().Where(r => r.HasChildren).Skip(1))
                    {
                        var obj = new Dictionary<string, string>();

                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            string value = cell.InnerText;
                            int index = int.Parse(value);

                            if (cell.DataType != null && cell.DataType == CellValues.SharedString)
                            {
                                value = stringTable.SharedStringTable.ElementAt(index).InnerText;
                            }

                            Console.WriteLine($"Console: {value}");
                            obj.Add(GetColumn(cell.CellReference.Value), value);
                        }

                        parsedObjects.Add(this.mapper.Map(obj));
                    }

                    //Location location = null;
                    //int column = 1;

                    //var reader = OpenXmlReader.Create(worksheetPart);
                    //while (reader.Read())
                    //{
                    //    if (reader.ElementType == typeof(CellValue))
                    //    {
                    //        if (int.TryParse(reader.GetText(), out int readerIndex))
                    //        {
                    //            if (readerIndex < 8)
                    //            {
                    //                continue;
                    //            }

                    //            column++;

                    //            if ((readerIndex % 8) == 0)
                    //            {
                    //                column = 1;
                    //                location = new Location();
                    //                locations.Add(location);
                    //            }

                    //            string value = stringTable.SharedStringTable.ElementAt(readerIndex).InnerText;
                    //            location[column] = value;
                    //            Console.WriteLine($"Console: {value}");
                    //        }
                    //    }
                    //}
                }

                return parsedObjects;
            }

            private static string GetColumn(string cellName) => regex.Match(cellName).Value;
        }
    }

}
