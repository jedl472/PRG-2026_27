using System.Text;

namespace OOP_Arena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Kostka kostka = new Kostka(6);
            Arena arena = new Arena(kostka);

            Console.WriteLine("Kolik bojovníků se dneska bude prát?");
            int pocetBojovniku = Int32.Parse(Console.ReadLine());


            for (int i = 0; i < pocetBojovniku; i++)
            {
                Console.WriteLine("Kdo?");
                Bojovnik bojovnik = new Bojovnik(Console.ReadLine(), 100, 20, 10, kostka);
                arena.PridejBojovnika( bojovnik );
            }

            Console.WriteLine("A kolik čarodějů?");
            int pocetCarodeju = Int32.Parse(Console.ReadLine());

            if (pocetCarodeju + pocetBojovniku <= 1)
            {
                Console.WriteLine("Takhle to asi úplně nefunguje.");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < pocetCarodeju; i++)
            {
                Console.WriteLine("Kdo?");
                Bojovnik bojovnik = new Carodej(Console.ReadLine(), 100, 67, 20, 10, kostka);
                arena.PridejBojovnika(bojovnik);
            }

            arena.SpustZapas();
            Console.ReadLine();
        }
    }


}
