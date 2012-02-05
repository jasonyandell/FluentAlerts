using System;
using System.Collections.Generic;

namespace FluentAlerts
{
    public static class ExtensionsToException
    {
        public static IEnumerable<Exception> ToList(this Exception ex)
        {
            while (ex != null)
            {
                yield return ex;
                ex = ex.InnerException;
            }
        }

    }

}
