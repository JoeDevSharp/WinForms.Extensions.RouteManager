using JoeDevSharp.WinForms.Extensions.RouteManager;

namespace WinFormsApp
{
    public partial class Main : Form
    {
        public Router Router;
        public Main()
        {
            InitializeComponent();
            Router = new Router(AppRoutes.Main, this);

            Router.To("Users");
        }
    }
}
