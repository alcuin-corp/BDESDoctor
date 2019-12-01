// <copyright file="IColumnProvider.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Alcuin.BDES.Domain
{
    internal interface IColumnProvider
    {
        List<Column> GetColumns();
    }
}