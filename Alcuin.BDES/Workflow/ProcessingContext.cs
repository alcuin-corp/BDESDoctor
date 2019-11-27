using System.Collections.Generic;
using System.IO;
using Alcuin.BDES.Domain;
using Aspose.Cells;

namespace Alcuin.BDES.Workflow
{
    internal class ProcessingContext
    {
        public ProcessingContext(Request request)
        {
            this.Request = request;
            this.FileName = Path.GetFileName(this.FilePath);
            this.AvailableSheets = new List<Sheet>();
            this.ReferenceYear = request.ReferenceYear;
        }

        public Request Request { get; }

        public Step CurrentStep
        {
            get => this.Request.CurrentStep;
            set => this.Request.RaiseStepChanged(value);
        }

        public int ProgressRate
        {
            get => this.Request.ProgressRate;
            set => this.Request.ProgressRate = value;
        }

        public ProcessingException ProcessingException { get; internal set; }

        public string FileName { get; }

        public string OutputFileName { get; internal set; }

        public string FilePath => this.Request.FilePath;

        public bool IsFailed
        {
            get => this.Request.IsFailed;
            set => this.Request.IsFailed = value;
        }

        internal Workbook Workbook { get; set; }

        internal List<Sheet> AvailableSheets { get; set; }

        internal int ReferenceYear { get; set; }
    }
}
