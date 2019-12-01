using Alcuin.BDES.Domain.Transcodification;

namespace Alcuin.BDES.Domain.Columns
{
    internal class TextColumn : Column
    {
        private const int MaximumTextLenght = 255;

        private readonly TextTranscoder textTranscoder;

        public TextColumn(string columnheader, bool isMandatory = false, bool allowDuplicateValues = true, int filtringPriority = 0)
                : base(columnheader, isMandatory, allowDuplicateValues)
        {
            this.textTranscoder = new TextTranscoder();
        }

        internal override bool IsValidContent(string cellContent, out string errorMessage)
        {
            if (cellContent.Length <= MaximumTextLenght)
            {
                errorMessage = null;
                return true;
            }

            errorMessage = this.GetInvalidCellContentMessage(cellContent);
            return false;
        }

        internal override string CleanValue(string value)
        {
            var result = value;
            foreach (var item in value)
            {
                if (this.textTranscoder.TryTranscode(item.ToString(), out var txt))
                {
                    result.Replace(item, txt);
                }
            }

            return result;
        }

        protected override string GetInvalidCellContentMessage(string cellContent)
        {
            return $"Dans l'onglet '{this.Sheet.Name}', la colonne '{this.Header}' contient la donnée [{cellContent}] qui dépasse la limite des {MaximumTextLenght} caractères.";
        }
    }
}