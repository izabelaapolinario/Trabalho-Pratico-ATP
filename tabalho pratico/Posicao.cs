﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabalho_pratico
{
    internal class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int Linha, int Coluna)
        {
            this.Linha = Linha;
            this.Coluna = Coluna;
        }
    }
}
