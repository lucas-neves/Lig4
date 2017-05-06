using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste {
	public abstract class JogadorTicTacToe : Jogador {
		private readonly int id;
		private readonly string nome;

		public JogadorTicTacToe(int id) {
			this.id = id;
			if (id == EstadoTicTacToe.X) {
				nome = "Jogador X";
			} else {
				nome = "Jogador O";
			}
		}

		public int Id {
			get {
				return id;
			}
		}

		public string Nome {
			get {
				return nome;
			}
		}

		public IEnumerable<Estado> JogadasPossiveis(Estado estadoAtual) {
			EstadoTicTacToe atual = (estadoAtual as EstadoTicTacToe);

			List<EstadoTicTacToe> proximosEstados = new List<EstadoTicTacToe>();

			for (int linha = 0; linha < EstadoTicTacToe.TAMANHO; linha++) {
				for (int coluna = 0; coluna < EstadoTicTacToe.TAMANHO; coluna++) {

					if (atual.IsCelulaVazia(linha, coluna) == true) {
						proximosEstados.Add(atual.MarcarCelula(linha, coluna, id));
					}

				}
			}

			return proximosEstados;
		}

		public IEnumerable<Estado> JogadasPossiveisDoOponente(Estado estadoAtual) {
			EstadoTicTacToe atual = (estadoAtual as EstadoTicTacToe);

			List<EstadoTicTacToe> proximosEstados = new List<EstadoTicTacToe>();

			int idDoOponente;
			if (id == EstadoTicTacToe.X) {
				idDoOponente = EstadoTicTacToe.O;
			} else {
				idDoOponente = EstadoTicTacToe.X;
			}

			for (int linha = 0; linha < EstadoTicTacToe.TAMANHO; linha++) {
				for (int coluna = 0; coluna < EstadoTicTacToe.TAMANHO; coluna++) {

					if (atual.IsCelulaVazia(linha, coluna) == true) {
						proximosEstados.Add(atual.MarcarCelula(linha, coluna, idDoOponente));
					}

				}
			}

			return proximosEstados;
		}

		public abstract Estado EfetuarJogada(Estado estadoAtual);
	}
}
