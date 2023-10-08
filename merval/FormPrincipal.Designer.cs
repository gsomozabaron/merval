namespace merval
{
    partial class FormPrincipal
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
            menuStrip2 = new MenuStrip();
            mostrarUsuariosToolStripMenuItem = new ToolStripMenuItem();
            adquirirAccioneToolStripMenuItem = new ToolStripMenuItem();
            venderTitulosToolStripMenuItem = new ToolStripMenuItem();
            verMercadoToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { mostrarUsuariosToolStripMenuItem, adquirirAccioneToolStripMenuItem, venderTitulosToolStripMenuItem, verMercadoToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(836, 24);
            menuStrip2.TabIndex = 3;
            menuStrip2.Text = "menuStrip2";
            // 
            // mostrarUsuariosToolStripMenuItem
            // 
            mostrarUsuariosToolStripMenuItem.Name = "mostrarUsuariosToolStripMenuItem";
            mostrarUsuariosToolStripMenuItem.Size = new Size(124, 20);
            mostrarUsuariosToolStripMenuItem.Text = "Cartera de Acciones";
            mostrarUsuariosToolStripMenuItem.Click += mostrarUsuariosToolStripMenuItem_Click;
            // 
            // adquirirAccioneToolStripMenuItem
            // 
            adquirirAccioneToolStripMenuItem.Name = "adquirirAccioneToolStripMenuItem";
            adquirirAccioneToolStripMenuItem.Size = new Size(104, 20);
            adquirirAccioneToolStripMenuItem.Text = "Comprar Titulos";
            adquirirAccioneToolStripMenuItem.Click += adquirirAccioneToolStripMenuItem_Click;
            // 
            // venderTitulosToolStripMenuItem
            // 
            venderTitulosToolStripMenuItem.Name = "venderTitulosToolStripMenuItem";
            venderTitulosToolStripMenuItem.Size = new Size(93, 20);
            venderTitulosToolStripMenuItem.Text = "Vender Titulos";
            venderTitulosToolStripMenuItem.Click += venderTitulosToolStripMenuItem_Click;
            // 
            // verMercadoToolStripMenuItem
            // 
            verMercadoToolStripMenuItem.Name = "verMercadoToolStripMenuItem";
            verMercadoToolStripMenuItem.Size = new Size(85, 20);
            verMercadoToolStripMenuItem.Text = "Ver Mercado";
            verMercadoToolStripMenuItem.Click += verMercadoToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(836, 337);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(836, 361);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip2);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip2;
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem mostrarUsuariosToolStripMenuItem;
        private DataGridView dataGridView1;
        private ToolStripMenuItem adquirirAccioneToolStripMenuItem;
        private ToolStripMenuItem venderTitulosToolStripMenuItem;
        private ToolStripMenuItem verMercadoToolStripMenuItem;
    }
}