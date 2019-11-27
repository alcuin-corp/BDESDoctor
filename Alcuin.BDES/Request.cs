using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alcuin.BDES.Indicators;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES
{
    public class Request : IRequest
    {
        private int progressRate;

        private bool isFinished;

        internal Request(string filePath, int referenceYear)
        {
            this.FilePath = filePath;
            this.ReferenceYear = referenceYear;
            this.PublishedMessages = new Dictionary<string, List<MonitoringMessage>>();
            this.Indicators = new List<Indicator>();
        }

        public event EventHandler<MonitoringMsgPublishedEventArgs> MonitoringMsgPublished;

        public event EventHandler<StepChangedEventArgs> StepChanged;

        public event EventHandler<ProcessFinishedEventArgs> ProcessFinished;

        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        public Dictionary<string, List<MonitoringMessage>> PublishedMessages { get; }

        public string FilePath { get; }

        public int ProgressRate
        {
            get => this.progressRate;
            set
            {
                if (this.progressRate != value)
                {
                    this.progressRate = value;
                    this.RaiseProgressChanged();
                }
            }
        }

        public string OutputFilePath { get; internal set; }

        public string LogFilePath { get; internal set; }

        public int ReferenceYear { get; }

        public string CurrentStep { get; private set; }

        public bool IsFailed { get; internal set; }

        public bool IsFinished
        {
            get => this.isFinished;
            internal set
            {
                if (this.isFinished != value && value)
                {
                    this.isFinished = true;
                    this.RaiseProcessFinished();
                }
            }
        }

        internal List<Indicator> Indicators { get; private set; }

        public void Run()
        {
            var workflow = new Workflow.Workflow(this);
            Task.Factory.StartNew(workflow.Process);
        }

        internal void AppendMessage(string code, string message)
        {
            var monitoringMsg = new MonitoringMessage(code, message, this.CurrentStep);
            if (!this.PublishedMessages.TryGetValue(monitoringMsg.Code, out var storedMessages))
            {
                this.PublishedMessages[monitoringMsg.Code] = new List<MonitoringMessage> { monitoringMsg };
            }
            else
            {
                storedMessages.Add(monitoringMsg);
            }

            this.MonitoringMsgPublished?.Invoke(this, new MonitoringMsgPublishedEventArgs(monitoringMsg));
        }

        internal void RaiseStepChanged(string step)
        {
            if (this.CurrentStep != step)
            {
                var oldStep = this.CurrentStep;
                this.CurrentStep = step;
                this.StepChanged?.Invoke(this, new StepChangedEventArgs(oldStep, this.CurrentStep));
            }
        }

        internal void RaiseProcessFinished()
        {
            this.ProgressRate = 100;
            this.ProcessFinished?.Invoke(this, new ProcessFinishedEventArgs(this.IsFailed));
        }

        private void RaiseProgressChanged()
        {
            this.ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(this.ProgressRate));
        }
    }
}