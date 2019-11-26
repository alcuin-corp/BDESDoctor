// <copyright file="IndicatorMapper.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using CsvHelper.Configuration;

namespace Alcuin.BDES.Indicators.Parser.Raw
{
    internal sealed class IndicatorMapper : ClassMap<Indicator>
    {
        public IndicatorMapper()
        {
            this.Map(m => m.Domain).Name("Domaine");
            this.Map(m => m.SubDomain).Name("Sous Domaine");
            this.Map(m => m.Name).Name("Indicateur");
            this.Map(m => m.Field).Name("Champs");
            this.Map(m => m.Formula).Name("Formule");
        }
    }
}
