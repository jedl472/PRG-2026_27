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

            Console.WriteLine("Kolik lidi se dneska bude prát?");
            int pocetBojovniku = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < pocetBojovniku; i++)
            {
                Console.WriteLine("Kdo?");
                Bojovnik bojovnik = new Bojovnik(Console.ReadLine(), 100, 20, 10, kostka);
                arena.PridejBojovnika( bojovnik );
            }

            arena.SpustZapas();
            Console.ReadLine();
        }
    }


}
