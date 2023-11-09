using merval.Excepciones;
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
    public partial class Machete_Notas_Apuntes : Form
    {
        public Machete_Notas_Apuntes()
        {
            InitializeComponent();
        }

        private void Machete_Notas_Apuntes_Load(object sender, EventArgs e)
        {
            string form = "machete";
            ManejadorDeExcepciones.ManejarExcepcion(form, () =>
            { 
            
            });

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Usuario> list = new List<Usuario>();
            List<Monedas> listM = new List<Monedas>();
            List<Acciones> listAcc = new List<Acciones>();

            foreach (Usuario usuario in list)
            {
                DataGridViewRow row = new DataGridViewRow();    //crea la fila
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell(); //crea la celda
                cell.Value = usuario.Apellido; //carga el valor en la celda
                row.Cells.Add(cell); //carga la celda a la fila
                dataGridView1.Rows.Add(row);    //agrega la fila al datagrid    
            }
            
        }
        
       
    }
}
