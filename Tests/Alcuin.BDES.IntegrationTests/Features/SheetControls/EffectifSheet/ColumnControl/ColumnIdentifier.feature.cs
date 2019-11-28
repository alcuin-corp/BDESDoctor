// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.1.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Alcuin.BDES.IntegrationTests.Features.SheetControls.EffectifSheet.ColumnControl
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Identifier column Control")]
    public partial class IdentifierColumnControlFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "ColumnIdentifier.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Identifier column Control", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file with missing column \'Matricule\' in the \'effectif\' worksheet shoul" +
            "d have an error message")]
        public virtual void ProcessingFileWithMissingColumnMatriculeInTheEffectifWorksheetShouldHaveAnErrorMessage()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file with missing column \'Matricule\' in the \'effectif\' worksheet shoul" +
                    "d have an error message", null, ((string[])(null)));
#line 3
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
 testRunner.Given("I have a workbook mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table78 = new TechTalk.SpecFlow.Table(new string[] {
                            "Nom",
                            "Prenom",
                            "Age"});
                table78.AddRow(new string[] {
                            "CAIO",
                            "John",
                            "33"});
                table78.AddRow(new string[] {
                            "LEGROS",
                            "Isabelle",
                            "33"});
#line 5
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table78, "And ");
#line hidden
#line 9
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table79 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table79.AddRow(new string[] {
                            "Dans l\'onglet \'effectifs\' la colonne \'Matricule\' n\'est pas présente. Cette colonn" +
                                "e est obligatoire, veuillez vérifier que la colonne est correctement nommée et q" +
                                "ue celle-ci est présente dans l’onglet."});
#line 10
 testRunner.Then("I should found the following Error messages", ((string)(null)), table79, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file within column \'Matricule\' in the \'effectif\' worksheet should have" +
            " a success message")]
        public virtual void ProcessingFileWithinColumnMatriculeInTheEffectifWorksheetShouldHaveASuccessMessage()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file within column \'Matricule\' in the \'effectif\' worksheet should have" +
                    " a success message", null, ((string[])(null)));
#line 14
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 15
 testRunner.Given("I have a workbook mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table80 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Nom",
                            "Prenom",
                            "Age"});
                table80.AddRow(new string[] {
                            "1254",
                            "CAIO",
                            "John",
                            "33"});
                table80.AddRow(new string[] {
                            "1255",
                            "LEGROS",
                            "Isabelle",
                            "33"});
#line 16
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table80, "And ");
#line hidden
#line 20
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table81 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table81.AddRow(new string[] {
                            "La colonne \'Matricule\' de l’onglet \'effectifs\' est bien prise en compte."});
#line 21
 testRunner.Then("I should found the following Succes messages", ((string)(null)), table81, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file within duplicate values in column \'Matricule\' in the \'effectif\' w" +
            "orksheet should have an error message")]
        public virtual void ProcessingFileWithinDuplicateValuesInColumnMatriculeInTheEffectifWorksheetShouldHaveAnErrorMessage()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file within duplicate values in column \'Matricule\' in the \'effectif\' w" +
                    "orksheet should have an error message", null, ((string[])(null)));
#line 25
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 26
 testRunner.Given("I have a workbook mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table82 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Structure",
                            "CSP",
                            "Sexe"});
                table82.AddRow(new string[] {
                            "1254",
                            "Alcuin",
                            "Cadre",
                            "Homme"});
                table82.AddRow(new string[] {
                            "1254",
                            "Alcuin",
                            "Cadre",
                            "Femme"});
#line 27
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table82, "And ");
#line hidden
#line 31
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table83 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table83.AddRow(new string[] {
                            "Dans l\'onglet «effectifs» des doublons de «Matricule» ont été trouvé. Veuillez vé" +
                                "rifier qu’il n’y est pas de «Matricule» en double."});
#line 32
 testRunner.Then("I should found the following Error messages", ((string)(null)), table83, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file with empty cell in column \'Matricule\' should have a warrning mess" +
            "age")]
        public virtual void ProcessingFileWithEmptyCellInColumnMatriculeShouldHaveAWarrningMessage()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file with empty cell in column \'Matricule\' should have a warrning mess" +
                    "age", null, ((string[])(null)));
#line 36
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 37
 testRunner.Given("I have a workbook mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table84 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Structure",
                            "CSP",
                            "Sexe"});
                table84.AddRow(new string[] {
                            "",
                            "Alcuin",
                            "Cadre",
                            "Homme"});
#line 38
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table84, "And ");
#line hidden
#line 41
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table85 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table85.AddRow(new string[] {
                            "Certaines cellules textes sont vides dans votre fichier, les données vides ne ser" +
                                "ont pas prises en compte dans les calculs."});
#line 42
 testRunner.Then("I should found the following Warrning messages", ((string)(null)), table85, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file with invalid cell content in column \'Matricule\' should have an er" +
            "ror message")]
        public virtual void ProcessingFileWithInvalidCellContentInColumnMatriculeShouldHaveAnErrorMessage()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file with invalid cell content in column \'Matricule\' should have an er" +
                    "ror message", null, ((string[])(null)));
#line 46
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 47
 testRunner.Given("I have a workbook mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table86 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Sexe",
                            "Structure",
                            "CSP"});
                table86.AddRow(new string[] {
                            "1235",
                            "Femme",
                            "Interne",
                            "Cadre"});
                table86.AddRow(new string[] {
                            @"125422222222222222222222222222222222222222222222222222222222222222222221111111111111111111111111111nbbbbbbvggggfffffffffdas11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111",
                            "Homme",
                            "Externe",
                            "Cadre"});
#line 48
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table86, "And ");
#line hidden
#line 52
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table87 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table87.AddRow(new string[] {
                            "Dans l\'onglet «effectifs», la colonne «Matricule» contient une valeur texte qui d" +
                                "épasse la limite des 255 caractères. Veuillez vérifier que les valeurs textes re" +
                                "spectent cette limite."});
#line 53
 testRunner.Then("I should found the following Error messages", ((string)(null)), table87, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
