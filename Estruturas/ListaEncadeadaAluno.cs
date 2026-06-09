using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Estruturas
{
    // Lista encadeada de alunos - os nos sao ligados um ao outro pelo ponteiro Proximo
    public class ListaEncadeadaAluno
    {
        private NOAluno _cabeca;
        public NOAluno Cabeca
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

        public ListaEncadeadaAluno()
        {
            _cabeca = null;
            _quantidade = 0;
        }

        public bool EstaVazia()
        {
            return _cabeca == null;
        }

        public void InserirFinal(Aluno dado)
        {
            NOAluno novo = new NOAluno(dado);

            if (_cabeca == null)
            {
                _cabeca = novo;
            }
            else
            {
                NOAluno atual = _cabeca;
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
