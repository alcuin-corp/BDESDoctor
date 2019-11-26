// <copyright file="Sheet.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Indicators;
using Aspose.Cells;

namespace Alcuin.BDES.Domain
{
    internal class Sheet
    {
        public Sheet(FileTab fileTab, bool isMandatory = false)
        {
            this.FileTab = fileTab;
            this.Name = fileTab.ToLowerString();
            this.IsMandatory = isMandatory;
            this.AvailableColumns = new List<Column>();
            this.ExpectedColumns = new List<Column>();
            this.Indicators = new List<Indicator>();
        }

        public string Name { get; }

        public FileTab FileTab { get; set; }

        public bool IsMandatory { get; set; }

        public List<Column> ExpectedColumns { get; set; }

        public List<Column> AvailableColumns { get; set; }

        public Worksheet RawSheet { get; set; }

        public Cells Cells => this.RawSheet?.Cells;

        public Cell FirstCell => this.Cells?.FirstCell;

        public List<Indicator> Indicators { get; set; }

        public int RowCount => this.Cells?.Rows.Count ?? 0;

        public IEnumerable<Row> GetRows(bool ignoreHeaderRow = true)
        {
            var startingIndex = ignoreHeaderRow ? 1 : 0;
            for (int i = startingIndex; i < this.RowCount; i++)
            {
                yield return this.RawSheet.Cells.Rows[i];
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
