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