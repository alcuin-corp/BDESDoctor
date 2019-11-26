using System;
using System.Collections.Generic;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES
{
    public interface IRequest
    {
        event EventHandler<MonitoringMsgPublishedEventArgs> MonitoringMsgPublished;

        event EventHandler<ProcessFinishedEventArgs> ProcessFinished;

        event EventHandler<StepChangedEventArgs> StepChanged;

        event EventHandler<ProgressEventArgs> OnProgress;

        public string OutputFilePath { get; }

        public string LogFilePath { get; }

        bool IsFinished { get; }

        bool IsFailed { get; }

        Step CurrentStep { get; }

        IEnumerable<KeyValuePair<string, List<MonitoringMessage>>> PublishedMessages { get; }

        void Run();
    }
}