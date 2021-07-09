using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Personaggio
    {
        public int id { get; set; }
        public string Categoria { get; set; }
        public int idArma { get; set; }
        public Arma arma { get; set; }
        public override string ToString()
        {
            return $"{id} - {Categoria} - {idArma}";
        }
    }
}
