using System;

namespace Alcuin.BDES.Monitoring
{
    internal interface IMonitoringManager
    {
        void AppendMessage(MonitoringType monitoringType, string monitoringMessage);

        void Append(Exception exception);

        void Dump();
    }
}