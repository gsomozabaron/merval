namespace merval
{
    partial class VentanaError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaError));
            Btn_Aceptar = new Button();
            lbl_error = new Label();
            PBox_error = new PictureBox();
            lbl_MensajeError = new Label();
            ((System.ComponentModel.ISupportInitialize)PBox_error).BeginInit();
            SuspendLayout();
            // 
            // Btn_Aceptar
            // 
            Btn_Aceptar.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Aceptar.Location = new Point(274, 146);
            Btn_Aceptar.Name = "Btn_Aceptar";
            Btn_Aceptar.Size = new Size(75, 23);
            Btn_Aceptar.TabIndex = 0;
            Btn_Aceptar.Text = "Aceptar";
            Btn_Aceptar.UseVisualStyleBackColor = true;
            Btn_Aceptar.Click += Btn_Aceptar_Click_1;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_error.ForeColor = Color.White;
            lbl_error.Location = new Point(283, 36);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(66, 24);
            lbl_error.TabIndex = 2;
            lbl_error.Text = "Error!";
            lbl_error.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PBox_error
            // 
            PBox_error.Image = (Image)resources.GetObject("PBox_error.Image");
            PBox_error.Location = new Point(11, 12);
            PBox_error.Name = "PBox_error";
            PBox_error.Size = new Size(177, 173);
            PBox_error.SizeMode = PictureBoxSizeMode.StretchImage;
            PBox_error.TabIndex = 3;
            PBox_error.TabStop = false;
            // 
            // lbl_MensajeError
            // 
            lbl_MensajeError.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_MensajeError.ForeColor = Color.White;
            lbl_MensajeError.Location = new Point(191, 85);
            lbl_MensajeError.Name = "lbl_MensajeError";
            lbl_MensajeError.Size = new Size(240, 39);
            lbl_MensajeError.TabIndex = 4;
            lbl_MensajeError.Text = "mensaje error";
            lbl_MensajeError.TextAlign = ContentAlignment.TopCenter;
            // 
            // VentanaError
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(438, 197);
            ControlBox = false;
            Controls.Add(lbl_MensajeError);
            Controls.Add(PBox_error);
            Controls.Add(lbl_error);
            Controls.Add(Btn_Aceptar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VentanaError";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VentanaError";
            ((System.ComponentModel.ISupportInitialize)PBox_error).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_Aceptar;
        private Label lbl_error;
        private PictureBox PBox_error;
        private Label lbl_MensajeError;
    }
}