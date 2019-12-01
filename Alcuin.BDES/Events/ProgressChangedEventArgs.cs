using System;

namespace Alcuin.BDES
{
    public class ProgressChangedEventArgs : EventArgs
    {
        public ProgressChangedEventArgs(int progressRate)
        {
            this.ProgressRate = progressRate;
        }

        public int ProgressRate { get; }
    }
}