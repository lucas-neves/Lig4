using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaCompetitiva {
	public class No {
		public readonly Estado Estado;
		public readonly int Utilidade;

		public No(Estado estado, int utilidade) {
			Estado = estado;
			Utilidade = utilidade;
		}
	}
}
