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
        public virtual string? Zprava { get; protected set; }

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

        public virtual string VratGrafickyPekneZivoty()
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


        public virtual void Utoc(Bojovnik souper)
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

    class Carodej : Bojovnik
    {
        protected int _mana;

        protected int _maxMana;

        public Carodej(string jmeno, int zivot, int mana, int utok, int obrana, Kostka kostka) : base(jmeno, zivot, utok, obrana, kostka)
        {
            _mana = mana;
            _maxMana = mana;
        }

        public override string VratGrafickyPekneZivoty()
        {
            int celkem = 20;

            // --- vypocet zivotu ---
            double pocetZivot = Math.Round(((double)_zivot / _maxZivot) * celkem);
            if ((pocetZivot == 0) && (JeNazivu()))
                pocetZivot = 1;

            int zbyvaZivot = (int)pocetZivot;
            int chybiZivot = celkem - zbyvaZivot;

            string zbyvajiciBlokyZivot = new string(' ', zbyvaZivot);
            string chybajiciBlokyZivot = new string(' ', chybiZivot);

            // --- vypocet many ---
            double pocetMana = _maxMana > 0 ? Math.Round(((double)_mana / _maxMana) * celkem) : 0;
            if ((pocetMana == 0) && (_mana > 0))
                pocetMana = 1;

            int zbyvaMana = (int)pocetMana;
            int chybiMana = celkem - zbyvaMana;

            string zbyvajiciBlokyMana = new string(' ', zbyvaMana);
            string chybajiciBlokyMana = new string(' ', chybiMana);

            // ANSI kódy:
            // \u001b[41m  = tmavě červené pozadí
            // \u001b[101m = světle červené pozadí
            // \u001b[44m  = tmavě modré pozadí (plná mana)
            // \u001b[104m = světle modré pozadí (chybějící mana)
            // \u001b[0m   = reset barev
            return $"Život: \u001b[41m{zbyvajiciBlokyZivot}\u001b[101m{chybajiciBlokyZivot}\u001b[0m  " +
                   $"Mana: \u001b[44m{zbyvajiciBlokyMana}\u001b[104m{chybajiciBlokyMana}\u001b[0m";
        }

        public override void Utoc(Bojovnik souper)
        {
            int typUtoku = (_mana == _maxMana ? 1 : 0);
            int uder = _utok + _kostka.HodSebou();

            switch (typUtoku)
            {
                case 0:
                    Zprava = $"{_jmeno} útočí s úderem za {uder} hp";
                    _mana = (_mana <= (_maxMana - 10) ? _mana + 10 : _maxMana);
                    souper.BranSe(uder);
                    break;
                case 1:
                    Zprava = $"{_jmeno} útočí magicky s úderem za {uder} hp";
                    _mana = 0;
                    souper.BranSe(uder);
                    break;
            }
        }
    }
}
