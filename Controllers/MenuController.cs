using ProjetoAnkerN1.Estruturas;
using ProjetoAnkerN1.Views;
using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Controllers
{
    // Controla o menu principal e submenus
    public class MenuController
    {
        private MenuView menuView = new MenuView();
        private AlunoController alunoController = new AlunoController();
        private DisciplinaController disciplinaController = new DisciplinaController();
        private MatriculaController matriculaController = new MatriculaController();
        private AlunoView alunoView = new AlunoView();
        private DisciplinaView disciplinaView = new DisciplinaView();
        private MatriculaView matriculaView = new MatriculaView();

        public void MenuPrincipal()
        {
            bool sair = true;
            while (sair)
            {
                int opcao = menuView.ExibirMenu();
                switch (opcao)
                {
                    case 1: Console.Clear(); SubMenuConsultar(); break;
                    case 2: Console.Clear(); SubMenuCadastros(); break;
                    case 3: Salvar(); Console.WriteLine("Dados salvos!"); break;
                    case 4:
                        Console.WriteLine("Tem certeza que deseja sair? (S/N)");
                        if (Console.ReadLine().Trim().ToUpper() == "S")
                        {
                            Salvar();
                            sair = false;
                        }
                        break;
                }
            }
        }

        public void SubMenuConsultar()
        {
            bool voltar = true;
            while (voltar)
            {
                int opcao = menuView.ExibirSubMenuConsultar();
                switch (opcao)
                {
                    case 1: Console.Clear(); alunoView.ExibirAlunos(alunoController.lstAlunos); break;
                    case 2: Console.Clear(); disciplinaView.ExibirDisciplinas(disciplinaController.lstDisciplinas); break;
                    case 3:
                        Console.Clear();
                        Disciplina d = disciplinaController.BuscarDisciplina();
                        disciplinaView.ExibirAlunosNaDisciplina(BuscarAlunosNaDisciplina(d), d);
                        break;
                    case 4:
                        Console.Clear();
                        Aluno a = alunoController.BuscarAluno();
                        alunoView.ExibirDisciplinasDoAluno(BuscarDisciplinasDoAluno(a), a);
                        break;
                    case 0: voltar = false; break;
                }
            }
        }

        public void SubMenuCadastros()
        {
            bool voltar = true;
            while (voltar)
            {
                int opcao = menuView.ExibirSubMenuCadastros();
                switch (opcao)
                {
                    case 1: Console.Clear(); alunoController.CadastrarAluno(alunoView.CadastrarAlunoView()); break;
                    case 2: Console.Clear(); disciplinaController.CadastrarDisciplina(disciplinaView.CadastrarDisciplinaView()); break;
                    case 3:
                        Console.Clear();
                        Aluno aM = alunoController.BuscarAluno();
                        Disciplina dM = disciplinaController.BuscarDisciplina();
                        matriculaController.CadastrarMatricula(aM.Matricula, dM.Codigo);
                        break;
                    case 4:
                        Console.Clear();
                        Aluno aN = alunoController.BuscarAluno();
                        Disciplina dN = disciplinaController.BuscarDisciplina();
                        matriculaView.AtribuirNotaView(out int n1, out int n2);
                        matriculaController.AtribuirNota(aN.Matricula, dN.Codigo, n1, n2);
                        break;
                    case 0: voltar = false; break;
                }
            }
        }

        // Busca todos os alunos matriculados em uma disciplina
        private ListaEncadeadaMatricula BuscarAlunosNaDisciplina(Disciplina disciplina)
        {
            ListaEncadeadaMatricula resultado = new ListaEncadeadaMatricula();

            NOMatricula nm = matriculaController.lstMatriculas.Cabeca;
            while (nm != null)
            {
                Matricula m = nm.Dado;
                if (m.DisciplinaId == disciplina.Codigo)
                {
                    NOAluno na = alunoController.lstAlunos.Cabeca;
                    while (na != null)
                    {
                        Aluno a = na.Dado;
                        if (a.Matricula == m.AlunoMatricula)
                        {
                            m.NomeAluno = a.Nome;
                            m.Media = (m.Nota1 + m.Nota2) / 2.0;
                            m.Situacao = m.Media >= disciplina.NotaMinima ? "Aprovado" : "Reprovado";
                            resultado.InserirFinal(m);
                            break;
                        }
                        na = na.Proximo;
                    }
                }
                nm = nm.Proximo;
            }

            return resultado;
        }

        // Busca todas as disciplinas em que um aluno esta matriculado
        private ListaEncadeadaMatricula BuscarDisciplinasDoAluno(Aluno aluno)
        {
            ListaEncadeadaMatricula resultado = new ListaEncadeadaMatricula();

            NOMatricula nm = matriculaController.lstMatriculas.Cabeca;
            while (nm != null)
            {
                Matricula m = nm.Dado;
                if (m.AlunoMatricula == aluno.Matricula)
                {
                    NODisciplina nd = disciplinaController.lstDisciplinas.Cabeca;
                    while (nd != null)
                    {
                        Disciplina d = nd.Dado;
                        if (d.Codigo == m.DisciplinaId)
                        {
                            m.NomeDisciplina = d.Nome;
                            m.Media = (m.Nota1 + m.Nota2) / 2.0;
                            m.Situacao = m.Media >= d.NotaMinima ? "Aprovado" : "Reprovado";
                            resultado.InserirFinal(m);
                            break;
                        }
                        nd = nd.Proximo;
                    }
                }
                nm = nm.Proximo;
            }

            return resultado;
        }

        public void Salvar()
        {
            alunoController.Salvar();
            disciplinaController.Salvar();
            matriculaController.Salvar();
        }
    }
}
