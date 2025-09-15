using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    ///TODAS MIS CLASES DEBEN SER PUBLIC PARA PODER USARLAR EN LOS OTROS PORYECTOS
    public class Pokemon//creo por asi decirlo, las valores de mi tabla pokemon de bd, pero la veces es necesario hacer relacion entre clases
    {
        public int Id {  get; set; }
        [DisplayName("Número")]///ESTO HACE QUE SE ESCRIBA COMO YO QUIERA, PERO SI O SI TENGO QUE PONERLO ENCIMA DEL ATRIBUTO QUE QUIERO QUE ME MODIFIQUE
        public int Numero { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Url Imagen")]
        public string UrlImagen {  get; set; }
        public Elemento Tipo { get; set; }
        public Elemento Debilidad { get; set; } 

    }
}
