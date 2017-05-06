using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste {
	public class JogadorLig4Facil : JogadorLig4 {
		public JogadorLig4Facil(int id) : base(id) {
		}

		public override Estado EfetuarJogada(Estado estadoAtual) {
			// o jogador fácil não utiliza o minimax...
			// apenas adiciona a peça na primeira coluna vazia

			EstadoLig4 atual = (estadoAtual as EstadoLig4);

            for (int linha = EstadoLig4.LINHAS-1; linha >= 0; linha--)
            {
                for (int coluna = 0; coluna < EstadoTicTacToe.TAMANHO; coluna++)
                {

                    if (atual.IsCelulaVazia(linha, coluna) == true)
                    {
                        return atual.MarcarCelula(linha, coluna, Id);
                    }

                }
            }

            return null;
		}
	}
}
