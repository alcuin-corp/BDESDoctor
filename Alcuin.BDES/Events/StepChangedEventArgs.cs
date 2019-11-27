// <copyright file="StepChangedEventArgs.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System;

namespace Alcuin.BDES
{
    public class StepChangedEventArgs : EventArgs
    {
        public StepChangedEventArgs(string oldStep, string currentStep)
        {
            this.OldStep = oldStep;
            this.CurrentStep = currentStep;
        }

        public string CurrentStep { get; internal set; }

        public string OldStep { get; internal set; }
    }
}
