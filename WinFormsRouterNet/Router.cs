using Codevia.WinForm.Router;
using Codevia.WinForm.Router.NetFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouterFramework = Codevia.WinForm.Router.NetFramework.Router;

namespace Codevia.WinForm.Router.Net
{
    public class Router : RouterFramework
    {
        public Router(List<Route> routes, ScrollableControl mainApplication, bool historyNavigate = false) : base(Helper.Routes.Convert(routes), mainApplication, historyNavigate) 
        {
        }
    }
}
