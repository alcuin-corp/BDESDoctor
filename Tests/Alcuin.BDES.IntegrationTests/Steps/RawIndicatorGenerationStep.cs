using System.IO;
using System.IO.Abstractions;
using System.Text;
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
            var stringbuilder = new StringBuilder();
            stringbuilder.AppendLine(string.Join(";", table.Header));
            foreach (var row in table.Rows)
            {
                stringbuilder.AppendLine(string.Join(";", row.Values));
            }

            var path = @"Ressources\RawIndicators.csv";
            this.fileSystem.Directory.CreateDirectory(Path.GetDirectoryName(path));
            this.fileSystem.File.WriteAllText(path, stringbuilder.ToString());
        }

    }
}
