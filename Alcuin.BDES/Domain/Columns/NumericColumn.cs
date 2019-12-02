using System.Text.RegularExpressions;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Indicators.Criterias;

namespace Alcuin.BDES.Domain.Columns
{
    internal class NumericColumn : Column
    {
        private readonly Regex regex;

        public NumericColumn(string columnheader, bool isMandatory = false)
                : base(columnheader, isMandatory)
        {
            this.regex = new Regex("^[0-9]*,?[0-9]{1,2}?$");
        }

        internal override string GetErrorMessageForEmptyCell() => $"Dans l'onglet «{this.Sheet.Name}», la colonne «{this.Header}» contient des cellules date vides.";

        internal override bool IsValidContent(string cellContent, out string errorMessage)
        {
            if (cellContent.IsNotEmpty() && this.regex.IsMatch(cellContent))
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
            var criteria = new NumericCriteria(criteriaDefinition) { Column = this };
            return criteria;
        }

        protected override string GetInvalidCellContentMessage(string cellContent)
        {
            return $"Dans l'onglet «{this.Sheet.Name}», la colonne «{this.Header}» contient une valeur numérique qui n’est pas dans le bon format. Le format attendu est « ####,## ». Veuillez vérifier que les valeurs numériques respectent ce format.";
        }
    }
}