using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Codevia.WinForm.Router.NetFramework
{
    /// <summary>
    /// Router model, permete de definir une route
    /// </summary>
    /// <typeparam name="T">Type generic of component</typeparam>
    public class Route
    {
        public string Name { get; set; }
        public string Title { get; set; } = "";
        public bool ShowInMenu { get; set; } = true;
        public object Permisions { get; set; }
        public string Description { get; set; } = "";
        public Image Image { get; set; } = null;
        public object Type { get; set; } = NavigationType.Navigation;
        public Form Component { get; set; }
        public Routes Childrend { get; set; } = null;
    }

    public class Routes : List<Route> { }
}
