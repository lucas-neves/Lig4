using BuscaCompetitiva;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste
{
    public abstract class JogadorLig4 : Jogador
    {
        private readonly int id;
        private readonly string nome;

        public JogadorLig4(int id)
        {
            this.id = id;
            if (id == EstadoLig4.X)
            {
                nome = "Jogador X";
            }
            else
            {
                nome = "Jogador O";
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }
        }

        public IEnumerable<Estado> JogadasPossiveis(Estado estadoAtual)
        {
            EstadoLig4 atual = (estadoAtual as EstadoLig4);

            List<EstadoLig4> proximosEstados = new List<EstadoLig4>();

            for (int coluna = 0; coluna < EstadoLig4.COLUNAS; coluna++)
            {
                for (int linha = EstadoLig4.LINHAS -1 ; linha >= 0; linha--)
                {

                    if (atual.IsCelulaVazia(linha, coluna) == true)
                    {
                        proximosEstados.Add(atual.MarcarCelula(linha, coluna, id));
                        break;
                    }
                    
                }
              


            }

            return proximosEstados;
        }

        public IEnumerable<Estado> JogadasPossiveisDoOponente(Estado estadoAtual)
        {
            EstadoLig4 atual = (estadoAtual as EstadoLig4);

            List<EstadoLig4> proximosEstados = new List<EstadoLig4>();

            int idDoOponente;
            if (id == EstadoLig4.X)
            {
                idDoOponente = EstadoLig4.O;
            }
            else
            {
                idDoOponente = EstadoLig4.X;
            }

            for (int coluna = 0; coluna < EstadoLig4.COLUNAS; coluna++)
            {
                for (int linha = EstadoLig4.LINHAS -1 ;  linha >= 0 ; linha--)
                {

                    if (atual.IsCelulaVazia(linha, coluna) == true)
                    {
                        proximosEstados.Add(atual.MarcarCelula(linha, coluna, idDoOponente));
                        break;
                    }
                    
                }
               

            }

            return proximosEstados;
        }

        public abstract Estado EfetuarJogada(Estado estadoAtual);
    }
}
