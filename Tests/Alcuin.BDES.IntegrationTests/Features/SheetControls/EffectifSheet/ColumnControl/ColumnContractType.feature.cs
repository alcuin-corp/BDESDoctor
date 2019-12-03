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
    [NUnit.Framework.DescriptionAttribute("Contract type column Control")]
    public partial class ContractTypeColumnControlFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "ColumnContractType.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Contract type column Control", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Processing file within column \'Type de contrat\' in \'effectifs\' worksheet should h" +
            "ave a success log")]
        public virtual void ProcessingFileWithinColumnTypeDeContratInEffectifsWorksheetShouldHaveASuccessLog()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file within column \'Type de contrat\' in \'effectifs\' worksheet should h" +
                    "ave a success log", null, ((string[])(null)));
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
                TechTalk.SpecFlow.Table table54 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Structure",
                            "CSP",
                            "Sexe",
                            "Type de contrat"});
                table54.AddRow(new string[] {
                            "1254",
                            "Alcuin",
                            "CADRE",
                            "Homme",
                            "CDI"});
                table54.AddRow(new string[] {
                            "1235",
                            "Alcuin",
                            "CADRE",
                            "Femme",
                            "CDD"});
#line 5
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table54, "And ");
#line hidden
#line 9
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table55 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table55.AddRow(new string[] {
                            "La colonne \'Type de contrat\' de l’onglet \'Effectifs\' est bien prise en compte."});
#line 10
 testRunner.Then("I should found the following Succes messages", ((string)(null)), table55, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file within column \'Type de contrat\' in \'effectifs\' should have a warr" +
            "ning message")]
        public virtual void ProcessingFileWithinColumnTypeDeContratInEffectifsShouldHaveAWarrningMessage()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file within column \'Type de contrat\' in \'effectifs\' should have a warr" +
                    "ning message", null, ((string[])(null)));
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
                TechTalk.SpecFlow.Table table56 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Structure",
                            "CSP",
                            "Sexe"});
                table56.AddRow(new string[] {
                            "1254",
                            "Alcuin",
                            "CADRE",
                            "Homme"});
                table56.AddRow(new string[] {
                            "1235",
                            "Alcuin",
                            "CADRE",
                            "Femme"});
#line 16
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table56, "And ");
#line hidden
#line 20
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table57 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table57.AddRow(new string[] {
                            "La colonne \'Type de contrat\' n\'est pas présente dans L\'onglet \'Effectifs\', aucun " +
                                "indicateur lié à cette colonne ne sera calculé lors de la conversion."});
#line 21
 testRunner.Then("I should found the following Warrning messages", ((string)(null)), table57, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file with empty cell in column \'Type de contrat\' should have a warrnin" +
            "g message")]
        public virtual void ProcessingFileWithEmptyCellInColumnTypeDeContratShouldHaveAWarrningMessage()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file with empty cell in column \'Type de contrat\' should have a warrnin" +
                    "g message", null, ((string[])(null)));
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
                TechTalk.SpecFlow.Table table58 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Structure",
                            "CSP",
                            "Sexe",
                            "Type de contrat"});
                table58.AddRow(new string[] {
                            "12345",
                            "Alcuin",
                            "Cadre",
                            "Homme",
                            ""});
#line 27
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table58, "And ");
#line hidden
#line 30
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table59 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table59.AddRow(new string[] {
                            "Dans l\'onglet «Effectifs», la colonne «Type de contrat» à une valeur texte qui n’" +
                                "est pas reconnue \'\'. Les valeurs pouvant être utilisées sont «CDI, CDD, CIE, Alt" +
                                "ernance, Professionnalisation, CTT, CUI, CAE»."});
#line 31
 testRunner.Then("I should found the following Error messages", ((string)(null)), table59, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file with invalid cell content in column \'Type de contrat\' should fail" +
            "d")]
        public virtual void ProcessingFileWithInvalidCellContentInColumnTypeDeContratShouldFaild()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file with invalid cell content in column \'Type de contrat\' should fail" +
                    "d", null, ((string[])(null)));
#line 35
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
#line 36
 testRunner.Given("I have a workbook mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table60 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Structure",
                            "CSP",
                            "Sexe",
                            "Type de contrat"});
                table60.AddRow(new string[] {
                            "1254",
                            "Alcuin",
                            "Cadre",
                            "Homme",
                            "Contrat"});
#line 37
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table60, "And ");
#line hidden
#line 40
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table61 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table61.AddRow(new string[] {
                            "Dans l\'onglet «Effectifs», la colonne «Type de contrat» à une valeur texte qui n’" +
                                "est pas reconnue \'Contrat\'. Les valeurs pouvant être utilisées sont «CDI, CDD, C" +
                                "IE, Alternance, Professionnalisation, CTT, CUI, CAE»."});
#line 41
 testRunner.Then("I should found the following Error messages", ((string)(null)), table61, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
