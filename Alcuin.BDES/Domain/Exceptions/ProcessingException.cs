// <copyright file="ProcessingException.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

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
