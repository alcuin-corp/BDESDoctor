// <copyright file="Gender.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Alcuin.BDES.Model
{
    internal enum Gender
    {
        [Description("Homme")]
        Male = 1,

        [Description("Femme")]
        Female
    }
}
