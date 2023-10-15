namespace merval
{
    partial class FormVender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVender));
            lbl_totalVenta = new Label();
            lbl_saldoTag = new Label();
            btn_calcularVenta = new Button();
            lbl_saldo = new Label();
            txt_Cantidad = new TextBox();
            txt_cotizacion = new TextBox();
            btn_Comprar = new Button();
            txt_titulo = new TextBox();
            Dtg1 = new DataGridView();
            titulo = new DataGridViewTextBoxColumn();
            cotizacion = new DataGridViewTextBoxColumn();
            cartera = new DataGridViewTextBoxColumn();
            precioCompra = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            fechaCompra = new DataGridViewTextBoxColumn();
            btn_Salir = new Button();
            menuStrip1 = new MenuStrip();
            ((System.ComponentModel.ISupportInitialize)Dtg1).BeginInit();
            SuspendLayout();
            // 
            // lbl_totalVenta
            // 
            lbl_totalVenta.AutoSize = true;
            lbl_totalVenta.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_totalVenta.Location = new Point(602, 166);
            lbl_totalVenta.Name = "lbl_totalVenta";
            lbl_totalVenta.Size = new Size(86, 19);
            lbl_totalVenta.TabIndex = 24;
            lbl_totalVenta.Text = "Total Venta";
            lbl_totalVenta.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_saldoTag
            // 
            lbl_saldoTag.AutoSize = true;
            lbl_saldoTag.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_saldoTag.Location = new Point(720, 71);
            lbl_saldoTag.Name = "lbl_saldoTag";
            lbl_saldoTag.Size = new Size(50, 19);
            lbl_saldoTag.TabIndex = 23;
            lbl_saldoTag.Text = "Saldo ";
            // 
            // btn_calcularVenta
            // 
            btn_calcularVenta.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_calcularVenta.Location = new Point(580, 122);
            btn_calcularVenta.Name = "btn_calcularVenta";
            btn_calcularVenta.Size = new Size(134, 31);
            btn_calcularVenta.TabIndex = 22;
            btn_calcularVenta.Text = "Calcular Compra";
            btn_calcularVenta.UseVisualStyleBackColor = true;
            // 
            // lbl_saldo
            // 
            lbl_saldo.AutoSize = true;
            lbl_saldo.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_saldo.Location = new Point(720, 38);
            lbl_saldo.Name = "lbl_saldo";
            lbl_saldo.Size = new Size(46, 19);
            lbl_saldo.TabIndex = 21;
            lbl_saldo.Text = "Saldo";
            // 
            // txt_Cantidad
            // 
            txt_Cantidad.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txt_Cantidad.Location = new Point(580, 93);
            txt_Cantidad.Name = "txt_Cantidad";
            txt_Cantidad.PlaceholderText = "Cantidad?";
            txt_Cantidad.Size = new Size(134, 26);
            txt_Cantidad.TabIndex = 20;
            txt_Cantidad.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_cotizacion
            // 
            txt_cotizacion.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txt_cotizacion.Location = new Point(580, 64);
            txt_cotizacion.Name = "txt_cotizacion";
            txt_cotizacion.PlaceholderText = "Cotizacion";
            txt_cotizacion.Size = new Size(134, 26);
            txt_cotizacion.TabIndex = 19;
            txt_cotizacion.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_Comprar
            // 
            btn_Comprar.BackgroundImage = (Image)resources.GetObject("btn_Comprar.BackgroundImage");
            btn_Comprar.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Comprar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Comprar.ForeColor = SystemColors.ControlLightLight;
            btn_Comprar.Location = new Point(580, 198);
            btn_Comprar.Name = "btn_Comprar";
            btn_Comprar.Size = new Size(134, 117);
            btn_Comprar.TabIndex = 18;
            btn_Comprar.Text = "VENDER";
            btn_Comprar.TextAlign = ContentAlignment.BottomCenter;
            btn_Comprar.UseVisualStyleBackColor = true;
            // 
            // txt_titulo
            // 
            txt_titulo.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txt_titulo.Location = new Point(580, 35);
            txt_titulo.Name = "txt_titulo";
            txt_titulo.PlaceholderText = "Titulo";
            txt_titulo.Size = new Size(134, 26);
            txt_titulo.TabIndex = 17;
            txt_titulo.TextAlign = HorizontalAlignment.Center;
            // 
            // Dtg1
            // 
            Dtg1.AllowUserToAddRows = false;
            Dtg1.AllowUserToDeleteRows = false;
            Dtg1.AllowUserToOrderColumns = true;
            Dtg1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dtg1.Columns.AddRange(new DataGridViewColumn[] { titulo, cotizacion, cartera, precioCompra, Cantidad, fechaCompra });
            Dtg1.Location = new Point(12, 55);
            Dtg1.Name = "Dtg1";
            Dtg1.ReadOnly = true;
            Dtg1.RowTemplate.Height = 25;
            Dtg1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dtg1.Size = new Size(543, 367);
            Dtg1.TabIndex = 16;
            Dtg1.CellFormatting += Dtg1_CellFormatting_1;
            // 
            // titulo
            // 
            titulo.HeaderText = "Titulo";
            titulo.Name = "titulo";
            titulo.ReadOnly = true;
            titulo.Width = 80;
            // 
            // cotizacion
            // 
            cotizacion.HeaderText = "Cotizacion Actual";
            cotizacion.Name = "cotizacion";
            cotizacion.ReadOnly = true;
            cotizacion.Width = 80;
            // 
            // cartera
            // 
            cartera.HeaderText = "Cartera Propia";
            cartera.Name = "cartera";
            cartera.ReadOnly = true;
            cartera.Width = 80;
            // 
            // precioCompra
            // 
            precioCompra.HeaderText = "Precio Adquirido";
            precioCompra.Name = "precioCompra";
            precioCompra.ReadOnly = true;
            precioCompra.Width = 80;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            Cantidad.Width = 80;
            // 
            // fechaCompra
            // 
            fechaCompra.HeaderText = "Feha Compra";
            fechaCompra.Name = "fechaCompra";
            fechaCompra.ReadOnly = true;
            // 
            // btn_Salir
            // 
            btn_Salir.BackColor = Color.Red;
            btn_Salir.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Salir.ForeColor = Color.White;
            btn_Salir.Location = new Point(631, 385);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new Size(91, 37);
            btn_Salir.TabIndex = 15;
            btn_Salir.Text = "Salir";
            btn_Salir.UseVisualStyleBackColor = false;
            btn_Salir.Click += btn_Salir_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // FormVender
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tomato;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(lbl_totalVenta);
            Controls.Add(lbl_saldoTag);
            Controls.Add(btn_calcularVenta);
            Controls.Add(lbl_saldo);
            Controls.Add(txt_Cantidad);
            Controls.Add(txt_cotizacion);
            Controls.Add(btn_Comprar);
            Controls.Add(txt_titulo);
            Controls.Add(Dtg1);
            Controls.Add(btn_Salir);
            Controls.Add(menuStrip1);
            Name = "FormVender";
            Text = "Vender Acciones";
            Load += FormVender_Load;
            ((System.ComponentModel.ISupportInitialize)Dtg1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_totalVenta;
        private Label lbl_saldoTag;
        private Button btn_calcularVenta;
        private Label lbl_saldo;
        private TextBox txt_Cantidad;
        private TextBox txt_cotizacion;
        private Button btn_Comprar;
        private TextBox txt_titulo;
        private DataGridView Dtg1;
        private Button btn_Salir;
        private MenuStrip menuStrip1;
        private DataGridViewTextBoxColumn titulo;
        private DataGridViewTextBoxColumn cotizacion;
        private DataGridViewTextBoxColumn cartera;
        private DataGridViewTextBoxColumn precioCompra;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn fechaCompra;
    }
}