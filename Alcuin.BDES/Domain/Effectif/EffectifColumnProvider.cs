﻿using System.Collections.Generic;
using Alcuin.BDES.Domain.Columns;
using Alcuin.BDES.Domain.Transcodification;
using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain
{
    internal class EffectifColumnProvider : IColumnProvider
    {
        public List<Column> GetColumns()
        {
            return new List<Column>
            {
                new TextColumn(ColumnNames.Identifier, true, false),
                new TextColumn(ColumnNames.Structure, true),
                new DateColumn(ColumnNames.BirthDay),
                new DateColumn(ColumnNames.EntryDate),
                new DateColumn(ColumnNames.LeavingDate),
                new NumericColumn(ColumnNames.RawMonthlySalary),
                new NumericColumn(ColumnNames.WeeklyWorkingTime),
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