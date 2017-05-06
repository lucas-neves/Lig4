using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste {
	public class JogadorTicTacToeFacil : JogadorTicTacToe {
		public JogadorTicTacToeFacil(int id) : base(id) {
		}

		public override Estado EfetuarJogada(Estado estadoAtual) {
			// o jogador fácil não utiliza o minimax...
			// apenas marca a primeira célula vazia

			EstadoTicTacToe atual = (estadoAtual as EstadoTicTacToe);

			for (int linha = 0; linha < EstadoTicTacToe.TAMANHO; linha++) {
				for (int coluna = 0; coluna < EstadoTicTacToe.TAMANHO; coluna++) {

					if (atual.IsCelulaVazia(linha, coluna) == true) {
						return atual.MarcarCelula(linha, coluna, Id);
					}

				}
			}

			return null;
		}
	}
}
