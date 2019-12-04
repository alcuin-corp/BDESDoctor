using System.Collections.Generic;
using System.IO;

namespace Alcuin.BDES.Indicators.Dumper
{
    internal interface IIndicatorDumper
    {
        void Dump(IEnumerable<Indicator> indicators, int referenceYear, string outputFilePath, Stream asposLicense);
    }
}