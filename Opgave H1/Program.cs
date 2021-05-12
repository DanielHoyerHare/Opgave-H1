using System;

namespace Opgave_H1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] alleH1Fag = new string[] { "Database programmering", "Grundlæggende programmering", "Machine Learning" };
            ElevModel ElevInfo = new ElevModel() { Fornavn = "Daniel", Efternavn = "Hare", Køn = "Mand", TelefonNr = "42418310", FødselsDato = new DateTime(2003,11,16), AlleH1Fag = alleH1Fag, H1Afslutdato = new DateTime(2021, 06, 22)};
            Elev Ny = new Elev(ElevInfo);
            Console.WriteLine("Elevens Information:");
            Console.WriteLine("Navn: " + Ny.info.navn);
            Console.WriteLine("Telefon Nr: " + Ny.info.telefonnr);
            Console.WriteLine("");
            Console.WriteLine("Elevs andet fag: " + ElevInfo.AlleH1Fag[1]);
            DageTilSlut Dage = new DageTilSlut(ElevInfo.H1Afslutdato);
            Console.WriteLine("Dage tilbage H1: " + Dage.tal);
            


            //DageTilSlut test = new DageTilSlut(); Udregning af Dage til afslutning via DageTilSlut struct klassen
            //Console.WriteLine(test.udregning());
        }
    }

    class ElevModel
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Køn { get; set; }
        public string TelefonNr { get; set; }
        public DateTime FødselsDato { get; set; }
        public string[] AlleH1Fag { get; set; }
        public DateTime H1Afslutdato { get; set; }
    }

    class Elev
    {
        public KontaktInfo info { get; set; }

        public Elev(ElevModel ny)
        {
            try
            {
                string navn = (ny.Fornavn + " " + ny.Efternavn);
                string telefonnr = ny.TelefonNr;
                info = new KontaktInfo(navn, telefonnr);
            }
            catch(Exception)
            {
                Console.WriteLine("Noget gik galt");
            }
        }
        public record KontaktInfo(string navn, string telefonnr);

    }
    public struct DageTilSlut
    {
        public DageTilSlut(DateTime Slutdato)
        {
            int dage = (Slutdato - DateTime.Now.Date).Days;
            tal = dage;
        }
        public int tal { get; set; }
    }
}
