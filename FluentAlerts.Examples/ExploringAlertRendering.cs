﻿using System;
using FluentAlerts.Domain;
using NUnit.Framework;

namespace FluentAlerts.Examples
{

    /*
     * Lets play around with serializing some Alerts, change up what you like,
     * but for the best experience pull the rendered alert text from the your 
     * test runners output window and view it in a browser or on some site like 
     * cssdesk.com
     */

    [TestFixture]
    public class ExploringAlertRendering : BaseExample
    {
        [Test]
        public void AlertsAreJustObjectTreesSoYouCanUseYourOwnObjectsTurnAnObjectIntoAnAlert()
        {
            // Note how the objects public properties and fields are enumerated in
            // the result, with nested classes being enumerated to given depth.  And
            // the format of the each types string representation.
            // This is driven by the Transformer and Formatter classes used
            // as well as the type info and formatter rules.
            // ** We will get into modifying each one of those later
            SerializeToConsole(Mother.CreateNestedTestObject(3), Alerts.HtmlSerializer());
        }

        [Test]
        public void TurnAnExceptionIntoAnAlert()
        {
            // An exception, or in this a class derived from exception is just another
            // object like above, but since we will be using these a lot and I
            // needed an example of how to specify transformation by type, here it is.
            // Note how the properties are limited to a select list an ordered in 
            // a specific way (as apposed to alpha in the example above).
            try
            {
                throw Mother.CreateNestedException(4);
            }
            catch (Exception ex)
            {
                SerializeToConsole(Mother.CreateNestedTestObject(3), Alerts.HtmlSerializer());
            }
        }

        //TODO: show Alerts are just object trees so no need for anything but your own object
        //TODO: Show 
        [Test]
        public void HtmlSerializeTable()
        {
            SerializeToConsole(GetTestTableAlert(), Alerts.HtmlSerializer());
        }
        [Test]
        public void HtmlSerializeDocument()
        {
            var doc = Alerts.Document("Create a simple document like alert")
                .WithHorizontalRule()
                .WithHeader("Hear is some code that is relevant to this alert (at Header 2)", 2)
                .WithCodeBlock("C#",
@"private string GetSpanningDecoration(int index, int maximumValueIndex)
{
    //span all remaining columns
    var span = 1 + (maximumValueIndex - index);
    var spanArgs = new[]
        {
            new RenderTemplateArguement(DecorationBasedRenderTemplateArguementType.SpanColumns,
                                        span.ToString())
        };
    return RenderTemplateItem(DecorationBasedRenderTemplateItemType.ValueSpanningDecoration, spanArgs);
}"
                )
                .WithLink("https://github.com/jeffwindsor/FluentAlerts", "Link to Github Source Code")
                .WithHorizontalRule()
                .WithTextBlock("Simple Text")
                .WithHorizontalRule()
                .With(Alerts.TextBlock().WithNormal("Starting normal").WithItalic(" then italics").WithBold(" then bold").WithUnderscore(" then underscore").WithStrikeThrough(" strike through").WithNewLine().WithNormal("And a new line"))
                .WithHorizontalRule()
                .With(Alerts.HeaderTextBlock(1).WithNormal("Starting Header 1").WithItalic(" then italics").WithBold(" then bold").WithUnderscore(" then underscore").WithStrikeThrough(" strike through").WithNewLine().WithNormal("And a new line"))
                .WithHorizontalRule()
                .With(Alerts.HeaderTextBlock(3).WithNormal("Starting Header 3").WithItalic(" then italics").WithBold(" then bold").WithUnderscore(" then underscore").WithStrikeThrough(" strike through").WithNewLine().WithNormal("And a new line"))
                .WithHorizontalRule()
                .WithOrderedList("one", "two", "three", 25, Guid.NewGuid(), "whatever you wants", "substitutions < & >")
                .WithHorizontalRule()
                .With(Mother.CreateNestedTestObject(1))
                //.WithHorizontalRule()
                //.With(Mother.CreateNestedException(3))
                //.WithHorizontalRule()
                //.With(GetTestTableAlert())
                .ToDocument();

            SerializeToConsole(doc, Alerts.HtmlSerializer());
        }

        private Table GetTestTableAlert()
        {
            var Alerts = Get<IFluentAlerts>();
            return Alerts.Table("Lets Play with layout to see what the render does.")
                               .WithHeaderRow("Putting the largest number of values in a section sets the number of columns, this is dynamic so this can happen anywhere in the alert")
                               .WithRow("One", "Two", "Three", "Four", "Five")
                               .WithEmphasizedRow("Any other value list with fewer columns will span the last column by default")
                               .WithRow("One", "Two", "Three", "Four")
                               .WithRow("One", "Two", "Three")
                               .WithRow("One", "Two")
                               .WithRow("One")
                               .WithEmphasizedRow("This works on any style, but this is Emphasized")
                               .WithEmphasizedRow("Emp One", "Emp Two", "Emp Three")
                               .WithEmphasizedRow("Put What Ever you want into the Rows")
                               .WithRow("Like Mixed Types", 25, Guid.NewGuid(), "whatever you wants")
                               .WithRow("Like Code", Alerts.CodeBlock("C#", 
@"private string GetSpanningDecoration(int index, int maximumValueIndex)
{
    //span all remaining columns
    var span = 1 + (maximumValueIndex - index);
    var spanArgs = new[]
        {
            new RenderTemplateArguement(DecorationBasedRenderTemplateArguementType.SpanColumns,
                                        span.ToString())
        };
    return RenderTemplateItem(DecorationBasedRenderTemplateItemType.ValueSpanningDecoration, spanArgs);
}"
                               ))
                               .WithRow("Like Objects", Mother.CreateNestedTestObject(3))
                               .WithRow("Like Exceptions", Mother.CreateNestedException(3))
                               .ToTable();

        }
    }
}
