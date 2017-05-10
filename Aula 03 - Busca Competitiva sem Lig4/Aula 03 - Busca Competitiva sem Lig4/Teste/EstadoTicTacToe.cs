using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste {
	public class EstadoTicTacToe : Estado {
		public const int VAZIO = 0;
		public const int X = 1;
		public const int O = 2;

		public const int TAMANHO = 3;

		private readonly int[,] tabuleiro;
		private readonly int vazios, vencedor;
		private int jogadorDaVez, hashCode;

		public EstadoTicTacToe(int[,] tabuleiro, int jogadorDaVez) {
			this.tabuleiro = tabuleiro;
			this.jogadorDaVez = jogadorDaVez;
			vazios = CalcularVazios();
			vencedor = CalcularVencedor();
		}

		public override string ToString() {
			// para poder imprimir a solução completa na tela
			StringBuilder sb = new StringBuilder();
			for (int linha = 0; linha < TAMANHO; linha++) {
				if (linha != 0) {
					sb.AppendLine();
					for (int coluna = 0; coluna < TAMANHO; coluna++) {
						if (coluna != 0)
							sb.Append('-');
						sb.Append('-');
					}
					sb.AppendLine();
				}
				for (int coluna = 0; coluna < TAMANHO; coluna++) {
					if (coluna != 0)
						sb.Append('|');
					switch (tabuleiro[linha, coluna]) {
						case X:
							sb.Append('X');
							break;
						case O:
							sb.Append('O');
							break;
						default:
							sb.Append(' ');
							break;
					}
				}
			}
			return sb.ToString();
		}

		public override bool Equals(object obj) {
			if (obj == this) {
				return true;
			}
			EstadoTicTacToe e = (obj as EstadoTicTacToe);
			if (e == null || e.jogadorDaVez != jogadorDaVez) {
				return false;
			}
			for (int linha = 0; linha < TAMANHO; linha++) {
				for (int coluna = 0; coluna < TAMANHO; coluna++) {
					if (e.tabuleiro[linha, coluna] != tabuleiro[linha, coluna]) {
						return false;
					}
				}
			}
			return true;
		}

		public override int GetHashCode() {
			// aqui é necessário que o hash code já tenha sido calculado!!!
			if (hashCode == 0) {
				hashCode = CalcularHashCode();
			}
			return hashCode;
		}

		private int CalcularHashCode() {
			int h = jogadorDaVez * 127;
			for (int linha = 0; linha < TAMANHO; linha++) {
				for (int coluna = 0; coluna < TAMANHO; coluna++) {
					h += ((tabuleiro[linha, coluna] - 1) * (((linha + 1) * TAMANHO) + (coluna + 1)));
				}
			}
			return h;
		}

		private int CalcularVazios() {
			int vazios = 0;

			// testa cada uma das linhas
			for (int linha = 0; linha < TAMANHO; linha++) {
				for (int coluna = 0; coluna < TAMANHO; coluna++) {
					if (tabuleiro[linha, coluna] == VAZIO) {
						vazios++;
					}
				}
			}

			return vazios;
		}

		private int CalcularVencedor() {
			int primeiro;

			// testa cada uma das linhas
			for (int linha = 0; linha < TAMANHO; linha++) {
				primeiro = tabuleiro[linha, 0];
				for (int coluna = 1; coluna < TAMANHO; coluna++) {
					if (tabuleiro[linha, coluna] != primeiro) {
						primeiro = 0;
						break;
					}
				}
				if (primeiro != 0) {
					return primeiro;
				}
			}

			// testa cada uma das colunas
			for (int coluna = 0; coluna < TAMANHO; coluna++) {
				primeiro = tabuleiro[0, coluna];
				for (int linha = 1; linha < TAMANHO; linha++) {
					if (tabuleiro[linha, coluna] != primeiro) {
						primeiro = 0;
						break;
					}
				}
				if (primeiro != 0) {
					return primeiro;
				}
			}

			// testa uma diagonal
			primeiro = tabuleiro[0, 0];
			for (int d = 1; d < TAMANHO; d++) {
				if (tabuleiro[d, d] != primeiro) {
					primeiro = 0;
					break;
				}
			}
			if (primeiro != 0) {
				return primeiro;
			}

			// testa a outra diagonal
			primeiro = tabuleiro[0, TAMANHO - 1];
			for (int d = 1; d < TAMANHO; d++) {
				if (tabuleiro[d, TAMANHO - 1 - d] != primeiro) {
					primeiro = 0;
					break;
				}
			}
			if (primeiro != 0) {
				return primeiro;
			}

			return 0;
		}

		public bool IsCelulaVazia(int linha, int coluna) {
			return (tabuleiro[linha, coluna] == VAZIO);
		}

		public EstadoTicTacToe MarcarCelula(int linha, int coluna, int jogador) {
			int[,] novo = new int[TAMANHO, TAMANHO];

			Array.Copy(tabuleiro, novo, TAMANHO * TAMANHO);
			novo[linha, coluna] = jogador;

			return new EstadoTicTacToe(novo, jogadorDaVez);
		}

		public string Descricao {
			get {
				return "Jogo da velha (tic-tac-toe)";
			}
		}

		public int NumeroMaximoDeTurnos {
			get {
				// o jogo da velha não tem mais de 9 turnos! ;)
				return TAMANHO * TAMANHO;
			}
		}

		public bool IsTerminal {
			get {
				return (vencedor != 0) || (vazios == 0);
			}
		}

		public int JogadorDoTurno {
			get {
				return jogadorDaVez;
			}
		}

		public void AlternarJogadorDoTurno() {
			if (jogadorDaVez == X) {
				jogadorDaVez = O;
			} else {
				jogadorDaVez = X;
			}
		}

		public int Vencedor {
			get {
				return vencedor;
			}
		}

		public int Pontuacao {
			get {
				switch (vencedor) {
					case X:
						if (jogadorDaVez == X) {
							return 1;
						}
						return -1;
					case O:
						if (jogadorDaVez == X) {
							return -1;
						}
						return 1;
					default:
						return 0;
				}
			}
		}
	}
}
