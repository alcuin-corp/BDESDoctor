using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Indicators.Criterias;
using Aspose.Cells;

namespace Alcuin.BDES.Domain
{
    internal abstract class Column
    {
        private const string EmptyCellFoundMessage = "Certaines cellules textes sont vides dans votre fichier, les données vides ne seront pas prises en compte dans les calculs.";

        public Column(string columnheader, bool isMandatory = false, bool allowDuplicateValues = true)
        {
            this.Header = columnheader;
            this.IsMandatory = isMandatory;
            this.AllowDuplicateValues = allowDuplicateValues;
        }

        public bool AllowDuplicateValues { get; }

        public string Header { get; set; }

        public Cell HeaderCell { get; set; }

        public int Index => this.HeaderCell.Column;

        public Sheet Sheet { get; internal set; }

        public bool IsMandatory { get; private set; }

        public IEnumerable<string> GetCells()
        {
            return this.Sheet.GetRows()
                .Select(this.GetCell);
        }

        public virtual string GetCell(Row row)
        {
            return row[this.Index].StringValue;
        }

        public override string ToString() => $"{this.Header}-{this.Sheet.Name}";

        internal virtual string GetErrorMessageForEmptyCell() => EmptyCellFoundMessage;

        internal virtual string CleanValue(string value) => value;

        internal virtual string GetCleanCell(Row row) => this.GetCell(row);

        internal abstract bool IsValidContent(string cellContent, out string errorMessage);

        internal abstract ICriteria GetCriteria(CriteriaDefinition criteriaDefinition);

        protected abstract string GetInvalidCellContentMessage(string cellContent);
    }
}