using System;

namespace Alcuin.BDES
{
    public class ProcessingFinishedEventArgs : EventArgs
    {
        public ProcessingFinishedEventArgs(bool isFailed)
        {
            this.IsFailed = isFailed;
        }

        public bool IsFailed { get; }
    }
}
