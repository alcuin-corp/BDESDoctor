namespace Alcuin.BDES.Model
{
    internal enum ContractTerminationNature
    {
        /// <summary>
        /// Still working
        /// </summary>
        None,

        /// <summary>
        /// Retraite
        /// </summary>
        Retirement,

        /// <summary>
        /// Démision
        /// </summary>
        Resignation,

        /// <summary>
        /// Fin de contrat de travail à durée déterminée
        /// </summary>
        EndOfFixedTermContract,

        /// <summary>
        /// Licenciement
        /// </summary>
        Layoff,

        /// <summary>
        /// Licenciement économique
        /// </summary>
        EconomicalLayoff,

        /// <summary>
        /// Préretraite
        /// </summary>
        EarlyRetirement,

        /// <summary>
        /// Décès
        /// </summary>
        Death
    }
}