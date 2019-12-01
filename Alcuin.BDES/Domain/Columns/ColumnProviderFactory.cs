using Alcuin.BDES.Ninject;

namespace Alcuin.BDES.Domain
{
    internal class ColumnProviderFactory : IColumnProviderFactory
    {
        public IColumnProvider Create(string sheetName)
        {
            return ServiceLocator.Resolve<IColumnProvider>(sheetName);
        }

        public IColumnProvider Create(SheetName sheetName)
        {
            return this.Create(sheetName.ToString());
        }
    }
}