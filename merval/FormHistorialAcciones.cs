using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using FastReport.DataVisualization.Charting;

namespace merval
{
    public partial class FormHistorialAcciones : Form
    {

        /////////////////// falta completar ///////////////////////////
        List<Acciones> historial = Serializadora.CargarHistoricoAcciones();

        public FormHistorialAcciones()
        {
            InitializeComponent();
            //ordenarLista();
        }

        private void FormHistorialAcciones_Load(object sender, EventArgs e)
        {
            List<string> listaOrdenada = Serializadora.CargarHistoricoOrdenado();
            MostrarListaOrdenadaEnDataGridView(listaOrdenada);
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //ordena la lista historico de saldos "nombre",fecha1,2,3....hasta 7.
        private void OrdenarLista()
        {
            string nombre;
            string fecha;
            decimal valorCompra;
            decimal valorVenta;

            List<string> listaOrdenada = new List<string>();
            foreach (Acciones accion in historial)
            {
                if (!listaOrdenada.Contains(accion.Nombre))
                {
                    nombre = accion.Nombre;
                    listaOrdenada.Add(nombre);
                    foreach (Acciones a in historial)
                    {
                        if (nombre.Equals(a.Nombre))
                        {
                            valorCompra = a.ValorCompra;
                            valorVenta = a.ValorVenta; 
                            listaOrdenada.Add(valorCompra.ToString());
                            listaOrdenada.Add(valorVenta.ToString());
                        }
                    }
                }
            }
            Serializadora.GuardarHistorialordenado(listaOrdenada);
        }

        private void MostrarListaOrdenadaEnDataGridView(List<string> listaOrdenada)
        {
            // Crea una nueva tabla de datos
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nombre de Acción");

            // Agrega columnas para los valores de las fechas
            for (int i = 1; i <= 7; i++)
            {   ///estaria bueno hacer el datenow en vez de fecha 1,2,3,4, *****************************
                dataTable.Columns.Add("Fecha " + i);
            }

            // Divide la lista ordenada en grupos de a 8 (1 nombre y 7 fechas)
            for (int i = 0; i < listaOrdenada.Count; i += 8)
            {
                DataRow row = dataTable.NewRow();
                row[0] = listaOrdenada[i];
                for (int j = 1; j <= 7; j++)
                {
                    row[j] = listaOrdenada[i + j];
                }
                dataTable.Rows.Add(row);
            }

            // Asigna la tabla de datos al DataGridView
            dataGridView1.DataSource = dataTable;
        }
    }
}
