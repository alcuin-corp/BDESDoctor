// <copyright file="IndicatorParser.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using Alcuin.BDES.Ninject;
using CsvHelper;

namespace Alcuin.BDES.Indicators.Parser.Raw
{
    internal class RawIndicatorReader
    {
        private readonly IFileSystem fileSystem;

        public RawIndicatorReader()
        {
            ServiceLocator.Resolve(out this.fileSystem);
        }

        public IEnumerable<Indicator> ReadFile(string path)
        {
            using (var reader = this.fileSystem.File.OpenText(path))
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
