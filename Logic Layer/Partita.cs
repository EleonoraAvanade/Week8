using Data_Layer.Models;
using Presentation_Layer;
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

        public void Play(Eroe hero) {
            eroe=Choose();
            int livelloMostro = RandMonsterLevel(eroe.Livello);
            Fight(livelloMostro);
        }

        private bool Fight(int liv)
        {
            RepositoryMostro repository = new RepositoryMostro();
            ICollection<Mostro> mostro = repository.GetAll();
            double HeroPower = Power(eroe.Livello);
            double HeroLifePoint = LifePoint(armis.GetById(eroe.idArma));
            double MonsterPower = Power(liv);
            Random r=new Random(1,2);
            Mostro mostro1 = repository.GetById(r);
            int sceltaArma = GetById(r.Next(3,4);
            double MonsterLifePoint = LifePoint(sceltaArma);
            while(HeroLifePoint>0 && MonsterLifePoint > 0)
            {
                MonsterLifePoint = print(eroe.Nome, HeroPower, MonsterLifePoint, "mostro");
                HeroLifePoint = print("mostro", MonsterPower, HeroLifePoint, eroe.Nome);
            }//////AGGIUNGERE LA OPT DI POTER FUGGIRE
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

        private void CalcolaNuovAEsperienza(bool v, int liv)
        {
            double esperienza = eroe.Esperienza;
            if (v) esperienza += (liv * 10);
            else esperienza -= (liv * 5);
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
            List<Eroe> eroi=GetAll();
            int choice=Helper.GestisciInput(eroi.Count);
            Eroe eroe=GetById(choice);
            return eroe;
        }
    }
}
