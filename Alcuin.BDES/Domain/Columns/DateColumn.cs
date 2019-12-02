using Alcuin.BDES.Helper;
using Alcuin.BDES.Indicators;
using Alcuin.BDES.Indicators.Criterias;

namespace Alcuin.BDES.Domain.Columns
{
    internal class DateColumn : Column
    {
        public DateColumn(string columnheader, bool isMandatory = false)
                : base(columnheader, isMandatory, true)
        {
        }

        internal override string GetErrorMessageForEmptyCell() => $"Dans l'onglet «{this.Sheet.Name}», la colonne «{this.Header}» contient des cellules date vides.";

        internal override bool IsValidContent(string cellContent, out string errorMessage)
        {
            if (cellContent.IsNotEmpty() && cellContent.TryParseDate(out var date))
            {
                errorMessage = null;
                return true;
            }

            if (cellContent.IsEmpty())
            {
                errorMessage = this.GetErrorMessageForEmptyCell();
            }
            else
            {
                errorMessage = this.GetInvalidCellContentMessage(cellContent);
            }

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