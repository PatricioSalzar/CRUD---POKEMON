using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;//inclluyo mi proyecto para usar sus clases

namespace negocio
{
    public class ElementoNegocio
    {
        public List<Elemento> Listar()
        {
			List<Elemento> lista = new List<Elemento>();
			AccesoDatos datos  = new AccesoDatos();//solo con esto ya tengo la primera parte lista

			try
			{
				datos.setearConsulta("select id, descripcion from ELEMENTOS");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Elemento aux = new Elemento();
					aux.id = (int)datos.Lector["Id"];
					aux.descripcion = (string)datos.Lector["Descripcion"];

					lista.Add(aux);
				}

				return lista;
			}
			catch (Exception ex)
			{

				throw ex;
			}finally
			{
				datos.cerrarConexion();
			}
        }
    }
}
