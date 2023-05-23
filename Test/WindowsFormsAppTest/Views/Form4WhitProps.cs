using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codevia.WinForm.Router;

namespace WindowsFormsAppTest.Views
{
    public partial class Form4WhitProps : Form
    {
        public Router Router { get; set; }
        public string Title { get; set; }
        public Form4WhitProps()
        {
            InitializeComponent();
        }

        private void Form4WhitProps_Load(object sender, EventArgs e)
        {
            UpdateProps();
        }

        public void UpdateProps()
        {
            label1.Text = Title;
        }
    }
}
