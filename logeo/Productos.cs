using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logeo
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }
        public void MostrarDatosProductos(ListBox lista, TextBox precio , TextBox ingredientes)
        {
            if (lista.Text=="Pan Frances")
            {
                precio.Text = "7 por un sol";
                ingredientes.Text = "1. Mejorador"+"\r\n"+"2. Harina"+ "\r\n" + "3. Sal";
            }
        }
        private void ListaProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProducto.Text = ListaProductos.Text;
            MostrarDatosProductos(ListaProductos,txtPrecio,txtIngredientes);
        }
    }
}
