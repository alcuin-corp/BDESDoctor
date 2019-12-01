namespace Alcuin.BDES.Monitoring
{
    public class MonitoringMessage
    {
        internal MonitoringMessage(MonitoringType monitoringType, string message, Step step)
        {
            this.Type = monitoringType;
            this.Message = message;
            this.Step = step;
        }

        public MonitoringType Type { get; }

        public string Message { get; }

        public Step Step { get; set; }
    }
}