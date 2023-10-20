namespace merval
{
    partial class FormBajaDeAcciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBajaDeAcciones));
            DTG_BajaAcciones = new DataGridView();
            btn_salir = new Button();
            btn_EliminarAccion = new Button();
            lbl_nombre = new Label();
            btn_actualizar = new Button();
            txt_Nombre = new TextBox();
            txt_clave = new TextBox();
            btn_Buscar = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DTG_BajaAcciones).BeginInit();
            SuspendLayout();
            // 
            // DTG_BajaAcciones
            // 
            DTG_BajaAcciones.BackgroundColor = SystemColors.ActiveCaption;
            DTG_BajaAcciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DTG_BajaAcciones.Location = new Point(49, 94);
            DTG_BajaAcciones.Name = "DTG_BajaAcciones";
            DTG_BajaAcciones.RowTemplate.Height = 25;
            DTG_BajaAcciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTG_BajaAcciones.Size = new Size(272, 241);
            DTG_BajaAcciones.TabIndex = 0;
            DTG_BajaAcciones.CellMouseDoubleClick += DTG_BajaAcciones_CellMouseDoubleClick;
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Red;
            btn_salir.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_salir.ForeColor = Color.Yellow;
            btn_salir.Location = new Point(368, 312);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(98, 28);
            btn_salir.TabIndex = 1;
            btn_salir.Text = "Salir";
            btn_salir.UseVisualStyleBackColor = false;
            btn_salir.Click += btn_salir_Click;
            // 
            // btn_EliminarAccion
            // 
            btn_EliminarAccion.BackColor = Color.Red;
            btn_EliminarAccion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EliminarAccion.ForeColor = Color.Yellow;
            btn_EliminarAccion.ImageAlign = ContentAlignment.BottomCenter;
            btn_EliminarAccion.Location = new Point(463, 71);
            btn_EliminarAccion.Name = "btn_EliminarAccion";
            btn_EliminarAccion.Size = new Size(86, 79);
            btn_EliminarAccion.TabIndex = 29;
            btn_EliminarAccion.Text = "Eliminar Titulo";
            btn_EliminarAccion.UseVisualStyleBackColor = false;
            btn_EliminarAccion.Click += btn_EliminarAccion_Click;
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_nombre.Location = new Point(392, 32);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(45, 19);
            lbl_nombre.TabIndex = 25;
            lbl_nombre.Text = "Titulo:";
            // 
            // btn_actualizar
            // 
            btn_actualizar.BackColor = Color.Lime;
            btn_actualizar.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_actualizar.Location = new Point(371, 71);
            btn_actualizar.Name = "btn_actualizar";
            btn_actualizar.Size = new Size(86, 79);
            btn_actualizar.TabIndex = 24;
            btn_actualizar.Text = "Actualizar datos";
            btn_actualizar.UseVisualStyleBackColor = false;
            btn_actualizar.Click += btn_actualizar_Click;
            // 
            // txt_Nombre
            // 
            txt_Nombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Nombre.Location = new Point(439, 29);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.PlaceholderText = "Nombre";
            txt_Nombre.Size = new Size(100, 26);
            txt_Nombre.TabIndex = 20;
            txt_Nombre.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_clave
            // 
            txt_clave.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_clave.Location = new Point(49, 32);
            txt_clave.Name = "txt_clave";
            txt_clave.PlaceholderText = "Titulo?";
            txt_clave.Size = new Size(100, 26);
            txt_clave.TabIndex = 19;
            txt_clave.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_Buscar
            // 
            btn_Buscar.BackColor = Color.Blue;
            btn_Buscar.BackgroundImage = (Image)resources.GetObject("btn_Buscar.BackgroundImage");
            btn_Buscar.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Buscar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Buscar.ForeColor = Color.FromArgb(0, 0, 192);
            btn_Buscar.Location = new Point(155, 12);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(75, 76);
            btn_Buscar.TabIndex = 18;
            btn_Buscar.Text = "Buscar";
            btn_Buscar.TextAlign = ContentAlignment.BottomCenter;
            btn_Buscar.UseVisualStyleBackColor = false;
            btn_Buscar.Click += btn_Buscar_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.InactiveCaption;
            textBox1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(371, 156);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(137, 105);
            textBox1.TabIndex = 30;
            textBox1.Text = "Ingrese el titulo y pulse buscar o haga doble click sobre el titulo buscado";
            // 
            // FormBajaDeAcciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(581, 347);
            ControlBox = false;
            Controls.Add(textBox1);
            Controls.Add(btn_EliminarAccion);
            Controls.Add(lbl_nombre);
            Controls.Add(btn_actualizar);
            Controls.Add(txt_Nombre);
            Controls.Add(txt_clave);
            Controls.Add(btn_Buscar);
            Controls.Add(btn_salir);
            Controls.Add(DTG_BajaAcciones);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FormBajaDeAcciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Baja De Acciones";
            Load += FormBajaDeAcciones_Load;
            ((System.ComponentModel.ISupportInitialize)DTG_BajaAcciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DTG_BajaAcciones;
        private Button btn_salir;
        internal Button btn_EliminarAccion;
        private Label lbl_nombre;
        private Button btn_actualizar;
        private TextBox txt_Nombre;
        private TextBox txt_clave;
        private Button btn_Buscar;
        private TextBox textBox1;
    }
}