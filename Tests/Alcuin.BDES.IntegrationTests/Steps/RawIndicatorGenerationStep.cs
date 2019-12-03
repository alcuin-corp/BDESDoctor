using System.IO.Abstractions;
using System.Linq;
using Alcuin.BDES.Indicators.Parser.Raw;
using Alcuin.BDES.IntegrationTests.Hooks;
using Alcuin.BDES.Ninject;
using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    [Binding]
    public class RawIndicatorGenerationStep : StepBase
    {
        private readonly IFileSystem fileSystem;

        public RawIndicatorGenerationStep(ScenarioContext injectedContext) : base(injectedContext)
        {
            ServiceLocator.Resolve(out this.fileSystem);
        }

        [Given(@"I have the folowing indicators definition")]
        public void GivenIHaveTheFolowingIndicatorsDefinition(Table table)
        {
            var rawIndicators = table.Rows.Select(row => new RawIndicator
            {
                Domain = row["Domaine"],
                SubDomain = row["Sous Domaine"],
                Field = row["Champs"],
                Name = row["Indicateur"],
                SheetName = row["Onglet"],
                Formula = row["Formule"]
            });

            this.context.Get<FakeRawDataReader>().AddRawIndicators(rawIndicators);
        }

    }
}
