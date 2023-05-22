using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformRouter;

namespace WindowsFormsAppTest
{
    public static class Routes
    {
        public static List<Route> routes = new List<Route>()
        {
            new Route()
            {
                Name = "Navigation1",
                Type = RouteType.Navigation,
                Component = new Views.Form1()
            },
            new Route()
            {
                Name = "Navigation2",
                Type = RouteType.Navigation,
                Component = new Views.Form2()
            },
            new Route()
            {
                Name = "Navigation3",
                Type = RouteType.Navigation,
                Component = new Views.Form3()
            },
            new Route()
            {
                Name = "Navigation4",
                Type = RouteType.Navigation,
                Component = new Views.Form4WhitProps()
            },
        };
    }
}
