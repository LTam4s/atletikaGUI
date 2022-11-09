using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atletikaGUI
{
    internal class atletika
    {
        readonly int nemzetId;
        readonly string nemzet;

        readonly string versenyszam;
        readonly char nem;
        readonly int nemzetKod;
        readonly string versenyzoNev;
        readonly string eredmeny;
        readonly string csucs;
        readonly int helyezes;

        public int NemzetId => nemzetId;

        public string Nemzet => nemzet;

        public string Versenyszam => versenyszam;

        public char Nem => nem;

        public int NemzetKod => nemzetKod;

        public string VersenyzoNev => versenyzoNev;

        public string Eredmeny => eredmeny;

        public string Csucs => csucs;

        public int Helyezes => helyezes;

        public atletika(int nemzetId, string nemzet, string versenyszam, char nem, int nemzetKod, string versenyzoNev, string eredmeny, string csucs, int helyezes)
        {
            this.nemzetId = nemzetId;
            this.nemzet = nemzet;
            this.versenyszam = versenyszam;
            this.nem = nem;
            this.nemzetKod = nemzetKod;
            this.versenyzoNev = versenyzoNev;
            this.eredmeny = eredmeny;
            this.csucs = csucs;
            this.helyezes = helyezes;
        }

        public override string ToString()
        {
            return Nemzet;
        }
    }
}
