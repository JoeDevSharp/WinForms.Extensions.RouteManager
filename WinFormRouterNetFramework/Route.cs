using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformRouter
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
        public string Description { get; set; } = "";
        public Image Image { get; set; } = null;
        public RouteType Type { get; set; } = RouteType.Navigation;
        public Form Component { get; set; }
        public List<Route> Childrend { get; set; } = null;
    }
}
