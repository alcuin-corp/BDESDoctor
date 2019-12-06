using System.Threading;

namespace Alcuin.BDES.Indicators
{
    internal class IndicatorValue
    {
        private int count;

        public int Count => this.count;

        public decimal Total { get; private set; }

        public decimal Average => this.count == 0 ? 0 : this.Total / this.count;

        internal int Increment()
        {
            Interlocked.Increment(ref this.count);
            return this.count;
        }

        internal decimal AddTotal(decimal value)
        {
            lock (this)
            {
                this.Total += value;
            }

            return this.Total;
        }
    }
}