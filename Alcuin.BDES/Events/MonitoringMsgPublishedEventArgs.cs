// <copyright file="MonitoringEventArgs.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System;

namespace Alcuin.BDES
{
    public class MonitoringMsgPublishedEventArgs : EventArgs
    {
        internal MonitoringMsgPublishedEventArgs(string monitoringCode, string monitoringMessage)
        {
            this.MonitoringCode = monitoringCode;
            this.MonitoringMessage = monitoringMessage;
        }

        public string MonitoringCode { get; }

        public string MonitoringMessage { get; }
    }
}
