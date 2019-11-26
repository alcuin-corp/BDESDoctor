using Aspose.Cells;
using TechTalk.SpecFlow;

namespace Alcuin.BDES.IntegrationTests.Steps
{
    [Binding]
    public sealed class FileNameValidationSteps : StepBase
    {
        public FileNameValidationSteps(ScenarioContext injectedContext)
            : base(injectedContext)
        {
        }

        [Given(@"I have a workbook (.*)")]
        public void GivenAWorkbook(string workbookName)
        {
            var workbook = new Workbook();
            workbook.FileName = workbookName;
            this.context.Set(workbook);
        }

        [Given(@"it has also a workSheet (.*) with the following content")]
        [Given(@"it has a workSheet (.*) with the following content")]
        public void GivenItHasAWorkSheetEffectifWithTheFollowingContent(string sheetName, Table table)
        {
            var workbook = this.context.Get<Workbook>();
            var workSheet = workbook.Worksheets.Add(sheetName);
            CopyTableContentIntoTheSheet(table, workSheet);
            workbook.Save(workbook.FileName);
        }

        [Given(@"the sheet (.*) also has the following content")]

        public void GivenTheWorkbookHasTheWorksheetWithTheFollowingContent(string sheetName, Table table)
        {
            var workbook = this.context.Get<Workbook>();
            var sheet = workbook.Worksheets[sheetName];
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
