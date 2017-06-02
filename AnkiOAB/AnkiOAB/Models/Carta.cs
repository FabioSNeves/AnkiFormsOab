using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnkiOAB.Models
{
    public class Carta
    {
        public int CodCarta { get; set; }
        public int CodBaralho { get; set; }
        public string Frente { get; set; }
        public string Verso { get; set; }
    }
}