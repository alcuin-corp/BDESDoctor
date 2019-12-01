using System.Collections.Generic;

namespace Alcuin.BDES.Domain
{
    internal interface IColumnProvider
    {
        List<Column> GetColumns();
    }
}