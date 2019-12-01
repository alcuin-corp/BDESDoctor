// <copyright file="ContractTerminationNature.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

namespace Alcuin.BDES.Model
{
    internal enum ContractTerminationNature
    {
        /// <summary>
        /// Retraite
        /// </summary>
        Retirement = 1,

        /// <summary>
        /// Démision
        /// </summary>
        Resignation,

        /// <summary>
        /// Fin de contrat de travail à durée déterminée
        /// </summary>
        EndOfFixedTermContract,

        /// <summary>
        /// Licenciement
        /// </summary>
        Layoff,

        /// <summary>
        /// Licenciement économique
        /// </summary>
        EconomicalLayoff,

        /// <summary>
        /// Préretraite
        /// </summary>
        EarlyRetirement
    }
}
