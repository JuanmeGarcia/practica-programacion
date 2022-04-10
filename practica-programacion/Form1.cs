using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica_programacion
{
    public partial class Landing : Form
    {
        public Landing()
        {
            InitializeComponent();
        }

        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if(msgExit.Show("Estas seguro que deseas salir?", "Advertencia!") == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            TableForm tableForm = new TableForm();
            tableForm.Show();
            this.Hide();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
