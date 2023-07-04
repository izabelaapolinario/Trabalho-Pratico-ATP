using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tabalho_pratico
    {
        internal class JogadorComputador
        {
            private TabuleiroBatalhaNaval tabuleiro;
            private int pontuacao;
            private Posicao[] posTirosDados;
            private Random numaleatorio;

            public JogadorComputador(int numLinhas, int numColunas)
            {
                tabuleiro = new TabuleiroBatalhaNaval(numColunas, numLinhas);
                pontuacao = 0;
                posTirosDados = new Posicao[numLinhas * numColunas];
                Random numaleatorio = new Random();
            }

            public int GetPontuacao()
            {
                return pontuacao;
            }

            public void SetPontuacao(int pontuacao)
            {
                this.pontuacao = pontuacao;
            }

            public Posicao EscolherAtaque()
            {
                Posicao tiro;
                int maxTentativas = tabuleiro.NumLinhas * tabuleiro.NumColunas;
                int tentativas = 0;

                do
                {
                    int linhaAleatoria = numaleatorio.Next(tabuleiro.NumLinhas);
                    int colunaAleatoria = numaleatorio.Next(tabuleiro.NumColunas);
                    tiro = new Posicao(linhaAleatoria, colunaAleatoria);
                    tentativas++;
                }
                while ((TiroInvalido(tiro) || TiroJaEfetuado(tiro)) && tentativas < maxTentativas);

                posTirosDados[pontuacao] = tiro;
                pontuacao++;

                return tiro;
            }

            private bool TiroInvalido(Posicao tiro)
            {
                return tiro.Linha < 0 || tiro.Linha >= tabuleiro.NumLinhas || tiro.Coluna < 0 || tiro.Coluna >= tabuleiro.NumColunas;
            }

            private bool TiroJaEfetuado(Posicao tiro)
            {
                foreach (Posicao pos in posTirosDados)
                {
                    if (pos != null && pos.Linha == tiro.Linha && pos.Coluna == tiro.Coluna)
                    {
                        return true; // Retorna true se a posição já foi utilizada anteriormente no tabuleiro do jogador computador
                    }
                }
                return false;
            }

            public bool ReceberAtaque(Posicao tiro)
            {
                char alvo = tabuleiro.TabuleiroComputado()[tiro.Linha, tiro.Coluna];
                bool acertou = alvo != 'A'; // Se não for 'A', acertou alguma embarcação

                if (acertou)
                {
                    tabuleiro.MarcarTiro(tiro);
                }
                else
                {
                    tabuleiro.MarcarAgua(tiro);
                }

                return acertou;
            }
        }
    }
}
}
