namespace Alcuin.BDES.Domain
{
    internal enum ContractType
    {
        /// <summary>
        /// Open-ended Contract "Contrat de travail à durée indeterminée"
        /// </summary>
        OEC = 1,

        /// <summary>
        /// Fixed-Term Contract
        /// </summary>
        FTC,

        /// <summary>
        /// Employment Initiative Contract
        /// </summary>
        EIC,

        /// <summary>
        /// Learning
        /// </summary>
        Learning,

        /// <summary>
        /// Professionalization
        /// </summary>
        Professionalization,

        /// <summary>
        /// Temporary Contract Of Employment
        /// </summary>
        TCE,

        /// <summary>
        /// Single Inclusion Contract
        /// </summary>
        SIC,

        /// <summary>
        /// Employment Accompanement Contract
        /// </summary>
        EAC
    }
}