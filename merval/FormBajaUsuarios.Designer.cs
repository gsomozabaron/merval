namespace merval
{
    partial class FormBajaUsuarios
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
            btn_salir = new Button();
            btn_confirm = new Button();
            DTG_datagrid = new DataGridView();
            btn_buscar = new Button();
            rBtn_nombre = new RadioButton();
            rBtn_nombreUsuario = new RadioButton();
            rBtn_Dni = new RadioButton();
            txt_dato = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DTG_datagrid).BeginInit();
            SuspendLayout();
            // 
            // btn_salir
            // 
            btn_salir.Location = new Point(773, 141);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(75, 23);
            btn_salir.TabIndex = 0;
            btn_salir.Text = "Salir";
            btn_salir.UseVisualStyleBackColor = true;
            btn_salir.Click += btn_salir_Click;
            // 
            // btn_confirm
            // 
            btn_confirm.Location = new Point(341, 141);
            btn_confirm.Name = "btn_confirm";
            btn_confirm.Size = new Size(123, 23);
            btn_confirm.TabIndex = 1;
            btn_confirm.Text = "confirmar baja";
            btn_confirm.UseVisualStyleBackColor = true;
            btn_confirm.Click += btn_confirm_Click;
            // 
            // DTG_datagrid
            // 
            DTG_datagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DTG_datagrid.Location = new Point(323, 29);
            DTG_datagrid.Name = "DTG_datagrid";
            DTG_datagrid.RowTemplate.Height = 25;
            DTG_datagrid.Size = new Size(525, 100);
            DTG_datagrid.TabIndex = 11;
            // 
            // btn_buscar
            // 
            btn_buscar.Location = new Point(189, 107);
            btn_buscar.Name = "btn_buscar";
            btn_buscar.Size = new Size(94, 23);
            btn_buscar.TabIndex = 4;
            btn_buscar.Text = "Buscar Usuario";
            btn_buscar.UseVisualStyleBackColor = true;
            btn_buscar.Click += btn_buscar_Click;
            // 
            // rBtn_nombre
            // 
            rBtn_nombre.AutoSize = true;
            rBtn_nombre.Location = new Point(189, 31);
            rBtn_nombre.Name = "rBtn_nombre";
            rBtn_nombre.Size = new Size(69, 19);
            rBtn_nombre.TabIndex = 1;
            rBtn_nombre.TabStop = true;
            rBtn_nombre.Text = "Nombre";
            rBtn_nombre.UseVisualStyleBackColor = true;
            // 
            // rBtn_nombreUsuario
            // 
            rBtn_nombreUsuario.AutoSize = true;
            rBtn_nombreUsuario.Location = new Point(189, 56);
            rBtn_nombreUsuario.Name = "rBtn_nombreUsuario";
            rBtn_nombreUsuario.Size = new Size(128, 19);
            rBtn_nombreUsuario.TabIndex = 2;
            rBtn_nombreUsuario.TabStop = true;
            rBtn_nombreUsuario.Text = "Nombre de Usuario";
            rBtn_nombreUsuario.UseVisualStyleBackColor = true;
            // 
            // rBtn_Dni
            // 
            rBtn_Dni.AutoSize = true;
            rBtn_Dni.Location = new Point(189, 82);
            rBtn_Dni.Name = "rBtn_Dni";
            rBtn_Dni.Size = new Size(43, 19);
            rBtn_Dni.TabIndex = 3;
            rBtn_Dni.TabStop = true;
            rBtn_Dni.Text = "Dni";
            rBtn_Dni.UseVisualStyleBackColor = true;
            // 
            // txt_dato
            // 
            txt_dato.Location = new Point(51, 55);
            txt_dato.Name = "txt_dato";
            txt_dato.PlaceholderText = "Dato a buscar?";
            txt_dato.Size = new Size(120, 23);
            txt_dato.TabIndex = 22;
            txt_dato.TextAlign = HorizontalAlignment.Center;
            // 
            // FormBajaUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 176);
            ControlBox = false;
            Controls.Add(txt_dato);
            Controls.Add(rBtn_Dni);
            Controls.Add(rBtn_nombreUsuario);
            Controls.Add(rBtn_nombre);
            Controls.Add(btn_buscar);
            Controls.Add(DTG_datagrid);
            Controls.Add(btn_confirm);
            Controls.Add(btn_salir);
            Name = "FormBajaUsuarios";
            Text = "Baja de Usuarios";
            ((System.ComponentModel.ISupportInitialize)DTG_datagrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_salir;
        private Button btn_confirm;
        private Button btn_Buscar;
        private DataGridView DTG_datagrid;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsm_tipoDeDato;
        private ToolStripMenuItem TSM_nombre;
        private ToolStripMenuItem TSM_nombreUsuario;
        private ToolStripMenuItem TSM_Dni;
        private Button btn_buscar;
        private RadioButton rBtn_nombre;
        private RadioButton rBtn_nombreUsuario;
        private RadioButton rBtn_Dni;
        private TextBox txt_dato;
    }
}