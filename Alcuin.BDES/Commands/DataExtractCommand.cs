// <copyright file="DataExtractionCommand.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Alcuin.Parser.Model;
using Alcuin.Parser.Monitoring;
using Alcuin.Parser.Workflow;

namespace Alcuin.BDES.Commands
{
    internal class DataExtractCommand : Command
    {
        public DataExtractCommand(IMonitoringManager monitoringManager)
            : base(Step.DataExtraction, monitoringManager)
        {
        }

        public override void Process(ProcessingContext processingContext)
        {
            var persons = new Dictionary<string, Person>();
            foreach (var sheet in processingContext.AvailableSheets)
            {
                foreach (var row in sheet.GetRows())
                {
                    foreach (var column in sheet.AvailableColumns)
                    {
                        var result = column.GetCellValue(row);
                    }
                }
            }
        }
    }
}