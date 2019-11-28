using System.Collections.Generic;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    internal class TestContext
    {
        public TestContext()
        {
            this.PublishedMessages = new Dictionary<MonitoringType, List<string>>();
            this.ReceivedProgressRates = new List<int>();
            this.ChangedSteps = new List<Step>();
        }

        public bool IsFinished { get; set; }

        public bool IsFailed { get; set; }

        public Dictionary<MonitoringType, List<string>> PublishedMessages { get; }

        public List<int> ReceivedProgressRates { get; }

        public List<Step> ChangedSteps { get; }
    }
}
