// <copyright file="IndicatorValue.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Threading;

namespace Alcuin.BDES.Indicators
{
    public class IndicatorValue
    {
        private int count;

        private decimal total;

        public int Count => this.count;

        public decimal Average => this.total != 0 ? this.count / this.total : 0;

        internal int Increment()
        {
            Interlocked.Increment(ref this.count);
            return this.count;
        }

        internal decimal AddTotal(decimal value)
        {
            lock (this)
            {
                this.total += value;
            }

            return this.total;
        }
    }
}
