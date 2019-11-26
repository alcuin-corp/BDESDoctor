using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    [Binding]
    public class WorkflowControlSteps : StepBase
    {
        public WorkflowControlSteps(ScenarioContext injectedContext)
            : base(injectedContext)
        {
        }

        [Then(@"all monitoring message should be notified")]
        public void ThenAllMonitoringMessageShouldBeNotified()
        {
            var request = this.context.Get<IRequest>();
            var requestContext = this.context.Get<TestContext>();
            foreach (var messageList in request.PublishedMessages)
            {
                Assert.IsTrue(requestContext.PublishedMessages.TryGetValue(messageList.Key, out var notifiedMessages));
                foreach (var message in messageList.Value)
                {
                    Assert.Contains(message.Message, notifiedMessages);
                }
            }
        }

        [Then(@"I should get a notification when the process is finished")]
        public void ThenIShouldGetANotificationWhenTheProcessIsFinished()
        {
            var requestContext = this.context.Get<TestContext>();
            Assert.IsTrue(requestContext.IsFinished);
        }

        [Then(@"I should get a progress rate notification at (.*) %")]
        public void ThenIShouldGetAProgressRateNotificationAt(int value)
        {
            var requestContext = this.context.Get<TestContext>();
            Assert.Contains(value, requestContext.ReceivedProgressRates);
        }


    }
}
