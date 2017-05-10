using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste {
	public class JogadorTicTacToeAleatorio : JogadorTicTacToe {
		private Random random;

		public JogadorTicTacToeAleatorio(int id) : base(id) {
			random = new Random();
		}

		public override Estado EfetuarJogada(Estado estadoAtual) {
			// o jogador aleatório não utiliza o minimax...
			// apenas marca uma célula vazia aleatória

			EstadoTicTacToe atual = (estadoAtual as EstadoTicTacToe);

			for (;;) {
				int linha = random.Next(EstadoTicTacToe.TAMANHO);
				int coluna = random.Next(EstadoTicTacToe.TAMANHO);

				if (atual.IsCelulaVazia(linha, coluna) == true) {
					return atual.MarcarCelula(linha, coluna, Id);
				}
			}
		}
	}
}
