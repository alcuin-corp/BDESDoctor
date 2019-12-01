using System.Collections.Generic;
using Alcuin.BDES.Domain;
using Aspose.Cells;

namespace Alcuin.BDES.Workflow
{
    internal class ProcessingContext
    {
        public ProcessingContext()
        {
            this.AvailableSheets = new List<Sheet>();
        }

        public string OutputFileName { get; internal set; }

        internal Workbook Workbook { get; set; }

        internal List<Sheet> AvailableSheets { get; set; }
    }
}