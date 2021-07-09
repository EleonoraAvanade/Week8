using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Utente
    {
        public string Nick { get; set; }
        public string Password { get; set; }
        public ICollection<Eroe> eroi { get; set; } = new List<Eroe>();
        public override string ToString()
        {
            return $"{Nick} - {Password}";
        }
    }
}
