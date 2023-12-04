using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudMYSQLCsharp.Classes
{
    internal class CAlumnos
    {
        public void mostrarAlumnos(DataGridView tablaAlumnos)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                string query = "select * from alumnos";
                tablaAlumnos.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaAlumnos.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la bd. Error:" + ex.ToString());
            }


        }
        public void guardarAlumno(TextBox nombre, TextBox apellido)
        {
            string sMensaje = "Por favor, no deje campos vacíos:\n\n";
            bool bError = false;
            try
            {
                if (string.IsNullOrWhiteSpace(nombre.Text))
            {
                sMensaje += "Ingrese Nombre\n";
                bError = true;
            }

           

            if (string.IsNullOrWhiteSpace(apellido.Text))
            {
                sMensaje += "Ingrese Apellido\n";
                bError = true;
            }

            if (bError)
            {
                MessageBox.Show(sMensaje);
            }
            else
            {
                CConexion objetoConexion = new CConexion();
                string query = "insert into alumnos (nombre, apellido)" +
                    "values('" + nombre.Text + "','" + apellido.Text + "');";
                MySqlCommand cmd = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }
                objetoConexion.cerrarConexion();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos de la bd Error:" + ex.ToString());
            }
        }
    public void seleccionarAlumno(DataGridView tablaAlumnos,TextBox id,TextBox nombre, TextBox apellido)
    {
        try
        {
          id.Text = tablaAlumnos.CurrentRow.Cells[0].Value.ToString();
            nombre.Text = tablaAlumnos.CurrentRow.Cells[1].Value.ToString();
            apellido.Text = tablaAlumnos.CurrentRow.Cells[2].Value.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se logró seleccionar, por favor, intente nuevamente");
        }
    }
        public void modificarAlumno(TextBox id, TextBox nombre, TextBox apellido)
        {
            string sMensaje = "Por favor, no deje campos vacíos:\n\n";
            bool bError = false;
            try
            {
                if (string.IsNullOrWhiteSpace(nombre.Text))
                {
                    sMensaje += "Ingrese Nombre\n";
                    bError = true;
                }



                if (string.IsNullOrWhiteSpace(apellido.Text))
                {
                    sMensaje += "Ingrese Apellido\n";
                    bError = true;
                }

                if (bError)
                {
                    MessageBox.Show(sMensaje);

                }
                else
                {
                    CConexion objetoConexion = new CConexion();
                    string query = "update  alumnos set nombre='" + nombre.Text + "', apellido='" + apellido.Text + "'where id ='" +
                        id.Text + "';";
                    MySqlCommand cmd = new MySqlCommand(query, objetoConexion.establecerConexion());
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                    objetoConexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se actualizaron los datos de la bd");
            }
        }
        public void eliminarAlumno(TextBox id)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                string query = "delete from alumnos where id ='" +
                    id.Text + "';";
                MySqlCommand cmd = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se borraron los datos de la bd" );
            }
        }
    }
}


