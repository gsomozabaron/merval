using System.Windows.Forms;

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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lbl_totalVenta = new Label();
            btn_calcularVenta = new Button();
            txt_Cantidad = new TextBox();
            txt_cotizacion = new TextBox();
            btn_Vender = new Button();
            txt_titulo = new TextBox();
            btn_Salir = new Button();
            label1 = new Label();
            Dtg1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Dtg1).BeginInit();
            SuspendLayout();
            // 
            // lbl_totalVenta
            // 
            lbl_totalVenta.AutoSize = true;
            lbl_totalVenta.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_totalVenta.Location = new Point(602, 166);
            lbl_totalVenta.Name = "lbl_totalVenta";
            lbl_totalVenta.Size = new Size(118, 19);
            lbl_totalVenta.TabIndex = 24;
            lbl_totalVenta.Text = "$$Total Venta$$";
            lbl_totalVenta.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_calcularVenta
            // 
            btn_calcularVenta.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_calcularVenta.Location = new Point(580, 122);
            btn_calcularVenta.Name = "btn_calcularVenta";
            btn_calcularVenta.Size = new Size(134, 31);
            btn_calcularVenta.TabIndex = 22;
            btn_calcularVenta.Text = "Calcular Venta";
            btn_calcularVenta.UseVisualStyleBackColor = true;
            btn_calcularVenta.Click += btn_calcularVenta_Click;
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
            txt_cotizacion.Enabled = false;
            txt_cotizacion.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txt_cotizacion.Location = new Point(580, 64);
            txt_cotizacion.Name = "txt_cotizacion";
            txt_cotizacion.PlaceholderText = "Cotizacion";
            txt_cotizacion.Size = new Size(134, 26);
            txt_cotizacion.TabIndex = 19;
            txt_cotizacion.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_Vender
            // 
            btn_Vender.BackgroundImage = (Image)resources.GetObject("btn_Vender.BackgroundImage");
            btn_Vender.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Vender.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Vender.ForeColor = SystemColors.ControlLightLight;
            btn_Vender.Location = new Point(580, 198);
            btn_Vender.Name = "btn_Vender";
            btn_Vender.Size = new Size(134, 117);
            btn_Vender.TabIndex = 18;
            btn_Vender.Text = "VENDER";
            btn_Vender.TextAlign = ContentAlignment.BottomCenter;
            btn_Vender.UseVisualStyleBackColor = true;
            btn_Vender.Click += btn_Vender_Click;
            // 
            // txt_titulo
            // 
            txt_titulo.Enabled = false;
            txt_titulo.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txt_titulo.Location = new Point(580, 35);
            txt_titulo.Name = "txt_titulo";
            txt_titulo.PlaceholderText = "Titulo";
            txt_titulo.Size = new Size(134, 26);
            txt_titulo.TabIndex = 17;
            txt_titulo.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_Salir
            // 
            btn_Salir.BackColor = Color.Red;
            btn_Salir.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Salir.ForeColor = Color.White;
            btn_Salir.Location = new Point(697, 401);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new Size(91, 37);
            btn_Salir.TabIndex = 15;
            btn_Salir.Text = "Salir";
            btn_Salir.UseVisualStyleBackColor = false;
            btn_Salir.Click += btn_Salir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(23, 9);
            label1.Name = "label1";
            label1.Size = new Size(501, 15);
            label1.TabIndex = 25;
            label1.Text = "selecciona la accion con el mouse, ingresa la cantidad, calcula la venta y hace click en vender";
            // 
            // Dtg1
            // 
            Dtg1.AllowUserToAddRows = false;
            Dtg1.AllowUserToDeleteRows = false;
            Dtg1.AllowUserToOrderColumns = true;
            Dtg1.BackgroundColor = Color.Tomato;
            Dtg1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Tomato;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkOrange;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Dtg1.DefaultCellStyle = dataGridViewCellStyle2;
            Dtg1.Location = new Point(12, 55);
            Dtg1.Name = "Dtg1";
            Dtg1.ReadOnly = true;
            Dtg1.RowHeadersVisible = false;
            Dtg1.RowTemplate.Height = 25;
            Dtg1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dtg1.Size = new Size(543, 367);
            Dtg1.TabIndex = 16;
            Dtg1.CellMouseDoubleClick += Dtg1_CellMouseDoubleClick;
            // 
            // FormVender
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tomato;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(Dtg1);
            Controls.Add(label1);
            Controls.Add(lbl_totalVenta);
            Controls.Add(btn_calcularVenta);
            Controls.Add(txt_Cantidad);
            Controls.Add(txt_cotizacion);
            Controls.Add(btn_Vender);
            Controls.Add(txt_titulo);
            Controls.Add(btn_Salir);
            Name = "FormVender";
            Text = "Vender Titulos";
            Load += FormVender_Load;
            ((System.ComponentModel.ISupportInitialize)Dtg1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_totalVenta;
        private Button btn_calcularVenta;
        private TextBox txt_Cantidad;
        private TextBox txt_cotizacion;
        private Button btn_Vender;
        private TextBox txt_titulo;
        private Button btn_Salir;
        private Label label1;
        private DataGridView Dtg1;
    }
}