using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste {
	public class JogadorTicTacToeDificil : JogadorTicTacToe {
		public JogadorTicTacToeDificil(int id) : base(id) {
		}

		public override Estado EfetuarJogada(Estado estadoAtual) {
			// quanto menor for a profundidade máxima de busca do algoritmo Minimax,
			// menor a chance de encontrarmos a jogada ideal
			return Minimax.EfetuarJogada(this, estadoAtual, estadoAtual.NumeroMaximoDeTurnos);
		}
	}
}
