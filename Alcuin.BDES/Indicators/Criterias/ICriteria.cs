using System.Collections.Generic;
using Alcuin.BDES.Domain;

namespace Alcuin.BDES.Indicators.Criterias
{
    internal interface ICriteria
    {
        Column Column { get; }

        LogicalOperator LogicalOperatorToNextCondition { get; }

        bool IsMatch(Aspose.Cells.Row row, int referenceYear);
    }
}