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
namespace FluentAlerts.Specs.AlertTransformation
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("DeveloperCanSpecifyTheFormattingOfObjectsDuringTransformation")]
    [NUnit.Framework.CategoryAttribute("Transformation")]
    public partial class DeveloperCanSpecifyTheFormattingOfObjectsDuringTransformationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DeveloperCanSpecifyTheFormattingOfObjectsDuringTransformation.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "DeveloperCanSpecifyTheFormattingOfObjectsDuringTransformation", "In order to have full control over the alert output\r\nAs a developer\r\nI want to be" +
                    " able to specify the format of any object during transformation", ProgrammingLanguage.CSharp, new string[] {
                        "Transformation"});
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
        [NUnit.Framework.DescriptionAttribute("Default formatter uses the objects to string on all types")]
        [NUnit.Framework.TestCaseAttribute("Null", null)]
        [NUnit.Framework.TestCaseAttribute("String", null)]
        [NUnit.Framework.TestCaseAttribute("DateTime", null)]
        [NUnit.Framework.TestCaseAttribute("Integer", null)]
        [NUnit.Framework.TestCaseAttribute("Long", null)]
        [NUnit.Framework.TestCaseAttribute("Float", null)]
        [NUnit.Framework.TestCaseAttribute("Double", null)]
        [NUnit.Framework.TestCaseAttribute("NumberEnum", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestClass", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestStruct", null)]
        public virtual void DefaultFormatterUsesTheObjectsToStringOnAllTypes(string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Default formatter uses the objects to string on all types", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given(string.Format("I have a {0} object", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
  testRunner.And("I have the default formatter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.When("I format the object", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then(string.Format("the result is equal to {0} to string", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Default formatter uses the objects to string as a title on all types")]
        [NUnit.Framework.TestCaseAttribute("Null", null)]
        [NUnit.Framework.TestCaseAttribute("String", null)]
        [NUnit.Framework.TestCaseAttribute("DateTime", null)]
        [NUnit.Framework.TestCaseAttribute("Integer", null)]
        [NUnit.Framework.TestCaseAttribute("Long", null)]
        [NUnit.Framework.TestCaseAttribute("Float", null)]
        [NUnit.Framework.TestCaseAttribute("Double", null)]
        [NUnit.Framework.TestCaseAttribute("NumberEnum", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestClass", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestStruct", null)]
        public virtual void DefaultFormatterUsesTheObjectsToStringAsATitleOnAllTypes(string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Default formatter uses the objects to string as a title on all types", exampleTags);
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.Given(string.Format("I have a {0} object", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
  testRunner.And("I have the default formatter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.When("I format the object as a title", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then(string.Format("the result is equal to {0} types name", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Can specify string format by type")]
        [NUnit.Framework.TestCaseAttribute("Null", null)]
        [NUnit.Framework.TestCaseAttribute("String", null)]
        [NUnit.Framework.TestCaseAttribute("DateTime", null)]
        [NUnit.Framework.TestCaseAttribute("Integer", null)]
        [NUnit.Framework.TestCaseAttribute("Long", null)]
        [NUnit.Framework.TestCaseAttribute("Float", null)]
        [NUnit.Framework.TestCaseAttribute("Double", null)]
        [NUnit.Framework.TestCaseAttribute("NumberEnum", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestClass", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestStruct", null)]
        public virtual void CanSpecifyStringFormatByType(string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Can specify string format by type", exampleTags);
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
 testRunner.Given(string.Format("I have a {0} object", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
  testRunner.And("I have the default formatter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
  testRunner.And(string.Format("I insert a format for the {0} at the beginning", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I format the object", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.Then(string.Format("the result is equal to {0} to format", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("WARNING Can hide string format behind more general rule")]
        [NUnit.Framework.TestCaseAttribute("Null", null)]
        [NUnit.Framework.TestCaseAttribute("String", null)]
        [NUnit.Framework.TestCaseAttribute("DateTime", null)]
        [NUnit.Framework.TestCaseAttribute("Integer", null)]
        [NUnit.Framework.TestCaseAttribute("Long", null)]
        [NUnit.Framework.TestCaseAttribute("Float", null)]
        [NUnit.Framework.TestCaseAttribute("Double", null)]
        [NUnit.Framework.TestCaseAttribute("NumberEnum", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestClass", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestStruct", null)]
        public virtual void WARNINGCanHideStringFormatBehindMoreGeneralRule(string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("WARNING Can hide string format behind more general rule", exampleTags);
#line 62
this.ScenarioSetup(scenarioInfo);
#line 63
 testRunner.Given(string.Format("I have a {0} object", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 64
  testRunner.And("I have the default formatter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
  testRunner.And(string.Format("I add a format for the {0}", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.When("I format the object", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
 testRunner.Then(string.Format("the result is equal to {0} to string", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Can specify string format by path")]
        [NUnit.Framework.TestCaseAttribute("Null", null)]
        [NUnit.Framework.TestCaseAttribute("String", null)]
        [NUnit.Framework.TestCaseAttribute("DateTime", null)]
        [NUnit.Framework.TestCaseAttribute("Integer", null)]
        [NUnit.Framework.TestCaseAttribute("Long", null)]
        [NUnit.Framework.TestCaseAttribute("Float", null)]
        [NUnit.Framework.TestCaseAttribute("Double", null)]
        [NUnit.Framework.TestCaseAttribute("NumberEnum", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestClass", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestStruct", null)]
        public virtual void CanSpecifyStringFormatByPath(string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Can specify string format by path", exampleTags);
#line 82
this.ScenarioSetup(scenarioInfo);
#line 83
 testRunner.Given(string.Format("I have a {0} object", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 84
  testRunner.And("I have a formatter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
  testRunner.And(string.Format("I specify a format for the {0} at A.B.C", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.When("I format the object at A.B.C", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.Then(string.Format("the result is equal to {0} to format", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Specifing string format by path does not format type at other paths")]
        [NUnit.Framework.TestCaseAttribute("Null", null)]
        [NUnit.Framework.TestCaseAttribute("String", null)]
        [NUnit.Framework.TestCaseAttribute("DateTime", null)]
        [NUnit.Framework.TestCaseAttribute("Integer", null)]
        [NUnit.Framework.TestCaseAttribute("Long", null)]
        [NUnit.Framework.TestCaseAttribute("Float", null)]
        [NUnit.Framework.TestCaseAttribute("Double", null)]
        [NUnit.Framework.TestCaseAttribute("NumberEnum", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestClass", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestStruct", null)]
        public virtual void SpecifingStringFormatByPathDoesNotFormatTypeAtOtherPaths(string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Specifing string format by path does not format type at other paths", exampleTags);
#line 101
this.ScenarioSetup(scenarioInfo);
#line 102
 testRunner.Given(string.Format("I have a {0} object", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 103
  testRunner.And("I have a formatter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
  testRunner.And(string.Format("I specify a format for the {0} at A.B.C", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.When("I format the object at A.B.D", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
 testRunner.Then(string.Format("the result is equal to {0} to string", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Can insert formatting rules")]
        [NUnit.Framework.TestCaseAttribute("String", null)]
        [NUnit.Framework.TestCaseAttribute("DateTime", null)]
        [NUnit.Framework.TestCaseAttribute("Integer", null)]
        [NUnit.Framework.TestCaseAttribute("Long", null)]
        [NUnit.Framework.TestCaseAttribute("Float", null)]
        [NUnit.Framework.TestCaseAttribute("Double", null)]
        [NUnit.Framework.TestCaseAttribute("NumberEnum", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestClass", null)]
        [NUnit.Framework.TestCaseAttribute("NestedTestStruct", null)]
        public virtual void CanInsertFormattingRules(string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Can insert formatting rules", exampleTags);
#line 120
this.ScenarioSetup(scenarioInfo);
#line 121
 testRunner.Given("I have the default formatter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 122
  testRunner.And(string.Format("I have a {0} object", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
  testRunner.And(string.Format("I insert a specific format for the {0} at the beginning", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
  testRunner.And(string.Format("I insert a different format for {0} in between", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.When("I format the object", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
 testRunner.Then(string.Format("the result is equal to {0} to format", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("If object has no applicable formatting rules a formatting exception will be throw" +
            "n")]
        public virtual void IfObjectHasNoApplicableFormattingRulesAFormattingExceptionWillBeThrown()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("If object has no applicable formatting rules a formatting exception will be throw" +
                    "n", ((string[])(null)));
#line 139
this.ScenarioSetup(scenarioInfo);
#line 140
 testRunner.Given("I have an empty formatter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 141
  testRunner.And("I have a DateTime object", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
 testRunner.When("I format the object", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 143
 testRunner.Then("I expect a FluentAlertFormattingException to be thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("If object has no applicable title formatting rules a formatting exception will be" +
            " thrown")]
        public virtual void IfObjectHasNoApplicableTitleFormattingRulesAFormattingExceptionWillBeThrown()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("If object has no applicable title formatting rules a formatting exception will be" +
                    " thrown", ((string[])(null)));
#line 145
this.ScenarioSetup(scenarioInfo);
#line 146
 testRunner.Given("I have an empty formatter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 147
  testRunner.And("I have a DateTime object", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 148
 testRunner.When("I format the object as a title", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 149
 testRunner.Then("I expect a FluentAlertFormattingException to be thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
