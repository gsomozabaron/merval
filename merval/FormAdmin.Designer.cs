namespace merval
{
    partial class FormAdmin
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
            menuStrip1 = new MenuStrip();
            verUsuariosToolStripMenuItem = new ToolStripMenuItem();
            modificarUsuariosToolStripMenuItem = new ToolStripMenuItem();
            altasToolStripMenuItem = new ToolStripMenuItem();
            bajasToolStripMenuItem = new ToolStripMenuItem();
            verTitulosToolStripMenuItem = new ToolStripMenuItem();
            modificarTitulosToolStripMenuItem = new ToolStripMenuItem();
            altasToolStripMenuItem1 = new ToolStripMenuItem();
            bajasToolStripMenuItem1 = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { verUsuariosToolStripMenuItem, modificarUsuariosToolStripMenuItem, verTitulosToolStripMenuItem, modificarTitulosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // verUsuariosToolStripMenuItem
            // 
            verUsuariosToolStripMenuItem.Name = "verUsuariosToolStripMenuItem";
            verUsuariosToolStripMenuItem.Size = new Size(83, 20);
            verUsuariosToolStripMenuItem.Text = "Ver Usuarios";
            verUsuariosToolStripMenuItem.Click += verUsuariosToolStripMenuItem_Click;
            // 
            // modificarUsuariosToolStripMenuItem
            // 
            modificarUsuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { altasToolStripMenuItem, bajasToolStripMenuItem });
            modificarUsuariosToolStripMenuItem.Name = "modificarUsuariosToolStripMenuItem";
            modificarUsuariosToolStripMenuItem.Size = new Size(118, 20);
            modificarUsuariosToolStripMenuItem.Text = "Modificar Usuarios";
            // 
            // altasToolStripMenuItem
            // 
            altasToolStripMenuItem.Name = "altasToolStripMenuItem";
            altasToolStripMenuItem.Size = new Size(180, 22);
            altasToolStripMenuItem.Text = "Altas";
            altasToolStripMenuItem.Click += altasToolStripMenuItem_Click;
            // 
            // bajasToolStripMenuItem
            // 
            bajasToolStripMenuItem.Name = "bajasToolStripMenuItem";
            bajasToolStripMenuItem.Size = new Size(101, 22);
            bajasToolStripMenuItem.Text = "Bajas";
            // 
            // verTitulosToolStripMenuItem
            // 
            verTitulosToolStripMenuItem.Name = "verTitulosToolStripMenuItem";
            verTitulosToolStripMenuItem.Size = new Size(73, 20);
            verTitulosToolStripMenuItem.Text = "Ver Titulos";
            // 
            // modificarTitulosToolStripMenuItem
            // 
            modificarTitulosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { altasToolStripMenuItem1, bajasToolStripMenuItem1 });
            modificarTitulosToolStripMenuItem.Name = "modificarTitulosToolStripMenuItem";
            modificarTitulosToolStripMenuItem.Size = new Size(108, 20);
            modificarTitulosToolStripMenuItem.Text = "Modificar Titulos";
            // 
            // altasToolStripMenuItem1
            // 
            altasToolStripMenuItem1.Name = "altasToolStripMenuItem1";
            altasToolStripMenuItem1.Size = new Size(101, 22);
            altasToolStripMenuItem1.Text = "Altas";
            // 
            // bajasToolStripMenuItem1
            // 
            bajasToolStripMenuItem1.Name = "bajasToolStripMenuItem1";
            bajasToolStripMenuItem1.Size = new Size(101, 22);
            bajasToolStripMenuItem1.Text = "Bajas";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(137, 71);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.Size = new Size(539, 115);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            Name = "FormAdmin";
            Text = "FormAdmin";
            Load += FormAdmin_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem verUsuariosToolStripMenuItem;
        private ToolStripMenuItem modificarUsuariosToolStripMenuItem;
        private ToolStripMenuItem altasToolStripMenuItem;
        private ToolStripMenuItem bajasToolStripMenuItem;
        private ToolStripMenuItem verTitulosToolStripMenuItem;
        private ToolStripMenuItem modificarTitulosToolStripMenuItem;
        private ToolStripMenuItem altasToolStripMenuItem1;
        private ToolStripMenuItem bajasToolStripMenuItem1;
        private DataGridView dataGridView1;
    }
}