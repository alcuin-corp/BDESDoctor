using System.Collections.Generic;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Indicators;

namespace Alcuin.BDES.Interfaces
{
    internal interface IIndicatorProvider
    {
        Dictionary<SheetName, List<Indicator>> Load();
    }
}