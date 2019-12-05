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
    [NUnit.Framework.DescriptionAttribute("Contract termination nature column Control")]
    public partial class ContractTerminationNatureColumnControlFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "ColumnContractTerminationNature.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Contract termination nature column Control", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Processing file within column \'Nature de la fin de contrat\' in \'effectifs\' worksh" +
            "eet should have a success log")]
        public virtual void ProcessingFileWithinColumnNatureDeLaFinDeContratInEffectifsWorksheetShouldHaveASuccessLog()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file within column \'Nature de la fin de contrat\' in \'effectifs\' worksh" +
                    "eet should have a success log", null, ((string[])(null)));
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
                TechTalk.SpecFlow.Table table49 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Structure",
                            "Nom",
                            "Prenom",
                            "Age",
                            "CSP",
                            "Sexe",
                            "Date de naissance",
                            "Type de contrat",
                            "Date d\'entrée",
                            "Date de sortie",
                            "Nature de la fin de contrat"});
                table49.AddRow(new string[] {
                            "1254",
                            "Alcuin",
                            "CAIO",
                            "John",
                            "33",
                            "CADRE",
                            "Homme",
                            "16/03/1986",
                            "CDI",
                            "12/11/2019",
                            "12/11/2021",
                            "Dem"});
                table49.AddRow(new string[] {
                            "1235",
                            "Alcuin",
                            "LEGROS",
                            "Isabelle",
                            "33",
                            "CADRE",
                            "Femme",
                            "13/05/1993",
                            "CDD",
                            "14/11/2019",
                            "14/11/2020",
                            "Dem"});
#line 5
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table49, "And ");
#line hidden
#line 9
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table50 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table50.AddRow(new string[] {
                            "La colonne \'Nature de la fin de contrat\' de l’onglet \'Effectifs\' est bien prise e" +
                                "n compte."});
#line 10
 testRunner.Then("I should found the following Succes messages", ((string)(null)), table50, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file without column \'Nature de la fin de contrat\' in \'effectifs\' shoul" +
            "d have a warrning message")]
        public virtual void ProcessingFileWithoutColumnNatureDeLaFinDeContratInEffectifsShouldHaveAWarrningMessage()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file without column \'Nature de la fin de contrat\' in \'effectifs\' shoul" +
                    "d have a warrning message", null, ((string[])(null)));
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
                TechTalk.SpecFlow.Table table51 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Structure",
                            "CSP",
                            "Sexe"});
                table51.AddRow(new string[] {
                            "1254",
                            "Alcuin",
                            "CADRE",
                            "Homme"});
                table51.AddRow(new string[] {
                            "1235",
                            "Alcuin",
                            "CADRE",
                            "Femme"});
#line 16
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table51, "And ");
#line hidden
#line 20
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table52 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table52.AddRow(new string[] {
                            "La colonne \'Nature de la fin de contrat\' n\'est pas présente dans L\'onglet \'Effect" +
                                "ifs\', aucun indicateur lié à cette colonne ne sera calculé lors de la conversion" +
                                "."});
#line 21
 testRunner.Then("I should found the following Warrning messages", ((string)(null)), table52, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Processing file with invalid cell content in column \'Nature de la fin de contrat\'" +
            " should faild")]
        public virtual void ProcessingFileWithInvalidCellContentInColumnNatureDeLaFinDeContratShouldFaild()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file with invalid cell content in column \'Nature de la fin de contrat\'" +
                    " should faild", null, ((string[])(null)));
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
                TechTalk.SpecFlow.Table table53 = new TechTalk.SpecFlow.Table(new string[] {
                            "Matricule",
                            "Structure",
                            "CSP",
                            "Sexe",
                            "Nature de la fin de contrat"});
                table53.AddRow(new string[] {
                            "1254",
                            "Alcuin",
                            "Cadre",
                            "Homme",
                            "Contrat"});
#line 27
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table53, "And ");
#line hidden
#line 30
 testRunner.When("I start processing the file mybook.xlsx for the period of 2015", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table54 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table54.AddRow(new string[] {
                            "Dans l\'onglet «Effectifs», la colonne «Nature de la fin de contrat» à une valeur " +
                                "texte qui n’est pas reconnue \'Contrat\'. Les valeurs pouvant être utilisées sont " +
                                "«Retraite, Décès, Démission, Fin de CDD, Licenciement, Licenciement économique, " +
                                "Pré-retraite»."});
#line 31
 testRunner.Then("I should found the following Error messages", ((string)(null)), table54, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
