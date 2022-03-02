using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace logeo
{
    public partial class FRMlogeo : Form
    {
        public FRMlogeo()
        {
            InitializeComponent();
            //FRMlogeo.
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int WMessage, int Wparam, int lparam);

        private void barraSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            String user = txtUser.Text.Trim();
            String pws = textBox2.Text.Trim();
            DialogResult rpta;
            if (user.Equals("admin") && pws.Equals("123"))
            {
                rpta = MessageBox.Show("¿Desea Ingresar?", "MESSAGE",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(rpta == DialogResult.Yes)
                {
                    this.Hide();
                    PantallaPrincipal pp = new PantallaPrincipal();
                    pp.Show();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecta", "Message",MessageBoxButtons.OK);
            }
        }

        private void btnInicio_MouseEnter(object sender, EventArgs e)
        {
            btnInicio.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void btnInicio_MouseLeave(object sender, EventArgs e)
        {
            btnInicio.ForeColor = Color.White;
        }
    }
}
 
