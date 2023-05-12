using System;
using System.Collections.Generic;
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
        public RouteType Type { get; set; } = RouteType.Navigation;
        public List<RouteProp> Props { get; set; } = null;
        public Form Component { get; set; }

        public object GetPropsValue(string Name)
        {
            return Props.SingleOrDefault(x => x.Name == Name).Value;
        } 
    }
}
