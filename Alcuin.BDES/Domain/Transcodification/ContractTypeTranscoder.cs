namespace Alcuin.BDES.Domain.Transcodification
{
    internal class ContractTypeTranscoder : Transcoder<ContractType>
    {
        public ContractTypeTranscoder()
        {
            this.Map(
                ContractType.OEC,
                "CDI",
                "DI",
                "contratadureeindeterminee",
                "contrat à durée indeterminée");

            this.Map(
                ContractType.FTC,
                "CDD",
                "DD",
                "contratadureedeterminee",
                "contrat à durée déterminée");

            this.Map(
                ContractType.EIC,
                "CIE",
                "Contrat initiative emploi");

            this.Map(
                ContractType.Learning,
                "Alternance",
                "Apprentissage",
                "Contrat d'apprentissage");

            this.Map(
                ContractType.Professionalization,
                "Professionnalisation",
                "Contrat de professionnalisation");

            this.Map(
                ContractType.TCE,
                "CTT",
                "Contrat de travail temporaire",
                "Intérim");

            this.Map(
                ContractType.SIC,
                "CUI",
                "Contrat unique d'insertion");

            this.Map(
                ContractType.EAC,
                "CAE",
                "Contrat d'accompagnement dans l'emploi");
        }
    }
}