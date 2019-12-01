﻿using System.Collections.Generic;
using Alcuin.BDES.Domain.Columns;

namespace Alcuin.BDES.Domain
{
    internal class DiseaseColumnProvider : IColumnProvider
    {
        public List<Column> GetColumns()
        {
            return new List<Column>()
            {
                new TextColumn(ColumnNames.Identifier, true, true),
            };
        }
    }
}