using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Estruturas
{
    // Lista encadeada de matriculas - os nos sao ligados um ao outro pelo ponteiro Proximo
    public class ListaEncadeadaMatricula
    {
        private NOMatricula _cabeca;
        public NOMatricula Cabeca
        {
            get { return _cabeca; }
            set { _cabeca = value; }
        }

        private int _quantidade;
        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        public ListaEncadeadaMatricula()
        {
            _cabeca = null;
            _quantidade = 0;
        }

        public bool EstaVazia()
        {
            return _cabeca == null;
        }

        public void InserirFinal(Matricula dado)
        {
            NOMatricula novo = new NOMatricula(dado);

            if (_cabeca == null)
            {
                _cabeca = novo;
            }
            else
            {
                NOMatricula atual = _cabeca;
                while (atual.Proximo != null)
                {
                    atual = atual.Proximo;
                }
                atual.Proximo = novo;
            }

            _quantidade++;
        }
    }
}
