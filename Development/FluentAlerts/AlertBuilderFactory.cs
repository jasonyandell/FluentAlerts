using System;
using System.Collections.Generic;

namespace FluentAlerts
{
    //TODO: When creating the tables allow the option to "ask" for a serialization of depth.
    //      but this will require the serializers to be smart enough to do the conversion to alerts at depth later
    //      also will need a serialize ALL
    //      also will need to allow the "asking" for a limit of property names
    public interface IAlertBuilderFactory
    {
        IAlertTableBuilder CreateTable();
        IAlertTableBuilder CreateTable(string title);
        IAlertTableBuilder CreateTable<T>(T source, int serializeToDepth, IEnumerable<string> limitToPropertyNames = null);
        IAlertTableBuilder CreateTable(Exception ex, IEnumerable<string> limitToPropertyNames = null, bool includeInnerExceptions = true);
        IAlertDocumentBuilder CreateDocument();
        IAlertDocumentBuilder CreateDocument(string title);
    }

    public class AlertBuilderFactory : IAlertBuilderFactory 
    {
        public IAlertTableBuilder CreateTable() { return new AlertTableBuilder();}
        
        public IAlertTableBuilder CreateTable(string title) { return CreateTable().AddHeaderRow(title); }

        public IAlertTableBuilder CreateTable<T>(T source, int serializeToDepth, IEnumerable<string> limitToPropertyNames)
        {
            //Convenience method which creates a table builder pre-filled with source's reflected properties to depth
            return new AlertTableBuilder()
                .AddHeaderRow(source.GetType().Name)
                .AddPropertyNameValuesAsRows(source, serializeToDepth, limitToPropertyNames);
        }

        public IAlertTableBuilder CreateTable(Exception ex, IEnumerable<string> limitToPropertyNames, bool includeInnerExceptions)
        {
            //Default to just Message and stack trace
            limitToPropertyNames = limitToPropertyNames ?? new HashSet<string> {"Message", "StackTrace"};

            return ScrollExceptionToTable(ex, limitToPropertyNames, includeInnerExceptions, new AlertTableBuilder());
        }

        private static IAlertTableBuilder ScrollExceptionToTable(Exception ex, IEnumerable<string> limitToPropertyNames, bool includeInnerExceptions, IAlertTableBuilder builder)
        {
            if(ex == null) return builder;

            builder.AddHeaderRow(ex.GetType().Name)
                .AddPropertyNameValuesAsRows(ex, 0, limitToPropertyNames);

            return includeInnerExceptions 
                ? ScrollExceptionToTable(ex.InnerException, limitToPropertyNames, includeInnerExceptions, builder)
                : builder;
        }

        public IAlertDocumentBuilder CreateDocument()
        {
            return new AlertDocumentBuilder(this);
        }

        public IAlertDocumentBuilder CreateDocument(string title)
        {
            return new AlertDocumentBuilder(this)
                .AddTextBlock(title);
        }
        
        private static IEnumerable<string> GetExceptionPropertyFilters(bool includeMessage, bool includeStackTrace)
        {
            var filter = new HashSet<string>();
            if (includeMessage) filter.Add("Message");
            if (includeStackTrace) filter.Add("StackTrace");
            filter.Add("InnerException");
            return filter;
        }

    }
}
