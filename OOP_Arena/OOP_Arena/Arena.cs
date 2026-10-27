using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_Arena
{
    class Arena
    {
        private List<Bojovnik> bojovnici;
        private Kostka kostka;

        public Arena(Kostka kostka)
        {
            bojovnici = new List<Bojovnik>();
            this.kostka = kostka;
        }
        public void PridejBojovnika(Bojovnik bojovnik)
        {
            bojovnici.Add(bojovnik);
        }
        private void VykresliArenu()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");

            Console.WriteLine("Zdraví bojovníků: \n");
            for (int i = 0; i  < bojovnici.Count; i++)
            {
                Console.WriteLine("{0} {1}", bojovnici[i], bojovnici[i].VratGrafickyPekneZivoty());
            }
            
        }

        private void VypisZpravu(string zprava)
        {
            Console.WriteLine(zprava);
            Thread.Sleep(500);
        }
        public void SpustZapas()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");
            Console.WriteLine("Vítejte v aréně!");
            Console.WriteLine($"Dnes se utkají TODO! \n");
            Console.WriteLine("Zápas může začít...");
            Console.ReadKey();

            Random r = new Random();
            int utociciBojovnik = r.Next(0, this.bojovnici.Count);
            int braniciBojovnik;

            // cyklus s bojem
            while (bojovnici.Count > 1)
            {
                for (int i = 0; i < bojovnici.Count; i++) {
                    if ( !(bojovnici[i].JeNazivu()) )
                    {
                        bojovnici.RemoveAt(i);
                    }
                }

                utociciBojovnik++;
                utociciBojovnik = utociciBojovnik % bojovnici.Count;

                do {
                    braniciBojovnik = r.Next(0, this.bojovnici.Count);
                } while (braniciBojovnik == utociciBojovnik);
                
                bojovnici[utociciBojovnik].Utoc(bojovnici[braniciBojovnik]);
                VykresliArenu();
                VypisZpravu(bojovnici[utociciBojovnik].Zprava); // zpráva o útoku
                VypisZpravu(bojovnici[braniciBojovnik].Zprava); // zpráva o obrane
                Console.WriteLine();
            }
        }
    }


}
