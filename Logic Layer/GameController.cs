using Data_Layer.Models;
using Data_Layer.Repository;
using System;
using System.Collections.Generic;

namespace Logic_Layer
{
    public class GameController
    {
        //int contUtenti = 0;
        //int contEroi = 0;
        RepositoryUtente utenti = new RepositoryUtente();
        RepositoryEroe eroi = new RepositoryEroe();
        RepositoryArma armi = new RepositoryArma();
        public Utente LoginUser(string name, string password)
        {
            Utente user = utenti.GetById(name);
            if (user != null) return user;
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
        public void Play(Utente u) {
            Partita partita = new Partita();
            partita.Play(u);
        }
        public void Create(Utente u)
        {
            Console.WriteLine("Creaiamo il nostro nuovo eroe!\n" +
                "Immetti il nome che vuoi assegnare al tuo nuovo eroe: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Scegli la categoria tra: \n" +
                "\t1 - Soldier\n" +
                "\t2 - Wizard\n");
            int res=GestisciInput(2);
            string Categoria=null;
            if (res == 1) Categoria = "Soldier";
            else Categoria = "Wizard";
            Console.WriteLine("Scegli l'arma tra le seguenti:\n");
            armi.GetAll().ToString();
            ICollection<Arma> a=armi.GetAll();
            foreach (Arma eroeee in a) eroeee.ToString();
            int idArma=GestisciInput(a.Count);
            Eroe eroe = new Eroe();
            eroe.idArma = idArma;
            eroe.Livello = 1;
            eroe.NickUtente = u.Nick;
            eroe.utente = u;
            eroe.Nome = nome;
            eroe.Esperienza = 0;
            eroe.Categoria = Categoria;
            Arma[] heroes=new Arma[a.Count];
            a.CopyTo(heroes, 0);
            eroe.arma = heroes[idArma];
            eroi.Create(eroe);
            Console.WriteLine("Eroe correttamente creato\n");
        }
        public int GestisciInput(int max)
        {
            string choice = Console.ReadLine();
            bool result = false;
            int ret = 0;
            while (true)
            {
                result = Int32.TryParse(choice, out ret);
                while (!result)
                {
                    Console.WriteLine("Inserisci un numero!\n");
                    choice = Console.ReadLine();
                }
                if (ret > 0 || ret < max + 1) return ret;
                Console.WriteLine("Inserisci un numero in lista!\n");
            }
            //return 0;Nel caso dovesse per un qualche motivo uscire dal while
        }
        public void Delete(Utente u)
        {
            Console.WriteLine("Quale eroe vuoi eliminare?\n");
            ICollection<Eroe> a = eroi.GetAll(u);
            foreach (Eroe eroeee in a) eroeee.ToString();
            Eroe[] e = new Eroe[a.Count];
            int index=GestisciInput(a.Count);
            eroi.Delete(e[index].id);
            Console.WriteLine("L'eroe {0} è stato eliminato correttamente\n", e[index].Nome);
        }
    }
}
