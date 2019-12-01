// <copyright file="AbsenceColumnProvider.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Alcuin.BDES.Domain.Columns;

namespace Alcuin.BDES.Domain
{
    internal class AbsenceColumnProvider : IColumnProvider
    {
        public List<Column> GetColumns()
        {
            return new List<Column>()
            {
                new TextColumn(ColumnNames.Identifier, true, true)
            };
        }
    }
}
