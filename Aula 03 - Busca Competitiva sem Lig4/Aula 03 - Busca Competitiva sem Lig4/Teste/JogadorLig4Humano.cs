using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuscaCompetitiva;

namespace Teste
{
    public class JogadorLig4Humano : JogadorLig4
    {
        private Random random;
        public JogadorLig4Humano(int id) : base(id)
        {
            random = new Random();
        }

        public override Estado EfetuarJogada(Estado estadoAtual)
        {
            // o jogador aleatório não utiliza o minimax...
            // apenas adiciona a peça na em uma coluna aleatória (e vazia)

            EstadoLig4 atual = (estadoAtual as EstadoLig4);

            

            for (;;)
            {
               
                int coluna;
                do
                {
                    Console.WriteLine("Digite uma coluna de 1 a 7");
                    coluna = int.Parse(Console.ReadLine());
                } while (coluna < 1 || coluna > 7);

                coluna = coluna - 1;
                int linha = EstadoLig4.LINHAS - 1;
                while (linha >= 0)
                {
                    if (atual.IsCelulaVazia(linha, coluna) == true)
                    {
                        return atual.MarcarCelula(linha, coluna, Id);
                    }
                    linha--;
                }
            }
        }





    }
}

