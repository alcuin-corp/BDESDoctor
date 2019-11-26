using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    [Binding]
    public sealed class FileRequestProcessingSteps : StepBase
    {
        private readonly ManualResetEventSlim manualResetEventSlim;

        private readonly RequestTestContext requestContext;

        public FileRequestProcessingSteps(ScenarioContext injectedContext) : base(injectedContext)
        {
            this.manualResetEventSlim = new ManualResetEventSlim();
            this.requestContext = new RequestTestContext();
            this.context.Set(this.requestContext);
        }

        [When(@"I start processing the file (.*) for the period of (.*)")]
        public void WhenIStartProcessingTheFile(string filePath, string yearStr)
        {
            var year = int.Parse(yearStr);
            var request = RequestFactory.Create(filePath, year);
            this.context.Set(request);
            request.MonitoringMsgPublished += Request_MonitoringMsgPublished;
            request.ProcessFinished += Request_ProcessFinished;
            RunAndWaitForProcessing(request);
        }

        private void Request_ProcessFinished(object sender, ProcessingFinishedEventArgs e)
        {
            this.requestContext.IsFinished = true;
            this.requestContext.IsFailed = e.IsFailed;
        }

        private void RunAndWaitForProcessing(IRequest request)
        {
            this.manualResetEventSlim.Reset();
            request.ProcessFinished += (s, a) => this.manualResetEventSlim.Set();
            request.Run();
            this.manualResetEventSlim.Wait();
        }

        private void Request_MonitoringMsgPublished(object sender, MonitoringMsgPublishedEventArgs e)
        {
            if (!this.requestContext.PublishedMessages.TryGetValue(e.MonitoringCode, out var messages))
            {
                this.requestContext.PublishedMessages[e.MonitoringCode] = messages = new List<string> { e.MonitoringMessage };
            }

            messages.Add(e.MonitoringMessage);
        }
    }
}
