using System.IO.Abstractions;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Ninject;
using Aspose.Cells;
using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    [Binding]
    public sealed class FileNameValidationSteps : StepBase
    {
        private readonly IFileSystem fileSystem;

        public FileNameValidationSteps(ScenarioContext injectedContext)
            : base(injectedContext)
        {
            ServiceLocator.Resolve(out this.fileSystem);
        }

        [Given(@"I have a workbook (.*)")]
        public void GivenAWorkbook(string workbookName)
        {
            var workbook = new Workbook();
            workbook.FileName = workbookName;
            this.context.Set(workbook);
            this.fileSystem.SaveWorkbook(workbook);
        }

        [Given(@"it has also a workSheet (.*) with the following content")]
        [Given(@"it has a workSheet (.*) with the following content")]
        public void GivenItHasAWorkSheetEffectifWithTheFollowingContent(string sheetName, Table table)
        {
            var workbook = this.context.Get<Workbook>();
            var workSheet = workbook.Worksheets.Add(sheetName);
            CopyTableContentIntoTheSheet(table, workSheet);
            this.fileSystem.SaveWorkbook(workbook);
        }

        [Given(@"the sheet (.*) also has the following content")]
        public void GivenTheWorkbookHasTheWorksheetWithTheFollowingContent(string sheetName, Table table)
        {
            var workbook = this.context.Get<Workbook>();
            var sheet = workbook.Worksheets[sheetName];
            this.fileSystem.SaveWorkbook(workbook);
        }


        private static void CopyTableContentIntoTheSheet(Table table, Worksheet workSheet)
        {
            int j = 0;
            foreach (var item in table.Header)
            {
                workSheet.Cells[0, j].Value = item;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i].TryGetValue(item, out var actualValue);
                    workSheet.Cells[i + 1, j].Value = actualValue;
                }
                j++;
            }
        }
    }
}
