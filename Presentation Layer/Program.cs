using System;

namespace Presentation_Layer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Benvenuto in Final Fantasy 2.Academy Mix!\n");
                Console.WriteLine("\nScegli tra le seguenti operazioni:\n" +
                    "\t1 - Accedi\n" +
                    "\t2 - Registrati\n" +
                    "\t3 - Esci\n");
                int choice = Helper.GestisciInput(3);
                int randomness = 0;
                switch (choice)
                {
                    case 1:
                        bool r = Helper.Login();
                        if (!r) Console.WriteLine("Non esistente\n");
                        break;
                    case 2:
                        while (!Helper.SignUp(randomness))
                        {
                            Console.WriteLine("NickName non valido, scegline un altro simile!\n" +
                                "Se vuoi te ne consiglio io uno simile, si o no? ");
                            string yes = Console.ReadLine();
                            yes=yes.ToLower();
                            if (yes.Contains("si")) {
                                Random r = new Random();
                                randomness += r.Next(0, 20000);
                            }
                        }
                        Console.WriteLine("Adesso fa il login con queste credenziali!\n");
                        break;
                    case 3:
                        Console.WriteLine("Alla prossima!");
                        return;
                }
            }
        }
    }
}
