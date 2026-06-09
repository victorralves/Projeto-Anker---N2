using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Estruturas
{
    // Classe que representa um no da lista encadeada de alunos
    // Cada no guarda um aluno e aponta para o proximo no da lista
    public class NOAluno
    {
        private Aluno _dado;
        public Aluno Dado
        {
            get { return _dado; }
            set { _dado = value; }
        }

        private NOAluno _proximo;
        public NOAluno Proximo
        {
            get { return _proximo; }
            set { _proximo = value; }
        }

        public NOAluno(Aluno dado)
        {
            _dado = dado;
            _proximo = null;
        }
    }
}
