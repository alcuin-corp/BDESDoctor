using System;
using Alcuin.BDES.Interfaces;
using Alcuin.BDES.Ninject;

namespace Alcuin.BDES.Monitoring
{
    internal class MonitoringManager : IMonitoringManager
    {
        private IMonitoringDumper monitoringDumper;

        public MonitoringManager(Request requestResult)
        {
            this.Request = requestResult;
            ServiceLocator.Resolve(out this.monitoringDumper);
        }

        public Request Request { get; }

        public void Append(Exception exception)
        {
            this.AppendMessage(MonitoringType.Error, exception.Message);
        }

        public void AppendMessage(MonitoringType monitoringType, string monitoringMessage)
        {
            this.Request.AppendMessage(monitoringType, monitoringMessage);
        }

        public void Dump()
        {
            this.monitoringDumper.Dump(this.Request);
        }
    }
}