using System;

namespace Alcuin.BDES
{
    public class ProcessFinishedEventArgs : EventArgs
    {
        public ProcessFinishedEventArgs(bool isFailed)
        {
            this.IsFailed = isFailed;
        }

        public bool IsFailed { get; }
    }
}
