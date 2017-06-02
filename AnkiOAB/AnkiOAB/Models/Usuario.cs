using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnkiOAB.Models
{
    public class Usuario
    {
        public int CodUsuario { get; set; }// ficar de olho aqui.
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}