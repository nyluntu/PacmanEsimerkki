using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanEsimerkki2
{
    class Esimerkki2Program
    {
        static void Main(string[] args)
        {
            /** 
             * Esimerkki2Program.cs
             * 
             * Jos EN TUNTISI ohjelmoinnista seuraavia konsepteja:
             * - Luokan parametrillinen rakentaja
             * - Rajapinta ja rajapinnan toteutus
             * - Parametrilliset metodit
             * 
             * Jos TUNNEN ohjelmoinnista seuraavan konseptin:
             * - Staattinen luokan metodi tai staattinen luokan muuttuja
             * 
             * niin silloin toteutus olisi esimerkin näköinen.
             * Katso kohdat läpi ja siirry Esimerkki3Program.cs ohjelmaan.
             * 
             * Tässä esimerkissä suurin ero on, että pisteet -muuttuja Pacman
             * luokassa on merkitty staattiseksi. Tällöin kirjoittamalla luokan
             * nimi ja viittaamalla pisteet -muuttujaan, päästään käsiksi
             * tämän arvoon. Tämä ratkaisu on myös kömpelö sen takia,
             * ett jos Packan luokasta luodaan useita olioita, ne jakaisivat 
             * saman muuttujan, koska se on staattinen. Staattiset luokan
             * muuttujat toimivat tietyissä tilanteissa mutta tässä esimerkissä
             * ei kovin hyvin.
             * 
             **/
            Pacman pacman = new Pacman(); // Luodaan uusi pacman olio

            pacman.Syo(); // kutsutaan olion Syo-metodia
            pacman.Syo(); // kutsutaan olion Syo-metodia
            pacman.Syo(); // kutsutaan olion Syo-metodia

            Console.WriteLine(Pacman.pisteet);
            Console.ReadKey();
        }
    }

    class Pacman
    {
        public static int pisteet; // packan luokan staattinen ominaisuus
        Hedelma hedelma = new Hedelma(); // Luodaan uusi hedelmä olio

        public Pacman()
        {
            pisteet = 0; // pisteet muuttujan alustus rakentajassa
        }

        public void TulostaTiedot()
        {
            Console.WriteLine(pisteet);
        }

        public void Syo()
        {
            Console.WriteLine("Hedelmä syöty");
            hedelma.Katoa();
        }
    }

    class Hedelma
    {
        public bool nakyvissa; // ominaisuus näkyvyyden määrittämiseen

        public Hedelma()
        {
            nakyvissa = true; // nakyvissa muuttujan alustus rakentajassa
        }

        public void Katoa()
        {
            // Erona tässä Katoa() -metodissa edelliseen on se, että nyt 
            // voitaisiin viitata staattiseen muuttujaan Pacman-luokassa.
            // Huomaa, että puhun luokasta, enkä oliosta. Selitys tämän
            // ongelmista on esimerkin alussa.
            nakyvissa = false;
            Console.WriteLine("Hedelmä piilotettu");
            Pacman.pisteet++;
        }
    }

}
