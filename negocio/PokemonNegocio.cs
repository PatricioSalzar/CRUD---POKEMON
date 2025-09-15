using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;///ESTO ME PERMITE UTILIZAR TODOS LOS COMANDOS EN RELACION A SQL
using dominio;//ESTO ME DEJA USAR LAS CLASES DEL PROYECTO DOMINIO (TODO ESTO MAS QUE NADA ES UNA BUENA PRACTICA A TENER MUY EN CUENNTA)


namespace negocio
{
    ///TODAS MIS CLASES DEBEN SER PUBLIC PARA PODER USARLAR EN LOS OTROS PORYECTOS
    public class PokemonNegocio//ESTA ES LA CLASE QUE ME PERMITE MANITULAR LOS DATOS PARA LOS POKEMONSY VINCULAR LA BD
    {
        public List<Pokemon> listar()//DEVUELVE VARIOS REGISTROS/LISTA DE POKEMOS, POR QUE SON MUCHOS REGISTROS DE POKEMONS
        {
            List<Pokemon> lista = new List<Pokemon>();//creo lista
            SqlConnection conexion = new SqlConnection();//me permite conectarme con la "coneccion" a la BD SQL
            SqlCommand comando = new SqlCommand();//esto me permita realizar acciones o comandos
            SqlDataReader lector;//resultado de la lectura de datos, obtengo un set de datos, no hace falta crearle una instancia

            try//pongo todo lo que pueda llegar a fallar
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";//ME CONECTO A MI MOTOR DE BD CON EL NOMBRE, A LA BASE DE DATOS QUE ME VOY A CONECTAR, Y LO ULTIMO ES COMO ME VOY A CONECTAR  
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and D.Id = P.IdDebilidad And P.Activo = 1";///QUE DATOS ME QUIERO TRAER DE MI BASE DE DATOS, ACA TAMBIEN PUEDO FILTRAR
                comando.Connection = conexion;//los comando se ejecutan en la conexion

                conexion.Open();//abro la conexion
                lector = comando.ExecuteReader();//realizo una lectura

                while (lector.Read())//leo el lector, si lo lee devuelve true
                {   ///TODO ESTO SON LOS DATOS QUE VA A APARECER EN MI PANTALLA
                    Pokemon aux = new Pokemon();//creo un auxiliar de la clase pokemon
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(0);//leo el numero y me devuelve un valor int de 32 osea medio, hay de 16 hasta 64, entre los parentecis tengo que poner el indice de cuando aparece el dato, como su fuera un vector
                    aux.Nombre = (string)lector["Nombre"];//le paso el nombre del dato en la columna
                    aux.Descripcion = (string)lector["Descripcion"];

                    ///AHORA VERIFICO SI ESTA EN NULL
                    //if(!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                    //    aux.UrlImagen = (string)lector["UrlImagen"];
                    ///OTRA FORMA
                    if (!(lector["UrlImagen"] is DBNull))
                          aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Tipo = new Elemento();//creo una instancio para mi objeto tipo para poder usarlo
                    aux.Tipo.id = (int)lector["IdTipo"];
                    aux.Tipo.descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.id = (int)lector["IdDebilidad"];
                    aux.Debilidad.descripcion = (string)lector["Debilidad"];
                    lista.Add(aux);//agrego ese pokemon auxiliar al que le cargue los datos a mi listaPokemon
                }

                conexion.Close();//cierro la conexion
                return lista;//si tdo sale bien retorna la lista, ESTO VA SIEMPRE
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregar(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen)values(" + nuevo.Numero + ", '" + nuevo.Nombre +"', '" + nuevo.Descripcion +"',1, @idTipo, @idDebilidad, @urlImagen)");//AL FINAL CREO VARIABELS 
                datos.setearParametro("@idtipo", nuevo.Tipo.id);///LE PASO POR PARAMETROS EL VALOR DEL TIPO
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.id);
                datos.setearParametro("@urlImagen",nuevo.UrlImagen);
                datos.ejecutarAccion();///ejecuta el comando que esta arriba e inserta los datos en la base de datos
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Pokemon poke)//modifica mi pokemon
        {
            AccesoDatos dato = new AccesoDatos();       
            try
            {
                //ejecuta la consulta sql que va a cambiar los valores de mi pokemon, usando variables
                dato.setearConsulta("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @descripcion, UrlImagen = @imagen, IdTipo = @idTipo, IdDebilidad = @idDebilidad where id = @id");
                dato.setearParametro("@numero", poke.Numero);
                dato.setearParametro("@nombre", poke.Nombre);
                dato.setearParametro("@descripcion", poke.Descripcion);
                dato.setearParametro("@imagen", poke.UrlImagen);
                dato.setearParametro("@idTipo", poke.Tipo.id);//hizo falta llamar a los id por que son atributos que vienen de otra clase (Elemento) 
                dato.setearParametro("@idDebilidad", poke.Debilidad.id);//hizo falta llamar a los id por que son atributos que vienen de otra clase (Elemento)
                dato.setearParametro("@id", poke.Id);

                dato.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dato.cerrarConexion();
            }
        }

        public void eliminar (int id)//esta funcion me va a eliminar un pokemon
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from POKEMONS where id =  @Id");//setea una consulta sql que modifica mi base de datos
                datos.setearParametro("@Id",id);//le paso el valor a ese parametro para que la consulta se ejecute de acuerdo al dato
                datos.ejecutarAccion();//ejecuta mi accion

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void eliminarLogico(int id)//esto me hace una baja logica (osea que me cambia el estado del pokemon)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update POKEMONS set Activo = 0 where id = @id");//esto ejecuta una consulta sql, esa consulta la copio de la misma base de datos en una consulta
                datos.setearParametro("@id",id);//le paso el valor qud va a recibir la consulta
                datos.ejecutarAccion();//ejecuto la consulta
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and D.Id = P.IdDebilidad And P.Activo = 1 And ";
                if(campo == "Numero")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }
                }
                else if(campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' " ;
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "' " ;
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%' " ;
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "P.Descripcion like '%" + filtro + "%' ";
                            break;
                    }
                }
                datos.setearConsulta( consulta );
                datos.ejecutarLectura();
                while (datos.Lector.Read())//leo el lector, si lo lee devuelve true
                {   ///TODO ESTO SON LOS DATOS QUE VA A APARECER EN MI PANTALLA
                    Pokemon aux = new Pokemon();//creo un auxiliar de la clase pokemon
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);//leo el numero y me devuelve un valor int de 32 osea medio, hay de 16 hasta 64, entre los parentecis tengo que poner el indice de cuando aparece el dato, como su fuera un vector
                    aux.Nombre = (string)datos.Lector["Nombre"];//le paso el nombre del dato en la columna
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    ///AHORA VERIFICO SI ESTA EN NULL
                    //if(!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                    //    aux.UrlImagen = (string)lector["UrlImagen"];
                    ///OTRA FORMA
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();//creo una instancio para mi objeto tipo para poder usarlo
                    aux.Tipo.id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.descripcion = (string)datos.Lector["Debilidad"];
                    lista.Add(aux);//agrego ese pokemon auxiliar al que le cargue los datos a mi listaPokemon
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
