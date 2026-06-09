using ProjetoAnkerN1.Estruturas;
using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Services
{
    // Le e grava o arquivo Matriculas.dat
    public class MatriculaService
    {
        private string caminhoArquivo = Path.Combine("Data", "Matriculas.dat");

        public ListaEncadeadaMatricula CarregarMatriculas()
        {
            ListaEncadeadaMatricula lista = new ListaEncadeadaMatricula();

            if (!File.Exists(caminhoArquivo))
                return lista;

            StreamReader leitor = new StreamReader(caminhoArquivo);
            while (!leitor.EndOfStream)
            {
                string linha = leitor.ReadLine();
                if (string.IsNullOrWhiteSpace(linha)) continue;

                string[] dados = linha.Split(';');
                lista.InserirFinal(new Matricula(int.Parse(dados[0]), int.Parse(dados[1]), int.Parse(dados[2]), int.Parse(dados[3])));
            }
            leitor.Close();

            return lista;
        }

        public void Salvar(ListaEncadeadaMatricula matriculas)
        {
            StreamWriter gravador = new StreamWriter(caminhoArquivo);
            NOMatricula no = matriculas.Cabeca;
            while (no != null)
            {
                Matricula m = no.Dado;
                gravador.WriteLine(m.AlunoMatricula + ";" + m.DisciplinaId + ";" + m.Nota1 + ";" + m.Nota2);
                no = no.Proximo;
            }
            gravador.Close();
        }
    }
}
