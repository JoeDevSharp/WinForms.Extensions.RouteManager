using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codevia.WinForm.Router.NetFramework;
using WindowsFormsAppTest.Enums;

namespace WindowsFormsAppTest
{
    public static class Routes
    {
        public static List<Route> routes = new List<Route>()
        {
            new Route()
            {
                Name = "Navigation1",
                Type = NavigationType.Navigation,
                Component = new Views.Form1(),
                Permisions = Permisions.Contributeur
            },
            new Route()
            {
                Name = "Navigation2",
                Type = NavigationType.Navigation,
                Component = new Views.Form2(),
                Permisions = Permisions.Admin
            },
            new Route()
            {
                Name = "Navigation3",
                Type = NavigationType.Navigation,
                Component = new Views.Form3(),
                Permisions = Permisions.Dev
            },
            new Route()
            {
                Name = "Navigation4",
                Type = NavigationType.Navigation,
                Component = new Views.Form4WhitProps(),
                Permisions = Permisions.Contributeur
            },
        };
    }
}
