using System.Collections.Generic;
using Alcuin.BDES.Indicators;

namespace Alcuin.BDES.Interfaces
{
    internal interface IIndicatorProvider
    {
        Dictionary<string, List<Indicator>> Load();
    }
}