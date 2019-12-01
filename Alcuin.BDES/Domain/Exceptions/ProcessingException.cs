using System;

namespace Alcuin.BDES
{
    public class ProcessingException : Exception
    {
        public ProcessingException(string message)
            : base(message)
        {
        }
    }
}