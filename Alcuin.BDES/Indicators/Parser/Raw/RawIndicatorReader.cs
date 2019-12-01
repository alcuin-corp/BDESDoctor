// <copyright file="IndicatorParser.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.IO.Abstractions;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Interfaces;
using CsvHelper;

namespace Alcuin.BDES.Indicators.Parser.Raw
{
    internal class RawIndicatorReader : IRawIndicatorReader
    {
        private readonly IFileSystem fileSystem;

        public RawIndicatorReader(IFileSystem fileSystem)
        {
            fileSystem.IsNotNull(nameof(fileSystem));

            this.fileSystem = fileSystem;
        }

        public IEnumerable<RawIndicator> LoadInidcatorFromFile(string path)
        {
            using (var reader = this.fileSystem.File.OpenText(path))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<RawIndicatorMapper>();
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.BadDataFound = null;
                    foreach (var indicator in csv.GetRecords<RawIndicator>())
                    {
                        yield return indicator;
                    }
                }
            }
        }
    }
}
