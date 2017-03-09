using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanEsimerkki3
{
    class Esimerkki3Program
    {
        static void Main(string[] args)
        {
            /** 
             * Esimerkki3Program.cs
             * 
             * Jos EN TUNTISI ohjelmoinnista seuraavia konsepteja:
             * - Luokan parametrillinen rakentaja
             * - Rajapinta ja rajapinnan toteutus
             * 
             * Jos TUNNEN ohjelmoinnista seuraavan konseptin:
             * - Staattinen luokan metodi tai staattinen luokan muuttuja
             * - Parametrilliset metodit
             * 
             * niin silloin toteutus olisi esimerkin näköinen.
             * Katso kohdat läpi ja siirry Esimerkki4Program.cs ohjelmaan.
             * 
             * Edellisiin esimerkkeihin verrattuna suurin ero on, että 
             * hedelmä olio syötetään parametrina Syo()-metodiin. Huomaa
             * myös, että nyt voimme luoda useita eri hedelmä ja pacman 
             * olioita ja nämä ovat kaikki omia luokan instansseja ja olioita.
             * Tällä tavoin jokin peli jo voisi toimia järkevästi ja pacmaneilla
             * olisi omat pisteet eikä vaikutusta muihin.
             * 
             * Nyt staattiset luokan muuttujat on myös poistettu, koska niillä ei 
             * varsinaisesti saada mitään lisää tähän. Huomaa, että edelleen 
             * pisteet kasvatetaan Syo() -metodissa eikä Hedelmä-luokassa ole 
             * mitään viittaista Packam-luokkaan tai sen olioihin.
             * 
             * Tästä voisi vääntää kömpelön ratkaisun, jolla pisteisiin voisiin
             * vaikuttaa hedelmän Katoa()-metodista mutta esittelen toisenlaisen
             * ratkaisun seuraavassa esimerkissä, jossa tätä samaa parametrillista
             * metodia on jalostetu eteenpäin.
             * 
             * Tässä kohdin on hyvä esittää myös kysymys, kuuluuko Packman-luokan/olion
             * tietää, että Hedelmä tai jokin tällainen muu olio on edes olemassa?
             * 
             * Ylläoleva kysymys viittaa luokkien vastuualueisiin, että kuka tunteen ja 
             * kenet. Näisäs pienissä esimerkeissä sillä ei ole väliä mutta suuremmissa
             * ohjelmissa vahvat riippuvuudet luokkien kesken aiheuttaa yleensä outoja
             * bugeja ja vaikeuksia kehittää ohjelmaa ketterästi eteenpäin. Selitän vielä
             * Unityn tavan sähköpostissasi, koska siinä käytetään tietääkseni erilaista
             * konseptia ja lähestymistapaa minkä takia se toimii kuten alkuperäisessä
             * viestissä kerroit.
             * 
             **/
            Pacman pacman1 = new Pacman(); // Luodaan uusi pacman1 olio
            Hedelma hedelma1 = new Hedelma(); // Luodaan hedelma1 olio
            Hedelma hedelma2 = new Hedelma(); // Luodaan hedelma2 olio
            Hedelma hedelma3 = new Hedelma(); // Luodaan hedelma3 olio

            pacman1.Syo(hedelma1); // kutsutaan olion Syo-metodia
            pacman1.Syo(hedelma2); // kutsutaan olion Syo-metodia
            pacman1.Syo(hedelma3); // kutsutaan olion Syo-metodia

            Console.WriteLine(pacman1.pisteet);

            Pacman pacman2 = new Pacman(); // Luodaan uusi pacman2 olio
            Hedelma hedelma4 = new Hedelma(); 
            Hedelma hedelma5 = new Hedelma(); 

            pacman2.Syo(hedelma4); 
            pacman2.Syo(hedelma5); 

            Console.WriteLine(pacman2.pisteet);
            Console.ReadKey();
        }
    }

    class Pacman
    {
        public int pisteet; // packan luokan staattinen ominaisuus

        public Pacman()
        {
            pisteet = 0; // pisteet muuttujan alustus rakentajassa
        }

        public void TulostaTiedot()
        {
            Console.WriteLine(pisteet);
        }

        public void Syo(Hedelma hedelma)
        {
            Console.WriteLine("Hedelmä syöty");
            hedelma.Katoa();
            pisteet++;
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
            // Edelleenkään tässä en kutsuisi tai kasvattaisi pisteet muuttujaa
            // vaan pisteiden kasvu tapahtuu Syo() metodissa Packan luokassa.
            // Ongelmana on ettei ole hyvää tapaa vielä viitata näillä tiedoilla
            // packan olioihin.
            nakyvissa = false;
            Console.WriteLine("Hedelmä piilotettu");
        }
    }

}
