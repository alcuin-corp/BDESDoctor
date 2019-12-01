using System;

namespace Alcuin.BDES.Domain
{
    internal class ColumnProviderFactory
    {
        public IColumnProvider Create(FileTab fileTab)
        {
            switch (fileTab)
            {
                case FileTab.Effectifs:
                    return new EffectifColumnProvider();
                case FileTab.Maladies:
                    return new DiseaseColumnProvider();
                case FileTab.Absences:
                    return new AbsenceColumnProvider();
                default:
                    throw new Exception("Unknown tab name!");
            }
        }
    }
}