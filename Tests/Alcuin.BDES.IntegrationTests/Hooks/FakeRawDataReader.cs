using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alcuin.BDES.Indicators.Parser.Raw;
using Alcuin.BDES.Interfaces;

namespace Alcuin.BDES.IntegrationTests.Hooks
{
    internal class FakeRawDataReader : IRawIndicatorReader
    {
        private readonly List<RawIndicator> rawIndicators;

        public FakeRawDataReader()
        {
            this.rawIndicators = new List<RawIndicator>();
        }

        public void AddRawIndicators(IEnumerable<RawIndicator> rawIndicators)
        {
            this.rawIndicators.AddRange(rawIndicators);
        }

        public void AddRawIndicator(RawIndicator rawIndicator)
        {
            this.rawIndicators.Add(rawIndicator);
        }

        public IEnumerable<RawIndicator> LoadEmbadedRawIndicators()
        {
            return rawIndicators;
        }

        public void Clear()
        {
            this.rawIndicators.Clear();
        }
    }
}
