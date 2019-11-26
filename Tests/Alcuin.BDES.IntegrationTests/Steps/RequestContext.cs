using System.Collections.Generic;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    internal class RequestTestContext
    {
        public RequestTestContext()
        {
            this.PublishedMessages = new Dictionary<string, List<string>>();
        }

        public bool IsFinished { get; set; }
        
        public bool IsFailed { get; set; }

        public Dictionary<string, List<string>> PublishedMessages;
    }

    
}
