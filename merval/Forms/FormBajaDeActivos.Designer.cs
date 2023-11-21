﻿namespace merval
{
    partial class FormBajaDeActivos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBajaDeActivos));
            DTG_BajaAcciones = new DataGridView();
            btn_salir = new Button();
            btn_EliminarAccion = new Button();
            lbl_nombre = new Label();
            txt_Nombre = new TextBox();
            txt_clave = new TextBox();
            btn_Buscar = new Button();
            textBox1 = new TextBox();
            txt_tipo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DTG_BajaAcciones).BeginInit();
            SuspendLayout();
            // 
            // DTG_BajaAcciones
            // 
            DTG_BajaAcciones.AllowUserToAddRows = false;
            DTG_BajaAcciones.AllowUserToDeleteRows = false;
            DTG_BajaAcciones.AllowUserToOrderColumns = true;
            DTG_BajaAcciones.AllowUserToResizeColumns = false;
            DTG_BajaAcciones.AllowUserToResizeRows = false;
            DTG_BajaAcciones.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DTG_BajaAcciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DTG_BajaAcciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DTG_BajaAcciones.DefaultCellStyle = dataGridViewCellStyle2;
            DTG_BajaAcciones.Location = new Point(49, 94);
            DTG_BajaAcciones.Name = "DTG_BajaAcciones";
            DTG_BajaAcciones.ReadOnly = true;
            DTG_BajaAcciones.RowHeadersVisible = false;
            DTG_BajaAcciones.RowTemplate.Height = 25;
            DTG_BajaAcciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTG_BajaAcciones.Size = new Size(480, 302);
            DTG_BajaAcciones.TabIndex = 0;
            DTG_BajaAcciones.CellMouseDoubleClick += DTG_BajaAcciones_CellMouseDoubleClick;
            // 
            // btn_salir
            // 
            btn_salir.BackColor = Color.Red;
            btn_salir.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_salir.ForeColor = Color.Yellow;
            btn_salir.Location = new Point(701, 381);
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
            btn_EliminarAccion.Location = new Point(590, 71);
            btn_EliminarAccion.Name = "btn_EliminarAccion";
            btn_EliminarAccion.Size = new Size(157, 79);
            btn_EliminarAccion.TabIndex = 29;
            btn_EliminarAccion.Text = "Eliminar Titulo";
            btn_EliminarAccion.UseVisualStyleBackColor = false;
            btn_EliminarAccion.Click += btn_EliminarAccion_Click;
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_nombre.Location = new Point(590, 32);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(45, 19);
            lbl_nombre.TabIndex = 25;
            lbl_nombre.Text = "Titulo:";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Nombre.Location = new Point(637, 29);
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
            textBox1.Location = new Point(600, 156);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(137, 105);
            textBox1.TabIndex = 30;
            textBox1.Text = "Ingrese el titulo y pulse buscar o haga doble click sobre el titulo buscado";
            // 
            // txt_tipo
            // 
            txt_tipo.Location = new Point(49, 5);
            txt_tipo.Name = "txt_tipo";
            txt_tipo.Size = new Size(100, 21);
            txt_tipo.TabIndex = 31;
            txt_tipo.TextAlign = HorizontalAlignment.Center;
            // 
            // FormBajaDeAcciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(811, 421);
            ControlBox = false;
            Controls.Add(txt_tipo);
            Controls.Add(textBox1);
            Controls.Add(btn_EliminarAccion);
            Controls.Add(lbl_nombre);
            Controls.Add(txt_Nombre);
            Controls.Add(txt_clave);
            Controls.Add(btn_Buscar);
            Controls.Add(btn_salir);
            Controls.Add(DTG_BajaAcciones);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FormBajaDeAcciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Baja De Activos";
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
        private TextBox txt_Nombre;
        private TextBox txt_clave;
        private Button btn_Buscar;
        private TextBox textBox1;
        private TextBox txt_tipo;
    }
}