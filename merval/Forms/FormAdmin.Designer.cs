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
            TSP_AccionesVerTitulos = new ToolStripMenuItem();
            TSM_VerMonedas = new ToolStripMenuItem();
            ModificarTitulosToolStripMenuItem = new ToolStripMenuItem();
            TSP_acciones = new ToolStripMenuItem();
            TSP_AccionesAltas = new ToolStripMenuItem();
            TSP_AccionesBajas = new ToolStripMenuItem();
            TSP_AccionesModificar = new ToolStripMenuItem();
            monedasToolStripMenuItem1 = new ToolStripMenuItem();
            TSM_altasMoneda = new ToolStripMenuItem();
            TSM_bajasMoneda = new ToolStripMenuItem();
            TSM_modificarMoneda = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            btn_salir = new Button();
            btn_ocultarDataGrid = new Button();
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
            VerTitulos.DropDownItems.AddRange(new ToolStripItem[] { TSP_AccionesVerTitulos, TSM_VerMonedas });
            VerTitulos.Name = "VerTitulos";
            VerTitulos.Size = new Size(85, 23);
            VerTitulos.Text = "Ver Titulos";
            // 
            // TSP_AccionesVerTitulos
            // 
            TSP_AccionesVerTitulos.Name = "TSP_AccionesVerTitulos";
            TSP_AccionesVerTitulos.Size = new Size(135, 24);
            TSP_AccionesVerTitulos.Text = "Acciones";
            TSP_AccionesVerTitulos.Click += TSP_AccionesVerTitulos_Click;
            // 
            // TSM_VerMonedas
            // 
            TSM_VerMonedas.Name = "TSM_VerMonedas";
            TSM_VerMonedas.Size = new Size(135, 24);
            TSM_VerMonedas.Text = "Monedas";
            TSM_VerMonedas.Click += TSM_VerMonedas_Click;
            // 
            // ModificarTitulosToolStripMenuItem
            // 
            ModificarTitulosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { TSP_acciones, monedasToolStripMenuItem1 });
            ModificarTitulosToolStripMenuItem.Name = "ModificarTitulosToolStripMenuItem";
            ModificarTitulosToolStripMenuItem.Size = new Size(123, 23);
            ModificarTitulosToolStripMenuItem.Text = "Modificar Titulos";
            // 
            // TSP_acciones
            // 
            TSP_acciones.DropDownItems.AddRange(new ToolStripItem[] { TSP_AccionesAltas, TSP_AccionesBajas, TSP_AccionesModificar });
            TSP_acciones.Name = "TSP_acciones";
            TSP_acciones.Size = new Size(135, 24);
            TSP_acciones.Text = "Acciones";
            // 
            // TSP_AccionesAltas
            // 
            TSP_AccionesAltas.Name = "TSP_AccionesAltas";
            TSP_AccionesAltas.Size = new Size(137, 24);
            TSP_AccionesAltas.Text = "Altas";
            TSP_AccionesAltas.Click += TSP_AccionesAltas_Click;
            // 
            // TSP_AccionesBajas
            // 
            TSP_AccionesBajas.Name = "TSP_AccionesBajas";
            TSP_AccionesBajas.Size = new Size(137, 24);
            TSP_AccionesBajas.Text = "Bajas";
            TSP_AccionesBajas.Click += TSP_AccionesBajas_Click;
            // 
            // TSP_AccionesModificar
            // 
            TSP_AccionesModificar.Name = "TSP_AccionesModificar";
            TSP_AccionesModificar.Size = new Size(137, 24);
            TSP_AccionesModificar.Text = "Modificar";
            TSP_AccionesModificar.Click += TSP_AccionesModificar_Click;
            // 
            // monedasToolStripMenuItem1
            // 
            monedasToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { TSM_altasMoneda, TSM_bajasMoneda, TSM_modificarMoneda });
            monedasToolStripMenuItem1.Name = "monedasToolStripMenuItem1";
            monedasToolStripMenuItem1.Size = new Size(135, 24);
            monedasToolStripMenuItem1.Text = "Monedas";
            // 
            // TSM_altasMoneda
            // 
            TSM_altasMoneda.Name = "TSM_altasMoneda";
            TSM_altasMoneda.Size = new Size(157, 24);
            TSM_altasMoneda.Text = "Altas";
            TSM_altasMoneda.Click += TSM_altasMoneda_Click;
            // 
            // TSM_bajasMoneda
            // 
            TSM_bajasMoneda.Name = "TSM_bajasMoneda";
            TSM_bajasMoneda.Size = new Size(157, 24);
            TSM_bajasMoneda.Text = "Bajas";
            TSM_bajasMoneda.Click += TSM_bajasMoneda_Click;
            // 
            // TSM_modificarMoneda
            // 
            TSM_modificarMoneda.Name = "TSM_modificarMoneda";
            TSM_modificarMoneda.Size = new Size(157, 24);
            TSM_modificarMoneda.Text = "Modificacion";
            TSM_modificarMoneda.Click += TSM_modificarMoneda_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            dataGridView1.ScrollBars = ScrollBars.Vertical;
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
        private DataGridView dataGridView1;
        private Button btn_salir;
        private Button btn_ocultarDataGrid;
        private ToolStripMenuItem Mts_ModificarDatos;
        private ToolStripMenuItem TSP_AccionesVerTitulos;
        private ToolStripMenuItem TSM_VerMonedas;
        private ToolStripMenuItem TSP_acciones;
        private ToolStripMenuItem TSP_AccionesAltas;
        private ToolStripMenuItem TSP_AccionesBajas;
        private ToolStripMenuItem TSP_AccionesModificar;
        private ToolStripMenuItem monedasToolStripMenuItem1;
        private ToolStripMenuItem TSM_altasMoneda;
        private ToolStripMenuItem TSM_bajasMoneda;
        private ToolStripMenuItem TSM_modificarMoneda;
    }
}