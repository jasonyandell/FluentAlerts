using System;
using System.ComponentModel;
using System.Linq;
using FluentAlerts;
using FluentAlerts.Extensions;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Specs.FluentAlerts.StepDefinitions
{
    [Binding]
    public class TableStepDefinitions
    {
        private IAlertBuilderFactory _builder;
        private IAlertTableBuilder _table;
        private FluentAlertTable _alertTable;
        private TestObject _object;
        private Exception _exception;
        private int _depth;
        public TableStepDefinitions()
        {
            _builder = new AlertBuilderFactory();
        }


        [Given(@"I create a table with a title '(.*)'")]
        public void GivenICreateATableWithATitle(string title)
        {
            _table = _builder.CreateTable(title);
        }
        [Given(@"I have a table")]
        public void GivenIHaveATable()
        {
            _table = _builder.CreateTable();
        }
        public RowStyle GetRowStyle(string style)
        {
            RowStyle rowStyle;
            RowStyle.TryParse(style, true, out rowStyle);
            return rowStyle;
        }
        [Given(@"I create a table with an object using depth (\d+)")]
        public void GivenICreateATableWithAnObject(int depth)
        {
            _depth = depth;
            _object = TestObject.Create(_depth+1);  //Will show the reflecter stopped before bottom
            _table = _builder.CreateTable(_object, _depth);
        }
        [Given(@"I create a table with an exception")]
        public void GivenICreateATableWithAnException()
        {
            _depth = 3;
            _exception = Mother.GetNestedException(_depth);
            _table = _builder.CreateTable(_exception);
        }


        [When(@"I add the '(.*)' rows")]
        public void WhenIAddTheFollowingRows(string style, Table table)
        {
            var rowStyle = GetRowStyle(style);
            Func<object[], IAlertTableBuilder> add;
            switch (rowStyle)
            {
                case RowStyle.Header:
                    add = _table.AddHeaderRow ;
                    break;
                case RowStyle.Highlighted:
                    add = _table.AddHighlightedRow;
                    break;
                case RowStyle.Normal:
                    add = _table.AddRow;
                    break;
                case RowStyle.Footer:
                    add = _table.AddFooterRow ;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
            
            foreach (var row in table.Rows)
            {
                add(row.Values.ToArray());
            }
        }
        [When(@"I build the alert")]
        public void WhenIBuildTheAlert()
        {
            _alertTable = _table.ToAlert() as FluentAlertTable;
        }
        

         [Then(@"the table should have a row for the type, message and stack trace for all exception in chain")]
        public void ThenTheTableShouldHaveARowForTheTypeMessageAndStackTraceForAllExceptionInChain()
        {
            AssertIsTableForException(_alertTable, _exception);
        }
        [Then(@"the title is the objects type")]
        public void ThenTitleIsTheObjectsType()
        {
            AssertTitleIsTheObjectsTypeRecursively(_alertTable,_object,_depth);
        }
        [Then(@"a row is added for each property with cells for property name and property value")]
        public void ThenARowIsAddedForEachPropertyWithCellsForPropertyNameAndPropertyValue()
        {
            AssertHasSingleRowForEachPropertyWithCellsForPropertyNameAndPropertyValueRecursively(_alertTable, _object, _depth);
        }
        [Then(@"the alert should have (\d+) rows")]
        public void ThenTheAlertShouldHaveXRows(int rows)
        {
            Assert.AreEqual(rows, _alertTable.Rows.Count);
        }
        [Then(@"the alert should have (\d+) columns")]
        public void ThenTheAlertShouldHaveXColumns(int columnCount)
        {
            Assert.AreEqual(columnCount, _alertTable.ColumnCount);
        }
        [Then(@"row (\d+) should have (\d+) cells")]
        public void ThenRowXShouldHaveYCells(int row, int cells)
        {
            Assert.AreEqual(cells, GetRow(_alertTable,row).Values.Length);
        }
        [Then(@"row (\d+) should be a '(.*)' row")]
        public void ThenRowXShouldBeAHeaderRow(int row, string style)
        {
            Assert.AreEqual(GetRowStyle(style), GetRow(_alertTable, row).Style);
        }
        [Then(@"row (\d+) cell (\d+) should be '(.*)'")]
        public void ThenRowXCellXShouldBeATypeEqualToValue(int row, int cell, string value)
        {
            Assert.AreEqual(value, GetCell<string>(_alertTable, row,cell));
        }
        
        #region helpers 
        private const int ROW_NAME_CELL = 1;
        private const int ROW_VALUE_CELL = 2;
        private static string GetTitle(FluentAlertTable alertTable)
        {
            return GetCell<string>(alertTable, r => r.Style == RowStyle.Header && r.Values.Length == 1, 1);
        }
        private static FluentAlertTable.Row GetRow(FluentAlertTable alertTable, int row)
        {
            return alertTable.Rows[row - 1];
        }
        private static FluentAlertTable.Row GetRow(FluentAlertTable alertTable, Func<FluentAlertTable.Row, bool> rowMatchPredicate)
        {
            return alertTable.Rows.FirstOrDefault(rowMatchPredicate);
        }
        private static TCell GetNameCell<TCell>(FluentAlertTable alertTable, int row)
        {
            return GetCell<TCell>(GetRow(alertTable, row), ROW_NAME_CELL);
        }
        private static TCell GetValueCell<TCell>(FluentAlertTable alertTable, int row)
        {
            return GetCell<TCell>(GetRow(alertTable, row), ROW_VALUE_CELL);
        }
        private static TCell GetCell<TCell>(FluentAlertTable alertTable, int row, int cell)
        {
            return GetCell<TCell>(GetRow(alertTable, row), cell);
        }
        private static TCell GetCell<TCell>(FluentAlertTable alert, string rowName, int cell)
        {
            return GetCell<TCell>(alert, r => GetCell<string>(r, ROW_NAME_CELL) == rowName, cell);
        }
        private static TCell GetCell<TCell>(FluentAlertTable alert, string rowName, RowStyle rowStyle, int cell)
        {
            return GetCell<TCell>(alert, r => GetCell<string>(r,ROW_NAME_CELL) == rowName && r.Style == rowStyle, cell);
        }
        private static TCell GetCell<TCell>(FluentAlertTable alertTable, Func<FluentAlertTable.Row, bool> rowMatchPredicate, int cell)
        {
            var row = GetRow(alertTable,rowMatchPredicate);
            return GetCell<TCell>(row, cell);
        }
        private static TCell GetCell<TCell>(FluentAlertTable.Row row, int cell)
        {
            var result = (TCell)row.Values[cell - 1];
            return result;
        }

        private static void AssertIsTableForException(FluentAlertTable alert, Exception ex)
        {
            var row = 1;
            foreach (var e in ex.ToList())
            {
                //Scrolled list of Title, Message, StackTrace
                Assert.AreEqual(e.GetType().Name, GetNameCell<string>(alert,row), "Title");
                Assert.AreEqual(e.Message, GetValueCell<string>(alert, row+1), "Message");
                Assert.AreEqual(e.StackTrace, GetValueCell<string>(alert, row+2), "Stack Trace");
                
                //increment three rows
                row += 3;
            }
        }
        private static void AssertTitleIsTheObjectsTypeRecursively(FluentAlertTable alert, TestObject source, int toDepth = 0)
        {
            Assert.AreEqual(source.GetType().Name, GetTitle(alert), "Title");

            if (toDepth == 0) return;
            var innerAlert = GetCell<FluentAlertTable>(alert, "Inner", ROW_VALUE_CELL);
            AssertTitleIsTheObjectsTypeRecursively(innerAlert, source.Inner, --toDepth);
        }
        private static void AssertHasSingleRowForEachPropertyWithCellsForPropertyNameAndPropertyValueRecursively(FluentAlertTable alert, TestObject source, int toDepth)
        {
            Assert.AreEqual(source.One, GetCell<string>(alert, "One", RowStyle.Normal, ROW_VALUE_CELL));
            Assert.AreEqual(source.Two, GetCell<decimal>(alert, "Two", RowStyle.Normal, ROW_VALUE_CELL));
            if (toDepth == 0) return;
            AssertHasSingleRowForEachPropertyWithCellsForPropertyNameAndPropertyValueRecursively(
                GetCell<FluentAlertTable>(alert, "Inner", ROW_VALUE_CELL), source.Inner, --toDepth);
        }
        #endregion
    }

}
