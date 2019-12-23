using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    [Binding]
    public class IndicatorControlStep : StepBase
    {
        public IndicatorControlStep(ScenarioContext injectedContext)
            : base(injectedContext)
        {
        }

        [Then(@"I should compute (.*) indicators")]
        public void ThenIShouldComputeIndicator(int indicatorCount)
        {
            var request = this.context.Get<IRequest>() as Request;
            Assert.AreEqual(indicatorCount, request.Indicators.Count, "Indicator count missmatch !");
        }

        [Then(@"I should found the following indicators")]
        public void IShouldFoundTheFollowingIndicators(Table table)
        {
            var request = this.context.Get<IRequest>() as Request;
            var indicators = request.Indicators.ToDictionary(x => x.Name.ToLowerInvariant());
            Assert.IsNotNull(indicators);
            foreach (var row in table.Rows)
            {
                Assert.IsTrue(indicators.TryGetValue(row["Indicator"].ToLowerInvariant(), out var indicator), $"Missing indicator {row["Indicator"]} !");
                var groupName = row["Group"].ToString();
                Assert.IsTrue(indicator.GroupedValues.TryGetValue(groupName, out var value), $"Missing group {groupName}");
                if (table.Header.Contains("Average"))
                {
                    var ExpectedAvg = decimal.Parse(row["Average"]);
                    Assert.AreEqual(ExpectedAvg, value.Average, $"Expected average for group {groupName} of indicator {indicator.Name} : {ExpectedAvg}, but was {value.Average}");
                }
                else
                {
                    var expectedCount = int.Parse(row["Count"]);
                    Assert.AreEqual(expectedCount, value.Count, $"Expected count for group [{groupName}] of indicator [{indicator.Name}] is : {expectedCount}, but was {value.Count}");
                }
            }
        }
    }
}
