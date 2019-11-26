// <copyright file="OutputGenerateCommand.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.IO;
using Alcuin.BDES.Domain.Columns;
using Alcuin.BDES.Monitoring;
using Aspose.Cells;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class OutputGenerateCommand : Command
    {
        private readonly string[] headers;

        public OutputGenerateCommand(IMonitoringManager monitoringManager)
            : base(Step.DataAnalyzing, monitoringManager)
        {
            this.headers = this.GetOutputFileHeaders();
        }

        public override void Process(ProcessingContext processingContext)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(processingContext.FileName);
            processingContext.OutputFileName = $"{fileNameWithoutExtension}-Output.xlsx";
            var workBook = new Workbook();
            workBook.Worksheets.Clear();
            foreach (var sheet in processingContext.AvailableSheets)
            {
                var worksheet = workBook.Worksheets.Add(sheet.Name);
                this.AppendHeaders(worksheet);
                var rowId = 0;
                foreach (var indicator in sheet.Indicators)
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
            }

            SaveWorkBook(processingContext, workBook);
        }

        private static void SaveWorkBook(ProcessingContext processingContext, Workbook workBook)
        {
            var outputDirectory = @"C:\DEV\Outputs";
            Directory.CreateDirectory(outputDirectory);
            workBook.Save(Path.Combine(outputDirectory, processingContext.OutputFileName));
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
