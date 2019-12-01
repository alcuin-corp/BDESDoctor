using System.Text.RegularExpressions;

namespace Alcuin.BDES.Domain.Columns
{
    internal class NumericColumn : Column
    {
        private const string EmptyCellFoundMessage = "Certaines cellules numériques sont vides dans votre fichier, les données vides ne seront pas prises en compte dans les calculs.";

        private readonly Regex regex;

        public NumericColumn(string columnheader, bool isMandatory = false)
                : base(columnheader, isMandatory)
        {
            this.regex = new Regex("^[0-9]*,?[0-9]{1,2}?$");
        }

        internal override string GetErrorMessageForEmptyCell() => EmptyCellFoundMessage;

        internal override bool IsValidContent(string cellContent, out string errorMessage)
        {
            if (this.regex.IsMatch(cellContent))
            {
                errorMessage = null;
                return true;
            }

            errorMessage = this.GetInvalidCellContentMessage(cellContent);
            return false;
        }

        protected override string GetInvalidCellContentMessage(string cellContent)
        {
            return $"Dans l'onglet '{this.Sheet.Name}', la colonne '{this.Header}' contient une donnée non reconnue [{cellContent}] (format attendu [####,##]).";
        }
    }
}