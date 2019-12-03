using System;
using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Indicators.Criterias;
using Alcuin.BDES.Indicators.Parser.Raw;

namespace Alcuin.BDES.Indicators.Parser
{
    internal class IndicatorDefinition
    {
        private readonly static Tokenizer Tokenizer = new Tokenizer();

        private readonly RawIndicator rawIndicator;

        public IndicatorDefinition(RawIndicator rawIndicator)
        {
            this.rawIndicator = rawIndicator;
            var tokens = Tokenizer.Tokenize(rawIndicator.Formula)
                .ToList();
            var analyzer = new FormulaAnalyzer(tokens);
            this.AgregateColumnHeader = analyzer.ColumnToAgregate;
            this.GroupColumnHeader = analyzer.GroupByColumn;
            this.CriteriaDefinitions = analyzer.CriteriaDefinitions;
            this.AgregateFunction = analyzer.AgregateFunction;
            this.Name = this.rawIndicator.Name;
            this.Field = this.rawIndicator.Field;
        }

        public static bool CanParse(RawIndicator rawIndicator)
        {
            try
            {
                var tokens = Tokenizer.Tokenize(rawIndicator.Formula).ToList();
                var analyzer = new FormulaAnalyzer(tokens);
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        public AgregateFunction AgregateFunction { get; private set; }

        public string Domain => this.rawIndicator.Domain;

        public string SubDomain => this.rawIndicator.SubDomain;

        public string Name { get; internal set; }

        public string SheetName => this.rawIndicator.SheetName;

        public string Field { get; internal set; }

        public List<CriteriaDefinition> CriteriaDefinitions { get; set; }

        public string AgregateColumnHeader { get; private set; }

        public string GroupColumnHeader { get; private set; }

        public IndicatorDefinition Clone()
        {
            var clone = (IndicatorDefinition)this.MemberwiseClone();
            clone.CriteriaDefinitions = new List<CriteriaDefinition>(this.CriteriaDefinitions);
            return clone;
        }
    }
}