using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codevia.WinForm.Router.Net
{
    public class Route
    {
        public string Name { get; set; }
        public string Title { get; set; } = "";
        public bool ShowInMenu { get; set; } = true;
        public string Description { get; set; } = "";
        public Image Image { get; set; } = null;
        public object Type { get; set; } = NavigationType.Navigation;
        public Form Component { get; set; }
        public List<Route> Childrend { get; set; } = null;
    }
}
