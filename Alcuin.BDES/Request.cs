using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alcuin.BDES.Indicators;

namespace Alcuin.BDES
{
    public class Request : IRequest
    {
        private readonly Dictionary<string, List<string>> publishedMessages;

        internal Request(string filePath, int referenceYear)
        {
            this.FilePath = filePath;
            this.ReferenceYear = referenceYear;
            this.publishedMessages = new Dictionary<string, List<string>>();
            this.Indicators = new List<Indicator>();
        }

        public event EventHandler<MonitoringMsgPublishedEventArgs> MonitoringMsgPublished;

        public event EventHandler<StepChangedEventArgs> StepChanged;

        public event EventHandler<ProcessingFinishedEventArgs> ProcessFinished;

        public string FilePath { get; }

        public int ReferenceYear { get; }

        public int RequestId => throw new NotImplementedException();

        public Step CurrentStep { get; private set; }

        public bool IsFailed { get; private set; }

        public bool IsFinished { get; private set; }

        public IEnumerable<KeyValuePair<string, List<string>>> PublishedMessages => this.publishedMessages;

        internal List<Indicator> Indicators { get; private set; }

        public void Run()
        {
            var workflow = new Workflow.Workflow(this);
            Task.Factory.StartNew(workflow.Process);
        }

        internal void AppendMessage(string monitoringCode, string monitoringMessage)
        {
            if (!this.publishedMessages.TryGetValue(monitoringCode, out var storedMessages))
            {
                this.publishedMessages[monitoringCode] = new List<string> { monitoringMessage };
            }
            else
            {
                storedMessages.Add(monitoringMessage);
            }

            this.MonitoringMsgPublished?.Invoke(this, new MonitoringMsgPublishedEventArgs(monitoringCode,monitoringMessage));
        }

        internal void RaiseStepChanged(Step step)
        {
            var oldStep = this.CurrentStep;
            this.CurrentStep = step;
            this.StepChanged?.Invoke(this, new StepChangedEventArgs(oldStep, this.CurrentStep));
        }

        internal void RaiseProcessFinished(bool isFailed)
        {
            this.IsFinished = true;
            this.IsFailed = isFailed;
            this.ProcessFinished?.Invoke(this, new ProcessingFinishedEventArgs(this.IsFailed));
        }
    }
}