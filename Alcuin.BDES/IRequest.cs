using System;
using System.Collections.Generic;

namespace Alcuin.BDES
{
    public interface IRequest
    {
        event EventHandler<MonitoringMsgPublishedEventArgs> MonitoringMsgPublished;

        event EventHandler<ProcessingFinishedEventArgs> ProcessFinished;

        event EventHandler<StepChangedEventArgs> StepChanged;

        int RequestId { get; }

        bool IsFinished { get; }

        bool IsFailed { get; }

        Step CurrentStep { get; }

        IEnumerable<KeyValuePair<string, List<string>>> PublishedMessages { get; }

        void Run();
    }
}