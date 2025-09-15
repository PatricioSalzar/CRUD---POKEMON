using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;///INCLUYO LA LIBRERIA PARA SQL

namespace negocio
{
    public class AccesoDatos//con esta clase voy a crear un par de cosas para concectarme de forma mas ordenada a mi base de datos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector//getter
        {
            get { return lector; }
        }



        public AccesoDatos()//constructor
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true");//conexion con la base de datos
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
            conexion.Open();
            lector = comando.ExecuteReader();//realiza la lectura y la guarda en el lector
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion; 
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();//no se que hace
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
