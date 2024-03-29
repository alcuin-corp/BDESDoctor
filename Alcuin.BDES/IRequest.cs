﻿using System;
using System.Collections.Generic;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES
{
    public interface IRequest
    {
        event EventHandler<MonitoringMsgPublishedEventArgs> MonitoringMsgPublished;

        event EventHandler<ProcessFinishedEventArgs> ProcessFinished;

        event EventHandler<StepChangedEventArgs> StepChanged;

        event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        string OutputFilePath { get; }

        string LogFilePath { get; }

        bool IsFinished { get; }

        bool IsFailed { get; }

        Step CurrentStep { get; }

        Dictionary<MonitoringType, List<MonitoringMessage>> PublishedMessages { get; }

        void Run();
    }
}