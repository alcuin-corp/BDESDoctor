using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    [Binding]
    public class RawIndicatorGenerationStep : StepBase
    {
        public RawIndicatorGenerationStep(ScenarioContext injectedContext) : base(injectedContext)
        {
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

            File.WriteAllText("RawIndicators.csv", stringbuilder.ToString());
        }

    }
}
