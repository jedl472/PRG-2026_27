using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Arena
{
    public class Kostka
    {

        private int pocetSten;
        public Kostka(int pocetSten)
        {
            this.pocetSten = pocetSten;
        }
        public int HodSebou()
        {
            Random rnd = new Random();
            return rnd.Next(1, pocetSten + 1);
        }
        
    }
}
