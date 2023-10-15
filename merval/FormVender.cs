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
    public partial class FormVender : Form
    {
        private List<Usuario> listaUsuarios = Serializadora.LeerListadoUsuarios();
        private List<Acciones> listaDeAcciones = Serializadora.LeerListaAcciones();
        private Usuario usuarioActual;

        public FormVender(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FormVender_Load(object sender, EventArgs e)
        {
            // Configura las columnas en el diseño del DataGridView (no en el código)
            Dtg1.AutoGenerateColumns = false;
            Dtg1.Columns.Add("Titulo", "Título");
            Dtg1.Columns.Add("Cotizacion", "Cotización");
            Dtg1.Columns.Add("Cartera", "Cartera");
            Dtg1.Columns.Add("PrecioCompra", "Precio de Compra");
            Dtg1.Columns.Add("Cantidad", "Cantidad");
            Dtg1.Columns.Add("FechaCompra", "Fecha de Compra");

            // Establece la fuente de datos
            Dtg1.DataSource = usuarioActual.ListadoDeAccionesPropias;
        }


        private void Dtg1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < Dtg1.Rows.Count)
            {
                if (e.ColumnIndex == Dtg1.Columns["Titulo"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Nombre;
                }
                else if (e.ColumnIndex == Dtg1.Columns["Cotizacion"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Valor.ToString();
                }
                else if (e.ColumnIndex == Dtg1.Columns["Cartera"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Nombre;
                }
                else if (e.ColumnIndex == Dtg1.Columns["PrecioCompra"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Valor.ToString();
                }
                else if (e.ColumnIndex == Dtg1.Columns["Cantidad"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Cantidad.ToString();
                }
                else if (e.ColumnIndex == Dtg1.Columns["FechaCompra"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Fecha.ToString("dd/MM/yyyy");
                }
            }

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
