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
            VerUsuarios = new ToolStripMenuItem();
            ModificarUsuarios = new ToolStripMenuItem();
            altasUsuarios = new ToolStripMenuItem();
            BajaUsuariosMenu = new ToolStripMenuItem();
            VerTitulos = new ToolStripMenuItem();
            ModificarTitulosToolStripMenuItem = new ToolStripMenuItem();
            AltasAcciones = new ToolStripMenuItem();
            BajasAcciones = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            btn_salir = new Button();
            btn_ocultarDataGrid = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { VerUsuarios, ModificarUsuarios, VerTitulos, ModificarTitulosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // VerUsuarios
            // 
            VerUsuarios.Name = "VerUsuarios";
            VerUsuarios.Size = new Size(83, 20);
            VerUsuarios.Text = "Ver Usuarios";
            VerUsuarios.Click += VerUsuarios_Click;
            // 
            // ModificarUsuarios
            // 
            ModificarUsuarios.DropDownItems.AddRange(new ToolStripItem[] { altasUsuarios, BajaUsuariosMenu });
            ModificarUsuarios.Name = "ModificarUsuarios";
            ModificarUsuarios.Size = new Size(118, 20);
            ModificarUsuarios.Text = "Modificar Usuarios";
            ModificarUsuarios.Click += modificarUsuarios_Click;
            // 
            // altasUsuarios
            // 
            altasUsuarios.Name = "altasUsuarios";
            altasUsuarios.Size = new Size(101, 22);
            altasUsuarios.Text = "Altas";
            altasUsuarios.Click += altasUsuarios_Click;
            // 
            // BajaUsuariosMenu
            // 
            BajaUsuariosMenu.Name = "BajaUsuariosMenu";
            BajaUsuariosMenu.Size = new Size(101, 22);
            BajaUsuariosMenu.Text = "Bajas";
            BajaUsuariosMenu.Click += BajaUsuariosMenu_Click;
            // 
            // VerTitulos
            // 
            VerTitulos.Name = "VerTitulos";
            VerTitulos.Size = new Size(73, 20);
            VerTitulos.Text = "Ver Titulos";
            VerTitulos.Click += VerTitulos_Click;
            // 
            // ModificarTitulosToolStripMenuItem
            // 
            ModificarTitulosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AltasAcciones, BajasAcciones });
            ModificarTitulosToolStripMenuItem.Name = "ModificarTitulosToolStripMenuItem";
            ModificarTitulosToolStripMenuItem.Size = new Size(108, 20);
            ModificarTitulosToolStripMenuItem.Text = "Modificar Titulos";
            // 
            // AltasAcciones
            // 
            AltasAcciones.AccessibleName = "altas";
            AltasAcciones.Name = "AltasAcciones";
            AltasAcciones.Size = new Size(101, 22);
            AltasAcciones.Text = "Altas";
            AltasAcciones.Click += AltasAcciones_Click;
            // 
            // BajasAcciones
            // 
            BajasAcciones.Name = "BajasAcciones";
            BajasAcciones.Size = new Size(101, 22);
            BajasAcciones.Text = "Bajas";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(81, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(610, 276);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btn_salir
            // 
            btn_salir.Location = new Point(713, 415);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(75, 23);
            btn_salir.TabIndex = 10;
            btn_salir.Text = "Salir";
            btn_salir.UseVisualStyleBackColor = true;
            btn_salir.Click += btn_salir_Click;
            // 
            // btn_ocultarDataGrid
            // 
            btn_ocultarDataGrid.Location = new Point(697, 27);
            btn_ocultarDataGrid.Name = "btn_ocultarDataGrid";
            btn_ocultarDataGrid.Size = new Size(91, 23);
            btn_ocultarDataGrid.TabIndex = 11;
            btn_ocultarDataGrid.Text = "Ocultar DTG";
            btn_ocultarDataGrid.UseVisualStyleBackColor = true;
            btn_ocultarDataGrid.Click += btn_ocultarDataGrid_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_ocultarDataGrid);
            Controls.Add(btn_salir);
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
        private ToolStripMenuItem VerUsuarios;
        private ToolStripMenuItem ModificarUsuarios;
        private ToolStripMenuItem altasUsuarios;
        private ToolStripMenuItem BajaUsuariosMenu;
        private ToolStripMenuItem VerTitulos;
        private ToolStripMenuItem ModificarTitulosToolStripMenuItem;
        private ToolStripMenuItem AltasAcciones;
        private ToolStripMenuItem BajasAcciones;
        private DataGridView dataGridView1;
        private Button btn_salir;
        private Button btn_ocultarDataGrid;
    }
}