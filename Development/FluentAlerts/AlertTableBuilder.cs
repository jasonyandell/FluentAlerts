using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentAlerts
{
    public interface IAlertTableBuilder: IAlertBuilder 
    {
        IAlertTableBuilder WithNumberOfColumns(int columns);
        IAlertTableBuilder AddRow(params object[] values);
        IAlertTableBuilder AddHeaderRow(params object[] values);
        IAlertTableBuilder AddFooterRow(params object[] values);
        IAlertTableBuilder AddHighlightedRow(params object[] values);
        IAlertTableBuilder AddPropertyNameValuesAsRows<T>(T source, int convertRefTypesToDepth, IEnumerable<string> limitToPropertyNames = null);
    }

    internal class AlertTableBuilder : IAlertTableBuilder
    {
        private readonly AlertTable _table = new AlertTable();
        public IAlert ToAlert() { return _table; }
        public IAlertTableBuilder WithNumberOfColumns(int columns)
        {
            _table.ColumnCount = columns;
            return this;
        }
        public IAlertTableBuilder AddRow(params object[] values) { return AddTypedRow(RowStyle.Normal, values); }
        public IAlertTableBuilder AddHeaderRow(params object[] values) { return AddTypedRow(RowStyle.Header, values); }
        public IAlertTableBuilder AddFooterRow(params object[] values) { return AddTypedRow(RowStyle.Footer, values); }
        public IAlertTableBuilder AddHighlightedRow(params object[] values) { return AddTypedRow(RowStyle.Highlighted, values); }
        private IAlertTableBuilder AddTypedRow(RowStyle style, params object[] values)
        {
            _table.AddRow(style, values);
            return this;
        }

        public IAlertTableBuilder AddPropertyNameValuesAsRows<T>(T source, int convertRefTypesToDepth, IEnumerable<string> limitToPropertyNames = null)
        {
            //Get Property Name Value Pairs
            var pairs = GetPropertyNameValuePairs(source, limitToPropertyNames);

            //Add Pairs as Rows
            foreach (var row in pairs)
            {
                if (convertRefTypesToDepth == 0 || row.Value is string || row.Value is ValueType)
                {
                    //Create Row from Name and Value
                    AddRow(row.Name, row.Value);
                }
                else if (convertRefTypesToDepth > 0)
                {
                    //Create Row from Name and New Alert Table for Value
                    AddRow(row.Name, new AlertTableBuilder()
                                         .AddHeaderRow(row.Value.GetType().Name)
                                         .AddPropertyNameValuesAsRows(row.Value, convertRefTypesToDepth - 1, limitToPropertyNames)
                                         .ToAlert());
                }
            }
            return this;
        }

        public IAlertTableBuilder AddPropertyValuesAsRow<T>(T source, IEnumerable<string> limitToPropertyNames = null)
        {
            //Get Property Name Value Pairs
            var values = from item in GetPropertyNameValuePairs(source, limitToPropertyNames)
                         select item.Value;
            AddRow(values.ToArray());
            return this;
        }

        public IAlertTableBuilder AddPropertyNamesAsRow<T>(IEnumerable<string> limitToPropertyNames = null)
        {
            var names = GetPropertyNames<T>(limitToPropertyNames).Cast<object>().ToArray();
            AddRow(names);
            return this;
        }

        private static IEnumerable<string> GetPropertyNames<T>(IEnumerable<string> limitToPropertyNames = null)
        {
            return limitToPropertyNames ??
                   from pi in typeof(T).GetProperties()
                   select pi.Name;
        }

        private static IEnumerable<NameValue> GetPropertyNameValuePairs<T>(T source, IEnumerable<string> limitToPropertyNames = null)
        {
            //Extract Reflection Info
            var pairs = from pi in source.GetType().GetProperties()
                        orderby pi.Name
                        select new NameValue { Name = pi.Name, Value = GetPropertyValue(pi, source) };

            //Filter by Property Names if supplied
            if (limitToPropertyNames != null)
            {
                pairs = from item in pairs
                          from allowedName in limitToPropertyNames
                          where item.Name == allowedName
                          select item;
            }

            return pairs;
        }

        private static object GetPropertyValue(PropertyInfo pi, object source)
        {
            try
            {
                var result = pi.GetValue(source, null);
                return result ?? "Null";
            }
            catch (Exception)
            {
                return "Reflection Failed to Obtain Value";
            }
        }

        //Using this instead of tuple just for readability
        private class NameValue
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }
    }
}
