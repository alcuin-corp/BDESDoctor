using System.Collections.Generic;
using Alcuin.BDES.Domain.Columns;
using Alcuin.BDES.Domain.Transcodification;
using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain
{
    internal class AbsenceColumnProvider : IColumnProvider
    {
        public List<Column> GetColumns()
        {
            return new List<Column>()
            {
                new TextColumn(ColumnNames.Identifier, true, true),
                new RepositoryColumn<AbsenceKind>(ColumnNames.AbsenceKind, new AbsenceKindTranscoder()),
                new NumericColumn(ColumnNames.AbsenceDayCount, false),
                new NumericColumn(ColumnNames.AbsenceCalendarDayCount, false)
            };
        }
    }
}