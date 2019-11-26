// <copyright file="RepositoryColumn.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System;
using Alcuin.BDES.Domain.Columns;
using Alcuin.BDES.Domain.Transcodification;
using Aspose.Cells;

namespace Alcuin.BDES.Domain
{
    internal class RepositoryColumn<T> : TextColumn
        where T : Enum
    {
        private readonly Transcoder<T> transcoder;

        private readonly string allowedValues;

        public RepositoryColumn(string columnheader, Transcoder<T> transcoder, bool isMandatory = false)
                : base(columnheader, isMandatory)
        {
            this.transcoder = transcoder;
            this.allowedValues = string.Join(", ", transcoder.AllowedKeys);
        }

        internal override bool IsValidContent(string cellContent, out string errorMessage)
        {
            if (this.transcoder.TryTranscode(cellContent, out var result))
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

            return value;
        }

        internal override string GetCleanCell(Row row)
        {
            var value = this.GetCell(row);
            return this.CleanValue(value);
        }

        protected override string GetInvalidCellContentMessage(string cellContent)
        {
            return $"Dans l'onglet «{this.Sheet.Name}», la colonne «{this.Header}» à une valeur qui texte n’est pas reconnue '{cellContent}'."
                 + $" Les valeurs pouvant être utilisées sont «{this.allowedValues}».";
        }
    }
}
