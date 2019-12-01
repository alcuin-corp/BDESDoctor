// <copyright file="IndicatorParser.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Alcuin.BDES.Indicators.Parser.Raw;

namespace Alcuin.BDES.Interfaces
{
    internal interface IRawIndicatorReader
    {
        IEnumerable<RawIndicator> LoadInidcatorFromFile(string path);
    }
}