﻿using System.IO;
using System.Linq;
using FluentAlerts.Renderers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace FluentAlerts.Specs
{
    [Binding]
    public class RenderSteps
    {
        private const string DefaultTemplateName = "HtmlWithEmbeddedCssTableTemplate";
        private const string DefaultTemplateFilePath = "DefaultTemplates.json";
        private const string TestTemplateFilePath = "TestTemplates.json";
        private const string TestTemplateName = "TestTemplate";
        private const char TestMemberPathSeperator = ':';
        
        private IFluentAlertSettings _appsettings;
        private TemplateDictionary _templateDictionary;
        private TemplateDictionary _otherTemplateDictionary;
        private Template _template;
        private Template _otherTemplate;
        private ITemplateRender _templateRender;
        private IAlertRenderer _render;
        private string _renderResult;
        private ITemplateIssueHandler _templateIssueHandler;

        private readonly AlertContext _context;
        public RenderSteps(AlertContext context)
        {
            _context = context;
        }

        [Given(@"I have custom app settings")]
        private void GivenIHaveCustomAppSettings()
        {
            _context.Settings = new TestFluentAlertSettings()
                {
                    DefaultTemplateName = TestTemplateName,
                    TemplateFileName = TestTemplateFilePath,
                    MemberPathSeperator = TestMemberPathSeperator
                };
            _appsettings = _context.Settings;
        }

        [Given(@"I set the default template name to (.*)")]
        public void GivenISetTheDefaultTemplateNameTo(string name)
        {
            _context.Settings.DefaultTemplateName = name;
        }

        [Given(@"I set the default template file location to (.*)")]
        public void GivenISetTheDefaultTemplateFileLocationTo(string fileName)
        {
            _context.Settings.TemplateFileName = fileName;
        }

        [Given(@"I have a template file at (.*)")]
        public void GivenIHaveATemplateFileAt(string fileName)
        {
            File.Copy(TestTemplateFilePath, fileName, true);
        }
        
        [Given(@"I have the default app settings")]
        public void GivenIHaveADefaultAppSettings()
        {
            _appsettings = new FluentAlertSettings();
        }

        [Given(@"I have a template issue handler")]
        public void GivenIHaveATemplateIssueHandler()
        {
            _templateIssueHandler = new TemplateIssueHandler(_appsettings, _context.AlertBuilderFactory);
        }

        [When(@"I get the template choices from the default file")]
        [Given(@"I have the template choices from the default file")]
        public void GivenIHaveATemplateDictionary()
        {
            _templateDictionary = new TemplateDictionary(_templateIssueHandler, _appsettings.TemplateFileName());
        }

        [Given(@"I have a (.*) template")]
        public void GivenIHaveANamedTemplate(string templateName)
        {
            _template = _templateDictionary.GetTemplate(templateName);
        }

        [Given(@"I have a template render")]
        public void GivenIHaveATemplateRender()
        {
            _templateRender = new TemplateRenderer(_template);
        }

        [Given(@"I have an alert render")]
        public void GivenIHaveAnAlertRender()
        {
            _render = new AlertRenderer(_context.Transformer, _templateRender);
        }

        //[Given(@"I have a (.*) alert render")]
        // public void GivenIHaveATemplateNameAlertRender(string templateName)
        //{
        //    //Combine all steps to produce a complete render
        //    GivenIHaveCustomAppSettings();
        //    GivenIHaveATemplateDictionary();

        //    if (templateName == "default")
        //        templateName = _appsettings.DefaultTemplateName();
             
        //    GivenIHaveANamedTemplate(templateName);

        //    GivenIHaveATemplateRender();
        //    GivenIHaveAnAlertRender();
        //}
        
        
        [When(@"I render the alert")]
        public void WhenIRenderTheAlert()
        {
            _renderResult = _render.RenderAlert(_context.Alert);
        }

        [When(@"I create a new template dictionary from (.*)")]
        public void WhenICreateANewTemplateDictionaryFrom(string fileName)
        {
            if (fileName == "Default")
                fileName = DefaultTemplateFilePath;

            _otherTemplateDictionary = new TemplateDictionary(_templateIssueHandler,fileName);
        }

        [When(@"I export the templates to (.*)")]
        public void WhenIExportTheTemplatesTo(string fileName)
        {
            _templateDictionary.Export(fileName);
        }

        [When(@"I get the default template")]
        public void WhenIHaveADefaultTemplate()
        {
            _template = _templateDictionary.GetTemplate(_appsettings.DefaultTemplateName());
        }

        [When(@"I get the (.*) as the other template")]
        public void WhenIGetTheOtherNamedTemplate(string templateName)
        {
            _otherTemplate = _templateDictionary.GetTemplate(templateName);
        }


        [Then(@"the rendered text has the default formatting")]
        public void ThenTheRenderedTextHasTheDefaultFormatting()
        {
            File.WriteAllText("render_output.html", _renderResult);
            //ScenarioContext.Current.Pending();
        }
  
        [Then(@"the templates are equivilant")]
        public void ThenTheTemplatesAreEquivilant()
        {
            _template.ShouldBeEquivalentTo(_otherTemplate);
        }
    
        [Then(@"the template dictionaries are equivilant")]
        public void ThenTheTemplateDictionariesAreEquivilant()
        {
            _templateDictionary.Keys.ShouldBeEquivalentTo(_otherTemplateDictionary.Keys);
            foreach (var key in _templateDictionary.Keys) 
            {
                _templateDictionary.GetTemplate(key).ShouldBeEquivalentTo(_otherTemplateDictionary.GetTemplate(key));
            }
        }

        [Then(@"a backup of the original (.*) is written to the same directory")]
        public void ThenABackupOfTheOriginalIsWrittenToTheSameDirectory(string fileName)
        {
            var searchPattern =GetSearchPattern(fileName);
            var f = from fi in Directory.GetFiles(Directory.GetCurrentDirectory() ,searchPattern)
                    orderby fi descending
                    select fi;

            var o = File.ReadAllText(TestTemplateFilePath); 
            var n = File.ReadAllText(f.First());
            o.Should().Be(n);
        }

        [Then(@"clean up file (.*)")]
        public void ThenCleanUpFile(string fileName)
        {
            var searchPattern = GetSearchPattern(fileName);
            foreach (var fn in Directory.GetFiles(Directory.GetCurrentDirectory(), searchPattern))
            {
                File.Delete(fn);
            }
        }

        [Then(@"the settings default template name is the Html with Embedded Css template")]
        public void ThenTheSettingsDefaultTemplateNameIsTheDefault()
        {
            _appsettings.DefaultTemplateName().Should().Be(DefaultTemplateName);
        }


        private static string GetSearchPattern(string fileName)
        {
            var path = Path.GetDirectoryName(fileName);
            return string.Format("{0}*{1}",
                                 Path.GetFileNameWithoutExtension(fileName),
                                 Path.GetExtension(fileName));
        }

    }
}