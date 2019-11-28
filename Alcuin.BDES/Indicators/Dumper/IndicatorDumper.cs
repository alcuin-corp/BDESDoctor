using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using Alcuin.BDES.Domain.Columns;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Ninject;
using Aspose.Cells;

namespace Alcuin.BDES.Indicators.Dumper
{
    internal class IndicatorDumper : IIndicatorDumper
    {
        private readonly IFileSystem fileSystem;
        private readonly string[] headers;

        public IndicatorDumper(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            this.headers = this.GetOutputFileHeaders();
        }

        public void Dump(IEnumerable<Indicator> indicators, string outputFilePath)
        {
            var workBook = new Workbook();
            workBook.Worksheets.Clear();
            var worksheet = workBook.Worksheets.Add("Indicateurs");
            this.AppendHeaders(worksheet);
            var rowId = 0;
            foreach (var indicator in indicators)
            {
                rowId++;
                foreach (var group in indicator.groupedValues)
                {
                    var row = worksheet.Cells.Rows[rowId];
                    row[0].Value = group.Key;
                    row[1].Value = indicator.Domain;
                    row[2].Value = indicator.SubDomain;
                    row[3].Value = indicator.Name;
                    row[4].Value = indicator.Field;
                    row[7].Value = "Numerique";
                }
            }

            this.fileSystem.SaveWorkbook(workBook, outputFilePath);
        }

        private void AppendHeaders(Worksheet worksheet)
        {
            for (int i = 0; i < this.headers.Length; i++)
            {
                worksheet.Cells[0, i].Value = this.headers[i];
            }
        }

        private string[] GetOutputFileHeaders()
        {
            return new[]
            {
                OutputColumnNames.Structure,
                OutputColumnNames.Domaine,
                OutputColumnNames.SubDomaine,
                OutputColumnNames.Indicator,
                OutputColumnNames.FieldName,
                OutputColumnNames.EntryHelp,
                OutputColumnNames.FieldType,
                OutputColumnNames.Unit,
                OutputColumnNames.Period,
                OutputColumnNames.NumericValue,
                OutputColumnNames.TextValue,
                OutputColumnNames.GeneralTrend,
                OutputColumnNames.Trend,
                OutputColumnNames.Comment,
            };
        }
    }
}
