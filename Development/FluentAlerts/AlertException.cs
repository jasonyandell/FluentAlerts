using System;

namespace FluentAlerts
{
    public class AlertException: ApplicationException 
    {
        public AlertException(string message) : this(new AlertTextBlock(message)) { }
        public AlertException(string message, Exception inner) : this(new AlertTextBlock(message), inner) { }
        public AlertException(IAlertBuilder builder) : this(builder.ToAlert()){}
        public AlertException(IAlertBuilder builder, Exception inner) : this(builder.ToAlert(), inner){}
        public AlertException(IAlert alert)
            :base(alert.ToText(s=>s.Replace(Environment.NewLine, string.Empty)))
        {
            Alert = alert;
        }
        public AlertException(IAlert alert, Exception inner) 
            : base(alert.ToText(s => s.Replace(Environment.NewLine, string.Empty)), inner)
        {
            Alert = alert;
        }
        public IAlert Alert { get; set; }
    }
}
