using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Estruturas
{
    // Classe que representa um no da lista encadeada de matriculas
    // Cada no guarda uma matricula e aponta para o proximo no da lista
    public class NOMatricula
    {
        private Matricula _dado;
        public Matricula Dado
        {
            get { return _dado; }
            set { _dado = value; }
        }

        private NOMatricula _proximo;
        public NOMatricula Proximo
        {
            get { return _proximo; }
            set { _proximo = value; }
        }

        public NOMatricula(Matricula dado)
        {
            _dado = dado;
            _proximo = null;
        }
    }
}
