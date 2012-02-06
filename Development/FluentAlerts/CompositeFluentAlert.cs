using System.Collections.Generic;

namespace FluentAlerts
{
    internal class CompositeFluentAlert: List<IFluentAlert>, IFluentAlert{}
}

