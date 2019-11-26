using System;
using System.Collections.Generic;

namespace Alcuin.BDES.Domain
{
    internal class Filtre<T>
    {
        public Filtre()
        {
        }

        public List<Filtre<T>> SubFiltres { get; set; }

        public List<Predicate<T>> Predicates { get; set; }

        public List<Indicator<T>> Indicators { get; set; }
    }
}
