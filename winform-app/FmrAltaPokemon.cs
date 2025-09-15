using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;//lo viculo donde tengo las clases de pokemon
using negocio;//incluyo el archivo negocio
using System.Configuration;
using System.Configuration.Internal;//ya lo añadie en las referencias

namespace winform_app
{
    public partial class FmrAltaPokemon : Form
    {
        private Pokemon pokemon = null;// arranca el pokemon, parametro del constructor en nulo
        private OpenFileDialog archivo = null;
        public FmrAltaPokemon()
        {
            InitializeComponent();
        }
        public FmrAltaPokemon(Pokemon pokemon)///creo otro constructor para que pueda recibir por parametros un objeto de la clase pokemon
        {
            InitializeComponent();
            this.pokemon = pokemon;//uso el this por que se llaman igual
            Text = "MODIFICAR POKEMON";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();///cierra la ventana
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                if(pokemon == null)//si el pokemon esta en nulo significa que es nuevo pokemoo y los esta agregando no modificando, sino si lo esta modificando
                    pokemon = new Pokemon();    
                pokemon.Numero = int.Parse(txtNumero.Text);//lo tenogo que pasar a entero, por eso el int.parse
                pokemon.Nombre = txtNombre.Text;
                pokemon.Descripcion = txtDescripcion.Text;
                pokemon.UrlImagen = txtUrlImagen.Text;
                pokemon.Tipo = (Elemento)cboTipo.SelectedItem;
                pokemon.Debilidad = (Elemento)cboDebilidad.SelectedItem;

                if(pokemon.Id != 0)
                {
                negocio.modificar(pokemon);
                MessageBox.Show("MODIFICADO EXITOSAMENTE");
                }else
                {
                negocio.agregar(pokemon);//le mando un pokemon a mi clase pokemonNegocio
                MessageBox.Show("AGREGADO EXITOSAMENTE");
                }

                //guardar imagen si la levanto localmente
                if(archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP")))//aca me guardo las imagenes que busco desde la computadora y no las url sacadas de internet
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.FileName);//necesito ell usinf . IO
                }

                Close();//para que regrese a la ventana que estaba antes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LblTipo_Click(object sender, EventArgs e)
        {

        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FmrAltaPokemon_Load(object sender, EventArgs e)//cargar el formulario y carga los desplegables
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();

            try
            {
                cboTipo.DataSource = elementoNegocio.Listar();//cargo la combo box con las opciones que corresponde
                cboTipo.ValueMember = "Id";
                cboTipo.DisplayMember = "Descripcion";
                cboDebilidad.DataSource = elementoNegocio.Listar();
                cboDebilidad.ValueMember = "Id";
                cboDebilidad.DisplayMember = "Descripcion";

                if(pokemon != null)//si tengo un pokemon distinto de null significa que tengo un pokemon para modificar
                {// le cargo a mi modificar pokemon los elemento  que ya tiene es pokemon-precargar
                    txtNumero.Text = pokemon.Numero.ToString();
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImagen.Text = pokemon.UrlImagen;
                    cargarImangen(pokemon.UrlImagen);
                    cboTipo.SelectedValue = pokemon.Tipo.id;
                    cboDebilidad.SelectedValue = pokemon.Debilidad.id;
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImangen(txtUrlImagen.Text);
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

        private void pbPokemon_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();//creo un objeto
            archivo.Filter = "jpg|*.jpg;|png|*.png";//yo con esto voy a abirir mis archivos desde la app y esto me lo filtra directamente por las cosas que yo quiere (jpg)
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                txtUrlImagen.Text = archivo.FileName;//esto guarda la ruta del archivo que estoy selecionando desde mi compu
                cargarImangen(archivo.FileName);

                //guardo la imagen ingresada
                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.FileName);//necesito ell usinf . IO
            }
        }
    }
}
