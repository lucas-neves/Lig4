using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaCompetitiva {
	public interface Estado {
		// retorna uma descricao do problema que esta representação
		// de estado resolve
		string Descricao { get; }

		// retorna a quantidade máxima de turnos esperada para o jogo
		int NumeroMaximoDeTurnos { get; }

		// verifica se o estado é considerado como terminal (alguém ganhou
		// ou os movimentos se esgotaram)
		bool IsTerminal { get; }

		// de quem é a vez nesse turno? (1 ou 2)
		int JogadorDoTurno { get; }

		// alterna o jogador da vez (se é 1 vira 2, e vice-versa)
		void AlternarJogadorDoTurno();

		// número do jogador vencedor (1, 2 ou 0 para nenhum)
		int Vencedor { get; }

		// pontuação desse estado considerando o jogador atual
		// (1 se o jogador atual ganhar, -1 se ele perder, 0 se o estado
		// não for terminal / for um empate)
		int Pontuacao { get; }
	}
}
