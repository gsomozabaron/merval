﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace merval
{
    public partial class FormPrincipal : Form
    {

        ///Form Formulario; //formulario es una instancia del formulario acciones hay que agregar el "Form formulario justo abajo del contructor"


        public FormPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        
        private void mostrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAcciones fa = new FormAcciones();
            fa.Show();
        }
    }
}
