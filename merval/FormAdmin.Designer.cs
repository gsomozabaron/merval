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
            verUsuarios = new ToolStripMenuItem();
            modificarUsuarios = new ToolStripMenuItem();
            altasUsuarios = new ToolStripMenuItem();
            bajasToolStripMenuItem = new ToolStripMenuItem();
            verTitulosToolStripMenuItem = new ToolStripMenuItem();
            modificarTitulosToolStripMenuItem = new ToolStripMenuItem();
            altasToolStripMenuItem1 = new ToolStripMenuItem();
            bajasToolStripMenuItem1 = new ToolStripMenuItem();
            guardarDatosToolStripMenuItem = new ToolStripMenuItem();
            cargarDatosToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { verUsuarios, modificarUsuarios, verTitulosToolStripMenuItem, modificarTitulosToolStripMenuItem, guardarDatosToolStripMenuItem, cargarDatosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // verUsuarios
            // 
            verUsuarios.Name = "verUsuarios";
            verUsuarios.Size = new Size(83, 20);
            verUsuarios.Text = "Ver Usuarios";
            verUsuarios.Click += verUsuariosToolStripMenuItem_Click;
            // 
            // modificarUsuarios
            // 
            modificarUsuarios.DropDownItems.AddRange(new ToolStripItem[] { altasUsuarios, bajasToolStripMenuItem });
            modificarUsuarios.Name = "modificarUsuarios";
            modificarUsuarios.Size = new Size(118, 20);
            modificarUsuarios.Text = "Modificar Usuarios";
            modificarUsuarios.Click += modificarUsuarios_Click;
            // 
            // altasUsuarios
            // 
            altasUsuarios.Name = "altasUsuarios";
            altasUsuarios.Size = new Size(180, 22);
            altasUsuarios.Text = "Altas";
            altasUsuarios.Click += altasToolStripMenuItem_Click;
            // 
            // bajasToolStripMenuItem
            // 
            bajasToolStripMenuItem.Name = "bajasToolStripMenuItem";
            bajasToolStripMenuItem.Size = new Size(180, 22);
            bajasToolStripMenuItem.Text = "Bajas";
            // 
            // verTitulosToolStripMenuItem
            // 
            verTitulosToolStripMenuItem.Name = "verTitulosToolStripMenuItem";
            verTitulosToolStripMenuItem.Size = new Size(73, 20);
            verTitulosToolStripMenuItem.Text = "Ver Titulos";
            verTitulosToolStripMenuItem.Click += verTitulosToolStripMenuItem_Click;
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
            altasToolStripMenuItem1.Click += altasToolStripMenuItem1_Click;
            // 
            // bajasToolStripMenuItem1
            // 
            bajasToolStripMenuItem1.Name = "bajasToolStripMenuItem1";
            bajasToolStripMenuItem1.Size = new Size(101, 22);
            bajasToolStripMenuItem1.Text = "Bajas";
            // 
            // guardarDatosToolStripMenuItem
            // 
            guardarDatosToolStripMenuItem.Name = "guardarDatosToolStripMenuItem";
            guardarDatosToolStripMenuItem.Size = new Size(92, 20);
            guardarDatosToolStripMenuItem.Text = "guardar datos";
            guardarDatosToolStripMenuItem.Click += guardarDatosToolStripMenuItem_Click;
            // 
            // cargarDatosToolStripMenuItem
            // 
            cargarDatosToolStripMenuItem.Name = "cargarDatosToolStripMenuItem";
            cargarDatosToolStripMenuItem.Size = new Size(84, 20);
            cargarDatosToolStripMenuItem.Text = "cargar datos";
            cargarDatosToolStripMenuItem.Click += cargarDatosToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(137, 71);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
        private ToolStripMenuItem verUsuarios;
        private ToolStripMenuItem modificarUsuarios;
        private ToolStripMenuItem altasUsuarios;
        private ToolStripMenuItem bajasToolStripMenuItem;
        private ToolStripMenuItem verTitulosToolStripMenuItem;
        private ToolStripMenuItem modificarTitulosToolStripMenuItem;
        private ToolStripMenuItem altasToolStripMenuItem1;
        private ToolStripMenuItem bajasToolStripMenuItem1;
        private DataGridView dataGridView1;
        private ToolStripMenuItem guardarDatosToolStripMenuItem;
        private ToolStripMenuItem cargarDatosToolStripMenuItem;
    }
}