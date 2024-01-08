using Codevia.Router.Winform;

namespace WinFormsAppNetTest
{
    public partial class Form1 : Form
    {
        private Routes routes = new _Routes();
        private Routes routes2 = new _Routes();
        public Router Router;
        public Router Router2;
        public Form1()
        {
            InitializeComponent();
            Router = new Router(routes, splitContainer1.Panel2);
            Router2 = new Router(routes2, splitContainer1.Panel1);
            Router.To("Home");
            Router2.To("Page2");
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router2.To("Home");
        }

        private void page2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router2.To("Page2");
        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Router.To("Home");
        }

        private void page2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Router.To("Page2");
        }
    }
}