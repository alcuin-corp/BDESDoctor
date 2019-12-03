using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Reflection;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Interfaces;
using CsvHelper;

namespace Alcuin.BDES.Indicators.Parser.Raw
{
    internal class RawIndicatorReader : IRawIndicatorReader
    {
        private readonly string indicatorRessouceName;

        private Assembly currentAssembly;

        public RawIndicatorReader()
        {
            this.currentAssembly = this.GetType().Assembly;
            this.indicatorRessouceName = this.currentAssembly.GetManifestResourceNames()[0];
        }

        public IEnumerable<RawIndicator> LoadEmbadedRawIndicators()
        {
            using (var reader = new StreamReader(this.currentAssembly.GetManifestResourceStream(this.indicatorRessouceName)))
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