// <copyright file="ProcessingException.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System;

namespace Alcuin.BDES.Domain
{
    public class ProcessingException : Exception
    {
        public ProcessingException(string message, string step, Exception innerException = null)
            : base(message, innerException)
        {
            this.Step = step;
        }

        public string Step { get; }
    }
}
