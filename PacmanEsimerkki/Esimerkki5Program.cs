using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanEsimerkki5
{
    class Esimerkki5Program
    {
        static void Main(string[] args)
        {
            /** 
             * Esimerkki5Program.cs
             * 
             * Jos EN TUNTISI ohjelmoinnista seuraavia konsepteja:
             * - Luokan parametrillinen rakentaja
             * 
             * Jos TUNNEN ohjelmoinnista seuraavan konseptin:
             * - Staattinen luokan metodi tai staattinen luokan muuttuja
             * - Parametrilliset metodit
             * - Rajapinta ja rajapinnan toteutus
             * 
             * niin silloin toteutus olisi esimerkin näköinen.
             * 
             * En ota enää esille parametrillista rakentajaa. Se ei tuo
             * oikeastaan mitään suuria hyötyjä tässä esimerkissä.
             * 
             * Esimerkissä suurin ero on, että mukaan otettu yksinkertainen
             * rajapinta, joka kertoo metodin nimen, joka huolehtii
             * pisteiden laskemisesta. Huomaa, että jälkimmäinen olio saa
             * enemmän pisteitä.
             * 
             * Rajapinta on nimeltään PisteLogiikka ja jokainen luokka, joka
             * sen perii toteuttaa KasvataPisteita()-metodin. Tällöin Hedelmän
             * Katoa()-metodissa kutsutaankin parametrina annetun olion 
             * KasvataPisteita()-metodia. Parametrin tyypinä on rajapinta,
             * jolloin voidaan kutsua vain rajapinnan metodia, joten C# ja 
             * Visual Studio huolehtii, ettei mikään muu luokka voi päästä
             * metodiin parametrina, jos se ei toteuta rajapintaa.
             * 
             * Tämä tapa voi olla alkuun hankalin hahmottaa ja etsiä hyötyjä.
             * Hyödyt syntyvät taas isommissa ohjelmissa. Nyt esimerkissä
             * on luotu kaksi erilaista rajapinnan toteuttavaa luokkaa. Tällöin
             * luokissa itsessään on määritetty KasvataPisteitä()-metodi
             * ja kuten esimerkissä huomaa niin voidaan vaihdella toteutusta.
             * Nyt pelissä voisi olla erilaisia pelattavia hahmoja, jotka saavat
             * erilaisella kaavalla pisteitä.
             * 
             * Huomaa myös, että kun rajapinta annetaan parametrin tyyppinä, 
             * ei Hedelma-luokka enää tiedä mistään Packan luokista tai muista
             * ja voi toimia näin omana yksikkönään. Tämä tuo mahdollisuuden laajentaa
             * ominaisuuksia myöhemmin mikä ei tästä esimerkistä välttämättä
             * käy ilmi parhaiten. Vahvan riippuvuuden sijasta puhuttaisiin 
             * heikosta luokkien välisestä riippuvuudesta.
             * 
             **/
            Pacman pacman = new Pacman(); // Luodaan uusi pacman olio
            Hedelma hedelma1 = new Hedelma(); 
            Hedelma hedelma2 = new Hedelma(); 
            Hedelma hedelma3 = new Hedelma(); 

            pacman.Syo(hedelma1); 
            pacman.Syo(hedelma2); 
            pacman.Syo(hedelma3); 

            Console.WriteLine(pacman.pisteet);

            MsPacman mspackman = new MsPacman(); // Huomaa, että luodaan MsPackman olio
            Hedelma hedelma4 = new Hedelma(); 
            Hedelma hedelma5 = new Hedelma(); 

            mspackman.Syo(hedelma4); 
            mspackman.Syo(hedelma5); 

            Console.WriteLine(mspackman.pisteet);
            Console.ReadKey();
        }
    }

    class Pacman : PisteLogiikka
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
            hedelma.Katoa(this);
        }

        public void KasvataPisteita()
        {
            pisteet++;
        }
    }

    class MsPacman : PisteLogiikka
    {
        public int pisteet;

        public MsPacman()
        {
            pisteet = 0; 
        }

        public void TulostaTiedot()
        {
            Console.WriteLine(pisteet);
        }

        public void Syo(Hedelma hedelma)
        {
            Console.WriteLine("Hedelmä syöty");
            hedelma.Katoa(this);
        }

        public void KasvataPisteita()
        {
            pisteet = pisteet + 2;
        }
    }

    class Hedelma
    {
        public bool nakyvissa; 

        public Hedelma()
        {
            nakyvissa = true; 
        }

        public void Katoa(PisteLogiikka pacman)
        {
            nakyvissa = false;
            Console.WriteLine("Hedelmä piilotettu");

            // Tässä kohdin kutsuttu rajapinnan määrittelemä
            // KasvataPisteitä() -metodi, jonka toteutus
            // on Packman tai MsPackman luokassa.
            pacman.KasvataPisteita(); 
        }
    }

    interface PisteLogiikka
    {
        void KasvataPisteita();
    }

}
