using System.Text;

namespace FluentAlerts.Serializers
{
    internal class AlertSerializerToText : AlertSerializer
    {
        protected override void AppendSerialization(FluentAlertSeperator source, StringBuilder sb)
        {
            sb.AppendLine();
            sb.AppendLine("================================================");
        }

        protected override void AppendSerialization(FluentAlertTable source, StringBuilder sb)
        {
            foreach (var row in source.Rows)
            {
                AppendSerialization(row, source.ColumnCount, sb);
            }
        }

        protected override void AppendSerialization(FluentAlertTable.Row source, int columns, StringBuilder sb)
        {
            //UNDONE: inserts 1 to many commas
            foreach(var v in source.Values)
            {
                sb.Append(v).AppendLine(", ");
            }
        }

        protected override void AppendSerialization(FluentAlertTextBlock source, StringBuilder sb)
        {
            sb.AppendLine(source.Text.ToString());
        }

        protected override void AppendSerialization(FluentAlertUrl source, StringBuilder sb)
        {
            sb.AppendLine(string.Format("{0}<{1}>", source.Text, source.Url));
        }
        
    }

}
