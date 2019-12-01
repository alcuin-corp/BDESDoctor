using System.Reflection;
using Alcuin.BDES.Ninject;
using Ninject;

namespace Alcuin.BDES
{
    public static class RequestFactory
    {
        public static IRequest Create(string filePath, int referenceYear)
        {
            return new Request(filePath, referenceYear);
        }
    }
}