using System.IO;
using System.IO.Abstractions;
using Aspose.Cells;

namespace Alcuin.BDES.Helper
{
    public static class IFileSystemExtensions
    {
        public static void SaveWorkbook(this IFileSystem fileSystem, Workbook workbook, string filePath = "")
        {
            if (filePath.IsEmpty())
            {
                filePath = workbook.FileName;
            }

            if (Path.GetDirectoryName(filePath).IsEmpty())
            {
                filePath = Path.Combine(fileSystem.Directory.GetCurrentDirectory(), filePath);
            }

            using (var stream = fileSystem.FileStream.Create(filePath, FileMode.OpenOrCreate))
            {
                using (var memorytream = workbook.SaveToStream())
                {
                    memorytream.WriteTo(stream);
                }
            }
        }

        public static Workbook LoadWorkbook(this IFileSystem fileSystem, string filePath)
        {
            using (var fstream = fileSystem.FileStream.Create(filePath, FileMode.Open))
            {
                var workbook = new Workbook(fstream);
                return workbook;
            }
        }
    }
}