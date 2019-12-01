using System;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES
{
    public class MonitoringMsgPublishedEventArgs : EventArgs
    {
        internal MonitoringMsgPublishedEventArgs(MonitoringMessage monitoringMsg)
        {
            this.Type = monitoringMsg.Type;
            this.Message = monitoringMsg.Message;
            this.Step = monitoringMsg.Step;
        }

        public MonitoringType Type { get; }

        public string Message { get; }

        public Step Step { get; }
    }
}