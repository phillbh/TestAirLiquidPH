using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLiquidTestApi
{
    public class DefaultRetorno
    {
        public string Mensagem { get; set; }
        public int Status { get; set; }
        public List<object> ListaObjeto { get; set; } = new List<object>();
    }
}
