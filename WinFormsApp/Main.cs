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

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("UserDetails");
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("UserSettings");
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("Users");
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("UserAdd");
        }
    }
}
