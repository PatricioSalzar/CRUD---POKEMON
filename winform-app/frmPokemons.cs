using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;//EN TODOS LADOS DONDE UTILICE CLASES DE MI BIBLITECA DE CLASES TENGO QUE VINCULARLO
using negocio;

namespace winform_app
{
    public partial class frmPokemons : Form
    {
        private List<Pokemon> ListaPokemon;
        public frmPokemons()
        {
            InitializeComponent();
        }

        private void frmPokemons_Load(object sender, EventArgs e)//invoco la lectura a base de datos
        {
            cargar();
            //una vez que se cargue tambinel le asigno los campos a mi desplegable campo
            cbocampo.Items.Add("Numero");
            cbocampo.Items.Add("Nombre");
            cbocampo.Items.Add("Descricion");

        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)//me permite seleccionat el pokemon con el cursor
        {
            if (dgvPokemons.CurrentRow != null)
            {
                Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
                cargarImangen(seleccionado.UrlImagen);
            }
        }

        private void cargar()   
        {
            PokemonNegocio negocio = new PokemonNegocio();//creo una instancia de mi clase donde tengo los datos, para usar la lista de datos
            try
            {
                ListaPokemon = negocio.listar();
                dgvPokemons.DataSource = ListaPokemon;//le doy mi lista de objetos/pokemons a datasource, para que lea la estructura de la clse pokemon y crea la tabla con sus columnas de pokemons
                ocultarColumnas();
                cargarImangen(ListaPokemon[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }

        private void ocultarColumnas()//con esto eligo las columnas que no quiero que se vean
        {
            dgvPokemons.Columns["UrlImagen"].Visible = false;//oculta la columna que yo le asigno
            dgvPokemons.Columns["Id"].Visible = false;
        }

        private void cargarImangen(string imagen)///ESTO ME PERMITE QUE EN CASO DE NO CARGAR LA IMAGEN, QUE TIRE OTRA POR DEFECTO PARA QUE NO SE ROMPA EL PROGRAMA
        {
            try
            {
                pbPokemon.Load(imagen);
            }
            catch (Exception ex)
            {
                pbPokemon.Load("https://winguweb.org/wp-content/uploads/2022/09/placeholder.png");
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FmrAltaPokemon alta = new FmrAltaPokemon();//creo la instancia y se ejecuta la segunta ventana que me va a dejar ingresar otro pokemon
            alta.ShowDialog();//no te permite ir a otra ventana hasta que no cierres en la que estas
            //si pusriea show solo me dejaria usar la ventana del fondo igual, cosa que esta malllll
            cargar();

        }

        private void btbModificar_Click(object sender, EventArgs e)///es casi lo mismo que el agregar pokemon
        {
            Pokemon seleccionado;
            seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;//con esto se supone que ya tendira el pokemon seleccionado//y ahora se lo voy a pasar por parametro a modificar
            FmrAltaPokemon modificar = new FmrAltaPokemon(seleccionado);///le mando un objeto de la clase pokemon por que asi lo puse en el constructor
            modificar.ShowDialog();
            cargar();
        }

        private void dgvPokemons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//eliminacion fisica
        {
            eliminar();
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }

        private void eliminar(bool logico = false)//esta funcion elimina un pokemon (fisico o logico) 
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon selecionado;
            try
            {
                DialogResult respuestas = MessageBox.Show("¿Estas seguro que queres eliminar este pokemon?", "Eliminado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);//esto mensaje retorna un valor que se puede evaluar
                if (respuestas == DialogResult.Yes)
                {
                    selecionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;//esto me permita selecionar un pokemon de mis pokemones cargados con el mouse

                    if(logico)
                        negocio.eliminarLogico(selecionado.Id);
                    else
                        negocio.eliminar(selecionado.Id);//y despues lo elimino, por que recibe le id del pokemon que tengo selecionado con el mouse
                    
                    cargar();//actualiza la grilla para que se muestre como se borra el pokemon
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro()
        {
            if(cbocampo.SelectedIndex < 0)//pregunto si esa caja tiene algo cargado
            {
                MessageBox.Show("por favor, selecione el campo para filtrar");
                return true;
            }
            if(cbocriterio.SelectedIndex < 0)
            {
                MessageBox.Show("por favor, selecione el criterio para filtrar");
                return true;
            }
            if(cbocampo.SelectedItem.ToString() == "Numero")
            {
                if (string.IsNullOrEmpty(txtfiltroavanzado.Text))//pregunto si la caja de texto esta vacia
                {
                    MessageBox.Show("tenes que cargar el filtro con algun valor numerico...");
                    return true;
                }
                if (!(soloNumeros(txtfiltroavanzado.Text)))
                {
                    MessageBox.Show("solo se aceptan numeros para filtrar por un campo numerico..");
                    return true;
                }
            }
            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))//aca pregunto si los caracteres de la cadena NO son numeros
                {
                    return false;
                }
            }
            return true;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio(); 
            try
            {
                if (validarFiltro())
                    return;//este return no devuelve nada, sino que cancela la ejecucion

                string campo = cbocampo.SelectedItem.ToString();
                string criterio = cbocriterio.SelectedItem.ToString();
                string filtro = txtfiltroavanzado.Text;
                dgvPokemons.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void txtbFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtbFiltro_TextChanged(object sender, EventArgs e)//cada que se vaya tocando una tecla, se va a ir actualizando el filtro y la pantalla
        {
            List<Pokemon> ListaFiltrada; // no le genero una instancia por que ya la voy a obtener de una lista ya cargada, solo le voy a aplicar un filtro
            string filtro = txtbFiltro.Text;
            if (filtro.Length >= 3)// si el filtro es mayor o igual a 3 filtra, length seria la catidad de caracteres
            {
                ListaFiltrada = ListaPokemon.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Tipo.descripcion.ToUpper().Contains(filtro.ToUpper()));//es como un for, una especie de ciclo( dondde el nombre del objeto sea igual al filtro de la caja de texto entonces ese objeto se devuelto dentro de la lista de objetos filitreados)//con el toupper puedo buscarlo sin importar las mayusculas o minusculas//contain me lo train si algunos caracteres coisiden, sin la nececidad de escribri todo el nombre//ahora tambine me los traer por la descripcion del tipo
            }
            else//si la caja de texto esta vacia entoces se van a volver a mostrar todos los pokemons que estan
            {
                ListaFiltrada = ListaPokemon;
            }
            dgvPokemons.DataSource = null;//primero lo limpio
            dgvPokemons.DataSource = ListaFiltrada;//despues le asigno la lista filtreada//por eso la lista vacia
            ocultarColumnas();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbocampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbocampo.SelectedItem.ToString();
            if(opcion == "Numero")///si en mi primer combobox eligen numero,
            {
                cbocriterio.Items.Clear();
                cbocriterio.Items.Add("Mayor a");//con esto le agrego las opciones al desplegable
                cbocriterio.Items.Add("Menor a");
                cbocriterio.Items.Add("Igual a");
            }
            else//si elgiguen la opcion con caracteres(nombre o descripcion)
            {
                cbocriterio.Items.Clear();
                cbocriterio.Items.Add("Comienza con");
                cbocriterio.Items.Add("Termina con");
                cbocriterio.Items.Add("Contiene");
            }
        }
    }
}
