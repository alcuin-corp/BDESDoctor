// <copyright file="CSP.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Alcuin.BDES.Model
{
    public enum CSP
    {
        [Description("Cadre")]
        Cadre = 1,

        [Description("Agent de maitrise")]
        AgentDeMaitrise,

        [Description("Technicien")]
        Technicien,

        [Description("Ouvrier")]
        Ouvrier,

        [Description("Employé")]
        Employé,
    }
}
