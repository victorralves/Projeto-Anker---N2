using ProjetoAnkerN1.Estruturas;
using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Services;
using ProjetoAnkerN1.Views;

namespace ProjetoAnkerN1.Controllers
{
    // Controla as operacoes com alunos
    public class AlunoController
    {
        private AlunoService alunoService = new AlunoService();
        public ListaEncadeadaAluno lstAlunos = new ListaEncadeadaAluno();

        public AlunoController()
        {
            lstAlunos = alunoService.CarregarAlunos();
        }

        // Busca aluno por matricula ou nome
        public Aluno BuscarAluno()
        {
            AlunoView alunoView = new AlunoView();
            string input = alunoView.EscolherAlunoView();

            NOAluno no = lstAlunos.Cabeca;
            while (no != null)
            {
                Aluno a = no.Dado;
                if (int.TryParse(input, out int matricula))
                {
                    if (a.Matricula == matricula) return a;
                }
                else
                {
                    if (NormalizarNome(a.Nome) == input) return a;
                }
                no = no.Proximo;
            }

            Console.WriteLine("Aluno nao encontrado. Tente novamente!");
            return BuscarAluno();
        }

        // Cadastra aluno com matricula gerada automaticamente
        public void CadastrarAluno(Aluno aluno)
        {
            aluno.Matricula = GerarMatricula();
            lstAlunos.InserirFinal(aluno);
            Console.WriteLine("Aluno cadastrado com matricula " + aluno.Matricula + "!");
        }

        // Gera matricula unica: maior existente + 1
        public int GerarMatricula()
        {
            int maior = 0;
            NOAluno no = lstAlunos.Cabeca;
            while (no != null)
            {
                if (no.Dado.Matricula > maior)
                    maior = no.Dado.Matricula;
                no = no.Proximo;
            }
            return maior + 1;
        }

        public void Salvar()
        {
            alunoService.Salvar(lstAlunos);
        }

        private string NormalizarNome(string nome)
        {
            return nome.ToLower()
                .Replace("á","a").Replace("ã","a").Replace("â","a")
                .Replace("é","e").Replace("ê","e").Replace("í","i")
                .Replace("ó","o").Replace("ô","o").Replace("õ","o")
                .Replace("ú","u").Replace("ç","c");
        }
    }
}
