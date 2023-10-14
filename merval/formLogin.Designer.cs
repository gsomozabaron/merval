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
            btn_autocompletar = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.Silver;
            txtUsuario.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txtUsuario.ForeColor = SystemColors.WindowText;
            txtUsuario.Location = new Point(222, 65);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Ingrese usuario";
            txtUsuario.Size = new Size(247, 22);
            txtUsuario.TabIndex = 1;
            txtUsuario.Tag = "";
            txtUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.Silver;
            txtPassword.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txtPassword.Location = new Point(222, 97);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(247, 22);
            txtPassword.TabIndex = 2;
            txtPassword.Tag = "";
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.SkyBlue;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.Location = new Point(222, 221);
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
            btnSalir.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.Gold;
            btnSalir.Location = new Point(466, 310);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(83, 32);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "exit";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.BackColor = Color.FromArgb(128, 128, 255);
            btnRegistrarse.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrarse.Location = new Point(264, 160);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(158, 25);
            btnRegistrarse.TabIndex = 5;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = false;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // btn_autocompletar
            // 
            btn_autocompletar.BackColor = Color.PaleTurquoise;
            btn_autocompletar.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_autocompletar.Location = new Point(222, 310);
            btn_autocompletar.Name = "btn_autocompletar";
            btn_autocompletar.Size = new Size(77, 32);
            btn_autocompletar.TabIndex = 6;
            btn_autocompletar.Text = "auto login";
            btn_autocompletar.UseVisualStyleBackColor = false;
            btn_autocompletar.Click += btn_autocompletar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(538, 65);
            label1.Name = "label1";
            label1.Size = new Size(131, 36);
            label1.TabIndex = 7;
            label1.Text = "Mc Pato";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.RoyalBlue;
            label2.Location = new Point(548, 97);
            label2.Name = "label2";
            label2.Size = new Size(112, 24);
            label2.TabIndex = 8;
            label2.Text = "Bursatil 1.0";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // formLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(725, 387);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_autocompletar);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnAceptar;
        private Button btnSalir;
        private Button btnRegistrarse;
        private Button btn_autocompletar;
        private Label label1;
        private Label label2;
    }
}