namespace merval
{
    partial class FormSaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSaldo));
            lbl_tagBotonCargar = new Label();
            btn_CargarSaldo = new Button();
            txt_MontoAumentar = new TextBox();
            btn_Salir = new Button();
            lbl_NuevoSaldo = new Label();
            lbl_NuevoSaldoTag = new Label();
            label1 = new Label();
            btn_extraer = new Button();
            txt_montoExtraer = new TextBox();
            SuspendLayout();
            // 
            // lbl_tagBotonCargar
            // 
            lbl_tagBotonCargar.AutoSize = true;
            lbl_tagBotonCargar.BackColor = Color.Transparent;
            lbl_tagBotonCargar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_tagBotonCargar.Location = new Point(15, 157);
            lbl_tagBotonCargar.Name = "lbl_tagBotonCargar";
            lbl_tagBotonCargar.Size = new Size(75, 19);
            lbl_tagBotonCargar.TabIndex = 7;
            lbl_tagBotonCargar.Text = "Depositar";
            // 
            // btn_CargarSaldo
            // 
            btn_CargarSaldo.BackgroundImage = Properties.Resources.images__7_;
            btn_CargarSaldo.BackgroundImageLayout = ImageLayout.Stretch;
            btn_CargarSaldo.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_CargarSaldo.ForeColor = Color.Blue;
            btn_CargarSaldo.Location = new Point(12, 79);
            btn_CargarSaldo.Name = "btn_CargarSaldo";
            btn_CargarSaldo.Size = new Size(97, 73);
            btn_CargarSaldo.TabIndex = 6;
            btn_CargarSaldo.TextAlign = ContentAlignment.BottomCenter;
            btn_CargarSaldo.UseVisualStyleBackColor = true;
            btn_CargarSaldo.Click += btn_CargarSaldo_Click;
            // 
            // txt_MontoAumentar
            // 
            txt_MontoAumentar.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txt_MontoAumentar.Location = new Point(12, 52);
            txt_MontoAumentar.Name = "txt_MontoAumentar";
            txt_MontoAumentar.PlaceholderText = "Monto a Depositar";
            txt_MontoAumentar.Size = new Size(100, 21);
            txt_MontoAumentar.TabIndex = 5;
            txt_MontoAumentar.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_Salir
            // 
            btn_Salir.BackColor = Color.Red;
            btn_Salir.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Salir.ForeColor = SystemColors.ControlLightLight;
            btn_Salir.Location = new Point(643, 285);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new Size(82, 34);
            btn_Salir.TabIndex = 4;
            btn_Salir.Text = "Salir";
            btn_Salir.UseVisualStyleBackColor = false;
            btn_Salir.Click += btn_Salir_Click;
            // 
            // lbl_NuevoSaldo
            // 
            lbl_NuevoSaldo.AutoSize = true;
            lbl_NuevoSaldo.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_NuevoSaldo.Location = new Point(592, 79);
            lbl_NuevoSaldo.Name = "lbl_NuevoSaldo";
            lbl_NuevoSaldo.Size = new Size(94, 19);
            lbl_NuevoSaldo.TabIndex = 8;
            lbl_NuevoSaldo.Text = "Nuevo Saldo";
            // 
            // lbl_NuevoSaldoTag
            // 
            lbl_NuevoSaldoTag.AutoSize = true;
            lbl_NuevoSaldoTag.BackColor = Color.Transparent;
            lbl_NuevoSaldoTag.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_NuevoSaldoTag.Location = new Point(579, 108);
            lbl_NuevoSaldoTag.Name = "lbl_NuevoSaldoTag";
            lbl_NuevoSaldoTag.Size = new Size(126, 19);
            lbl_NuevoSaldoTag.TabIndex = 9;
            lbl_NuevoSaldoTag.Text = "Saldo Actualizado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(144, 157);
            label1.Name = "label1";
            label1.Size = new Size(60, 19);
            label1.TabIndex = 12;
            label1.Text = "Extraer";
            // 
            // btn_extraer
            // 
            btn_extraer.BackgroundImage = (Image)resources.GetObject("btn_extraer.BackgroundImage");
            btn_extraer.BackgroundImageLayout = ImageLayout.Stretch;
            btn_extraer.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_extraer.ForeColor = Color.Blue;
            btn_extraer.Location = new Point(141, 79);
            btn_extraer.Name = "btn_extraer";
            btn_extraer.Size = new Size(97, 73);
            btn_extraer.TabIndex = 11;
            btn_extraer.TextAlign = ContentAlignment.BottomCenter;
            btn_extraer.UseVisualStyleBackColor = true;
            btn_extraer.Click += btn_extraer_Click;
            // 
            // txt_montoExtraer
            // 
            txt_montoExtraer.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txt_montoExtraer.Location = new Point(141, 52);
            txt_montoExtraer.Name = "txt_montoExtraer";
            txt_montoExtraer.PlaceholderText = "Monto a Extraer";
            txt_montoExtraer.Size = new Size(100, 21);
            txt_montoExtraer.TabIndex = 10;
            txt_montoExtraer.TextAlign = HorizontalAlignment.Center;
            // 
            // FormSaldo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images__4_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(737, 331);
            Controls.Add(label1);
            Controls.Add(btn_extraer);
            Controls.Add(txt_montoExtraer);
            Controls.Add(lbl_NuevoSaldoTag);
            Controls.Add(lbl_NuevoSaldo);
            Controls.Add(lbl_tagBotonCargar);
            Controls.Add(btn_CargarSaldo);
            Controls.Add(txt_MontoAumentar);
            Controls.Add(btn_Salir);
            Name = "FormSaldo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSaldo";
            Load += FormSaldo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_tagBotonCargar;
        private Button btn_CargarSaldo;
        private TextBox txt_MontoAumentar;
        private Button btn_Salir;
        private Label lbl_NuevoSaldo;
        private Label lbl_NuevoSaldoTag;
        private Label label1;
        private Button btn_extraer;
        private TextBox txt_montoExtraer;
    }
}