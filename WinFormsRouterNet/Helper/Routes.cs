using RouteFramework = Codevia.WinForm.Router.NetFramework.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codevia.WinForm.Router.Net.Helper
{
    public static class Routes
    {
        public static List<RouteFramework> Convert(List<Route> Routes)
        {
            var routes = new List<RouteFramework>();

            foreach (var route in Routes)
            {
                routes.Add(route);
            }

            return routes;
        }
    }
}
