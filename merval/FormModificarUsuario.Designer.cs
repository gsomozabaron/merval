namespace merval
{
    partial class FormModificarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModificarUsuario));
            dataGridView1 = new DataGridView();
            btn_Buscar = new Button();
            txt_clave = new TextBox();
            btn_Salir = new Button();
            txt_Nombre = new TextBox();
            txt_Apellido = new TextBox();
            txt_NombreUsuario = new TextBox();
            txt_DNI = new TextBox();
            btn_actualizar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btn_EliminarUsuario = new Button();
            txt_modoDeUso = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 138);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(560, 212);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellMouseDoubleClick += dataGridView1_CellMouseDoubleClick;
            // 
            // btn_Buscar
            // 
            btn_Buscar.BackgroundImage = (Image)resources.GetObject("btn_Buscar.BackgroundImage");
            btn_Buscar.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Buscar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Buscar.ForeColor = Color.Blue;
            btn_Buscar.Location = new Point(151, 26);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(75, 76);
            btn_Buscar.TabIndex = 1;
            btn_Buscar.Text = "Buscar";
            btn_Buscar.TextAlign = ContentAlignment.BottomCenter;
            btn_Buscar.TextImageRelation = TextImageRelation.TextAboveImage;
            btn_Buscar.UseVisualStyleBackColor = true;
            btn_Buscar.Click += btn_Buscar_Click;
            // 
            // txt_clave
            // 
            txt_clave.BackColor = SystemColors.GradientActiveCaption;
            txt_clave.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_clave.Location = new Point(45, 47);
            txt_clave.Name = "txt_clave";
            txt_clave.PlaceholderText = "clave a buscar";
            txt_clave.Size = new Size(100, 26);
            txt_clave.TabIndex = 2;
            // 
            // btn_Salir
            // 
            btn_Salir.BackColor = Color.Red;
            btn_Salir.ForeColor = SystemColors.ControlLightLight;
            btn_Salir.Location = new Point(652, 356);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new Size(88, 26);
            btn_Salir.TabIndex = 7;
            btn_Salir.Text = "Cerrar";
            btn_Salir.UseVisualStyleBackColor = false;
            btn_Salir.Click += btn_Salir_Click;
            // 
            // txt_Nombre
            // 
            txt_Nombre.BackColor = SystemColors.GradientActiveCaption;
            txt_Nombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Nombre.Location = new Point(305, 26);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.PlaceholderText = "Nombre";
            txt_Nombre.Size = new Size(100, 26);
            txt_Nombre.TabIndex = 8;
            txt_Nombre.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_Apellido
            // 
            txt_Apellido.BackColor = SystemColors.GradientActiveCaption;
            txt_Apellido.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Apellido.Location = new Point(305, 55);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.PlaceholderText = "Apellido";
            txt_Apellido.Size = new Size(100, 26);
            txt_Apellido.TabIndex = 9;
            txt_Apellido.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_NombreUsuario
            // 
            txt_NombreUsuario.BackColor = SystemColors.GradientActiveCaption;
            txt_NombreUsuario.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_NombreUsuario.Location = new Point(419, 40);
            txt_NombreUsuario.Name = "txt_NombreUsuario";
            txt_NombreUsuario.PlaceholderText = "Nombre Usuario";
            txt_NombreUsuario.Size = new Size(133, 26);
            txt_NombreUsuario.TabIndex = 10;
            txt_NombreUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_DNI
            // 
            txt_DNI.BackColor = SystemColors.GradientActiveCaption;
            txt_DNI.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_DNI.Location = new Point(305, 84);
            txt_DNI.Name = "txt_DNI";
            txt_DNI.PlaceholderText = "DNI";
            txt_DNI.Size = new Size(100, 26);
            txt_DNI.TabIndex = 11;
            txt_DNI.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_actualizar
            // 
            btn_actualizar.BackColor = Color.Blue;
            btn_actualizar.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_actualizar.ForeColor = Color.Yellow;
            btn_actualizar.Location = new Point(562, 31);
            btn_actualizar.Name = "btn_actualizar";
            btn_actualizar.Size = new Size(86, 79);
            btn_actualizar.TabIndex = 12;
            btn_actualizar.Text = "Actualizar datos";
            btn_actualizar.UseVisualStyleBackColor = false;
            btn_actualizar.Click += btn_actualizar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(245, 29);
            label1.Name = "label1";
            label1.Size = new Size(63, 19);
            label1.TabIndex = 13;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(245, 58);
            label2.Name = "label2";
            label2.Size = new Size(63, 19);
            label2.TabIndex = 14;
            label2.Text = "Apellido:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.GradientActiveCaption;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(419, 66);
            label3.Name = "label3";
            label3.Size = new Size(133, 19);
            label3.TabIndex = 15;
            label3.Text = "Nombre de Usuario:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(245, 87);
            label4.Name = "label4";
            label4.Size = new Size(40, 19);
            label4.TabIndex = 16;
            label4.Text = "DNI:";
            // 
            // btn_EliminarUsuario
            // 
            btn_EliminarUsuario.BackColor = Color.Red;
            btn_EliminarUsuario.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EliminarUsuario.ForeColor = Color.Yellow;
            btn_EliminarUsuario.Location = new Point(654, 31);
            btn_EliminarUsuario.Name = "btn_EliminarUsuario";
            btn_EliminarUsuario.Size = new Size(86, 79);
            btn_EliminarUsuario.TabIndex = 17;
            btn_EliminarUsuario.Text = "Eliminar Usuario";
            btn_EliminarUsuario.UseVisualStyleBackColor = false;
            btn_EliminarUsuario.Click += btn_EliminarUsuario_Click;
            // 
            // txt_modoDeUso
            // 
            txt_modoDeUso.BackColor = SystemColors.GradientActiveCaption;
            txt_modoDeUso.Enabled = false;
            txt_modoDeUso.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_modoDeUso.Location = new Point(608, 153);
            txt_modoDeUso.Multiline = true;
            txt_modoDeUso.Name = "txt_modoDeUso";
            txt_modoDeUso.Size = new Size(106, 127);
            txt_modoDeUso.TabIndex = 18;
            txt_modoDeUso.Text = "Ingrese clave a buscar o haga doble click sobre el usuario a modificar";
            txt_modoDeUso.TextAlign = HorizontalAlignment.Center;
            // 
            // FormModificarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(763, 417);
            ControlBox = false;
            Controls.Add(txt_modoDeUso);
            Controls.Add(btn_EliminarUsuario);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_actualizar);
            Controls.Add(txt_DNI);
            Controls.Add(txt_NombreUsuario);
            Controls.Add(txt_Apellido);
            Controls.Add(txt_Nombre);
            Controls.Add(btn_Salir);
            Controls.Add(txt_clave);
            Controls.Add(btn_Buscar);
            Controls.Add(dataGridView1);
            Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Name = "FormModificarUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormModificarUsuario";
            Load += FormModificarUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn_Buscar;
        private TextBox txt_clave;
        private Button btn_Salir;
        private TextBox txt_Nombre;
        private TextBox txt_Apellido;
        private TextBox txt_NombreUsuario;
        private TextBox txt_DNI;
        private Button btn_actualizar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        internal Button btn_EliminarUsuario;
        private TextBox txt_modoDeUso;
    }
}