using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Estruturas
{
    // Lista encadeada de disciplinas - os nos sao ligados um ao outro pelo ponteiro Proximo
    public class ListaEncadeadaDisciplina
    {
        private NODisciplina _cabeca;
        public NODisciplina Cabeca
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

        public ListaEncadeadaDisciplina()
        {
            _cabeca = null;
            _quantidade = 0;
        }

        public bool EstaVazia()
        {
            return _cabeca == null;
        }

        public void InserirFinal(Disciplina dado)
        {
            NODisciplina novo = new NODisciplina(dado);

            if (_cabeca == null)
            {
                _cabeca = novo;
            }
            else
            {
                NODisciplina atual = _cabeca;
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
