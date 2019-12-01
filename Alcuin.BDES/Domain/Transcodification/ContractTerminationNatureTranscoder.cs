// <copyright file="ContractTerminationNatureTranscoder.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain.Transcodification
{
    internal class ContractTerminationNatureTranscoder : Transcoder<ContractTerminationNature>
    {
        public ContractTerminationNatureTranscoder()
        {
            this.Map(ContractTerminationNature.Retirement, "Retraite");

            this.Map(
                ContractTerminationNature.Resignation,
                "Démission",
                "Demission",
                "dem.",
                "dem");

            this.Map(
                ContractTerminationNature.EndOfFixedTermContract,
                "Fin de CDD",
                "Fin de contrat de travail à durée déterminée",
                "fin de contrat de travail a duree determinee",
                "Fin cdd",
                "CDD",
                "DD");

            this.Map(
                ContractTerminationNature.Layoff,
                "Licenciement",
                "Lic.",
                "Lic");

            this.Map(
                ContractTerminationNature.EconomicalLayoff,
                "Licenciement économique",
                "licenciement economique",
                "Licencement éco",
                "lic.eco.",
                "lic.eco",
                "liceco",
                "Lic. Éco");

            this.Map(
                ContractTerminationNature.EarlyRetirement,
                "Pré-retraite",
                "Pré retraite",
                "Pre retraite",
                "Pre-retraite",
                "Preretraite");
        }
    }
}