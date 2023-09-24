namespace merval
{
    partial class FormRegistroUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroUsuarios));
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtNombreUsuario = new TextBox();
            txtPassword = new TextBox();
            txtPasswordCheck = new TextBox();
            btnAceptar = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.DarkTurquoise;
            txtNombre.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.ForeColor = SystemColors.ButtonHighlight;
            txtNombre.Location = new Point(286, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(211, 29);
            txtNombre.TabIndex = 1;
            txtNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.DarkTurquoise;
            txtApellido.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtApellido.ForeColor = SystemColors.ButtonHighlight;
            txtApellido.Location = new Point(286, 57);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellido";
            txtApellido.Size = new Size(211, 29);
            txtApellido.TabIndex = 2;
            txtApellido.TextAlign = HorizontalAlignment.Center;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.BackColor = Color.DarkTurquoise;
            txtNombreUsuario.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreUsuario.ForeColor = SystemColors.ButtonHighlight;
            txtNombreUsuario.Location = new Point(286, 92);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.PlaceholderText = "Nombre Usuario";
            txtNombreUsuario.Size = new Size(211, 29);
            txtNombreUsuario.TabIndex = 3;
            txtNombreUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.DarkTurquoise;
            txtPassword.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = SystemColors.ButtonHighlight;
            txtPassword.Location = new Point(286, 200);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(211, 29);
            txtPassword.TabIndex = 5;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPasswordCheck
            // 
            txtPasswordCheck.BackColor = Color.DarkTurquoise;
            txtPasswordCheck.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPasswordCheck.ForeColor = SystemColors.ButtonHighlight;
            txtPasswordCheck.Location = new Point(286, 235);
            txtPasswordCheck.Name = "txtPasswordCheck";
            txtPasswordCheck.PasswordChar = '*';
            txtPasswordCheck.PlaceholderText = "reingrese Password";
            txtPasswordCheck.Size = new Size(211, 29);
            txtPasswordCheck.TabIndex = 6;
            txtPasswordCheck.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.LightSkyBlue;
            btnAceptar.Location = new Point(310, 284);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(167, 23);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Registrar Usuario";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // checkBox1
            // 
            checkBox1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(286, 150);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(211, 44);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Es comisionista?";
            checkBox1.TextAlign = ContentAlignment.MiddleCenter;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormRegistroUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkTurquoise;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(777, 350);
            ControlBox = false;
            Controls.Add(checkBox1);
            Controls.Add(btnAceptar);
            Controls.Add(txtPasswordCheck);
            Controls.Add(txtPassword);
            Controls.Add(txtNombreUsuario);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.ButtonHighlight;
            Name = "FormRegistroUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistroUsuarios";
            Load += FormRegistroUsuarios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtNombreUsuario;
        private TextBox txtPassword;
        private TextBox txtPasswordCheck;
        private Button btnAceptar;
        private CheckBox checkBox1;
    }
}