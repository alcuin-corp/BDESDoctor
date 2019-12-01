// <copyright file="IndicatorProvider.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Alcuin.BDES.Indicators;

namespace Alcuin.BDES.Interfaces
{
    internal interface IIndicatorProvider
    {
        Dictionary<string, List<Indicator>> Load();
    }
}