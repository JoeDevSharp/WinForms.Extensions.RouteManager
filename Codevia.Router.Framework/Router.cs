using Codevia.Router.Net;
using System.Windows.Forms;

namespace Codevia.Router.Framework
{
    public class Router : Net.Router
    {
        public Router(Routes routes, ScrollableControl routerContainer, int? accessLevel = null, bool historyNavigate = false) : base(routes, routerContainer, accessLevel, historyNavigate)
        {
        }
    }
}
