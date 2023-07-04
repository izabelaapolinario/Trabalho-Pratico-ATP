using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabalho_pratico
{
    internal class TabuleiroBatalhaNaval
    {
  
        public int NumColunas { get; set; }
        public int NumLinhas { get; set; }

        private char[,] tabuleiro;
        private char[,] tabuleiroJogador;

        //Construtor do tabuleiro do jogador e do computador sem nenhuma embarcação
        public TabuleiroBatalhaNaval(int numColunas, int numLinhas)
        {
            this.NumColunas = numColunas;
            this.NumLinhas = numLinhas;
            tabuleiro = new char[numLinhas, numColunas];
            tabuleiroJogador = new char[numLinhas, numColunas];

            for (int l = 0; l < tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c < tabuleiro.GetLength(1); c++)
                {
                    tabuleiro[l, c] = 'A';
                }
            }
            for (int l = 0; l < tabuleiroJogador.GetLength(0); l++)
            {
                for (int c = 0; c < tabuleiroJogador.GetLength(1); c++)
                {
                    tabuleiroJogador[l, c] = 'A';
                }
            }
        }

        //inserindo as embarcações do computador
        public char[,] TabuleiroComputado()
        {
            try
            {
                int linha, coluna, tamanhoNavio=0;
                string navio;
                char siglaNavio='A';
                StreamReader arq = new StreamReader("C:\\Users\\diogo\\OneDrive\\Área de Trabalho\\embarcacções\\position.txt", Encoding.UTF8); //exemplo de diretorio 
                string linhaArq=arq.ReadLine();
                while (linhaArq != null)
                {
                    string[] posicoes = linhaArq.Split(';');
                    coluna = int.Parse(posicoes[1]);
                    linha = int.Parse(posicoes[2]);
                    navio = posicoes[0];
                    switch (navio)
                    {
                        case "Porta-aviões":
                            tamanhoNavio = 5;
                            siglaNavio = 'P';
                            break;
                        case "Encouraçado":
                            tamanhoNavio = 4;
                            siglaNavio = 'E';
                            break;
                        case "Cruzador":
                            tamanhoNavio = 3;
                            siglaNavio = 'C';
                            break;
                        case "Hidroavião":
                            tamanhoNavio = 2;
                            siglaNavio = 'H';
                            break;
                        case "Submarino":
                            tamanhoNavio = 1;
                            siglaNavio = 'S';
                            break;



                    }
                    for (int i = 0; i < tamanhoNavio; i++)
                    {
                        tabuleiro[linha, coluna] = siglaNavio;

                    }
                }
                
            }
            catch (Exception ex)
            {

            }
            return tabuleiro;

        }


        //adicionando embarcações do jogador
        public char[,] AdicionarEmbarcacao(Embarcacao embarcacao, Posicao posicao)
        {
            int linha = posicao.Linha;
            int coluna = posicao.Coluna;
            int tamanho = embarcacao.Tamanho;
            string nome = embarcacao.Nome;
            char sigla = embarcacao.Sigla;
            bool livre = true;

            do
            {
                
                for (int i = 0, c = coluna; i <= tamanho; i++, c++)
                {
                    if (tabuleiroJogador[linha,c] != 'A')
                    {
                        livre = false;
                        Console.WriteLine("posição invalida, favor informar um outro local"); //duvida em como fazer o usuario selecionar uma nova posição
                    }
                    else
                    {
                        livre = true;
                    }
                }
            }while (livre==false);

            for(int i = 0, c = coluna; i <= tamanho; i++, c++)
            {
                tabuleiroJogador[linha,c] = sigla;
            }

            return tabuleiroJogador;
           
        }

        //imprimir tabuleiro jogador humano
        public void ImprimirTabuleiroJogador()
        {
            for (int i = 0; i < tabuleiroJogador.GetLength(0); i++)
            {
                for(int j = 0; j < tabuleiroJogador.GetLength(1); j++)
                {
                    Console.Write(tabuleiroJogador[i, j] + " ");
                    Console.ReadLine();
                }
            }

        }


        //imprimir tabuleiro computador
        public void ImprimirTabuleiroAdversario()
        {
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    Console.Write(tabuleiro[i, j] + " ");
                    Console.ReadLine();
                }
            }
        }


    }
}
