using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Estruturas
{
    // Classe que representa um no da lista encadeada de disciplinas
    // Cada no guarda uma disciplina e aponta para o proximo no da lista
    public class NODisciplina
    {
        private Disciplina _dado;
        public Disciplina Dado
        {
            get { return _dado; }
            set { _dado = value; }
        }

        private NODisciplina _proximo;
        public NODisciplina Proximo
        {
            get { return _proximo; }
            set { _proximo = value; }
        }

        public NODisciplina(Disciplina dado)
        {
            _dado = dado;
            _proximo = null;
        }
    }
}
