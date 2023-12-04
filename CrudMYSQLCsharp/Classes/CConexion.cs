using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudMYSQLCsharp.Classes
{
    internal class CConexion
    {
        MySqlConnection conexion = new MySqlConnection();


            static string servidor = "localhost";
            static string bd = "escuela";
            static string usuario = "root";
            static string password = "root";
            static string puerto = "3306";

        string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto +";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
    
        public MySqlConnection establecerConexion()
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                //MessageBox.Show("Se conectó a la bd");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la bd");
            }
                return conexion;
        }
        public void cerrarConexion()
        {
            conexion.Close();
        }
    }
}
