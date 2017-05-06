using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaCompetitiva {
	public static class Minimax {
		public static long EstadosAvaliados;
		public static bool UtilizarPodaAlphaBeta;

		// perceba que o Minimax é na verdade uma busca em profundidade!!!!
		public static Estado EfetuarJogada(Jogador jogador, Estado estadoAtual, int profundidadeMaxima) {
			No no;
			if (UtilizarPodaAlphaBeta == true) {
				no = MaxValueAB(jogador, estadoAtual, int.MinValue, int.MaxValue, profundidadeMaxima, 0);
			} else {
				no = MaxValue(jogador, estadoAtual, profundidadeMaxima, 0);
			}
			return no.Estado;
		}

		private static No AvaliarEstado(Estado estadoAtual, int profundidadeMaxima, int profundidadeAtual) {
			EstadosAvaliados++;
			int utilidade = estadoAtual.Pontuacao * (profundidadeMaxima + 1);
			if (utilidade == 0) {
				return new No(estadoAtual, 0);
			} else if (utilidade > 0) {
				// o jogador venceu!
				return new No(estadoAtual, utilidade - profundidadeAtual);
			} else {
				// o jogador perdeu!
				return new No(estadoAtual, profundidadeAtual + utilidade);
			}
		}


		private static No MaxValue(Jogador jogador, Estado estadoAtual, int profundidadeMaxima, int profundidadeAtual) {
			if (estadoAtual.IsTerminal == true || profundidadeAtual >= profundidadeMaxima) {
				return AvaliarEstado(estadoAtual, profundidadeMaxima, profundidadeAtual);
			}

			No maior = null;

			IEnumerable<Estado> sucessores = jogador.JogadasPossiveis(estadoAtual);
			foreach (Estado e in sucessores) {
				No no = MinValue(jogador, e, profundidadeMaxima, profundidadeAtual + 1);

				if (maior == null || maior.Utilidade < no.Utilidade) {
					maior = new No(e, no.Utilidade);
				}
			}

			return maior;
		}

		private static No MinValue(Jogador jogador, Estado estadoAtual, int profundidadeMaxima, int profundidadeAtual) {
			if (estadoAtual.IsTerminal == true || profundidadeAtual >= profundidadeMaxima) {
				return AvaliarEstado(estadoAtual, profundidadeMaxima, profundidadeAtual);
			}

			No menor = null;

			IEnumerable<Estado> sucessores = jogador.JogadasPossiveisDoOponente(estadoAtual);
			foreach (Estado e in sucessores) {
				No no = MaxValue(jogador, e, profundidadeMaxima, profundidadeAtual + 1);

				if (menor == null || menor.Utilidade > no.Utilidade) {
					menor = new No(e, no.Utilidade);
				}
			}

			return menor;
		}

		private static No MaxValueAB(Jogador jogador, Estado estadoAtual, int alpha, int beta, int profundidadeMaxima, int profundidadeAtual) {
			if (estadoAtual.IsTerminal == true || profundidadeAtual >= profundidadeMaxima) {
				return AvaliarEstado(estadoAtual, profundidadeMaxima, profundidadeAtual);
			}

			No maior = null;

			IEnumerable<Estado> sucessores = jogador.JogadasPossiveis(estadoAtual);
			foreach (Estado e in sucessores) {
				No no = MinValueAB(jogador, e, alpha, beta, profundidadeMaxima, profundidadeAtual + 1);

				if (maior == null || alpha < no.Utilidade) {
					maior = new No(e, no.Utilidade);
				}

				alpha = maior.Utilidade;

				if (alpha >= beta) {
					return maior;
				}
			}

			return maior;
		}

		private static No MinValueAB(Jogador jogador, Estado estadoAtual, int alpha, int beta, int profundidadeMaxima, int profundidadeAtual) {
			if (estadoAtual.IsTerminal == true || profundidadeAtual >= profundidadeMaxima) {
				return AvaliarEstado(estadoAtual, profundidadeMaxima, profundidadeAtual);
			}

			No menor = null;

			IEnumerable<Estado> sucessores = jogador.JogadasPossiveisDoOponente(estadoAtual);
			foreach (Estado e in sucessores) {
				No no = MaxValueAB(jogador, e, alpha, beta, profundidadeMaxima, profundidadeAtual + 1);

				if (menor == null || beta > no.Utilidade) {
					menor = new No(e, no.Utilidade);
				}

				beta = menor.Utilidade;

				if (beta <= alpha) {
					return menor;
				}
			}

			return menor;
		}
	}
}
