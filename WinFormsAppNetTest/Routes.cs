using Codevia.Router.Winform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppNetTest
{
    public class _Routes : Routes
    {
        public _Routes()
        {
            this.AddRange(new Routes()
            {
                new Route()
                {
                    Name = "Home",
                    Component = new Views.Home(),
                },
                new Route()
                {
                    Name = "Page2",
                    Component = new Views.Page2(),
                }
            });
        }
    }
}
