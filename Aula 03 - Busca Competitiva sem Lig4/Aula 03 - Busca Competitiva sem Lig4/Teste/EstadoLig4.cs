using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste {
	public class EstadoLig4 : Estado {
		public const int VAZIO = 0;
		public const int X = 1;
		public const int O = 2;

		public const int LINHAS = 6;
		public const int COLUNAS = 7;

		private readonly int[,] tabuleiro;
		// @@@
		
		private readonly int vencedor, vazios;
		private int jogadorDaVez, hashCode;

		public EstadoLig4(int[,] tabuleiro, int jogadorDaVez) {
			this.tabuleiro = tabuleiro;
			this.jogadorDaVez = jogadorDaVez;
            vazios = CalcularVazios();
            vencedor = CalcularVencedor();
        }

		public override string ToString() {
			// para poder imprimir a solução completa na tela
			StringBuilder sb = new StringBuilder();
			for (int linha = 0; linha < LINHAS; linha++) {
				if (linha != 0) {
					sb.AppendLine();
					for (int coluna = 0; coluna < COLUNAS; coluna++) {
						if (coluna != 0)
							sb.Append('-');
						sb.Append('-');
					}
					sb.AppendLine();
				}
				for (int coluna = 0; coluna < COLUNAS; coluna++) {
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
			EstadoLig4 e = (obj as EstadoLig4);
			if (e == null || e.jogadorDaVez != jogadorDaVez) {
				return false;
			}
			for (int linha = 0; linha < LINHAS; linha++) {
				for (int coluna = 0; coluna < COLUNAS; coluna++) {
					if (e.tabuleiro[linha, coluna] != tabuleiro[linha, coluna]) {
						return false;
					}
				}
			}
			return true;
		}

		public override int GetHashCode() {
			
			if (hashCode == 0) {
				hashCode = CalcularHashCode();
			}
			return hashCode;
		}

		private int CalcularHashCode() {
			int h = jogadorDaVez * 7919;
			for (int linha = 0; linha < LINHAS; linha++) {
				for (int coluna = 0; coluna < COLUNAS; coluna++) {
					h += ((tabuleiro[linha, coluna] - 1) * (((linha + 1) * COLUNAS) + (coluna + 1)));
				}
			}
			return h;
		}

        private int CalcularVazios()
        {
            int vazios = 0;

            // testa cada uma das linhas
            for (int linha = 0; linha < LINHAS; linha++)
            {
                for (int coluna = 0; coluna < COLUNAS; coluna++)
                {
                    if (tabuleiro[linha, coluna] == VAZIO)
                    {
                        vazios++;
                    }
                }
            }

            return vazios;
        }

        private int CalcularVencedor()
        {
            int primeiro;
            
            // testa cada uma das linhas
            for (int linha = 0; linha < LINHAS; linha++)
            {
                int seq = 1;
                primeiro = tabuleiro[linha, 0];

                for (int coluna = 1; coluna < COLUNAS; coluna++)
                {
                    if (tabuleiro[linha, coluna] != primeiro)
                    {
                        if(coluna < COLUNAS - 3)
                        {
                            primeiro = tabuleiro[linha, coluna];
                            seq = 1;
                        }
                       
                    }
                    else
                    {
                        seq++;
                        if (seq == 4 && primeiro != 0)
                        {
                            return primeiro;
                        }
                    }
                }
            }

            // testa cada uma das colunas
            for (int coluna = 0; coluna < COLUNAS; coluna++)
            {
                int seq = 1;
                primeiro = tabuleiro[0, coluna];

                for (int linha = 1; linha < LINHAS; linha++)
                {
                    if (tabuleiro[linha, coluna] != primeiro)
                    {
                        if (linha < LINHAS - 3)
                        {
                            primeiro = tabuleiro[linha, coluna];
                            seq = 1;
                        }

                    }
                    else
                    {
                        seq++;
                        if (seq == 4 && primeiro != 0)
                        {
                            return primeiro;
                        }
                    }
                }
                
            }

            // testa uma diagonal DIREITA PARA ESQUERDA
            
            primeiro = tabuleiro[0, 0];

            for (int linha = 0; linha < LINHAS -3; linha++)
            {
                int seq = 1;
                primeiro = tabuleiro[linha, 0];
                int aux = linha;

                for (int coluna = 1; coluna < COLUNAS; coluna++)
                {
                    
                    if (tabuleiro[aux, coluna] != primeiro)
                    {
                        if (coluna < COLUNAS - 3)
                        {
                            primeiro = tabuleiro[aux, coluna];
                            seq = 1;
                        }

                    }
                    else
                    {
                        seq++;
                        if (seq == 4)
                        {
                            return primeiro;
                        }
                    }
                    aux++;
                }
                
            }
            
                // testa a outra diagonal
                //primeiro = tabuleiro[0, LINHAS - 1];
                //for (int d = 1; d < TAMANHO; d++)
                //{
                //    if (tabuleiro[d, TAMANHO - 1 - d] != primeiro)
                //    {
                //        primeiro = 0;
                //        break;
                //    }
                //}
                //if (primeiro != 0)
                //{
                //    return primeiro;
                //}

                return 0;
        }

        public bool IsCelulaVazia(int linha, int coluna)
        {
            return (tabuleiro[linha, coluna] == VAZIO);
        }

        public EstadoLig4 MarcarCelula(int linha, int coluna, int jogador)
        {
            int[,] novo = new int[LINHAS, COLUNAS];

            Array.Copy(tabuleiro, novo, LINHAS * COLUNAS);
            novo[linha, coluna] = jogador;

            return new EstadoLig4(novo, jogadorDaVez);
        }

        public string Descricao {
			get {
				return "Jogo Lig-4";
			}
		}

		public int NumeroMaximoDeTurnos {
			get {
				// impossível existirem mais turnos do que células na matriz! ;)
				return LINHAS * COLUNAS;
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
