using ProjetoAnkerN1.Estruturas;
using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Views
{
    public class AlunoView
    {
        public void ExibirAlunos(ListaEncadeadaAluno alunos)
        {
            Console.WriteLine("Consultando alunos...\n");
            NOAluno no = alunos.Cabeca;
            while (no != null)
            {
                Aluno a = no.Dado;
                Console.WriteLine("Matricula: " + a.Matricula);
                Console.WriteLine("Nome: " + a.Nome);
                Console.WriteLine("Idade: " + a.Idade + "\n");
                no = no.Proximo;
            }
        }

        public string EscolherAlunoView()
        {
            Console.WriteLine("Digite a matricula ou o nome do aluno:");
            string input = Console.ReadLine().ToLower().Trim();
            input = input.Replace("á","a").Replace("ã","a").Replace("â","a")
                .Replace("é","e").Replace("ê","e").Replace("í","i")
                .Replace("ó","o").Replace("ô","o").Replace("õ","o")
                .Replace("ú","u").Replace("ç","c");

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Entrada invalida! Tente novamente!");
                return EscolherAlunoView();
            }
            return input;
        }

        // Exibe disciplinas do aluno com notas, media e situacao
        public void ExibirDisciplinasDoAluno(ListaEncadeadaMatricula disciplinas, Aluno aluno)
        {
            Console.WriteLine("Disciplinas do aluno " + aluno.Nome + ":\n");
            if (disciplinas.EstaVazia())
            {
                Console.WriteLine("Nenhuma disciplina matriculada.\n");
                return;
            }
            NOMatricula no = disciplinas.Cabeca;
            while (no != null)
            {
                Matricula m = no.Dado;
                Console.WriteLine("Disciplina: " + m.NomeDisciplina);
                Console.WriteLine("Nota 1: " + m.Nota1);
                Console.WriteLine("Nota 2: " + m.Nota2);
                Console.WriteLine("Media: " + m.Media);
                Console.WriteLine("Situacao: " + m.Situacao + "\n");
                no = no.Proximo;
            }
        }

        public Aluno CadastrarAlunoView()
        {
            Console.WriteLine("Digite o nome do aluno:");
            string nome = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome invalido! Tente novamente!");
                return CadastrarAlunoView();
            }
            Console.WriteLine("Digite a idade do aluno:");
            int idade = int.Parse(Console.ReadLine());
            Aluno aluno = new Aluno();
            aluno.Nome = nome;
            aluno.Idade = idade;
            return aluno;
        }
    }
}
