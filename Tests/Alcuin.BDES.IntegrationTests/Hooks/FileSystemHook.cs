using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using Alcuin.BDES.IntegrationTests.Steps;
using Alcuin.BDES.Ninject;
using Aspose.Cells;
using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Hooks
{
    [Binding]
    public sealed class FileSystemHook : StepBase
    {
        public FileSystemHook(ScenarioContext injectedContext)
            : base(injectedContext)
        {
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ServiceLocator.RegisterInstance<IFileSystem>(new MockFileSystem());
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var workbook = this.context.Get<Workbook>();
            workbook.Dispose();
        }
    }
}
