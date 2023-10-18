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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            menuStrip2 = new MenuStrip();
            Ver_AccionesPropias = new ToolStripMenuItem();
            operar = new ToolStripMenuItem();
            venderToolStripMenuItem = new ToolStripMenuItem();
            verMercado = new ToolStripMenuItem();
            consultarSaldo_TSM = new ToolStripMenuItem();
            historicoToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            btn_salir = new Button();
            menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { Ver_AccionesPropias, operar, venderToolStripMenuItem, verMercado, consultarSaldo_TSM, historicoToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(741, 24);
            menuStrip2.TabIndex = 3;
            menuStrip2.Text = "menuStrip2";
            // 
            // Ver_AccionesPropias
            // 
            Ver_AccionesPropias.Name = "Ver_AccionesPropias";
            Ver_AccionesPropias.Size = new Size(124, 20);
            Ver_AccionesPropias.Text = "Cartera de Acciones";
            Ver_AccionesPropias.Click += Ver_AccionesPropias_Click;
            // 
            // operar
            // 
            operar.Name = "operar";
            operar.Size = new Size(66, 20);
            operar.Text = "Comprar";
            operar.Click += ComprarTitulos_Click;
            // 
            // venderToolStripMenuItem
            // 
            venderToolStripMenuItem.Name = "venderToolStripMenuItem";
            venderToolStripMenuItem.Size = new Size(55, 20);
            venderToolStripMenuItem.Text = "Vender";
            venderToolStripMenuItem.Click += venderToolStripMenuItem_Click;
            // 
            // verMercado
            // 
            verMercado.Name = "verMercado";
            verMercado.Size = new Size(85, 20);
            verMercado.Text = "Ver Mercado";
            verMercado.Click += verMercado_Click;
            // 
            // consultarSaldo_TSM
            // 
            consultarSaldo_TSM.Name = "consultarSaldo_TSM";
            consultarSaldo_TSM.Size = new Size(102, 20);
            consultarSaldo_TSM.Text = "Consultar Saldo";
            consultarSaldo_TSM.Click += consultarSaldo_TSM_Click;
            // 
            // historicoToolStripMenuItem
            // 
            historicoToolStripMenuItem.Name = "historicoToolStripMenuItem";
            historicoToolStripMenuItem.Size = new Size(118, 20);
            historicoToolStripMenuItem.Text = "Historico Acciones";
            historicoToolStripMenuItem.Click += historicoToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.Tomato;
            dataGridView1.CausesValidation = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Tomato;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkOrange;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(12, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(434, 358);
            dataGridView1.TabIndex = 5;
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Red;
            btn_salir.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_salir.ForeColor = SystemColors.ControlLightLight;
            btn_salir.Location = new Point(637, 350);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(92, 35);
            btn_salir.TabIndex = 7;
            btn_salir.Text = "Salir";
            btn_salir.UseVisualStyleBackColor = false;
            btn_salir.Click += btn_salir_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(741, 397);
            ControlBox = false;
            Controls.Add(btn_salir);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip2);
            Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = SystemColors.ActiveCaptionText;
            MainMenuStrip = menuStrip2;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mc Pato Bursatil 1.0";
            Load += FormPrincipal_Load;
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem Ver_AccionesPropias;
        private DataGridView dataGridView1;
        private ToolStripMenuItem operar;
        private ToolStripMenuItem verMercado;
        private ToolStripMenuItem consultarSaldo_TSM;
        private Button btn_salir;
        private ToolStripMenuItem venderToolStripMenuItem;
        private ToolStripMenuItem historicoToolStripMenuItem;
    }
}