using Data_Layer.Models;
using Data_Layer.Repository;
using System;
using System.Collections.Generic;

namespace Data_Layer
{
    public class GameController
    {
        RepositoryUtente utenti = new RepositoryUtente();
        public static Utente LoginUser(string name, string password)
        {
            ICollection<Utente> user = utenti.GetById(name);
            if (user.Count!=0) return user;
            return null;
        }
    }
}
