using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Indicators.Criterias;

namespace Alcuin.BDES.Indicators.Parser.Raw
{
    internal class RawIndicator
    {
        private readonly Tokenizer tokenizer;

        public RawIndicator()
        {
            this.tokenizer = new Tokenizer();
        }

        public string SheetName { get; set; }

        public string Domain { get; set; }

        public string SubDomain { get; set; }

        public string Name { get; set; }

        public string Field { get; set; }

        public string Formula { get; set; }

        
    }
}
