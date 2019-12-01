// <copyright file="ContractType.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Alcuin.BDES.Domain
{
    internal enum ContractType
    {
        /// <summary>
        /// Open-ended Contract "Contrat de travail à durée indeterminée"
        /// </summary>
        [Description("CDI")]
        OEC = 1,

        /// <summary>
        /// Fixed-Term Contract
        /// </summary>
        [Description("CDD")]
        FTC,

        /// <summary>
        /// Employment Initiative Contract
        /// </summary>
        [Description("CIE")]
        EIC,

        /// <summary>
        /// Learning
        /// </summary>
        [Description("Apprentissage")]
        Learning,

        /// <summary>
        /// Professionalization
        /// </summary>
        [Description("Apprentissage")]
        Professionalization,

        /// <summary>
        /// Temporary Contract Of Employment
        /// </summary>
        [Description("Intérim")]
        TCE,

        /// <summary>
        /// Single Inclusion Contract
        /// </summary>
        [Description("CUI")]
        SIC,

        /// <summary>
        /// Employment Accompanement Contract
        /// </summary>
        [Description("CAE")]
        EAC
    }
}
