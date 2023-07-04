using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabalho_pratico
{
    internal class BatalhaNaval
    {
        static void Main(string[] args)
        {
            //apenas um exemplo de como instaciar as embarcações na MAIN
            Embarcacao portaAviao = new Embarcacao("Porta-Aviões", 5,'P');
            Embarcacao encouracado = new Embarcacao("Encouraçado", 4,'E');
            Embarcacao cruzador = new Embarcacao("Cruzador", 3,'C');
            Embarcacao hidroaviao = new Embarcacao("Hidroavião", 2,'H');
            Embarcacao submarino = new Embarcacao("Submarino", 1,'S');

        }
    }
}
