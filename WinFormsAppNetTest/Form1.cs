using Codevia.WinForm.Router.Net;

namespace WinFormsAppNetTest
{
    public partial class Form1 : Form
    {
        public Router Router;
        public Form1()
        {
            Router = new Router(new List<Route>()
            {
                new Route()
                {
                    Name = "Navigation1",
                    Type = NavigationType.Navigation,
                    Component = new Form()
                }
            }, this);
            InitializeComponent();
        }
    }
}