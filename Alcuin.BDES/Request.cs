using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Alcuin.BDES.Indicators;
using Alcuin.BDES.Interfaces;
using Alcuin.BDES.Monitoring;
using Alcuin.BDES.Ninject;

namespace Alcuin.BDES
{
    internal class Request : IRequest
    {
        private decimal progressRate;

        private bool isFinished;
        private Step currentStep;
        private int lastProgressRate;

        internal Request(string filePath, int referenceYear, Stream asposeLicense = null)
        {
            this.FilePath = filePath;
            this.ReferenceYear = referenceYear;
            this.PublishedMessages = new Dictionary<MonitoringType, List<MonitoringMessage>>();
            this.Indicators = new List<Indicator>();
            this.AsposeLicense = asposeLicense;
        }

        public event EventHandler<MonitoringMsgPublishedEventArgs> MonitoringMsgPublished;

        public event EventHandler<StepChangedEventArgs> StepChanged;

        public event EventHandler<ProcessFinishedEventArgs> ProcessFinished;

        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        public Dictionary<MonitoringType, List<MonitoringMessage>> PublishedMessages { get; }

        public string FilePath { get; }

        public Stream AsposeLicense { get; }

        public decimal ProgressRate
        {
            get => this.progressRate;
            set
            {
                this.progressRate = value;
                this.RaiseProgressChanged();
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
            var processFinishedEventArgs = new ProcessFinishedEventArgs(this.IsFailed, this.CurrentStep, this.Exception)
            {
                LogFilePath = this.LogFilePath,
                OutputFilePath = this.OutputFilePath
            };

            this.ProcessFinished?.Invoke(this, processFinishedEventArgs);
        }

        private void RaiseProgressChanged()
        {
            var currentProgress = (int)this.ProgressRate;
            if (this.lastProgressRate < currentProgress)
            {
                this.lastProgressRate = currentProgress;
                this.ProgressChanged?.Invoke(this, new ProgressChangedEventArgs((int)this.ProgressRate));
            }
        }

        private void RaiseStepChanged(Step oldStep, Step newStep)
        {
            this.StepChanged?.Invoke(this, new StepChangedEventArgs(oldStep, newStep));
        }
    }
}