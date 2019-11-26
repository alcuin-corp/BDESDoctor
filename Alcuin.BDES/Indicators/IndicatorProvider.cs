// <copyright file="IndicatorProvider.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Indicators.Parser;
using Alcuin.BDES.Indicators.Parser.Raw;

namespace Alcuin.BDES.Indicators
{
    internal class IndicatorProvider
    {
        private readonly RawIndicatorReader rawIndicatorReader;
        private readonly Tokenizer tokenizer;

        public IndicatorProvider()
        {
            this.rawIndicatorReader = new RawIndicatorReader();
            this.tokenizer = new Tokenizer();
        }

        public IEnumerable<Indicator> GetAll()
        {
            foreach (var indicator in this.rawIndicatorReader.ReadFile("RawIndicators.csv"))
            {
                var tokens = this.tokenizer.Tokenize(indicator.Formula).ToList();
                var analyzer = new FormulaAnalyzer(tokens);
                indicator.MatchConditions = analyzer.MatchConditions;
                indicator.ColumnToAgregateName = analyzer.ColumnToAgregate;
                indicator.AgregateFunction = analyzer.AgregateFunction;
                indicator.GroupColumnName = analyzer.GroupByColumn;
                yield return indicator;
            }
        }
    }
}
