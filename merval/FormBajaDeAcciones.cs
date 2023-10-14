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
    public partial class FormBajaDeAcciones : Form
    {
        List<Acciones> listadeAccionesGral = Serializadora.LeerListaAcciones();

        public FormBajaDeAcciones()
        {
            InitializeComponent();
        }

        private void FormBajaDeAcciones_Load(object sender, EventArgs e)
        {
            DTG_BajaAcciones.DataSource = listadeAccionesGral;

        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            bool encontro = false;
            txt_Nombre.Text = "nombre";
            string buscar = txt_clave.Text;

            for (int rowIndex = 0; rowIndex < this.DTG_BajaAcciones.Rows.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < this.DTG_BajaAcciones.Columns.Count; columnIndex++)
                {
                    // Acceder al valor de la celda en la fila rowIndex y columna columnIndex
                    object cellValue = this.DTG_BajaAcciones.Rows[rowIndex].Cells[columnIndex].Value;

                    // Comprobar si el valor de la celda contiene el texto de búsqueda (ignorando mayúsculas y minúsculas)
                    if (cellValue != null && cellValue.ToString().IndexOf(buscar, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        encontro = true;

                        txt_Nombre.Text = DTG_BajaAcciones.Rows[rowIndex].Cells["Nombre"].Value.ToString();

                        break;
                    }
                }

                if (encontro)
                {
                    break;
                }
            }

            if (!encontro)
            {
                Ventana_error ve = new Ventana_error("Titulo no encontrado");
                ve.ShowDialog();
            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_EliminarAccion_Click(object sender, EventArgs e)
        {
            Acciones a = (Acciones)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;
            VentanaConfirmar ve = new VentanaConfirmar("ATENCION", "SE ELIMINARA\n PERMANENTEMENTE EL TITULO");
            if (ve.ShowDialog() == DialogResult.OK)
            {
                listadeAccionesGral.Remove(a);
                Serializadora.GuardarGralAcciones(listadeAccionesGral);
                VentanaEmergente ve2 = new VentanaEmergente("TITULO", "ELIMINADO");
                ve2.ShowDialog();
                DTG_BajaAcciones.DataSource = Serializadora.LeerListaAcciones();
            }
            else
            {
                VentanaEmergente ve2 = new VentanaEmergente("OPERACION", "CANCELADA");
                ve2.ShowDialog();
            }
        }

        private void DTG_BajaAcciones_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DTG_BajaAcciones.SelectedRows.Count > 0)
            {
                Acciones a = (Acciones)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;

                txt_Nombre.Text = a.Nombre;
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            Acciones a = (Acciones)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;
            a.Nombre = txt_Nombre.Text;

            VentanaConfirmar vc = new VentanaConfirmar("ATENCION", "esta seguro?\nSe sobreescribira el archivo ");

            if (vc.ShowDialog() == DialogResult.OK)
            {
                Serializadora.GuardarGralAcciones(listadeAccionesGral);
                DTG_BajaAcciones.DataSource = Serializadora.LeerListaAcciones();
            }
            else
            {
                DTG_BajaAcciones.DataSource = listadeAccionesGral;
            }
        }
    }
}
