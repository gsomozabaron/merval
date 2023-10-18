using Entidades;
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
    public partial class FormAltaAcciones : Form
    {
        private List<Acciones> listaAccionesGral = Serializadora.LeerListaAcciones();

        public FormAltaAcciones()
        {
            InitializeComponent();
        }
       
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            string titulo = txt_Titulo.Text;
            string valor = Txt_precio.Text;
            string respuesta = "exito";
            // Inicializamos la respuesta como "exito" por defecto
            // Verificar si un elemento con el mismo título ya existe en la lista
            if (listaAccionesGral.Any(a => a.Nombre == titulo))
            {
                respuesta = "El título ya se encuentra dado de alta";
                Ventana_error verror = new Ventana_error(respuesta);
                verror.ShowDialog();
            }
            else
            {
                // Agregar la nueva acción solo si no existe un elemento con el mismo título
                Acciones nuevaAccion = new Acciones(titulo, valor);
                listaAccionesGral.Add(nuevaAccion);
                Serializadora.GuardarGralAcciones(listaAccionesGral);
                VentanaEmergente ve = new VentanaEmergente(respuesta,"Titulo Ingresado");
                ve.ShowDialog();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
