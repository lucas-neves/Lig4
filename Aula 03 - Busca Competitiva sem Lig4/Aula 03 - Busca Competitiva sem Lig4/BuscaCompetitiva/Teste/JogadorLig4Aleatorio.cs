using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste {
	public class JogadorLig4Aleatorio : JogadorLig4 {
        private Random random;
		public JogadorLig4Aleatorio(int id) : base(id) {
            random = new Random();
        }

		public override Estado EfetuarJogada(Estado estadoAtual) {
			// o jogador aleatório não utiliza o minimax...
			// apenas adiciona a peça na em uma coluna aleatória (e vazia)

			EstadoLig4 atual = (estadoAtual as EstadoLig4);

            for (int linha = EstadoLig4.LINHAS-1; linha>=0; linha--)
            {                
                int coluna = random.Next(EstadoLig4.COLUNAS);

                if (atual.IsCelulaVazia(linha, coluna) == true)
                {
                    return atual.MarcarCelula(linha, coluna, Id);
                }
            }

            return null;
		}
	}
}
