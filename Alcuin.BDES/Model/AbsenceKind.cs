using System.ComponentModel;

namespace Alcuin.BDES.Model
{
    internal enum AbsenceKind
    {
        [Description("Évènement familial")]
        EvenementFamilial,

        [Description("Congès speciaux")]
        CongesSpeciaux,

        [Description("Absence maternite")]
        AbsenceMaternite,

        [Description("Absence paternite")]
        AbsencePaternite,

        [Description("Maladie professionnelle")]
        MaladieProfessionnelle,

        [Description("Accident de travail")]
        AccidentDeTravail,

        [Description("Accident de trajet")]
        AccidentDeTrajet,

        [Description("RTT")]
        RTT,

        [Description("Congés payés")]
        CongesPayes,

        [Description("Maladie")]
        Maladie,

        [Description("Repos compensateur de nuit")]
        ReposCompensateurDeNuit,

        [Description("Repos compensateur équivalent")]
        ReposCompensateurEquivalent
    }
}
