namespace merval
{
    partial class FormOperar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperar));
            menuStrip1 = new MenuStrip();
            btn_Salir = new Button();
            Dtg1 = new DataGridView();
            txt_titulo = new TextBox();
            btn_Comprar = new Button();
            txt_cotizacion = new TextBox();
            txt_Cantidad = new TextBox();
            lbl_saldo = new Label();
            btn_calcularCompra = new Button();
            lbl_saldoTag = new Label();
            lbl_totalventa = new Label();
            ((System.ComponentModel.ISupportInitialize)Dtg1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(734, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // btn_Salir
            // 
            btn_Salir.BackColor = Color.Red;
            btn_Salir.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Salir.ForeColor = Color.White;
            btn_Salir.Location = new Point(631, 357);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new Size(91, 37);
            btn_Salir.TabIndex = 1;
            btn_Salir.Text = "Salir";
            btn_Salir.UseVisualStyleBackColor = false;
            btn_Salir.Click += btn_Salir_Click;
            // 
            // Dtg1
            // 
            Dtg1.BackgroundColor = Color.Tomato;
            Dtg1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Tomato;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkOrange;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            Dtg1.DefaultCellStyle = dataGridViewCellStyle1;
            Dtg1.GridColor = Color.Tomato;
            Dtg1.Location = new Point(12, 27);
            Dtg1.Name = "Dtg1";
            Dtg1.RowTemplate.Height = 25;
            Dtg1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dtg1.Size = new Size(327, 367);
            Dtg1.TabIndex = 2;
            Dtg1.CellMouseDoubleClick += Dtg1_CellMouseDoubleClick;
            // 
            // txt_titulo
            // 
            txt_titulo.Enabled = false;
            txt_titulo.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txt_titulo.Location = new Point(384, 80);
            txt_titulo.Name = "txt_titulo";
            txt_titulo.PlaceholderText = "Titulo";
            txt_titulo.Size = new Size(134, 26);
            txt_titulo.TabIndex = 4;
            txt_titulo.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_Comprar
            // 
            btn_Comprar.BackgroundImage = (Image)resources.GetObject("btn_Comprar.BackgroundImage");
            btn_Comprar.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Comprar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Comprar.ForeColor = SystemColors.ControlLightLight;
            btn_Comprar.Location = new Point(384, 243);
            btn_Comprar.Name = "btn_Comprar";
            btn_Comprar.Size = new Size(134, 117);
            btn_Comprar.TabIndex = 5;
            btn_Comprar.Text = "Comprar";
            btn_Comprar.TextAlign = ContentAlignment.BottomCenter;
            btn_Comprar.UseVisualStyleBackColor = true;
            btn_Comprar.Click += btn_Comprar_Click;
            // 
            // txt_cotizacion
            // 
            txt_cotizacion.Enabled = false;
            txt_cotizacion.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txt_cotizacion.Location = new Point(384, 109);
            txt_cotizacion.Name = "txt_cotizacion";
            txt_cotizacion.PlaceholderText = "Cotizacion";
            txt_cotizacion.Size = new Size(134, 26);
            txt_cotizacion.TabIndex = 7;
            txt_cotizacion.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_Cantidad
            // 
            txt_Cantidad.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txt_Cantidad.Location = new Point(384, 138);
            txt_Cantidad.Name = "txt_Cantidad";
            txt_Cantidad.PlaceholderText = "Cantidad?";
            txt_Cantidad.Size = new Size(134, 26);
            txt_Cantidad.TabIndex = 8;
            txt_Cantidad.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_saldo
            // 
            lbl_saldo.AutoSize = true;
            lbl_saldo.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_saldo.Location = new Point(573, 80);
            lbl_saldo.Name = "lbl_saldo";
            lbl_saldo.Size = new Size(46, 19);
            lbl_saldo.TabIndex = 10;
            lbl_saldo.Text = "Saldo";
            // 
            // btn_calcularCompra
            // 
            btn_calcularCompra.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_calcularCompra.Location = new Point(384, 167);
            btn_calcularCompra.Name = "btn_calcularCompra";
            btn_calcularCompra.Size = new Size(134, 31);
            btn_calcularCompra.TabIndex = 11;
            btn_calcularCompra.Text = "Calcular Compra";
            btn_calcularCompra.UseVisualStyleBackColor = true;
            btn_calcularCompra.Click += btn_calcularCompra_Click;
            // 
            // lbl_saldoTag
            // 
            lbl_saldoTag.AutoSize = true;
            lbl_saldoTag.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_saldoTag.Location = new Point(573, 109);
            lbl_saldoTag.Name = "lbl_saldoTag";
            lbl_saldoTag.Size = new Size(50, 19);
            lbl_saldoTag.TabIndex = 12;
            lbl_saldoTag.Text = "Saldo ";
            // 
            // lbl_totalventa
            // 
            lbl_totalventa.AutoSize = true;
            lbl_totalventa.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_totalventa.Location = new Point(406, 211);
            lbl_totalventa.Name = "lbl_totalventa";
            lbl_totalventa.Size = new Size(49, 19);
            lbl_totalventa.TabIndex = 13;
            lbl_totalventa.Text = "$$$$$";
            lbl_totalventa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormOperar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(734, 406);
            ControlBox = false;
            Controls.Add(lbl_totalventa);
            Controls.Add(lbl_saldoTag);
            Controls.Add(btn_calcularCompra);
            Controls.Add(lbl_saldo);
            Controls.Add(txt_Cantidad);
            Controls.Add(txt_cotizacion);
            Controls.Add(btn_Comprar);
            Controls.Add(txt_titulo);
            Controls.Add(Dtg1);
            Controls.Add(btn_Salir);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormOperar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Comprar y Vender Titulos";
            Load += FormOperar_Load;
            ((System.ComponentModel.ISupportInitialize)Dtg1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private Button btn_Salir;
        private DataGridView Dtg1;
        private TextBox txt_titulo;
        private Button btn_Comprar;
        private TextBox txt_cotizacion;
        private TextBox txt_Cantidad;
        private Label lbl_saldo;
        private Button btn_calcularCompra;
        private Label lbl_saldoTag;
        private Label lbl_totalventa;
    }
}