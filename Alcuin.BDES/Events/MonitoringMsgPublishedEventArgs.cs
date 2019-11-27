// <copyright file="MonitoringEventArgs.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES
{
    public class MonitoringMsgPublishedEventArgs : EventArgs
    {
        internal MonitoringMsgPublishedEventArgs(MonitoringMessage monitoringMsg)
        {
            this.Code = monitoringMsg.Code;
            this.Message = monitoringMsg.Message;
            this.Step = monitoringMsg.Step;
        }

        public string Code { get; }

        public string Message { get; }

        public Step Step { get; }
    }
}
