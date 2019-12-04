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
    }
}
