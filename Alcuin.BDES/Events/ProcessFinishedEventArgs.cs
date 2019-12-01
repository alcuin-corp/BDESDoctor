using System;

namespace Alcuin.BDES
{
    public class ProcessFinishedEventArgs : EventArgs
    {
        public ProcessFinishedEventArgs(bool isFailed, Step step, Exception exception = null)
        {
            this.IsFailed = isFailed;
            this.ExitStep = step;
            this.Exception = exception;
        }

        public bool IsFailed { get; }

        public Step ExitStep { get; }

        public Exception Exception { get; }
    }
}