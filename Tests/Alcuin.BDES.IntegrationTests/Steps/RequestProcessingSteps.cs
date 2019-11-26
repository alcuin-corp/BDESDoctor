using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    [Binding]
    public sealed class RequestProcessingSteps : StepBase
    {
        private readonly ManualResetEventSlim manualResetEventSlim;

        private readonly TestContext testContext;

        public RequestProcessingSteps(ScenarioContext injectedContext) : base(injectedContext)
        {
            this.manualResetEventSlim = new ManualResetEventSlim();
            this.testContext = new TestContext();
            this.context.Set(this.testContext);
        }

        [When(@"I start processing the file (.*) for the period of (.*)")]
        public void WhenIStartProcessingTheFile(string filePath, string yearStr)
        {
            var year = int.Parse(yearStr);
            var request = RequestFactory.Create(filePath, year);
            this.context.Set(request);
            request.OnProgress += Request_OnProgress;
            request.MonitoringMsgPublished += Request_MonitoringMsgPublished;
            request.ProcessFinished += Request_ProcessFinished;
            RunAndWaitForProcessing(request);
        }

        private void Request_OnProgress(object sender, ProgressEventArgs e)
        {
            this.testContext.ReceivedProgressRates.Add(e.ProgressRate);
        }

        private void Request_ProcessFinished(object sender, ProcessFinishedEventArgs e)
        {
            this.testContext.IsFinished = true;
            this.testContext.IsFailed = e.IsFailed;
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

            if (!this.testContext.PublishedMessages.TryGetValue(e.Code, out var messages))
            {
                this.testContext.PublishedMessages[e.Code] = messages = new List<string> { e.Message };
            }

            messages.Add(e.Message);
        }
    }
}
