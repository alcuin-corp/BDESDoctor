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
namespace Alcuin.BDES.IntegrationTests.Features.SheetControls.AbsencesSheet
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Absence workSheet Control")]
    public partial class AbsenceWorkSheetControlFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "AbsencesSheetControl.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Absence workSheet Control", "\tIn order to validate \'Absence\' worksheet control\r\n\tAs a user\r\n\tI want to control" +
                    " \'Absences\' worksheet.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Processing file with missing \'Absences\' worksheet should fail")]
        public virtual void ProcessingFileWithMissingAbsencesWorksheetShouldFail()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file with missing \'Absences\' worksheet should fail", null, ((string[])(null)));
#line 6
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
#line 7
 testRunner.Given("I have a workbook mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Nom",
                            "Prenom"});
                table25.AddRow(new string[] {
                            "1254",
                            "John",
                            "CONNOR"});
#line 8
 testRunner.And("it has a workSheet Effectifs with the following content", ((string)(null)), table25, "And ");
#line hidden
#line 11
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 12
 testRunner.Then("the process should fail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table26.AddRow(new string[] {
                            "L\'onglet \'Absences\' n\'est pas présent dans votre fichier, aucun indicateur lié au" +
                                "x absences ne sera calculé lors de la conversion."});
#line 13
 testRunner.And("I should found the following Warrning messages", ((string)(null)), table26, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file within \'Effectifs\' worksheet should have a success log")]
        public virtual void ProcessingFileWithinEffectifsWorksheetShouldHaveASuccessLog()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file within \'Effectifs\' worksheet should have a success log", null, ((string[])(null)));
#line 17
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
#line 18
 testRunner.Given("I have a workbook mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricul",
                            "Nom",
                            "Prenom"});
                table27.AddRow(new string[] {
                            "1254",
                            "John",
                            "CONNOR"});
#line 19
 testRunner.And("it has a workSheet Effectifs with the following content", ((string)(null)), table27, "And ");
#line hidden
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Nom",
                            "Prenom"});
                table28.AddRow(new string[] {
                            "1254",
                            "John",
                            "CONNOR"});
#line 22
 testRunner.And("it has also a workSheet Absences with the following content", ((string)(null)), table28, "And ");
#line hidden
#line 25
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table29.AddRow(new string[] {
                            "L’onglet \'Absences\' est bien pris en compte."});
#line 26
 testRunner.Then("I should found the following Succes messages", ((string)(null)), table29, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
