using System.Collections.Generic;
using System.IO;
using System.Linq;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Indicators;
using Aspose.Cells;

namespace Alcuin.BDES.Workflow
{
    internal class ProcessingContext
    {
        private bool isFinished;
        private Step currentStep;

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
            get => this.currentStep;
            set
            {
                if (this.currentStep != value)
                {
                    this.currentStep = value;
                    this.Request.RaiseStepChanged(this.currentStep);
                }
            }
        }

        public ProcessingException ProcessingException { get; internal set; }

        public string FileName { get; }

        public string OutputFileName { get; internal set; }

        public string FilePath => this.Request.FilePath;

        public bool IsFinished
        {
            get => this.isFinished;
            set
            {
                this.isFinished = value;
                if (value)
                {
                    this.Request.RaiseProcessFinished(this.IsFailed);
                }
            }
        }

        public bool IsFailed { get; set; }

        internal Workbook Workbook { get; set; }

        internal List<Sheet> AvailableSheets { get; set; }

        internal int ReferenceYear { get; set; }
    }
}
