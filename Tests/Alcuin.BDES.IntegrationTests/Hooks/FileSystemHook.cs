using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using Alcuin.BDES.IntegrationTests.Steps;
using Alcuin.BDES.Interfaces;
using Alcuin.BDES.Ninject;
using Aspose.Cells;
using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Hooks
{
    [Binding]
    public sealed class Hook : StepBase
    {
        private readonly FakeRawDataReader fakeRawDataReader;

        public Hook(ScenarioContext injectedContext)
            : base(injectedContext)
        {
            this.fakeRawDataReader = new FakeRawDataReader();
            this.context.Set(this.fakeRawDataReader);
            ServiceLocator.RegisterInstance<IRawIndicatorReader>(this.fakeRawDataReader);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ServiceLocator.RegisterInstance<IFileSystem>(new MockFileSystem());
            this.fakeRawDataReader.Clear();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var workbook = this.context.Get<Workbook>();
            workbook.Dispose();
        }
    }
}
