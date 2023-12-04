using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudMYSQLCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Classes.CAlumnos objetoAlumnos = new Classes.CAlumnos();
            objetoAlumnos.mostrarAlumnos(dgvTotalAlumnos);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;
        }



        private void dgvTotalAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTotalAlumnos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Classes.CAlumnos objetoAlumnos = new Classes.CAlumnos();
            objetoAlumnos.seleccionarAlumno(dgvTotalAlumnos, txtId, txtNombre, txtApellido);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Classes.CAlumnos objetoAlumnos = new Classes.CAlumnos();
            objetoAlumnos.guardarAlumno(txtNombre,txtApellido);
            objetoAlumnos.mostrarAlumnos(dgvTotalAlumnos);
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Classes.CAlumnos objetoAlumnos = new Classes.CAlumnos();
            objetoAlumnos.modificarAlumno(txtId,txtNombre, txtApellido);
            objetoAlumnos.mostrarAlumnos(dgvTotalAlumnos);
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Classes.CAlumnos objetoAlumnos = new Classes.CAlumnos();
            objetoAlumnos.eliminarAlumno(txtId);
            objetoAlumnos.mostrarAlumnos(dgvTotalAlumnos);
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

            if (txtId.Text == "")
            {
              
                btnGuardar.Enabled = true;
                btnModificar.Enabled = false;
                btnBorrar.Enabled = false;
                
              
            }
            else
            {
                btnGuardar.Enabled = false;
                btnModificar.Enabled = true;
                btnBorrar.Enabled = true;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
