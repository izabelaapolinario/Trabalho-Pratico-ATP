using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabalho_pratico
{
    internal class Embarcacao
    {
        public string Nome { get; set; }
        public int Tamanho { get; set; }

        public char Sigla { get; set; }

        public Embarcacao(string nome, int tamanho, char sigla)
        {
            this.Nome = nome;
            this.Tamanho = tamanho;
            this.Sigla = sigla;
        }
    }
}
