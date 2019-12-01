// <copyright file="StepChangedEventArgs.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System;

namespace Alcuin.BDES
{
    public class StepChangedEventArgs : EventArgs
    {
        public StepChangedEventArgs(Step oldStep, Step currentStep)
        {
            this.OldStep = oldStep;
            this.CurrentStep = currentStep;
        }

        public Step CurrentStep { get; internal set; }

        public Step OldStep { get; internal set; }
    }
}
