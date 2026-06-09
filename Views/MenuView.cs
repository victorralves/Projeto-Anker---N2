namespace ProjetoAnkerN1.Views
{
    public class MenuView
    {
        public int ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("==== MENU PRINCIPAL ====");
            Console.WriteLine("1 - Consultar");
            Console.WriteLine("2 - Cadastros");
            Console.WriteLine("3 - Salvar");
            Console.WriteLine("4 - Sair");
            if (int.TryParse(Console.ReadLine(), out int opcao)) return opcao;
            return 0;
        }

        public int ExibirSubMenuConsultar()
        {
            Console.WriteLine("==== CONSULTAR ====");
            Console.WriteLine("1 - Alunos");
            Console.WriteLine("2 - Disciplinas");
            Console.WriteLine("3 - Alunos da Disciplina");
            Console.WriteLine("4 - Disciplinas do Aluno");
            Console.WriteLine("0 - Voltar");
            if (int.TryParse(Console.ReadLine(), out int opcao)) return opcao;
            return 0;
        }

        public int ExibirSubMenuCadastros()
        {
            Console.WriteLine("==== CADASTROS ====");
            Console.WriteLine("1 - Alunos");
            Console.WriteLine("2 - Disciplinas");
            Console.WriteLine("3 - Matriculas");
            Console.WriteLine("4 - Atribuir Nota");
            Console.WriteLine("0 - Voltar");
            if (int.TryParse(Console.ReadLine(), out int opcao)) return opcao;
            return 0;
        }
    }
}
