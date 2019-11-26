namespace Alcuin.BDES.Monitoring
{
    internal interface IMonitoringManager
    {
        void AppendMessage(string monitoringCode, string monitoringMessage);
    }
}