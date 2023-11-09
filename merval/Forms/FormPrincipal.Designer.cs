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
            Cartera = new ToolStripMenuItem();
            TSM_carteraAcciones = new ToolStripMenuItem();
            TSM_CarteraMonedas = new ToolStripMenuItem();
            operar = new ToolStripMenuItem();
            ComprarAcciones = new ToolStripMenuItem();
            ComprarMonedas = new ToolStripMenuItem();
            vender = new ToolStripMenuItem();
            venderAcciones = new ToolStripMenuItem();
            VenderMonedas = new ToolStripMenuItem();
            verMercado = new ToolStripMenuItem();
            VerMercadoAcciones = new ToolStripMenuItem();
            VerMercadoMonedas = new ToolStripMenuItem();
            consultarSaldo_TSM = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            btn_salir = new Button();
            menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { Cartera, operar, vender, verMercado, consultarSaldo_TSM });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(741, 24);
            menuStrip2.TabIndex = 3;
            menuStrip2.Text = "menuStrip2";
            // 
            // Cartera
            // 
            Cartera.DropDownItems.AddRange(new ToolStripItem[] { TSM_carteraAcciones, TSM_CarteraMonedas });
            Cartera.Name = "Cartera";
            Cartera.Size = new Size(57, 20);
            Cartera.Text = "Cartera";
            // 
            // TSM_carteraAcciones
            // 
            TSM_carteraAcciones.Name = "TSM_carteraAcciones";
            TSM_carteraAcciones.Size = new Size(123, 22);
            TSM_carteraAcciones.Text = "Acciones";
            TSM_carteraAcciones.Click += TSM_carteraAcciones_Click;
            // 
            // TSM_CarteraMonedas
            // 
            TSM_CarteraMonedas.Name = "TSM_CarteraMonedas";
            TSM_CarteraMonedas.Size = new Size(123, 22);
            TSM_CarteraMonedas.Text = "Monedas";
            TSM_CarteraMonedas.Click += TSM_CarteraMonedas_Click;
            // 
            // operar
            // 
            operar.DropDownItems.AddRange(new ToolStripItem[] { ComprarAcciones, ComprarMonedas });
            operar.Name = "operar";
            operar.Size = new Size(66, 20);
            operar.Text = "Comprar";
            // 
            // ComprarAcciones
            // 
            ComprarAcciones.Name = "ComprarAcciones";
            ComprarAcciones.Size = new Size(123, 22);
            ComprarAcciones.Text = "Acciones";
            ComprarAcciones.Click += ComprarAcciones_Click;
            // 
            // ComprarMonedas
            // 
            ComprarMonedas.Name = "ComprarMonedas";
            ComprarMonedas.Size = new Size(123, 22);
            ComprarMonedas.Text = "Monedas";
            ComprarMonedas.Click += ComprarMonedas_Click;
            // 
            // vender
            // 
            vender.DropDownItems.AddRange(new ToolStripItem[] { venderAcciones, VenderMonedas });
            vender.Name = "vender";
            vender.Size = new Size(55, 20);
            vender.Text = "Vender";
            // 
            // venderAcciones
            // 
            venderAcciones.Name = "venderAcciones";
            venderAcciones.Size = new Size(180, 22);
            venderAcciones.Text = "Acciones";
            venderAcciones.Click += venderAcciones_Click;
            // 
            // VenderMonedas
            // 
            VenderMonedas.Name = "VenderMonedas";
            VenderMonedas.Size = new Size(180, 22);
            VenderMonedas.Text = "Monedas";
            VenderMonedas.Click += VenderMonedas_Click;
            // 
            // verMercado
            // 
            verMercado.DropDownItems.AddRange(new ToolStripItem[] { VerMercadoAcciones, VerMercadoMonedas });
            verMercado.Name = "verMercado";
            verMercado.Size = new Size(85, 20);
            verMercado.Text = "Ver Mercado";
            // 
            // VerMercadoAcciones
            // 
            VerMercadoAcciones.Name = "VerMercadoAcciones";
            VerMercadoAcciones.Size = new Size(123, 22);
            VerMercadoAcciones.Text = "Acciones";
            VerMercadoAcciones.Click += VerMercadoAcciones_Click;
            // 
            // VerMercadoMonedas
            // 
            VerMercadoMonedas.Name = "VerMercadoMonedas";
            VerMercadoMonedas.Size = new Size(123, 22);
            VerMercadoMonedas.Text = "Monedas";
            VerMercadoMonedas.Click += VerMercadoMonedas_Click;
            // 
            // consultarSaldo_TSM
            // 
            consultarSaldo_TSM.Name = "consultarSaldo_TSM";
            consultarSaldo_TSM.Size = new Size(102, 20);
            consultarSaldo_TSM.Text = "Consultar Saldo";
            consultarSaldo_TSM.Click += consultarSaldo_TSM_Click;
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
            dataGridViewCellStyle1.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkOrange;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(12, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(518, 358);
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
        private ToolStripMenuItem Cartera;
        private DataGridView dataGridView1;
        private ToolStripMenuItem operar;
        private ToolStripMenuItem verMercado;
        private ToolStripMenuItem consultarSaldo_TSM;
        private Button btn_salir;
        private ToolStripMenuItem vender;
        private ToolStripMenuItem TSM_carteraAcciones;
        private ToolStripMenuItem TSM_CarteraMonedas;
        private ToolStripMenuItem ComprarAcciones;
        private ToolStripMenuItem ComprarMonedas;
        private ToolStripMenuItem venderAcciones;
        private ToolStripMenuItem VenderMonedas;
        private ToolStripMenuItem VerMercadoAcciones;
        private ToolStripMenuItem VerMercadoMonedas;
    }
}