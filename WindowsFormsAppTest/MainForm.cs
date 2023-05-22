using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinformRouterNetFramework;

namespace WindowsFormsAppTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private Router Router;
        private void Form1_Load(object sender, EventArgs e)
        {
            Router = new Router(Routes.routes, this);
        }

        private void navigation1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("Navigation1");
        }

        private void navigation2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("Navigation2");
        }

        private void navigation3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("Navigation3");
        }

        private void show1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("Navigation1", NavigationType.Show);
        }

        private void show2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("Navigation2", NavigationType.Show);
        }

        private void show3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("Navigation3", NavigationType.Show);
        }

        private void defaultDialogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Router.To("Navigation1", NavigationType.Dialog);
        }

        private void defaultDialogToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Router.To("Navigation2", NavigationType.Dialog);
        }

        private void defaultDialogToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Router.To("Navigation3", NavigationType.Dialog);
        }

        private void navigationWhitPropsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("Navigation4", new Dictionary<string, object>()
            {
                { "Title", "hola" }
            });
        }

        private void navigationWhitPropsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Router.To("Navigation4", new Dictionary<string, object>()
            {
                { "Title", "Fea" }
            }, NavigationType.Show);
        }
    }
}
