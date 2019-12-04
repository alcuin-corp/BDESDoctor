using System.Collections.Generic;

namespace Alcuin.BDES.Indicators.Dumper
{
    internal interface IIndicatorDumper
    {
        void Dump(IEnumerable<Indicator> indicators, int referenceYear, string outputFilePath, string asposLicense);
    }
}