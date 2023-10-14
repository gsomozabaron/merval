namespace merval
{
    partial class FormAltaAcciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAltaAcciones));
            btn_cancel = new Button();
            btn_aceptar = new Button();
            txt_Titulo = new TextBox();
            Txt_precio = new TextBox();
            SuspendLayout();
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.Red;
            btn_cancel.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_cancel.ForeColor = Color.White;
            btn_cancel.Location = new Point(154, 108);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(106, 42);
            btn_cancel.TabIndex = 0;
            btn_cancel.Text = "Cancelar";
            btn_cancel.UseVisualStyleBackColor = false;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_aceptar
            // 
            btn_aceptar.BackColor = Color.Blue;
            btn_aceptar.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_aceptar.ForeColor = Color.White;
            btn_aceptar.Location = new Point(266, 108);
            btn_aceptar.Name = "btn_aceptar";
            btn_aceptar.Size = new Size(106, 42);
            btn_aceptar.TabIndex = 1;
            btn_aceptar.Text = "Dar Alta";
            btn_aceptar.UseVisualStyleBackColor = false;
            btn_aceptar.Click += btn_aceptar_Click;
            // 
            // txt_Titulo
            // 
            txt_Titulo.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Titulo.Location = new Point(14, 26);
            txt_Titulo.Name = "txt_Titulo";
            txt_Titulo.PlaceholderText = "Titulo";
            txt_Titulo.Size = new Size(100, 22);
            txt_Titulo.TabIndex = 2;
            txt_Titulo.Tag = "";
            txt_Titulo.TextAlign = HorizontalAlignment.Center;
            // 
            // Txt_precio
            // 
            Txt_precio.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_precio.Location = new Point(141, 26);
            Txt_precio.Name = "Txt_precio";
            Txt_precio.PlaceholderText = "Cotizacion";
            Txt_precio.Size = new Size(100, 22);
            Txt_precio.TabIndex = 3;
            Txt_precio.TextAlign = HorizontalAlignment.Center;
            // 
            // FormAltaAcciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(384, 162);
            ControlBox = false;
            Controls.Add(Txt_precio);
            Controls.Add(txt_Titulo);
            Controls.Add(btn_aceptar);
            Controls.Add(btn_cancel);
            Name = "FormAltaAcciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alta De Acciones";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_cancel;
        private Button btn_aceptar;
        private TextBox txt_Titulo;
        private TextBox Txt_precio;
    }
}