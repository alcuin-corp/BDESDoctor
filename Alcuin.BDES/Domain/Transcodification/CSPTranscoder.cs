// <copyright file="CSPTranscoder.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain.Transcodification
{
    internal class CSPTranscoder : Transcoder<CSP>
    {
        public CSPTranscoder()
        {
            this.Map(CSP.Cadre, "Cadre", "cade");

            this.Map(CSP.Employé, "Employé", "Employe", "Emp");

            this.Map(CSP.Ouvrier, "Ouvrier", "ouv");

            this.Map(CSP.AgentDeMaitrise, "Agent de maitrise", "agent");

            this.Map(CSP.Technicien, "Technicien", "tech");
        }
    }
}