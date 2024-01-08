namespace WinFormsAppNetTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            menuStrip1 = new MenuStrip();
            container1ToolStripMenuItem = new ToolStripMenuItem();
            homeToolStripMenuItem = new ToolStripMenuItem();
            page2ToolStripMenuItem = new ToolStripMenuItem();
            container2ToolStripMenuItem = new ToolStripMenuItem();
            homeToolStripMenuItem1 = new ToolStripMenuItem();
            page2ToolStripMenuItem1 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(800, 426);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { container1ToolStripMenuItem, container2ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // container1ToolStripMenuItem
            // 
            container1ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { homeToolStripMenuItem, page2ToolStripMenuItem });
            container1ToolStripMenuItem.Name = "container1ToolStripMenuItem";
            container1ToolStripMenuItem.Size = new Size(80, 20);
            container1ToolStripMenuItem.Text = "Container 1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(109, 22);
            homeToolStripMenuItem.Text = "Home";
            homeToolStripMenuItem.Click += homeToolStripMenuItem_Click;
            // 
            // page2ToolStripMenuItem
            // 
            page2ToolStripMenuItem.Name = "page2ToolStripMenuItem";
            page2ToolStripMenuItem.Size = new Size(109, 22);
            page2ToolStripMenuItem.Text = "Page 2";
            page2ToolStripMenuItem.Click += page2ToolStripMenuItem_Click;
            // 
            // container2ToolStripMenuItem
            // 
            container2ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { homeToolStripMenuItem1, page2ToolStripMenuItem1 });
            container2ToolStripMenuItem.Name = "container2ToolStripMenuItem";
            container2ToolStripMenuItem.Size = new Size(80, 20);
            container2ToolStripMenuItem.Text = "Container 2";
            // 
            // homeToolStripMenuItem1
            // 
            homeToolStripMenuItem1.Name = "homeToolStripMenuItem1";
            homeToolStripMenuItem1.Size = new Size(180, 22);
            homeToolStripMenuItem1.Text = "Home";
            homeToolStripMenuItem1.Click += homeToolStripMenuItem1_Click;
            // 
            // page2ToolStripMenuItem1
            // 
            page2ToolStripMenuItem1.Name = "page2ToolStripMenuItem1";
            page2ToolStripMenuItem1.Size = new Size(180, 22);
            page2ToolStripMenuItem1.Text = "Page 2";
            page2ToolStripMenuItem1.Click += page2ToolStripMenuItem1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private SplitContainer splitContainer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem container1ToolStripMenuItem;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem page2ToolStripMenuItem;
        private ToolStripMenuItem container2ToolStripMenuItem;
        private ToolStripMenuItem homeToolStripMenuItem1;
        private ToolStripMenuItem page2ToolStripMenuItem1;
    }
}