// <copyright file="IndicatorParser.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace Alcuin.BDES.Indicators.Parser.Raw
{
    internal class RawIndicatorReader
    {
        public IEnumerable<Indicator> ReadFile(string path)
        {
            using (var reader = new StreamReader(path))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<IndicatorMapper>();
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.BadDataFound = null;
                    foreach (var indicator in csv.GetRecords<Indicator>())
                    {
                        yield return indicator;
                    }
                }
            }
        }
    }
}
