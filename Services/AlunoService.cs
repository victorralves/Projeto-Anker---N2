using ProjetoAnkerN1.Estruturas;
using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Services
{
    // Le e grava o arquivo Alunos.dat
    public class AlunoService
    {
        private string caminhoArquivo = Path.Combine("Data", "Alunos.dat");

        public ListaEncadeadaAluno CarregarAlunos()
        {
            ListaEncadeadaAluno lista = new ListaEncadeadaAluno();

            if (!File.Exists(caminhoArquivo))
            {
                return lista;
            }

            StreamReader leitor = new StreamReader(caminhoArquivo);
            while (!leitor.EndOfStream)
            {
                string linha = leitor.ReadLine();
                if (string.IsNullOrWhiteSpace(linha)) continue;

                string[] dados = linha.Split(';');
                lista.InserirFinal(new Aluno(int.Parse(dados[0]), dados[1], int.Parse(dados[2])));
            }
            leitor.Close();

            return lista;
        }

        public void Salvar(ListaEncadeadaAluno alunos)
        {
            StreamWriter gravador = new StreamWriter(caminhoArquivo);
            NOAluno no = alunos.Cabeca;
            while (no != null)
            {
                Aluno a = no.Dado;
                gravador.WriteLine(a.Matricula + ";" + a.Nome + ";" + a.Idade);
                no = no.Proximo;
            }
            gravador.Close();
        }
    }
}
