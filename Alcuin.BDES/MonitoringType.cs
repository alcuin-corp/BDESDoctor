using System.ComponentModel;

namespace Alcuin.BDES
{
    public enum MonitoringType
    {
        [Description("Erreur")]
        Error,

        [Description("Succès")]
        Succes,

        [Description("Avertissement")]
        Warrning
    }
}