using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain.Transcodification
{
    internal class AbsenceKindTranscoder : Transcoder<AbsenceKind>
    {
        public AbsenceKindTranscoder()
        {
            this.Map(
                AbsenceKind.AbsenceMaternite,
                "Abs. Maternité",
                "Absence Maternité");

            this.Map(
                AbsenceKind.AbsencePaternite,
                "abs. Paternité",
                "absence paternité",
                "paternité");

            this.Map(
                AbsenceKind.EvenementFamilial,
                "évènement familial",
                "Evènement familial");

            this.Map(
                AbsenceKind.CongesSpeciaux,
                "congés spéciaux",
                "Congé Spéciaux");

            this.Map(
                AbsenceKind.MaladieProfessionnelle,
                "maladie professionnelle",
                "maladie pro.",
                "maladie pro");

            this.Map(
                AbsenceKind.AccidentDeTravail,
                "accident de travail",
                "acc. Travail");

            this.Map(
                AbsenceKind.AccidentDeTrajet,
                "accident de trajet",
                "acc. Trajet");
        }
    }
}
