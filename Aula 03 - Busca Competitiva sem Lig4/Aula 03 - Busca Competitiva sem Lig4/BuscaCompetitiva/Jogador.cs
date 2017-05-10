using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaCompetitiva {
	public interface Jogador {
		// retorna o id do jogador (1 ou 2)
		int Id { get; }

		// retorna o nome do jogador
		string Nome { get; }

		// retorna os estados resultantes das possíveis jogadas atuais
		IEnumerable<Estado> JogadasPossiveis(Estado estadoAtual);

		// retorna os estados resultantes das possíveis jogadas atuais (do oponente)
		IEnumerable<Estado> JogadasPossiveisDoOponente(Estado estadoAtual);

		// efetua uma jogada e retorna o estado depois da jogada
		Estado EfetuarJogada(Estado estadoAtual);
	}
}
