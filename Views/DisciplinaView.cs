using ProjetoAnkerN1.Estruturas;
using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Views
{
    public class DisciplinaView
    {
        public void ExibirDisciplinas(ListaEncadeadaDisciplina disciplinas)
        {
            Console.WriteLine("Consultando disciplinas...\n");
            NODisciplina no = disciplinas.Cabeca;
            while (no != null)
            {
                Disciplina d = no.Dado;
                Console.WriteLine("Codigo: " + d.Codigo);
                Console.WriteLine("Nome: " + d.Nome);
                Console.WriteLine("Nota Minima: " + d.NotaMinima + "\n");
                no = no.Proximo;
            }
        }

        public string EscolherDisciplinaView()
        {
            Console.WriteLine("Digite o codigo ou o nome da disciplina:");
            string input = Console.ReadLine().ToLower().Trim();
            input = input.Replace("á","a").Replace("ã","a").Replace("â","a")
                .Replace("é","e").Replace("ê","e").Replace("í","i")
                .Replace("ó","o").Replace("ô","o").Replace("õ","o")
                .Replace("ú","u").Replace("ç","c");

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Entrada invalida! Tente novamente!");
                return EscolherDisciplinaView();
            }
            return input;
        }

        // Exibe alunos de uma disciplina com notas, media e situacao
        public void ExibirAlunosNaDisciplina(ListaEncadeadaMatricula alunos, Disciplina disciplina)
        {
            Console.WriteLine("Alunos na disciplina de " + disciplina.Nome + ":\n");
            if (alunos.EstaVazia())
            {
                Console.WriteLine("Nenhum aluno matriculado nesta disciplina.\n");
                return;
            }
            NOMatricula no = alunos.Cabeca;
            while (no != null)
            {
                Matricula m = no.Dado;
                Console.WriteLine("Nome: " + m.NomeAluno);
                Console.WriteLine("Nota 1: " + m.Nota1);
                Console.WriteLine("Nota 2: " + m.Nota2);
                Console.WriteLine("Media: " + m.Media);
                Console.WriteLine("Situacao: " + m.Situacao + "\n");
                no = no.Proximo;
            }
        }

        public Disciplina CadastrarDisciplinaView()
        {
            Console.WriteLine("Digite o nome da disciplina:");
            string nome = Console.ReadLine().Trim();
            Console.WriteLine("Digite a nota minima:");
            int notaMinima = int.Parse(Console.ReadLine());
            Disciplina d = new Disciplina();
            d.Nome = nome;
            d.NotaMinima = notaMinima;
            return d;
        }
    }
}
