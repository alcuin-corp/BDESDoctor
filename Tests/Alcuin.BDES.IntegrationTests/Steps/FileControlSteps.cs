using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    [Binding]
    public class FileControlSteps : StepBase
    {
        public FileControlSteps(ScenarioContext injectedContext)
            : base(injectedContext)
        {
        }

        [Then(@"I should found the following log")]
        public void IShouldFoundTheFollowingMonitoringMessages(Table table)
        {
            var publishedMessages = this.context.Get<TestContext>().PublishedMessages;
            var expectedMessage = table.Rows.Select(row => new { Code = row["Code"], Message = row["Message"] });
            foreach (var item in expectedMessage)
            {
                Assert.IsTrue(publishedMessages.TryGetValue(item.Code, out var actualMessages), $"Missing code {item.Code} in published messages");
                Assert.Contains(item.Message, actualMessages, $"Missing monitoring message : {item.Message}");
            }
        }

        [Then(@"I should found the following (.*) messages")]
        public void IShouldFoundTheFollowingMessages(string messageCode, Table table)
        {
            var publishedMessages = this.context.Get<TestContext>().PublishedMessages;
            Assert.IsTrue(publishedMessages.TryGetValue(messageCode, out var actualMessages), $"Missing code {messageCode} in published messages");
            var expectedMessage = table.Rows.Select(row => row["Message"]);
            foreach (var message in expectedMessage)
            {
                Assert.Contains(message, actualMessages, $"Missing monitoring message : {message}");
            }
        }

        [Then(@"the process should fail")]
        public void ThenTheProcessShouldFailed()
        {
            var request = this.context.Get<IRequest>();
            Assert.IsTrue(request.IsFailed);
        }

        [Then(@"the process should be succes")]
        public void ThenTheProcessShouldBeSucces()
        {
            var request = this.context.Get<IRequest>();
            Assert.IsTrue(request.IsFinished);
            Assert.IsFalse(request.IsFailed);
        }

        [Then(@"the process should be exited in the (.*) step")]
        public void ThenTheProcessShouldExitStep(string stepName)
        {
            var request = this.context.Get<IRequest>();
            Assert.AreEqual(stepName, request.CurrentStep.ToString());
        }
    }
}
