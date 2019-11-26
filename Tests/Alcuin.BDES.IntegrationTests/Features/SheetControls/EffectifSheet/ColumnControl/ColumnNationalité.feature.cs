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
namespace BDES.IntegrationTests.Features.EffectifSheet.ColumnControl
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("\'Nationalité\' column Control")]
    public partial class NationaliteColumnControlFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "ColumnNationalité.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "\'Nationalité\' column Control", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Processing file within column \'Nationalité\' in \'effectifs\' should have a success " +
            "log")]
        public virtual void ProcessingFileWithinColumnNationaliteInEffectifsShouldHaveASuccessLog()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing file within column \'Nationalité\' in \'effectifs\' should have a success " +
                    "log", null, ((string[])(null)));
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
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
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
                            "Nature de la fin de contrat",
                            "Horaire hebdomadaire",
                            "Salaire mensuel brut",
                            "Nationalité"});
                table28.AddRow(new string[] {
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
                            "Dem",
                            "35",
                            "55000",
                            "Francaise"});
                table28.AddRow(new string[] {
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
                            "Dem",
                            "38",
                            "35000",
                            "Francaise"});
#line 5
 testRunner.And("it has a workSheet effectifs with the following content", ((string)(null)), table28, "And ");
#line hidden
#line 9
 testRunner.When("I start processing the file mybook.xlsx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Message"});
                table29.AddRow(new string[] {
                            "La colonne \'Nationalité\' de l’onglet \'effectifs\' est bien prise en compte."});
#line 10
 testRunner.Then("I should found the following Succès messages", ((string)(null)), table29, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
