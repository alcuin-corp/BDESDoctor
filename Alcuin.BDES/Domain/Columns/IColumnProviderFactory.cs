// <copyright file="ColumnProviderFactory.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

namespace Alcuin.BDES.Domain
{
    internal interface IColumnProviderFactory
    {
        IColumnProvider Create(SheetName sheetName);

        IColumnProvider Create(string sheetName);
    }
}