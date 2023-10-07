namespace merval
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip2 = new MenuStrip();
            mostrarUsuariosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip2
            // 
            menuStrip2.Dock = DockStyle.Left;
            menuStrip2.Items.AddRange(new ToolStripItem[] { mostrarUsuariosToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(113, 361);
            menuStrip2.TabIndex = 3;
            menuStrip2.Text = "menuStrip2";
            // 
            // mostrarUsuariosToolStripMenuItem
            // 
            mostrarUsuariosToolStripMenuItem.Name = "mostrarUsuariosToolStripMenuItem";
            mostrarUsuariosToolStripMenuItem.Size = new Size(100, 19);
            mostrarUsuariosToolStripMenuItem.Text = "mostrar usuarios";
            mostrarUsuariosToolStripMenuItem.Click += mostrarUsuariosToolStripMenuItem_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(633, 361);
            Controls.Add(menuStrip2);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip2;
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem mostrarUsuariosToolStripMenuItem;
    }
}