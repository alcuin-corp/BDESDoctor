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
                new TextColumn(ColumnNames.Identifier, true, true),
                new NumericColumn(ColumnNames.AbsenceDayCount, false),
                new NumericColumn(ColumnNames.AbsenceCalendarDayCount, false)
            };
        }
    }
}