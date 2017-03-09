using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanEsimerkki4
{
    class Esimerkki4Program
    {
        static void Main(string[] args)
        {
            /** 
             * Esimerkki4Program.cs
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
             * Katso kohdat läpi ja siirry Esimerkki5Program.cs ohjelmaan.
             * 
             * Esimerkki on aivan sama kuin edellinen esimerkki 3. Nyt erona 
             * on se, että jatketaan saman opitun asian hyödyntämistä ja
             * tehdään Hedelmä luokan Katoa()-metodista myös parametrillinen,
             * joka ottaa vastaan packan olion.
             * 
             * Nyt ohjelma on ihan toimiva ja käytännöllinen. Hedelma-luokan
             * Katoa()-metodissa on kerrottu asiasta lisää. Tämän hyvä
             * puoli on se, ettei tehdä mitään outoa kikkailua, joka voisi
             * myöhemmin aiheuttaa outoja bugeja ja ongelmia.
             * 
             * Tässäkin on huonot puolensa ja yksi esimerkki on vielä
             * kerrottu seuraavassa viimeisessä esimerkissä. Siinä päästään
             * hieman pienempään riippuvuuteen luokkien kesken, koska nyt
             * Hedelmä luokka tietää, että Packman luokka on olemassa ja toisinpäin.
             * Tällöin puhutaan myös vahvasta riippuvuudesta mikä välillä 
             * tuo suuremmissa ohjelmissa ongelmia.
             * 
             * Tätä suosittelisin eniten. Seuraava esimerkki on vielä parempi
             * mutta en tiedä kuinka ymmärrettävä se on.
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

            // Huomaa tässä this.
            // This viittaa olioon itseensä, joten tässä kohdin 
            // hedelmän Katoa() metodille annetaan nykyinen olio mikä
            // alunperin tätä Syo()-metodia kutsuu. Tällainen rakenne
            // ei ole kovin harvinainen mutta melko hyödyllinen ja 
            // tehokas oikein käytettynä.
            hedelma.Katoa(this);
        }
    }

    class Hedelma
    {
        public bool nakyvissa; // ominaisuus näkyvyyden määrittämiseen

        public Hedelma()
        {
            nakyvissa = true; // nakyvissa muuttujan alustus rakentajassa
        }

        public void Katoa(Pacman pacman)
        {
            // Nyt voimme kutsua täällä packman olion pisteet muuttujaa
            // ja kasvattaa sitä yhdellä. Eli kun packan olio välitetään
            // parametrina niin kyse on samasta oliosta mikä on jo luotu
            // pääohjelmassa. Kun olio tai luokka annetaan parametrina
            // niin tietoa ei kopioida vaan tässä viitataan käytännössä
            // siihen muistipaikkaan missä olio on ohjelman muistissa ja
            // sieltä löytyy oikea olio.
            //
            // Vertaa tätä kun parametrina on jokin perustietotyyppi,
            // esimerkiksi int tai double. Näiden perustietotyyppien kohdalla
            // parametri käsitellään eri tavoin ja siitä luodaan kopio
            // kun se annetaan parametrina.
            nakyvissa = false;
            Console.WriteLine("Hedelmä piilotettu");

            pacman.pisteet++; // tämä olio on siis se "this" kun Katoa()-metodia kutsutaan.
        }
    }

}
