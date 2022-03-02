using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logeo
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private Productos productos;
        private Empleados empleados;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int WMessage, int Wparam, int lparam);

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelSuperiorMP_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Productos());
        }
        private void AbrirFormHijo(object formHijo)
        {
            if (this.Contenedor.Controls.Count>0)// PREGUNTAMOS SI EXISTE ALGUN CONTROL
            {
                this.Contenedor.Controls.RemoveAt(0);//SI ES VERDAD LO ELIMINAMOS
            }
            Form formulario = formHijo as Form; //SE CREA UN FRM, Y EL PARAMETRO INGRESADO TIENE QUE SER TOMADO COMO OTRO FORM
            formulario.TopLevel = false; //AQUI LE DECIMOS QUE ES UN FOMRLARIO SECUNDARIO
            formulario.Dock = DockStyle.Fill;//HARA QUE EL FORMULARIO HIJO SE ACOPLE A TODO EL PANEL CONTENEDOR
            this.Contenedor.Controls.Add(formulario);//AGREGAMOS AL PANEL CONTENEDOR
            this.Contenedor.Tag = formulario;//lLE ASGINAMOS QUE ES LO QUE VA A RECIBIR EL CONTENEDOR
            formulario.Show();

        }
        private void bntEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Empleados());
        }
    }
}
