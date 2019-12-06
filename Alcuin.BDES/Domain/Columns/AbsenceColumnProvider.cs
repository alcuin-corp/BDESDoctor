using System.Collections.Generic;
using Alcuin.BDES.Domain.Columns;
using Alcuin.BDES.Domain.Transcodification;
using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain
{
    internal class AbsenceColumnProvider : IColumnProvider
    {
        private readonly List<Column> columns;

        public AbsenceColumnProvider()
        {
            this.columns = new List<Column>()
            {
                new TextColumn(ColumnNames.Identifier, true, true),
                new TextColumn(ColumnNames.Structure, true),
                new RepositoryColumn<CSP>(ColumnNames.CSP, new CSPTranscoder(), true),
                new RepositoryColumn<AbsenceKind>(ColumnNames.AbsenceKind, new AbsenceKindTranscoder()),
                new RepositoryColumn<Gender>(ColumnNames.Gender, new GenderTranscoder()),
                new NumericColumn(ColumnNames.AbsenceDayCount, false),
                new NumericColumn(ColumnNames.AbsenceCalendarDayCount, false)
            };
        }

        public List<Column> GetColumns() => this.columns;
    }
}