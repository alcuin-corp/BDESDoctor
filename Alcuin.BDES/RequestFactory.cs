namespace Alcuin.BDES
{
    public static class RequestFactory
    {
        public static IRequest Create(string filePath, int referenceYear, string asposeLisence = null)
        {
            return new Request(filePath, referenceYear, asposeLisence);
        }
    }
}