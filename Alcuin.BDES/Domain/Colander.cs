// <copyright file="Colander.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Alcuin.BDES.Indicators;
using Aspose.Cells;

namespace Alcuin.BDES.Domain
{
    internal class Colander
    {
        public bool CanPass(List<Column> columns, Row row)
        {
            return true;
        }

        public List<Indicator> Indicators { get; set; }

        public List<Colander> Colanders { get; set; }
    }
}
