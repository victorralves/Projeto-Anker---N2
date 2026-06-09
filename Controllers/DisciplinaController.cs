using ProjetoAnkerN1.Estruturas;
using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Services;
using ProjetoAnkerN1.Views;

namespace ProjetoAnkerN1.Controllers
{
    // Controla as operacoes com disciplinas
    public class DisciplinaController
    {
        private DisciplinaService disciplinaService = new DisciplinaService();
        public ListaEncadeadaDisciplina lstDisciplinas = new ListaEncadeadaDisciplina();

        public DisciplinaController()
        {
            lstDisciplinas = disciplinaService.CarregarDisciplinas();
        }

        // Busca disciplina por codigo ou nome
        public Disciplina BuscarDisciplina()
        {
            DisciplinaView disciplinaView = new DisciplinaView();
            string input = disciplinaView.EscolherDisciplinaView();

            NODisciplina no = lstDisciplinas.Cabeca;
            while (no != null)
            {
                Disciplina d = no.Dado;
                if (int.TryParse(input, out int codigo))
                {
                    if (d.Codigo == codigo) return d;
                }
                else
                {
                    if (NormalizarNome(d.Nome) == input) return d;
                }
                no = no.Proximo;
            }

            Console.WriteLine("Disciplina nao encontrada. Tente novamente!");
            return BuscarDisciplina();
        }

        // Cadastra disciplina com codigo gerado automaticamente
        public void CadastrarDisciplina(Disciplina disciplina)
        {
            disciplina.Codigo = GerarCodigo();
            lstDisciplinas.InserirFinal(disciplina);
            Console.WriteLine("Disciplina cadastrada com codigo " + disciplina.Codigo + "!");
        }

        public int GerarCodigo()
        {
            int maior = 0;
            NODisciplina no = lstDisciplinas.Cabeca;
            while (no != null)
            {
                if (no.Dado.Codigo > maior)
                    maior = no.Dado.Codigo;
                no = no.Proximo;
            }
            return maior + 1;
        }

        public void Salvar()
        {
            disciplinaService.Salvar(lstDisciplinas);
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
