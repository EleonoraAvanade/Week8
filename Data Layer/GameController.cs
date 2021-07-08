using Data_Layer.Models;
using Data_Layer.Repository;
using System;
using System.Collections.Generic;

namespace Data_Layer
{
    public class GameController
    {
        RepositoryUtente utenti = new RepositoryUtente();
        public Utente LoginUser(string name, string password)
        {
            List<Utente> user = utenti.GetById(name);
            if (user.Count != 0) foreach (Utente ob in user) return ob;
            return null;
        }
        public Utente SignUpUtente(string name, string password)
        {
            Utente utente = new Utente();
            utente.Nick = name;
            utente.Password = password;
            utente.eroi = new List<Eroe>();
            utenti.Create(utente);
            return utente;
        }
    }
}
