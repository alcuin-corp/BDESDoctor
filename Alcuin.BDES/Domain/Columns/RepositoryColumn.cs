using System;
using System.Linq;
using Alcuin.BDES.Domain.Columns;
using Alcuin.BDES.Domain.Transcodification;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Indicators.Criterias;
using Aspose.Cells;

namespace Alcuin.BDES.Domain
{
    internal class RepositoryColumn<T> : TextColumn
        where T : struct, Enum
    {
        private readonly Transcoder<T> transcoder;

        private readonly string allowedValues;

        private readonly bool useExtraValueAsOther;

        private readonly T otherValue;

        private readonly T noneValue;

        public RepositoryColumn(string columnheader, Transcoder<T> transcoder, bool isMandatory = false)
                : base(columnheader, isMandatory)
        {
            this.transcoder = transcoder;
            this.allowedValues = string.Join(", ", transcoder.AllowedKeys);


            //if ("None".TryParseEnum(out this.noneValue))
            //{
            //    this.transcoder.AddMapping(this.noneValue, string.Empty);
            //}

            if ("Other".TryParseEnum(out this.otherValue))
            {
                this.useExtraValueAsOther = true;
            }
        }

        internal override bool IsValidContent(string cellContent, out string errorMessage)
        {
            if (this.transcoder.TryTranscode(cellContent, out var result) || (this.useExtraValueAsOther && cellContent.IsNotEmpty()))
            {
                errorMessage = null;
                return true;
            }

            errorMessage = this.GetInvalidCellContentMessage(cellContent);
            return false;
        }

        internal override string CleanValue(string value)
        {
            value = base.CleanValue(value);
            if (this.transcoder.TryTranscode(value, out var result))
            {
                return result.ToString();
            }

            return this.useExtraValueAsOther ? this.otherValue.ToString() : value;
        }

        internal override string GetCleanCell(Row row)
        {
            var value = this.GetCell(row);
            return this.CleanValue(value);
        }

        internal override ICriteria GetCriteria(CriteriaDefinition criteriaDefinition)
        {
            var criteria = new RepositoryCriteria<T>(criteriaDefinition) { Column = this };
            foreach (var value in criteriaDefinition.Values)
            {
                if (!this.transcoder.TryTranscode(value, out T result) && !value.TryParseEnum(out result))
                {
                    throw new InvalidCastException($"{value}  can not be parsed !");
                }

                criteria.Values.Add(result);
            }

            return criteria;
        }

        protected override string GetInvalidCellContentMessage(string cellContent)
        {
            return $"Dans l'onglet «{this.Sheet.Name}», la colonne «{this.Header}» à une valeur texte qui n’est pas reconnue '{cellContent}'."
                 + $" Les valeurs pouvant être utilisées sont «{this.allowedValues}».";
        }
    }
}