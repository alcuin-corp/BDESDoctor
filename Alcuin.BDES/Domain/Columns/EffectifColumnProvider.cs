﻿using System.Collections.Generic;
using Alcuin.BDES.Domain.Columns;
using Alcuin.BDES.Domain.Transcodification;
using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain
{
    internal class EffectifColumnProvider : IColumnProvider
    {
        public EffectifColumnProvider()
        {
            this.Columns = this.LoadColumns();
        }

        public List<Column> Columns { get; }

        public List<Column> GetColumns() => this.Columns;

        private List<Column> LoadColumns()
        {
            return new List<Column>
            {
                new TextColumn(ColumnNames.Identifier, true, false),
                new TextColumn(ColumnNames.Structure, true),
                new DateColumn(ColumnNames.BirthDay, false, false),
                new DateColumn(ColumnNames.EntryDate, false, false),
                new DateColumn(ColumnNames.LeavingDate, true, true),
                new NumericColumn(ColumnNames.RawMonthlySalary),
                new NumericColumn(ColumnNames.WeeklyWorkingTime),
                new NumericColumn(ColumnNames.Variable),
                new RepositoryColumn<CSP>(ColumnNames.CSP, new CSPTranscoder(), true),
                new RepositoryColumn<Gender>(ColumnNames.Gender, new GenderTranscoder(), true),
                new RepositoryColumn<ContractType>(ColumnNames.ContractType, new ContractTypeTranscoder()),
                new RepositoryColumn<ContractTerminationNature>(ColumnNames.ContractTerminationNature, new ContractTerminationNatureTranscoder()),
                new RepositoryColumn<Nationality>(ColumnNames.Nationality, new NationalityTranscoder()),
                new RepositoryColumn<RecognitionType>(ColumnNames.RecognitionType, new RecognitionTypeTranscoder()),
            };
        }
    }
}