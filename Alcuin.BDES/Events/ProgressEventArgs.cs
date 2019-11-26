using System;

namespace Alcuin.BDES
{
    public class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(int progressRate)
        {
            this.ProgressRate = progressRate;
        }

        public int ProgressRate { get; }
    }
}
