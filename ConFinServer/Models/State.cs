using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConFinServer.Models
{
    public class State
    {
        public string est_sigla { get; set; }
        public string nome { get; set; }

        public State(string est_sigla, string nome)
        {
            this.est_sigla = est_sigla;
            this.nome = nome;
        }
    }
}
