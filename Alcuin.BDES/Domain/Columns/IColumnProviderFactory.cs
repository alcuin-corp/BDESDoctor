namespace Alcuin.BDES.Domain
{
    internal interface IColumnProviderFactory
    {
        IColumnProvider Create(SheetName sheetName);

        IColumnProvider Create(string sheetName);
    }
}