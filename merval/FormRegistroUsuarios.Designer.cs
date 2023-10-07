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
            txt_Nombre = new TextBox();
            txt_Dni = new TextBox();
            txt_NombreUsuario = new TextBox();
            txt_Pass = new TextBox();
            txt_PassCheck = new TextBox();
            btnAceptar = new Button();
            chk_comisionista = new CheckBox();
            SuspendLayout();
            // 
            // txt_Nombre
            // 
            txt_Nombre.BackColor = Color.DarkTurquoise;
            txt_Nombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Nombre.ForeColor = SystemColors.ButtonHighlight;
            txt_Nombre.Location = new Point(350, 88);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.PlaceholderText = "Nombre";
            txt_Nombre.Size = new Size(207, 26);
            txt_Nombre.TabIndex = 1;
            txt_Nombre.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_Dni
            // 
            txt_Dni.BackColor = Color.DarkTurquoise;
            txt_Dni.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Dni.ForeColor = SystemColors.ButtonHighlight;
            txt_Dni.Location = new Point(350, 120);
            txt_Dni.Name = "txt_Dni";
            txt_Dni.PlaceholderText = "Dni";
            txt_Dni.Size = new Size(207, 26);
            txt_Dni.TabIndex = 2;
            txt_Dni.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_NombreUsuario
            // 
            txt_NombreUsuario.BackColor = Color.DarkTurquoise;
            txt_NombreUsuario.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_NombreUsuario.ForeColor = SystemColors.ButtonHighlight;
            txt_NombreUsuario.Location = new Point(104, 88);
            txt_NombreUsuario.Name = "txt_NombreUsuario";
            txt_NombreUsuario.PlaceholderText = "Nombre Usuario";
            txt_NombreUsuario.Size = new Size(207, 26);
            txt_NombreUsuario.TabIndex = 3;
            txt_NombreUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_Pass
            // 
            txt_Pass.BackColor = Color.DarkTurquoise;
            txt_Pass.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Pass.ForeColor = SystemColors.ButtonHighlight;
            txt_Pass.Location = new Point(104, 120);
            txt_Pass.Name = "txt_Pass";
            txt_Pass.PasswordChar = '*';
            txt_Pass.PlaceholderText = "Password";
            txt_Pass.Size = new Size(207, 26);
            txt_Pass.TabIndex = 5;
            txt_Pass.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_PassCheck
            // 
            txt_PassCheck.BackColor = Color.DarkTurquoise;
            txt_PassCheck.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_PassCheck.ForeColor = SystemColors.ButtonHighlight;
            txt_PassCheck.Location = new Point(104, 152);
            txt_PassCheck.Name = "txt_PassCheck";
            txt_PassCheck.PasswordChar = '*';
            txt_PassCheck.PlaceholderText = "reingrese Password";
            txt_PassCheck.Size = new Size(207, 26);
            txt_PassCheck.TabIndex = 6;
            txt_PassCheck.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.LightSkyBlue;
            btnAceptar.Location = new Point(211, 278);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(167, 23);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Registrar Usuario";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // chk_comisionista
            // 
            chk_comisionista.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chk_comisionista.Location = new Point(350, 152);
            chk_comisionista.Name = "chk_comisionista";
            chk_comisionista.Size = new Size(207, 23);
            chk_comisionista.TabIndex = 4;
            chk_comisionista.Text = "Es comisionista?";
            chk_comisionista.TextAlign = ContentAlignment.MiddleCenter;
            chk_comisionista.UseVisualStyleBackColor = true;
            // 
            // FormRegistroUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkTurquoise;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(626, 346);
            ControlBox = false;
            Controls.Add(chk_comisionista);
            Controls.Add(btnAceptar);
            Controls.Add(txt_PassCheck);
            Controls.Add(txt_Pass);
            Controls.Add(txt_NombreUsuario);
            Controls.Add(txt_Dni);
            Controls.Add(txt_Nombre);
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

        private TextBox txt_Nombre;
        private TextBox txt_Dni;
        private TextBox txt_NombreUsuario;
        private TextBox txt_Pass;
        private TextBox txt_PassCheck;
        private Button btnAceptar;
        private CheckBox chk_comisionista;
    }
}