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
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
            Listar();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (msgExitMessage.Show("Estas seguro que deseas salir?", "Advertencia!") == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Landing landing = new Landing();
            landing.Show();
            this.Hide();
        }
        private void Listar(){ 
            try
            {
                FileStream Fs = new FileStream("Salida.txt", FileMode.Open);
                StreamReader SR = new StreamReader(Fs);

                string[] vectorRegristro;
                string registro;
                string nombre, apellido, DNI,birthday;
                listbox.Items.Clear();
                while (!(SR.Peek() == -1)){
                    registro = SR.ReadLine();
                    vectorRegristro = registro.Split(';');
                    nombre = vectorRegristro[0];
                    apellido = vectorRegristro[1];
                    DNI = vectorRegristro[2];
                    birthday = vectorRegristro[3];

                    ListViewItem ls = new ListViewItem(nombre);
                    ls.SubItems.Add(apellido);
                    ls.SubItems.Add(DNI);
                    ls.SubItems.Add(birthday);
                    listbox.Items.Add(ls);
                }
                SR.Close();
                Fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void TableForm_Load(object sender, EventArgs e)
        {
        }
        void restart()
        {
            txtLastName.Clear();
            txtName.Clear();
            txtDni.Clear();
            txtName.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            FileStream FS = new FileStream("Salida.txt", FileMode.Open);
            FileStream FSCopy = new FileStream("SalidaCopy.txt", FileMode.Create);
            StreamReader SR = new StreamReader(FS);
            StreamWriter SW = new StreamWriter(FSCopy);
            string[] vectorRegistro;
            string registro;
            string dni;
            while (!(SR.Peek() == -1))
            {
                registro = SR.ReadLine();
                vectorRegistro = registro.Split(';');
                dni = vectorRegistro[2];
                
                if (dni != lbl1.Text)
                {
                    SW.WriteLine(registro);
                }
            }
            SR.Close();
            SW.Close();
            FS.Close();
            FSCopy.Close();
            File.Delete("Salida.txt");
            File.Move("SalidaCopy.txt","Salida.txt");
            Listar();
            restart();
        }

        private void listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox.SelectedItems.Count > 0)
            {
                ListViewItem ls = listbox.SelectedItems[0];
                txtName.Text = ls.Text;
                txtLastName.Text = ls.SubItems[1].Text;
                txtDni.Text = ls.SubItems[2].Text;
                lbl1.Text= ls.SubItems[2].Text;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                if (txtLastName.Text != "")
                {
                    if (txtDni.Text != "")
                    {
                        FileStream FS = new FileStream("Salida.txt", FileMode.Open);
                        FileStream FSCopy = new FileStream("SalidaCopy.txt", FileMode.Create);
                        StreamReader SR = new StreamReader(FS);
                        StreamWriter SW = new StreamWriter(FSCopy);

                        string[] vectorRegistro;
                        string dni;
                        string registro;
                        while (!(SR.Peek() == -1))
                        {
                            registro = SR.ReadLine();
                            vectorRegistro = registro.Split(';');
                            dni = vectorRegistro[2];
                            if (dni == lbl1.Text)
                            {
                                registro = $"{txtName.Text};{txtLastName.Text};{txtDni.Text};{vectorRegistro[3]}"; ;
                            }

                            SW.WriteLine(registro);
                        }

                        SR.Close();
                        SW.Close();
                        FS.Close();
                        FSCopy.Close();
                        File.Delete("Salida.txt");
                        File.Move("SalidaCopy.txt","Salida.txt");
                        Listar();
                    }
                    else
                        mensajeError.Show("Ingrese un DNI por favor");
                }
                else
                    mensajeError.Show("Ingrese un apellio por favor");
            }
            else
                mensajeError.Show("Ingrese un nombre por favor");

        }
    }
}
