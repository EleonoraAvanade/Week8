using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Arma
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public int Danno { get; set; }
        public string TipoPersonaggio { get; set; }
        public ICollection<Eroe> eroi { get; set; } = new List<Eroe>();
        public ICollection<Mostro> mostri { get; set; } = new List<Mostro>();
    }
}
