using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codevia.Router.Net
{
    /// <summary>
    /// Router model, permete de definir une route
    /// </summary>
    /// <typeparam name="T">Type generic of component</typeparam>
    public class Route
    {
        public required string Name { get; set; }
        public string Title { get; set; } = "";
        public bool ShowInMenu { get; set; } = true;
        public object Permisions { get; set; }
        public string Description { get; set; } = "";
        public Image? Image { get; set; }
        public NavigationType Type { get; set; } = NavigationType.Navigation;
        public required Form Component { get; set; }
        public Routes? Childrend { get; set; }
    }

    public class Routes : List<Route> { }
}
