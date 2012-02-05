using System.Collections.Generic;

namespace FluentAlerts
{
    internal class CompositeAlert: List<IAlert>, IAlert{}
}

