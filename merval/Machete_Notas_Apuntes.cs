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
            //string form = "machete";
            ///ManejadorDeExcepciones.ManejarExcepcion(form, () =>
            //{ 

            //});

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
        
       
















































































//        using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using merval.DAO;
//using merval.DB;
//using merval.entidades;
//using merval.Serializadores;

//namespace merval
//    {
//        public partial class FormVender : Form
//        {
//            private Usuario usuarioActual;
//            private string tipoDeActivo;

//            public FormVender(Usuario usuario, string tipo)
//            {
//                InitializeComponent();
//                usuarioActual = usuario;
//                tipoDeActivo = tipo;
//            }

//            private void FormVender_Load(object sender, EventArgs e)
//            {
//                InitializeComponent();
//                List<Activos> listDTG = Usuario.CarteraUsuario(usuarioActual, tipoDeActivo);
//                LlenarDatagrid(listDTG);

//                //if (tipoDeActivo == "Acciones")
//                //{
//                //    VerAccionesDatagrid();
//                //}
//                //else if (tipoDeActivo == "Monedas")
//                //{
//                //    VerMonedasDatagrid();
//                //}
//                btn_Vender.Enabled = false;
//            }

//            private void VerAccionesDatagrid()
//            {
//                //List<Activos> listDTG = Usuario.CarteraUsuario(usuarioActual, tipoDeActivo);
//                //LlenarDatagrid(listDTG);
//            }

//            private void VerMonedasDatagrid()
//            {

//                List<Activos> listDTG = Usuario.CarteraUsuario(usuarioActual, tipoDeActivo);

//                LlenarDatagrid(listDTG);
//            }

//            private void LlenarDatagrid(List<Activos> listDTG)
//            {
//                this.DTG_1.Visible = true;
//                this.DTG_1.DataSource = listDTG;
//                this.DTG_1.Refresh();
//                this.DTG_1.Columns.Add("Nombre", "Nombre");
//                this.DTG_1.Columns.Add("Cantidad", "Cantidad");
//                this.DTG_1.Columns.Add("ValorCompra", "Valor Compra");
//                this.DTG_1.Columns.Add("ValorVenta", "Valor Venta");
//                // Cambiar el orden de las columnas 
//                this.DTG_1.Columns["Nombre"].DisplayIndex = 0;
//                this.DTG_1.Columns["Cantidad"].DisplayIndex = 1;
//                this.DTG_1.Columns["ValorCompra"].DisplayIndex = 2;
//                this.DTG_1.Columns["ValorVenta"].DisplayIndex = 3;

//            }

//            private void btn_calcularVenta_Click(object sender, EventArgs e)
//            {
//                btn_Vender.Enabled = true;

//                try
//                {
//                    float cotizacion = float.Parse(txt_cotizacion.Text);
//                    int cantidad = int.Parse(txt_Cantidad.Text);
//                    float totalVenta = cotizacion * cantidad;
//                    lbl_totalVenta.Text = totalVenta.ToString();

//                }
//                catch (Exception)
//                {
//                    if (txt_Cantidad.Text == "")
//                    {
//                        Vm.VentanaMensajeError("Ingresa cantidad");
//                    }
//                    else
//                    {
//                        Vm.VentanaMensajeError("Solo numeros");
//                    }
//                }
//            }

//            private void Dtg1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
//            {
//                if (DTG_1.SelectedRows.Count > 0)
//                {
//                    Activos Seleccionado = (Activos)DTG_1.SelectedRows[0].DataBoundItem;

//                    txt_titulo.Text = Seleccionado.Nombre;
//                    txt_cotizacion.Text = Seleccionado.ValorVenta.ToString();
//                }
//            }


//            private void btn_Vender_Click(object sender, EventArgs e)
//            {
//                try
//                {
//                    decimal totalVenta = decimal.Parse(lbl_totalVenta.Text);

//                    usuarioActual.Saldo = usuarioActual.Saldo + totalVenta;

//                    foreach (Activos a in usuarioActual.ListadoDeActivosPropios)
//                    {
//                        if ((a.Nombre == txt_titulo.Text) && (int.Parse(txt_Cantidad.Text) <= a.Cantidad))
//                        {
//                            if (Vm.VentanaMensajeConfirmar("Comfirmar venta?", $"{txt_Cantidad.Text} de: {txt_titulo.Text}") == DialogResult.OK)
//                            {
//                                a.Cantidad = a.Cantidad - int.Parse(txt_Cantidad.Text);
//                                if (a.Cantidad == 0)
//                                {
//                                    //Usuario.BajaDeActivosEnCartera(usuarioActual,a);  codigo viejo
//                                    usuarioActual.BajasEnCartera(usuarioActual, a);
//                                }
//                                else
//                                {
//                                    //DatabaseSQL.modificarCartera(usuarioActual,a);    codigo viejo
//                                    usuarioActual.modificarCartera(usuarioActual, a);
//                                }
//                                //DatabaseSQL.ModificarSaldo(usuarioActual);    codigo viejo
//                                usuarioActual.ModificarSaldo(usuarioActual);
//                                this.Close();
//                                break;
//                            }
//                            else
//                            {
//                                Vm.VentanaMensaje("Venta", "cancelada");
//                            }
//                        }
//                        else
//                        {
//                            if ((a.Nombre == txt_titulo.Text) && (int.Parse(txt_Cantidad.Text) > a.Cantidad))
//                            {
//                                Vm.VentanaMensajeError($"maximo {a.Cantidad}\nde {a.Nombre}");
//                                break;
//                            }
//                        }
//                    }

//                }
//                catch (Exception)
//                {
//                    Vm.VentanaMensajeError("Faltan datos");
//                    btn_Vender.Enabled = false;
//                }
//            }

//            private void btn_Salir_Click(object sender, EventArgs e)
//            {
//                this.Close();
//            }

//            private void Dtg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
//            {

//            }
//        }
//    }

//}
//}
