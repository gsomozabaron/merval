namespace merval
{
    partial class VentanaEmergente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaEmergente));
            btnVentanaEmergente = new Button();
            lblMensaje = new Label();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // btnVentanaEmergente
            // 
            btnVentanaEmergente.BackColor = Color.Gray;
            btnVentanaEmergente.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnVentanaEmergente.ForeColor = Color.White;
            btnVentanaEmergente.Location = new Point(150, 176);
            btnVentanaEmergente.Name = "btnVentanaEmergente";
            btnVentanaEmergente.Size = new Size(135, 36);
            btnVentanaEmergente.TabIndex = 0;
            btnVentanaEmergente.Text = "ACEPTAR";
            btnVentanaEmergente.UseVisualStyleBackColor = false;
            btnVentanaEmergente.Click += btnVentanaEmergente_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.BackColor = Color.Transparent;
            lblMensaje.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblMensaje.ForeColor = Color.White;
            lblMensaje.Location = new Point(84, 123);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(274, 24);
            lblMensaje.TabIndex = 2;
            lblMensaje.Text = "mensaje";
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(84, 88);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(274, 24);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "titulo";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VentanaEmergente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(437, 291);
            ControlBox = false;
            Controls.Add(lblTitulo);
            Controls.Add(lblMensaje);
            Controls.Add(btnVentanaEmergente);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VentanaEmergente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mensaje";
            Load += VentanaEmergente_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnVentanaEmergente;
        private Label lblMensaje;
        private Label lblTitulo;
    }
}