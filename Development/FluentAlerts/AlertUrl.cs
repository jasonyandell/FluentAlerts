namespace FluentAlerts
{
    internal class AlertUrl : IAlert
    {
        public AlertUrl(string text, string url)
        {
            Text = text;
            Url = url;
        }

        public string Text { get; set; }
        public string Url { get; set; }
    }
}