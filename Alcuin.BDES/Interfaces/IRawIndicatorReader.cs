using System.Collections.Generic;
using Alcuin.BDES.Indicators.Parser.Raw;

namespace Alcuin.BDES.Interfaces
{
    internal interface IRawIndicatorReader
    {
        IEnumerable<RawIndicator> LoadInidcatorFromFile(string path);
    }
}