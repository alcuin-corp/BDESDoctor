using System.Collections.Generic;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    internal class TestContext
    {
        public TestContext()
        {
            this.PublishedMessages = new Dictionary<string, List<string>>();
            this.ReceivedProgressRates = new List<int>();
            this.ChangedSteps = new List<string>();
        }

        public bool IsFinished { get; set; }

        public bool IsFailed { get; set; }

        public Dictionary<string, List<string>> PublishedMessages { get; }

        public List<int> ReceivedProgressRates { get; }

        public List<string> ChangedSteps { get; }
    }
}
