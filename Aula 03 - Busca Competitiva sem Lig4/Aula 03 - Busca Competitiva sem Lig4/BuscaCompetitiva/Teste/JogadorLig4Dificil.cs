using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste {
	public class JogadorLig4Dificil : JogadorLig4 {
		public JogadorLig4Dificil(int id) : base(id) {
		}

		public override Estado EfetuarJogada(Estado estadoAtual) {
			// quanto menor for a profundidade máxima de busca do algoritmo Minimax,
			// menor a chance de encontrarmos a jogada ideal

			EstadoLig4 atual = (estadoAtual as EstadoLig4);

			// @@@

			return null;
		}
	}
}
