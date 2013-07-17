﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.17929
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace FluentAlerts.Specs.AlertRendering
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("DeveloperCanRenderAlerts")]
    [NUnit.Framework.CategoryAttribute("Rendering")]
    public partial class DeveloperCanRenderAlertsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DeveloperCanRenderAlerts.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "DeveloperCanRenderAlerts", "", ProgrammingLanguage.CSharp, new string[] {
                        "Rendering"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
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
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Can render an alert")]
        public virtual void CanRenderAnAlert()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Can render an alert", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.Given("I have a full test alert", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
  testRunner.And("I have custom app settings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
  testRunner.And("I set the default template file location to Templates.json", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
  testRunner.And("I have the template choices from the default file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
  testRunner.And("I have a OutlookEmailCompliantTemplate template", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
  testRunner.And("I have a template render", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
  testRunner.And("I have a template issue handler", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
  testRunner.And("I have a default transformer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
  testRunner.And("I have an alert render", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.When("I render the alert", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then("the rendered text has the default formatting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Can specify the template used to render alerts")]
        [NUnit.Framework.CategoryAttribute("Extensibility")]
        public virtual void CanSpecifyTheTemplateUsedToRenderAlerts()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Can specify the template used to render alerts", new string[] {
                        "Extensibility"});
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given("I have custom app settings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
  testRunner.And("I set the default template name to TestTemplate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
  testRunner.And("I have a template issue handler", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
  testRunner.And("I have the template choices from the default file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("I get the default template", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
  testRunner.And("I get the TestTemplate as the other template", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.Then("the templates are equivilant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Can specify the templates source file used for template choices")]
        [NUnit.Framework.CategoryAttribute("Extensibility")]
        public virtual void CanSpecifyTheTemplatesSourceFileUsedForTemplateChoices()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Can specify the templates source file used for template choices", new string[] {
                        "Extensibility"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given("I have custom app settings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
  testRunner.And("I set the default template file location to custom_templates.json", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
  testRunner.And("I have a template file at custom_templates.json", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
  testRunner.And("I have a template issue handler", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.When("I get the template choices from the default file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
  testRunner.And("I create a new template dictionary from custom_templates.json", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.Then("the template dictionaries are equivilant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
  testRunner.And("clean up file custom_templates.json", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Html with Embedded Css template is used when no default template name is specifie" +
            "d")]
        [NUnit.Framework.CategoryAttribute("EaseOfUse")]
        public virtual void HtmlWithEmbeddedCssTemplateIsUsedWhenNoDefaultTemplateNameIsSpecified()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Html with Embedded Css template is used when no default template name is specifie" +
                    "d", new string[] {
                        "EaseOfUse"});
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given("I have the default app settings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.Then("the settings default template name is the Html with Embedded Css template", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Default rendering templates are used when no template file is present")]
        [NUnit.Framework.CategoryAttribute("EaseOfUse")]
        public virtual void DefaultRenderingTemplatesAreUsedWhenNoTemplateFileIsPresent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Default rendering templates are used when no template file is present", new string[] {
                        "EaseOfUse"});
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
 testRunner.Given("I have the default app settings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
  testRunner.And("I have a template issue handler", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I get the template choices from the default file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
  testRunner.And("I create a new template dictionary from Default", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.Then("the template dictionaries are equivilant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Can export and import templates to and from files")]
        [NUnit.Framework.CategoryAttribute("Extensibility")]
        public virtual void CanExportAndImportTemplatesToAndFromFiles()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Can export and import templates to and from files", new string[] {
                        "Extensibility"});
#line 52
this.ScenarioSetup(scenarioInfo);
#line 53
 testRunner.Given("I have the default app settings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
 testRunner.And("I have a template issue handler", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
  testRunner.And("I have the template choices from the default file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.When("I export the templates to export.json", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
  testRunner.And("I create a new template dictionary from export.json", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.Then("the template dictionaries are equivilant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
  testRunner.And("clean up file export.json", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("System will create a backup of the current file when exporting")]
        [NUnit.Framework.CategoryAttribute("Extensibility")]
        [NUnit.Framework.CategoryAttribute("EaseOfUse")]
        public virtual void SystemWillCreateABackupOfTheCurrentFileWhenExporting()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("System will create a backup of the current file when exporting", new string[] {
                        "Extensibility",
                        "EaseOfUse"});
#line 62
this.ScenarioSetup(scenarioInfo);
#line 63
 testRunner.Given("I have custom app settings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 64
  testRunner.And("I have a template issue handler", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
  testRunner.And("I have the template choices from the default file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
  testRunner.And("I have a template file at back_test.json", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.When("I export the templates to back_test.json", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
 testRunner.Then("a backup of the original back_test.json is written to the same directory", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
  testRunner.And("clean up file back_test.json", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
