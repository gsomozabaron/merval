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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            VerUsuarios = new ToolStripMenuItem();
            ModificarUsuarios = new ToolStripMenuItem();
            altasUsuarios = new ToolStripMenuItem();
            Mts_ModificarDatos = new ToolStripMenuItem();
            VerTitulos = new ToolStripMenuItem();
            ModificarTitulosToolStripMenuItem = new ToolStripMenuItem();
            AltasAcciones = new ToolStripMenuItem();
            BajasAcciones = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            btn_salir = new Button();
            btn_ocultarDataGrid = new Button();
            modificarDatosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { VerUsuarios, ModificarUsuarios, VerTitulos, ModificarTitulosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(722, 27);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // VerUsuarios
            // 
            VerUsuarios.Name = "VerUsuarios";
            VerUsuarios.Size = new Size(99, 23);
            VerUsuarios.Text = "Ver Usuarios";
            VerUsuarios.Click += VerUsuarios_Click;
            // 
            // ModificarUsuarios
            // 
            ModificarUsuarios.DropDownItems.AddRange(new ToolStripItem[] { altasUsuarios, Mts_ModificarDatos });
            ModificarUsuarios.Name = "ModificarUsuarios";
            ModificarUsuarios.Size = new Size(137, 23);
            ModificarUsuarios.Text = "Modificar Usuarios";
            // 
            // altasUsuarios
            // 
            altasUsuarios.Name = "altasUsuarios";
            altasUsuarios.Size = new Size(177, 24);
            altasUsuarios.Text = "Altas";
            altasUsuarios.Click += altasUsuarios_Click;
            // 
            // Mts_ModificarDatos
            // 
            Mts_ModificarDatos.Name = "Mts_ModificarDatos";
            Mts_ModificarDatos.Size = new Size(177, 24);
            Mts_ModificarDatos.Text = "Modificar Datos";
            Mts_ModificarDatos.Click += Mts_ModificarDatos_Click;
            // 
            // VerTitulos
            // 
            VerTitulos.Name = "VerTitulos";
            VerTitulos.Size = new Size(85, 23);
            VerTitulos.Text = "Ver Titulos";
            VerTitulos.Click += VerTitulos_Click;
            // 
            // ModificarTitulosToolStripMenuItem
            // 
            ModificarTitulosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AltasAcciones, BajasAcciones, modificarDatosToolStripMenuItem });
            ModificarTitulosToolStripMenuItem.Name = "ModificarTitulosToolStripMenuItem";
            ModificarTitulosToolStripMenuItem.Size = new Size(123, 23);
            ModificarTitulosToolStripMenuItem.Text = "Modificar Titulos";
            // 
            // AltasAcciones
            // 
            AltasAcciones.AccessibleName = "altas";
            AltasAcciones.Name = "AltasAcciones";
            AltasAcciones.Size = new Size(180, 24);
            AltasAcciones.Text = "Altas";
            AltasAcciones.Click += AltasAcciones_Click;
            // 
            // BajasAcciones
            // 
            BajasAcciones.Name = "BajasAcciones";
            BajasAcciones.Size = new Size(180, 24);
            BajasAcciones.Text = "Bajas";
            BajasAcciones.Click += BajasAcciones_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.SkyBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(12, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(698, 341);
            dataGridView1.TabIndex = 9;
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Red;
            btn_salir.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_salir.ForeColor = SystemColors.ControlLightLight;
            btn_salir.Location = new Point(609, 403);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(101, 35);
            btn_salir.TabIndex = 10;
            btn_salir.Text = "Salir";
            btn_salir.UseVisualStyleBackColor = false;
            btn_salir.Click += btn_salir_Click;
            // 
            // btn_ocultarDataGrid
            // 
            btn_ocultarDataGrid.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ocultarDataGrid.Location = new Point(593, 27);
            btn_ocultarDataGrid.Name = "btn_ocultarDataGrid";
            btn_ocultarDataGrid.Size = new Size(91, 23);
            btn_ocultarDataGrid.TabIndex = 11;
            btn_ocultarDataGrid.Text = "Ocultar DTG";
            btn_ocultarDataGrid.UseVisualStyleBackColor = true;
            btn_ocultarDataGrid.Click += btn_ocultarDataGrid_Click;
            // 
            // modificarDatosToolStripMenuItem
            // 
            modificarDatosToolStripMenuItem.Name = "modificarDatosToolStripMenuItem";
            modificarDatosToolStripMenuItem.Size = new Size(180, 24);
            modificarDatosToolStripMenuItem.Text = "Modificar datos";
            modificarDatosToolStripMenuItem.Click += modificarDatosToolStripMenuItem_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(722, 450);
            ControlBox = false;
            Controls.Add(btn_ocultarDataGrid);
            Controls.Add(btn_salir);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            Name = "FormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Principal Administrador";
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
        private ToolStripMenuItem VerTitulos;
        private ToolStripMenuItem ModificarTitulosToolStripMenuItem;
        private ToolStripMenuItem AltasAcciones;
        private ToolStripMenuItem BajasAcciones;
        private DataGridView dataGridView1;
        private Button btn_salir;
        private Button btn_ocultarDataGrid;
        private ToolStripMenuItem Mts_ModificarDatos;
        private ToolStripMenuItem modificarDatosToolStripMenuItem;
    }
}