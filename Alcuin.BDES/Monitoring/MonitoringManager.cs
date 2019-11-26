namespace Alcuin.BDES.Monitoring
{
    internal class MonitoringManager : IMonitoringManager
    {
        public MonitoringManager(Request requestResult)
        {
            this.RequestResult = requestResult;
        }

        public Request RequestResult { get; }

        public void AppendMessage(string monitoringCode, string monitoringMessage)
        {
            this.RequestResult.AppendMessage(monitoringCode, monitoringMessage);
        }
    }
}
