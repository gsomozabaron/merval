namespace merval
{
    partial class formLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnAceptar = new Button();
            btnSalir = new Button();
            btnRegistrarse = new Button();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.Silver;
            txtUsuario.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsuario.ForeColor = SystemColors.WindowText;
            txtUsuario.Location = new Point(310, 113);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Ingrese usuario";
            txtUsuario.Size = new Size(247, 24);
            txtUsuario.TabIndex = 1;
            txtUsuario.Tag = "";
            txtUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.Silver;
            txtPassword.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtPassword.Location = new Point(310, 145);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(247, 24);
            txtPassword.TabIndex = 2;
            txtPassword.Tag = "";
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.SkyBlue;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.Location = new Point(310, 269);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(248, 41);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Red;
            btnSalir.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.Gold;
            btnSalir.Location = new Point(738, 348);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(126, 49);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "exit";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.BackColor = Color.FromArgb(128, 128, 255);
            btnRegistrarse.Location = new Point(352, 208);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(158, 25);
            btnRegistrarse.TabIndex = 5;
            btnRegistrarse.Text = "Nuevo Usuario";
            btnRegistrarse.UseVisualStyleBackColor = false;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // formLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(878, 410);
            ControlBox = false;
            Controls.Add(btnRegistrarse);
            Controls.Add(btnSalir);
            Controls.Add(btnAceptar);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.WindowText;
            Name = "formLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Merval app 1.0";
            Load += formPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnAceptar;
        private Button btnSalir;
        private Button btnRegistrarse;
    }
}