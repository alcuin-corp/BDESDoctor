using System.Collections.Generic;

namespace Alcuin.BDES.Indicators.Dumper
{
    internal interface IIndicatorDumper
    {
        void Dump(IEnumerable<Indicator> indicators, string outputFilePath);
    }
}