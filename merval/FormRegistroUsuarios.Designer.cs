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
            btn_salir = new Button();
            btn_agregarUsuario = new Button();
            txt_Apellido = new TextBox();
            SuspendLayout();
            // 
            // txt_Nombre
            // 
            txt_Nombre.BackColor = Color.LightCoral;
            txt_Nombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Nombre.ForeColor = SystemColors.ControlText;
            txt_Nombre.Location = new Point(404, 32);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.PlaceholderText = "Nombre";
            txt_Nombre.Size = new Size(207, 26);
            txt_Nombre.TabIndex = 1;
            txt_Nombre.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_Dni
            // 
            txt_Dni.BackColor = Color.LightCoral;
            txt_Dni.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Dni.ForeColor = SystemColors.ControlText;
            txt_Dni.Location = new Point(404, 96);
            txt_Dni.Name = "txt_Dni";
            txt_Dni.PlaceholderText = "Dni";
            txt_Dni.Size = new Size(207, 26);
            txt_Dni.TabIndex = 2;
            txt_Dni.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_NombreUsuario
            // 
            txt_NombreUsuario.BackColor = Color.LightCoral;
            txt_NombreUsuario.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_NombreUsuario.ForeColor = SystemColors.ControlText;
            txt_NombreUsuario.Location = new Point(404, 151);
            txt_NombreUsuario.Name = "txt_NombreUsuario";
            txt_NombreUsuario.PlaceholderText = "Nombre Usuario";
            txt_NombreUsuario.Size = new Size(207, 26);
            txt_NombreUsuario.TabIndex = 3;
            txt_NombreUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_Pass
            // 
            txt_Pass.BackColor = Color.LightCoral;
            txt_Pass.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Pass.ForeColor = SystemColors.ControlText;
            txt_Pass.Location = new Point(404, 183);
            txt_Pass.Name = "txt_Pass";
            txt_Pass.PasswordChar = '*';
            txt_Pass.PlaceholderText = "Password";
            txt_Pass.Size = new Size(207, 26);
            txt_Pass.TabIndex = 5;
            txt_Pass.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_PassCheck
            // 
            txt_PassCheck.BackColor = Color.LightCoral;
            txt_PassCheck.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_PassCheck.ForeColor = SystemColors.ControlText;
            txt_PassCheck.Location = new Point(404, 215);
            txt_PassCheck.Name = "txt_PassCheck";
            txt_PassCheck.PasswordChar = '*';
            txt_PassCheck.PlaceholderText = "Reingresar Password";
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
            chk_comisionista.BackColor = Color.LightCoral;
            chk_comisionista.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chk_comisionista.ForeColor = SystemColors.ControlText;
            chk_comisionista.Location = new Point(404, 247);
            chk_comisionista.Name = "chk_comisionista";
            chk_comisionista.Size = new Size(207, 23);
            chk_comisionista.TabIndex = 4;
            chk_comisionista.Text = "Es comisionista?";
            chk_comisionista.TextAlign = ContentAlignment.MiddleCenter;
            chk_comisionista.UseVisualStyleBackColor = false;
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Red;
            btn_salir.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_salir.ForeColor = Color.White;
            btn_salir.Location = new Point(508, 294);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(103, 30);
            btn_salir.TabIndex = 7;
            btn_salir.Text = "Cancelar";
            btn_salir.UseVisualStyleBackColor = false;
            btn_salir.Click += button1_Click;
            // 
            // btn_agregarUsuario
            // 
            btn_agregarUsuario.BackColor = Color.Gold;
            btn_agregarUsuario.ForeColor = SystemColors.ActiveCaptionText;
            btn_agregarUsuario.Location = new Point(211, 238);
            btn_agregarUsuario.Name = "btn_agregarUsuario";
            btn_agregarUsuario.Size = new Size(167, 23);
            btn_agregarUsuario.TabIndex = 8;
            btn_agregarUsuario.Text = "Agregar Usuario";
            btn_agregarUsuario.UseVisualStyleBackColor = false;
            // 
            // txt_Apellido
            // 
            txt_Apellido.BackColor = Color.LightCoral;
            txt_Apellido.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Apellido.ForeColor = SystemColors.ControlText;
            txt_Apellido.Location = new Point(404, 64);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.PlaceholderText = "Apellido";
            txt_Apellido.Size = new Size(207, 26);
            txt_Apellido.TabIndex = 9;
            txt_Apellido.TextAlign = HorizontalAlignment.Center;
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
            Controls.Add(txt_Apellido);
            Controls.Add(btn_agregarUsuario);
            Controls.Add(btn_salir);
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
        private Button btn_salir;
        private Button btn_agregarUsuario;
        private TextBox txt_Apellido;
    }
}