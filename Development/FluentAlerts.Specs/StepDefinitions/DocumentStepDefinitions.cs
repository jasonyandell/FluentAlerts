using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAlerts;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Specs.FluentAlerts.StepDefinitions
{
    [Binding]
    public class DocumentStepDefinitions
    {
        private IAlertBuilderFactory _builder;
        private IAlertDocumentBuilder _doc;
        private CompositeFluentAlert _alertDoc;
        private string _text;
        private string _url;
        private TestObject _object;
        private IEnumerable<TestObject> _objects;
        private Exception _exception;


        [Given(@"I have a builder")]
        public void GivenIHaveABuilder()
        {
            _builder = new AlertBuilderFactory();
        }

        [Given(@"I have a document")]
        public void GivenIHaveADocument()
        {
            _doc = _builder.CreateDocument();
        }
        [Given(@"I have some text")]
        public void GivenIHaveSomeText()
        {
            _text = "asdgashgasgvqwtcqwertcqwrtc qwrt";
        }
        [Given(@"I have some url")]
        public void GivenIHaveSomeUrl()
        {
            _url = "http://afasgawegwq.sdfvas";
        }
        [Given(@"I have an exception")]
        public void GivenIHaveAnException()
        {
            _exception = Mother.GetNestedException(2);
        }
        [Given(@"I have a list of  objects")]
        public void GivenIHaveAListOfObjects()
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I create a document")]
        public void WhenICreateADocument()
        {
            _doc = _builder.CreateDocument();
        }
        [When(@"I create a document with the text")]
        public void WhenICreateADocumentWithTheTextTitle()
        {
            _doc = _builder.CreateDocument(_text);
        }
        [When(@"I add a exception as a list")]
        public void WhenIAddAExceptionAsAList()
        {
            _doc.AddExceptionAsList(_exception);
        }
        [When(@"I add a exception as a table")]
        public void WhenIAddAExceptionAsATable()
        {
            _doc.AddExceptionAsTable(_exception);
        }
        [When(@"I add a seperator")]
        public void WhenIAddASeperator()
        {
            _doc.AddSeperator();
        }
        [When(@"I add a url")]
        public void WhenIAddAUrl()
        {
            _doc.AddURL(_text, _url);
        }
        [When(@"I add a object as a table")]
        public void WhenIAddAObjectAsATable()
        {
            _doc.AddAsTable(_object);
        }
        [When(@"I add a list of objects as a list of tables")]
        public void WhenIAddAListOfObjectsAsAListOfTables()
        {
            _doc.AddAsTables(_objects);
        }
        [When(@"I add a url wit the text as the name")]
        public void WhenIAddAUrlWitTheTextAsTheName()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"the document should be empty")]
        public void ThenTheDocumentShouldBeEmpty()
        {
            Assert.AreEqual(0,_alertDoc.Count);
        }
        [Then(@"the document should be a list of alerts")]
        public void ThenTheDocumentShouldBeAListOfAlerts()
        {
            Assert.IsInstanceOf<CompositeFluentAlert>(_alertDoc);
        }
        [Then(@"the document should contain a url as the last alert")]
        public void ThenTheDocumentShouldContainAUrlAsTheLastAlert()
        {
            ScenarioContext.Current.Pending();
        }
        [Then(@"the document should contain a seperator as the last alert")]
        public void ThenTheDocumentShouldContainASeperatorAsTheLastAlert()
        {
            ScenarioContext.Current.Pending();
        }
        [Then(@"the document should contain a text block with a value of the text as the last alert")]
        public void ThenTheDocumentShouldContainATextBlockWithAValueOfTheTextTitleAsTheLastAlert()
        {
            ScenarioContext.Current.Pending();
        }
        [Then(@"the document should contain a url as the last alert with the url and text")]
        public void ThenTheDocumentShouldContainAUrlAsTheLastAlertWithTheUrlAndText()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
