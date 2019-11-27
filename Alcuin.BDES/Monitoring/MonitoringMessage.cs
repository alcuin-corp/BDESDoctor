namespace Alcuin.BDES.Monitoring
{
    public class MonitoringMessage
    {
        internal MonitoringMessage(string code, string message, string step)
        {
            this.Code = code;
            this.Message = message;
            this.Step = step;
        }

        public string Code { get; }

        public string Message { get; }

        public string Step { get; set; }
    }
}
