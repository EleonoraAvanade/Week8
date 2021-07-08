using Data_Layer;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public static class Helper
    {
        public static int GestisciInput(int max)
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
            return 0;//Nel caso dovesse per un qualche motivo uscire dal while
        }

        public static bool SignUp(int randomness)
        {
            GameController gc = new GameController();
            Console.WriteLine("Inserisci il tuo Nickname: ");
            string nick = Console.ReadLine()+randomness;
            Console.WriteLine("Inserisci la tua Password: ");
            string pass = Console.ReadLine();
            Utente accettato = gc.SignUpUtente(nick, pass);
            if (accettato != null) Console.WriteLine("Questo è il tuo Nick: {0}\n", nick);
            else return false;
            return true;
        }

        public static void MenuDiGiocoNonAdmin(Utente user)
        {
            while (true)
            {
                Console.WriteLine("\nScegli tra le seguenti operazioni:\n" +
                        "\t1 - Gioca\n" +
                        "\t2 - Crea un nuovo eroe\n" +
                        "\t3 - Elimina un eroe\n" +
                        "\t4 - Esci\n");
                int choice = Helper.GestisciInput(4);
                switch (choice)
                {
                    case 1:
                        Partita partita = new Partita();////sistemare con game controller
                        Play(user );
                        break;
                    case 2:
                        Create(user);
                        break;
                    case 3:
                        Delete(user);
                        break;
                    case 4:
                        Console.WriteLine("Alla prossima!");
                        return;
                }
            }
        }

        public static bool Login()
        {
            GameController gc = new GameController();
            Console.WriteLine("Inserisci il tuo Nickname: ");
            string nick = Console.ReadLine();
            Console.WriteLine("Inserisci la tua Password: ");
            string pass = Console.ReadLine();
            Utente exist = gc.LoginUser(nick, pass);
            if (exist!=null) MenuDiGiocoNonAdmin(exist);
            else return false;
            return true;
        }
    }
}
