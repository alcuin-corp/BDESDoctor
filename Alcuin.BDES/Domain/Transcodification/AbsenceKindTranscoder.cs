using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain.Transcodification
{
    internal class AbsenceKindTranscoder : Transcoder<AbsenceKind>
    {
        public AbsenceKindTranscoder()
        {
            this.Map(
                AbsenceKind.AbsenceMaternite,
                "Absence Maternité",
                "Maternité",
                "Abs. Maternité");

            this.Map(
                AbsenceKind.AbsencePaternite,
                "absence paternité",
                "abs. Paternité",
                "Paternité");

            this.Map(
                AbsenceKind.EvenementFamilial,
                "évènement familial",
                "Evènement familial");

            this.Map(
                AbsenceKind.CongesSpeciaux,
                "congés spéciaux",
                "congé spécial",
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

            this.Map(
                AbsenceKind.RTT,
                "RTT",
                "R.T.T");

            this.Map(
                AbsenceKind.CongesPayes,
                "Congés payés",
                "CP",
                "C.P",
                "C.P.");

            this.Map(
                AbsenceKind.ReposCompensateurDeNuit,
                "Repos compensateur nuit",
                "Repos compensateur de nuit");

            this.Map(
                AbsenceKind.ReposCompensateurEquivalent,
                "Repos compensateur équivalent",
                "Repos compensateur equivalent",
                "Repos compensateur");

            this.Map(AbsenceKind.Maladie, "maladie");
        }
    }
}