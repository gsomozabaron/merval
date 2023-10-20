namespace merval
{
    partial class VentanaConfirmar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaConfirmar));
            lbl_Titulo = new Label();
            lbl_Mensaje = new Label();
            btn_Aceptar = new Button();
            btn_Cancelar = new Button();
            SuspendLayout();
            // 
            // lbl_Titulo
            // 
            lbl_Titulo.BackColor = Color.Transparent;
            lbl_Titulo.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Titulo.Location = new Point(51, 22);
            lbl_Titulo.Name = "lbl_Titulo";
            lbl_Titulo.Size = new Size(259, 24);
            lbl_Titulo.TabIndex = 0;
            lbl_Titulo.Text = "titulo";
            lbl_Titulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Mensaje
            // 
            lbl_Mensaje.BackColor = Color.Transparent;
            lbl_Mensaje.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Mensaje.Location = new Point(51, 46);
            lbl_Mensaje.Name = "lbl_Mensaje";
            lbl_Mensaje.Size = new Size(259, 115);
            lbl_Mensaje.TabIndex = 1;
            lbl_Mensaje.Text = "mensaje";
            lbl_Mensaje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_Aceptar
            // 
            btn_Aceptar.BackColor = Color.LawnGreen;
            btn_Aceptar.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Aceptar.Location = new Point(51, 164);
            btn_Aceptar.Name = "btn_Aceptar";
            btn_Aceptar.Size = new Size(114, 48);
            btn_Aceptar.TabIndex = 2;
            btn_Aceptar.Text = "Aceptar";
            btn_Aceptar.UseVisualStyleBackColor = false;
            btn_Aceptar.Click += btn_Aceptar_Click;
            // 
            // btn_Cancelar
            // 
            btn_Cancelar.BackColor = Color.Red;
            btn_Cancelar.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Cancelar.ForeColor = Color.White;
            btn_Cancelar.Location = new Point(183, 164);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new Size(127, 48);
            btn_Cancelar.TabIndex = 3;
            btn_Cancelar.Text = "Cancelar";
            btn_Cancelar.UseVisualStyleBackColor = false;
            btn_Cancelar.Click += btn_Cancelar_Click;
            // 
            // VentanaConfirmar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(517, 224);
            ControlBox = false;
            Controls.Add(btn_Cancelar);
            Controls.Add(btn_Aceptar);
            Controls.Add(lbl_Mensaje);
            Controls.Add(lbl_Titulo);
            Name = "VentanaConfirmar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "A T E N C I O N ! ! ! !";
            Load += VentanaConfirmar_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_Titulo;
        private Label lbl_Mensaje;
        private Button btn_Aceptar;
        private Button btn_Cancelar;
    }
}