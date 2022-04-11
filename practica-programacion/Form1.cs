using System;
using System.IO;
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

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        void restart() {
            txtLastName.Clear();
            txtName.Clear();
            txtDni.Clear();
            dataPicker.Value = DateTime.Now;
            txtName.Focus();
        } 
        private void btnReset_Click(object sender, EventArgs e)
        {
            restart();
        }

        Boolean CheckInputs() {
            if ((txtDni.Text=="" || txtLastName.Text=="" || txtName.Text=="")){
                msgInputs.Show("Debe completar todas las casillas");
                return true;
            }
            return false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckInputs()){

            }
            else {
                FileStream Salida = new FileStream("Salida.txt", FileMode.Append);
                StreamWriter Wsalida = new StreamWriter(Salida);
                String lineaSalida = "";
                String registro = $"{txtName.Text};{txtLastName.Text};{txtDni.Text};{dataPicker.Value.ToString().Substring(0, 9)}";
                Wsalida.WriteLine(registro);
                Wsalida.Close();
                Salida.Close();
                restart();
            }
            
        }
    }
}
