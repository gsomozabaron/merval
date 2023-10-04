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
    public partial class FormCelulares : Form
    {
        List<celular> listaCelulares;

        public FormCelulares()
        {
            InitializeComponent();

        }

        private void Celulares_Load(object sender, EventArgs e)
        {
            this.listaCelulares = new List<celular>();

            this.listaCelulares.Add(new celular(EMarca.Apple, "14", 16, 128));
            this.listaCelulares.Add(new celular(EMarca.Samsung, "22", 16, 128));
            this.listaCelulares.Add(new celular(EMarca.Xiaomi, "A1", 16, 64));
            this.listaCelulares.Add(new celular(EMarca.Huawei, "H1", 4, 16));
            this.listaCelulares.Add(new celular(EMarca.Motorolla, "Razor", 16, 264));
            this.listaCelulares.Add(new celular(EMarca.Apple, "14", 16, 64));
            this.listaCelulares.Add(new celular(EMarca.Samsung, "J7", 8, 128));

            Dictionary<EMarca, int> stock = new Dictionary<EMarca, int>();
            stock[EMarca.Apple] = celular.ContarEnLista(listaCelulares, EMarca.Apple);
            stock[EMarca.Huawei] = celular.ContarEnLista(listaCelulares, EMarca.Huawei);
            stock[EMarca.Samsung] = celular.ContarEnLista(listaCelulares, EMarca.Samsung);
            stock[EMarca.Motorolla] = celular.ContarEnLista(listaCelulares, EMarca.Motorolla);

            BindingSource sb = new BindingSource(); //para poder bindear el diccionario al datasource 
            sb.DataSource = stock;
            this.dataGridView1.DataSource = sb;

        }
    }
}
