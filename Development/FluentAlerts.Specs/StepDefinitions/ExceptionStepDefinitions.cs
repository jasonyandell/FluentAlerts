using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAlerts;
using FluentAlerts.Extensions;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Specs.FluentAlerts.StepDefinitions
{
    [Binding]
    public class ExceptionStepDefinitions
    {
        private FluentAlertException _alertException;
        private IAlertDocumentBuilder _builder;
        private IFluentAlert _alert;
        private Exception _innerException;
        private string _textMessage;

        [Given(@"a non-empty builder")]
        public void GivenANonEmptyBuilder()
        {
            _builder = new AlertBuilderFactory()
                .CreateDocument("Test Title")
                .AddSeperator()
                .AddTextBlock("Test Text");
        }
        [Given(@"an inner exception")]
        public void GivenAnInnerException()
        {
            _innerException = Mother.GetNestedException(1);
        }
        [Given(@"an alert")]
        public void GivenAnAlert()
        {
            if(_builder == null) GivenANonEmptyBuilder();
            _alert = _builder.ToAlert();
        }
        [Given(@"a text message")]
        public void GivenATextMessage()
        {
            _textMessage = "sdghasfhastvqwvtqw erytewqrv qwry";
        }



        [When(@"I create an alert exception with the builder")]
        public void WhenICreateAnAlertExceptionWithTheBuilder()
        {
            _alertException = new FluentAlertException(_builder);
        }
        [When(@"I create an alert exception with a builder and other exception")]
        public void WhenICreateAnAlertExceptionWithABuilderAndOtherException()
        {
            _alertException = new FluentAlertException(_builder, _innerException);
        }
        [When(@"I create an alert exception with the alert")]
        public void WhenICreateAnAlertExceptionWithTheAlert()
        {
            _alertException = new FluentAlertException(_alert);
        }
        [When(@"I create an alert exception with an alert and other exception")]
        public void WhenICreateAnAlertExceptionWithAnAlertAndOtherException()
        {
            _alertException = new FluentAlertException(_alert, _innerException);
        }
        [When(@"I create an alert exception with the text message")]
        public void WhenICreateAnAlertExceptionWithTheTextMessage()
        {
            _alertException = new FluentAlertException(_textMessage);
        }
        [When(@"I create an alert exception with text message and the inner exception")]
        public void WhenICreateAnAlertExceptionWithTextMessageAndTheInnerException()
        {
            _alertException = new FluentAlertException(_textMessage,_innerException);
        }



        [Then(@"the exception alert is the alert created from the builder")]
        public void ThenTheExceptionAlertIsTheAlertCreatedFromTheBuilder()
        {
            Assert.AreEqual(_builder.ToAlert(), _alertException.Alert);
        }
        [Then(@"inner exception is other exception")]
        public void ThenInnerExceptionIsOtherException()
        {
            Assert.AreEqual(_innerException , _alertException.InnerException);
        }
        [Then(@"the exception alert is the alert")]
        public void ThenTheExceptionAlertIsTheAlert()
        {
            Assert.AreEqual(_alert, _alertException.Alert);
        }
        [Then(@"the exception message is the alert serialized to text")]
        public void ThenTheExceptionMessageIsTheAlertSerializedToText()
        {
            Assert.AreEqual(
                _alert.ToText(o=>o.Replace(Environment.NewLine,string.Empty)), 
                _alertException.Message);
        }
        [Then(@"the exception alert contains a text block containing the text message")]
        public void ThenTheExceptionAlertContainsATextBlockContainingSomeText()
        {
            Assert.IsInstanceOf<FluentAlertTextBlock>(_alertException.Alert);
            var alert = _alertException.Alert as FluentAlertTextBlock;
            var actual = alert.Text.ToString();
            Assert.AreEqual( _textMessage, actual);
        }
        [Then(@"exception message is the text message")]
        public void ThenExceptionMessageIsTheSomeText()
        {
            var actual = _alertException.Message;
            Assert.AreEqual(_textMessage, actual);
        }



    }
}
