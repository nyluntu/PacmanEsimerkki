using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanEsimerkki1
{
    class Esimerkki1Program
    {
        static void Main(string[] args)
        {
            /** 
             * Esimerkki1Program.cs
             * 
             * Jos EN TUNTISI ohjelmoinnista seuraavia konsepteja:
             * - Luokan parametrillinen rakentaja
             * - Rajapinta ja rajapinnan toteutus
             * - Parametrilliset metodit
             * - Staattinen luokan metodi tai staattinen luokan muuttuja
             * 
             * niin silloin toteutus olisi esimerkin näköinen.
             * 
             * Katso kohdat läpi ja siirry Esimerkki2Program.cs ohjelmaan.
             * Eli kaikki esimerkit ovat erilaisia tapoja kun tiedetään 
             * hieman enemmän olio-ohjelmoinnista.
             * 
             * Koska tarpeeksi konsepteja ohjelmoinnista ei ole pohjatietona,
             * toteutus on todella kömpelö ja epäkäytännöllinen.
             * 
             **/
            Pacman pacman = new Pacman(); // Luodaan uusi pacman olio

            pacman.Syo(); // kutsutaan olion Syo-metodia
            pacman.Syo(); // kutsutaan olion Syo-metodia
            pacman.Syo(); // kutsutaan olion Syo-metodia

            Console.WriteLine(pacman.pisteet);
            Console.ReadKey();
        }
    }

    class Pacman
    {
        public int pisteet; // packan luokan ominaisuus
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
            pisteet++; // kasvatetaan pisteitä
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
            // Esimerkin alussa kuvatuilla pohjatiedoilla en voisi mitenkään
            // järkevästi tämän metodin kautta kutsua toisen luokan metodia.
            // Siksi pisteiden vähennys sijoitettu myös Pacman luokan metodiin.
            // Jotta pääsisin käsiksi Packman luokan pisteet-muuttujaan niin 
            // pitäisi luoda uusi olio tässä mutta se olisi eri olio kuin mikä 
            // pääohjelmassa luodaan. Pisteet eivät tällöin pitäisi paikkaansa.
            nakyvissa = false;
            Console.WriteLine("Hedelmä piilotettu");
        }
    }

}
