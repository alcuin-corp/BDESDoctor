using System;

namespace Alcuin.BDES.Interfaces
{
    internal interface IMonitoringManager
    {
        void AppendMessage(MonitoringType monitoringType, string monitoringMessage);

        void Append(Exception exception);

        void Dump();
    }
}