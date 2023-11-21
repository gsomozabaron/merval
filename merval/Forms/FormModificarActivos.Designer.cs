namespace merval
{
    partial class FormModificarActivos
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModificarActivos));
            txt_Titulo = new TextBox();
            txt_Vcompra = new TextBox();
            txt_Vventa = new TextBox();
            dataGridView1 = new DataGridView();
            txt_BuscarTitulo = new TextBox();
            button1 = new Button();
            Btn_modificar = new Button();
            btn_salir = new Button();
            txt_tipo = new TextBox();
            txt_id = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txt_Titulo
            // 
            txt_Titulo.Enabled = false;
            txt_Titulo.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txt_Titulo.Location = new Point(40, 78);
            txt_Titulo.Name = "txt_Titulo";
            txt_Titulo.PlaceholderText = "Titulo";
            txt_Titulo.Size = new Size(100, 22);
            txt_Titulo.TabIndex = 0;
            txt_Titulo.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_Vcompra
            // 
            txt_Vcompra.Enabled = false;
            txt_Vcompra.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txt_Vcompra.Location = new Point(146, 78);
            txt_Vcompra.Name = "txt_Vcompra";
            txt_Vcompra.PlaceholderText = "Valor compra";
            txt_Vcompra.Size = new Size(100, 22);
            txt_Vcompra.TabIndex = 1;
            txt_Vcompra.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_Vventa
            // 
            txt_Vventa.Enabled = false;
            txt_Vventa.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txt_Vventa.Location = new Point(252, 78);
            txt_Vventa.Name = "txt_Vventa";
            txt_Vventa.PlaceholderText = "Valor venta";
            txt_Vventa.Size = new Size(100, 22);
            txt_Vventa.TabIndex = 2;
            txt_Vventa.TextAlign = HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 224, 192);
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 192, 192);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.Tomato;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Salmon;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightSalmon;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.LightCoral;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.GridColor = Color.MistyRose;
            dataGridView1.Location = new Point(12, 117);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.IndianRed;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(255, 128, 0);
            dataGridViewCellStyle5.Font = new Font("Times New Roman", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(424, 214);
            dataGridView1.TabIndex = 3;
            dataGridView1.MouseDoubleClick += dataGridView1_MouseDoubleClick;
            // 
            // txt_BuscarTitulo
            // 
            txt_BuscarTitulo.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txt_BuscarTitulo.Location = new Point(494, 78);
            txt_BuscarTitulo.Name = "txt_BuscarTitulo";
            txt_BuscarTitulo.PlaceholderText = "Buscar Titulo";
            txt_BuscarTitulo.Size = new Size(100, 22);
            txt_BuscarTitulo.TabIndex = 4;
            txt_BuscarTitulo.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Navy;
            button1.Location = new Point(600, 55);
            button1.Name = "button1";
            button1.Size = new Size(75, 67);
            button1.TabIndex = 5;
            button1.Text = "Buscar";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Btn_modificar
            // 
            Btn_modificar.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_modificar.Location = new Point(358, 65);
            Btn_modificar.Name = "Btn_modificar";
            Btn_modificar.Size = new Size(75, 46);
            Btn_modificar.TabIndex = 6;
            Btn_modificar.Text = "Modificar datos";
            Btn_modificar.UseVisualStyleBackColor = true;
            Btn_modificar.Click += Btn_modificar_Click;
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Red;
            btn_salir.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_salir.ForeColor = Color.Transparent;
            btn_salir.Location = new Point(713, 357);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(96, 34);
            btn_salir.TabIndex = 7;
            btn_salir.Text = "Salir";
            btn_salir.UseVisualStyleBackColor = false;
            btn_salir.Click += btn_salir_Click;
            // 
            // txt_tipo
            // 
            txt_tipo.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txt_tipo.Location = new Point(12, 12);
            txt_tipo.Name = "txt_tipo";
            txt_tipo.ReadOnly = true;
            txt_tipo.Size = new Size(100, 26);
            txt_tipo.TabIndex = 8;
            txt_tipo.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_id
            // 
            txt_id.Enabled = false;
            txt_id.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txt_id.Location = new Point(40, 50);
            txt_id.Name = "txt_id";
            txt_id.PlaceholderText = "id";
            txt_id.Size = new Size(100, 22);
            txt_id.TabIndex = 9;
            txt_id.TextAlign = HorizontalAlignment.Center;
            txt_id.Visible = false;
            // 
            // FormModificarAcciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(821, 403);
            ControlBox = false;
            Controls.Add(txt_id);
            Controls.Add(txt_tipo);
            Controls.Add(btn_salir);
            Controls.Add(Btn_modificar);
            Controls.Add(button1);
            Controls.Add(txt_BuscarTitulo);
            Controls.Add(dataGridView1);
            Controls.Add(txt_Vventa);
            Controls.Add(txt_Vcompra);
            Controls.Add(txt_Titulo);
            Name = "FormModificarAcciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Activos";
            Load += FormModificarAcciones_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Titulo;
        private TextBox txt_Vcompra;
        private TextBox txt_Vventa;
        private DataGridView dataGridView1;
        private TextBox txt_BuscarTitulo;
        private Button button1;
        private Button Btn_modificar;
        private Button btn_salir;
        private TextBox txt_tipo;
        private TextBox txt_id;
    }
}