using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    public class StepBase //: TechTalk.SpecFlow.Steps
    {
        protected readonly ScenarioContext context;

        public StepBase(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
    }
}
