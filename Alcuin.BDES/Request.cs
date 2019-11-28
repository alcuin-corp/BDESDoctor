using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alcuin.BDES.Indicators;
using Alcuin.BDES.Monitoring;
using Alcuin.BDES.Ninject;
using Alcuin.BDES.Workflow;

namespace Alcuin.BDES
{
    internal class Request : IRequest
    {
        private int progressRate;

        private bool isFinished;

        private Step currentStep;

        internal Request(string filePath, int referenceYear)
        {
            this.FilePath = filePath;
            this.ReferenceYear = referenceYear;
            this.PublishedMessages = new Dictionary<MonitoringType, List<MonitoringMessage>>();
            this.Indicators = new List<Indicator>();
        }

        public event EventHandler<MonitoringMsgPublishedEventArgs> MonitoringMsgPublished;

        public event EventHandler<StepChangedEventArgs> StepChanged;

        public event EventHandler<ProcessFinishedEventArgs> ProcessFinished;

        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        public Dictionary<MonitoringType, List<MonitoringMessage>> PublishedMessages { get; }

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

        public Exception Exception { get; internal set; }

        public string OutputFilePath { get; internal set; }

        public string LogFilePath { get; internal set; }

        public int ReferenceYear { get; }

        public bool IsFailed { get; internal set; }

        public Step CurrentStep
        {
            get => this.currentStep;
            internal set
            {
                if (this.currentStep != value)
                {
                    var oldStep = this.currentStep;
                    this.currentStep = value;
                    this.RaiseStepChanged(oldStep, value);
                }
            }
        }

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
            var workflow = ServiceLocator.Resolve<IWorkflow>();
            Task.Factory.StartNew(() => workflow.Process(this));
        }

        internal void AppendMessage(MonitoringType monitoringType, string message)
        {
            var monitoringMsg = new MonitoringMessage(monitoringType, message, this.CurrentStep);
            if (!this.PublishedMessages.TryGetValue(monitoringMsg.Type, out var storedMessages))
            {
                this.PublishedMessages[monitoringMsg.Type] = new List<MonitoringMessage> { monitoringMsg };
            }
            else
            {
                storedMessages.Add(monitoringMsg);
            }

            this.MonitoringMsgPublished?.Invoke(this, new MonitoringMsgPublishedEventArgs(monitoringMsg));
        }

        private void RaiseProcessFinished()
        {
            this.ProgressRate = 100;
            this.ProcessFinished?.Invoke(this, new ProcessFinishedEventArgs(this.IsFailed, this.CurrentStep, this.Exception));
        }

        private void RaiseProgressChanged()
        {
            this.ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(this.ProgressRate));
        }

        private void RaiseStepChanged(Step oldStep, Step newStep)
        {
            this.StepChanged?.Invoke(this, new StepChangedEventArgs(oldStep, newStep));
        }
    }
}