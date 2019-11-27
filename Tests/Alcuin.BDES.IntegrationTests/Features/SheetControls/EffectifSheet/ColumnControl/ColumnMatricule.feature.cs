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
namespace BDES.IntegrationTests.Features.SheetControls.EffectifSheet.ColumnControl
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Matricule column Control")]
    public partial class MatriculeColumnControlFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "ColumnMatricule.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Matricule column Control", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
            "d fail")]
        public virtual void ProcessingFileWithMissingColumnMatriculeInTheEffectifWorksheetShouldFail()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file with missing column \'Matricule\' in the \'effectif\' worksheet shoul" +
                    "d fail", null, ((string[])(null)));
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
                TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                            "Nom",
                            "Prenom",
                            "Age"});
                table34.AddRow(new string[] {
                            "CAIO",
                            "John",
                            "33"});
                table34.AddRow(new string[] {
                            "LEGROS",
                            "Isabelle",
                            "33"});
#line 5
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table34, "And ");
#line hidden
#line 9
 testRunner.When("I start processing the file mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.Then("the process should fail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table35.AddRow(new string[] {
                            "Dans l\'onglet \'effectifs\' la colonne \'Matricule\' n\'est pas présente. Cette colonn" +
                                "e est obligatoire, veuillez vérifier que la colonne est correctement nommée et q" +
                                "ue celle-ci est présente dans l’onglet."});
#line 11
 testRunner.And("I should found the following Erreur messages", ((string)(null)), table35, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file within column \'Matricule\' in the \'effectif\' worksheet should have" +
            " a success log")]
        public virtual void ProcessingFileWithinColumnMatriculeInTheEffectifWorksheetShouldHaveASuccessLog()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file within column \'Matricule\' in the \'effectif\' worksheet should have" +
                    " a success log", null, ((string[])(null)));
#line 15
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
#line 16
 testRunner.Given("I have a workbook mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Nom",
                            "Prenom",
                            "Age"});
                table36.AddRow(new string[] {
                            "1254",
                            "CAIO",
                            "John",
                            "33"});
                table36.AddRow(new string[] {
                            "1235",
                            "LEGROS",
                            "Isabelle",
                            "33"});
#line 17
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table36, "And ");
#line hidden
#line 21
 testRunner.When("I start processing the file mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table37.AddRow(new string[] {
                            "La colonne \'Matricule\' de l’onglet \'effectifs\' est bien prise en compte."});
#line 22
 testRunner.Then("I should found the following Succès messages", ((string)(null)), table37, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion