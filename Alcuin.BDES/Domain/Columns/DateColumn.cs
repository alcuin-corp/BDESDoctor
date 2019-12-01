// <copyright file="DateColumn.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using Alcuin.BDES.Helper;
using Alcuin.BDES.Indicators;
using Alcuin.BDES.Indicators.Criterias;

namespace Alcuin.BDES.Domain.Columns
{
    internal class DateColumn : Column
    {
        private const string EmptyCellFoundMessage = "Certaines cellules dates sont vides dans votre fichier, les données vides ne seront pas prises en compte dans les calculs.";

        public DateColumn(string columnheader, bool isMandatory = false)
                : base(columnheader, isMandatory, true)
        {
        }

        internal override string GetErrorMessageForEmptyCell() => EmptyCellFoundMessage;

        internal override bool IsValidContent(string cellContent, out string errorMessage)
        {
            if (cellContent.TryParseDate(out var date))
            {
                errorMessage = null;
                return true;
            }

            errorMessage = this.GetInvalidCellContentMessage(cellContent);
            return false;
        }

        internal override ICriteria GetCriteria(CriteriaDefinition criteriaDefinition)
        {
            if (criteriaDefinition.ScalarFunction == ScalarFunction.None)
            {
                return new DateCriteria(criteriaDefinition) { Column = this };
            }

            var criteria = new NumericCriteria(criteriaDefinition) { Column = this };

            return criteria;
        }

        protected override string GetInvalidCellContentMessage(string cellContent)
        {
            return $"Dans l'onglet «{this.Sheet.Name}», la colonne «{this.Header}» contient une date n’est pas dans le bon format. Le format attendu est JJ/MM/AAAA. Veuillez vérifier que les dates respectent ce format.";
        }
    }
}