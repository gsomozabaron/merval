namespace merval
{
    partial class FormAcciones
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
            dtg_Acciones = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtg_Acciones).BeginInit();
            SuspendLayout();
            // 
            // dtg_Acciones
            // 
            dtg_Acciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_Acciones.Location = new Point(115, 113);
            dtg_Acciones.Name = "dtg_Acciones";
            dtg_Acciones.RowHeadersVisible = false;
            dtg_Acciones.RowTemplate.Height = 25;
            dtg_Acciones.Size = new Size(557, 271);
            dtg_Acciones.TabIndex = 0;
            // 
            // FormAcciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(815, 466);
            Controls.Add(dtg_Acciones);
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "FormAcciones";
            Text = "acciones";
            TopMost = true;
            Load += acciones_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_Acciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtg_Acciones;
    }
}