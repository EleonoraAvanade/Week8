using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Eroe:Personaggio
    {
        public string NickUtente { get; set; }
        public Utente utente { get; set; }
        public string Nome { get; set; }
        public int Livello { get; set; }
        public int Esperienza { get; set; }
    }
}
