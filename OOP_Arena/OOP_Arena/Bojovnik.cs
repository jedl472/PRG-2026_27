using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Arena
{
    class Bojovnik
    {
        /// <summary>
        /// Jméno bojovníka
        /// </summary>
        protected string _jmeno;
        /// <summary>
        /// Život v hp
        /// </summary>
        protected int _zivot;
        /// <summary>
        /// Maximální zdraví
        /// </summary>
        protected int _maxZivot;
        /// <summary>
        /// Útok v hp
        /// </summary>
        protected int _utok;
        /// <summary>
        /// Obrana v hp
        /// </summary>
        protected int _obrana;
        /// <summary>
        /// Instance hrací kostky
        /// </summary>
        protected Kostka _kostka;
        /// <summary>
        /// Zpráva o tom, co bojovník dělá nebo co se mu děje
        /// </summary>
        public string Zprava { get; private set; }

        public Bojovnik(string jmeno, int zivot, int utok, int obrana, Kostka kostka)
        {
            _jmeno = jmeno;
            _zivot = zivot;
            _maxZivot = zivot;
            _utok = utok;
            _obrana = obrana;
            _kostka = kostka;
        }
        public override string ToString()
        {
            return _jmeno;
        }

        public bool JeNazivu()
        {
            return (_zivot > 0);
        }

        public string VratGrafickyPekneZivoty()
        {
            int celkem = 20;
            double pocet = Math.Round(((double)_zivot / _maxZivot) * celkem);
            if ((pocet == 0) && (JeNazivu()))
                pocet = 1;

            int zbyva = (int)pocet;
            int chybi = celkem - zbyva;

            // \u001b[101m = světlý červený podklad
            // \u001b[41m  = tmavě červený podklad
            // \u001b[0m   = reset barvy
            string zbyvajiciBloky = new string(' ', zbyva);
            string chybajiciBloky = new string(' ', chybi);

            return $"Život: \u001b[41m{zbyvajiciBloky}\u001b[101m{chybajiciBloky}\u001b[0m";
        }


        public void Utoc(Bojovnik souper)
        {
            int uder = _utok + _kostka.HodSebou();
            Zprava = $"{_jmeno} útočí s úderem za {uder} hp";
            souper.BranSe(uder);
        }

        public void BranSe(int uder)
        {
            int zraneni = uder - (_obrana + _kostka.HodSebou());
            if (zraneni > 0)
            {
                _zivot -= zraneni;
                Zprava = $"{_jmeno} utrpěl poškození {zraneni} hp";
                if (_zivot <= 0)
                {
                    _zivot = 0;
                    Zprava += " a zemřel";
                }

            }
            else
                Zprava = $"{0} odrazil útok";
        }
    }
}
