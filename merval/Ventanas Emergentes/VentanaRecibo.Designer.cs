namespace merval.Ventanas_Emergentes
{
    partial class VentanaRecibo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaRecibo));
            label1 = new Label();
            button1 = new Button();
            btn_guardarXml = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(325, 39);
            label1.Name = "label1";
            label1.Size = new Size(49, 19);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.Location = new Point(394, 287);
            button1.Name = "button1";
            button1.Size = new Size(75, 40);
            button1.TabIndex = 1;
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btn_guardarXml
            // 
            btn_guardarXml.Location = new Point(299, 287);
            btn_guardarXml.Name = "btn_guardarXml";
            btn_guardarXml.Size = new Size(75, 40);
            btn_guardarXml.TabIndex = 2;
            btn_guardarXml.Text = "Descargar recibo";
            btn_guardarXml.UseVisualStyleBackColor = true;
            btn_guardarXml.Click += btn_guardarXml_Click;
            // 
            // VentanaRecibo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(481, 339);
            ControlBox = false;
            Controls.Add(btn_guardarXml);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "VentanaRecibo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recibo Oficial";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button btn_guardarXml;
    }
}