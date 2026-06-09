using ProjetoAnkerN1.Estruturas;
using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Services;

namespace ProjetoAnkerN1.Controllers
{
    // Controla as operacoes com matriculas e notas
    public class MatriculaController
    {
        private MatriculaService matriculaService = new MatriculaService();
        public ListaEncadeadaMatricula lstMatriculas = new ListaEncadeadaMatricula();

        public MatriculaController()
        {
            lstMatriculas = matriculaService.CarregarMatriculas();
        }

        // Vincula aluno a disciplina com notas zeradas
        public void CadastrarMatricula(int alunoMatricula, int disciplinaId)
        {
            lstMatriculas.InserirFinal(new Matricula(alunoMatricula, disciplinaId, 0, 0));
            Console.WriteLine("Matricula cadastrada!");
        }

        // Atualiza as notas de uma matricula existente
        public void AtribuirNota(int alunoMatricula, int disciplinaId, int nota1, int nota2)
        {
            NOMatricula no = lstMatriculas.Cabeca;
            while (no != null)
            {
                Matricula m = no.Dado;
                if (m.AlunoMatricula == alunoMatricula && m.DisciplinaId == disciplinaId)
                {
                    m.Nota1 = nota1;
                    m.Nota2 = nota2;
                    Console.WriteLine("Notas atribuidas!");
                    return;
                }
                no = no.Proximo;
            }
            Console.WriteLine("Matricula nao encontrada!");
        }

        public void Salvar()
        {
            matriculaService.Salvar(lstMatriculas);
        }
    }
}
