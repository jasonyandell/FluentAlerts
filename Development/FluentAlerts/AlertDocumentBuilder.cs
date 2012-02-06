﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAlerts.Extensions;

namespace FluentAlerts
{
    public interface IAlertDocumentBuilder: IAlertBuilder 
    {
        IAlertDocumentBuilder AddSeperator();
        IAlertDocumentBuilder AddTextBlock(string text, TextStyle style = TextStyle.Normal);
        IAlertDocumentBuilder AddURL(string text, string url);
        IAlertDocumentBuilder AddAlert(IFluentAlert source);
        IAlertDocumentBuilder AddAlerts(IEnumerable<IFluentAlert> source);
        IAlertDocumentBuilder AddExceptionAsTable(Exception ex, IEnumerable<string> limitToPropertyNames = null);
        IAlertDocumentBuilder AddExceptionAsList(Exception ex, IEnumerable<string> limitToPropertyNames = null);
        IAlertDocumentBuilder AddAsTable<T>(T source, int serializeToDepth = 0, IEnumerable<string> limitToPropertyNames = null) where T : class;
        IAlertDocumentBuilder AddAsTables<T>(IEnumerable<T> source, int serializeToDepth = 0, IEnumerable<string> limitToPropertyNames = null) where T : class;
    }
    internal class AlertDocumentBuilder : IAlertDocumentBuilder 
    {
        private readonly CompositeFluentAlert _alerts = new CompositeFluentAlert();
        private readonly IAlertBuilderFactory _alertBuilderfactory;
        public AlertDocumentBuilder(IAlertBuilderFactory factory)
        {
            _alertBuilderfactory = factory;
        }

        public IAlertDocumentBuilder AddAlert(IFluentAlert source)
        {
            _alerts.Add(source);
            return this;
        }
        public IAlertDocumentBuilder AddAlerts(IEnumerable<IFluentAlert> source)
        {
            _alerts.AddRange(source);
            return this;
        }

        public IFluentAlert ToAlert() { return _alerts; }
        public IAlertDocumentBuilder AddSeperator() { return AddAlert(new FluentAlertSeperator()); }
        public IAlertDocumentBuilder AddTextBlock(string text, TextStyle style = TextStyle.Normal) { return AddAlert(new FluentAlertTextBlock(text, style));}
        public IAlertDocumentBuilder AddURL(string text, string url) { return AddAlert(new FluentAlertUrl(text, url)); }            
        public IAlertDocumentBuilder AddAsTable<T>(T source, int serializeToDepth, IEnumerable<string> limitToPropertyNames) where T : class
        {
            return source == null ? this : AddAlert(_alertBuilderfactory.CreateTable(source, serializeToDepth, limitToPropertyNames).ToAlert());
        }
        public IAlertDocumentBuilder AddAsTables<T>(IEnumerable<T> source, int serializeToDepth, IEnumerable<string> limitToPropertyNames) where T : class
        {
            return (source == null)
                       ? this
                       : AddAlerts(
                           source.Select(
                               item =>
                               _alertBuilderfactory.CreateTable(item, serializeToDepth, limitToPropertyNames)
                                   .ToAlert()));
        }
        public IAlertDocumentBuilder AddExceptionAsTable(Exception ex, IEnumerable<string> limitToPropertyNames)
        {
            //Create a table of the first exceptions in the tree and add to the list
            return AddAlert(_alertBuilderfactory.CreateTable(ex, limitToPropertyNames).ToAlert());
        }
        public IAlertDocumentBuilder AddExceptionAsList(Exception ex, IEnumerable<string> limitToPropertyNames)
        {           
            //Create a list of tables of each exception in the tree in order and add them to list
            return AddAlerts(from exception in ex.ToList()
                             select _alertBuilderfactory.CreateTable(exception,limitToPropertyNames,false).ToAlert());

        }
    }
}
