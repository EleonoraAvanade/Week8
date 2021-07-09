using Data_Layer.Models;
using System;
using System.Collections.Generic;
using Data_Layer.Repository;

namespace Logic_Layer
{
    public class Partita
    {
        public Eroe eroe=null;
        RepositoryArma armis=new RepositoryArma(); 
        RepositoryEroe repositoryEroe = new RepositoryEroe();
        Utente uts = null;
        GameController gc = new GameController();
        public void Play(Utente ut) {
            uts = ut;
            eroe=Choose();
            int livelloMostro = RandMonsterLevel(eroe.Livello);
            Fight(livelloMostro);
        }

        private bool Fight(int liv)
        {
            RepositoryMostro repository = new RepositoryMostro();
            ICollection<Mostro> mostro = repository.GetAll();
            double HeroPower = Power(armis.GetById(eroe.idArma));
            double HeroLifePoint = LifePoint(eroe.Livello);
            Random r=new Random();
            Mostro mostro1 = repository.GetById(r.Next(1,2));
            Arma sceltaArma = armis.GetById(r.Next(3,4));
            double MonsterLifePoint = LifePoint(liv);
            double MonsterPower = Power(sceltaArma);
            bool heroFuggito = false;
            while(HeroLifePoint>0 && MonsterLifePoint > 0)
            {
                if (Fuggi()) { heroFuggito = true; Console.WriteLine("Fuggito\n");  break; }
                MonsterLifePoint = print(eroe.Nome, HeroPower, MonsterLifePoint, "mostro");
                HeroLifePoint = print("mostro", MonsterPower, HeroLifePoint, eroe.Nome);
            }
            if (HeroLifePoint > 0) {
                Console.WriteLine("Hai vinto!!!!!\n");
                CalcolaNuovAEsperienza(true, liv);
                return true;
            }
            if(heroFuggito)
            {
                CalcolaNuovAEsperienza(false, liv);
                return false;
            }
            else
            {
                Console.WriteLine("Hai perso :(\n");
                return false;
            }
        }

        private double LifePoint(int liv)
        {
            switch (liv)
            {
                case 1: return 20;
                case 2: return 40;
                case 3: return 60;
                case 4: return 80;
                case 5: return 100;
            }
            return 0;
        }

        private double Power(Arma arma)
        {
            return arma.Danno;
        }

        private bool Fuggi()
        {
            Console.WriteLine("Provi a fuggire (f) o combatti (c)?\n");
            if (Console.ReadLine().Contains("f"))
            {
                Random randomNumb = new Random();
                if (randomNumb.Next(1,1000) % 2 == 0) return true;
                else return false;
            }
            else return false;
        }

        private void CalcolaNuovAEsperienza(bool v, int liv)
        {
            int esperienza = eroe.Esperienza;
            if (v) esperienza += (liv * 10);
            else esperienza -= (liv * 5);
            if (esperienza > 29) eroe.Livello = 2;
            else if (esperienza > 60) eroe.Livello = 3;
            else if (esperienza > 90) eroe.Livello = 4;
            else eroe.Livello = 5;
            repositoryEroe.Update(eroe, esperienza);
        }

        private double print(string attaccante, double damage, double lifepoint, string ricevente)
        {
            Console.WriteLine("Attacca {0} infliggendo {1} a {2}\n", attaccante, damage, ricevente);
            lifepoint -= damage;
            Console.WriteLine("Life point di {0}: {1}\n",  ricevente, lifepoint);
            return lifepoint;
        }

        private int RandMonsterLevel(int livello)
        {
            Random r = new Random();
            return r.Next(0, livello);
        }

        public Eroe Choose()
        {
            Console.WriteLine("Scegli tra i seguenti eroi immettendone l'id:\n");
            ICollection<Eroe> eroi= repositoryEroe.GetAll(uts);
            int choice=gc.GestisciInput(eroi.Count);
            Eroe eroe=repositoryEroe.GetById(choice);
            return eroe;
        }
    }
}
