using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    ///TODAS MIS CLASES DEBEN SER PUBLIC PARA PODER USARLAR EN LOS OTROS PORYECTOS
    public class Elemento
    {
        public int id {  get; set; }
        public string descripcion { get; set; }

        public override string ToString()//esto hace que cuando llame a la descripcion me la muestre y no me muestra en que clase esta
        {
            return descripcion;
        }
    }
}
