using ProjetoAnkerN1.Estruturas;
using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Services
{
    // Le e grava o arquivo Disciplinas.dat
    public class DisciplinaService
    {
        private string caminhoArquivo = Path.Combine("Data", "Disciplinas.dat");

        public ListaEncadeadaDisciplina CarregarDisciplinas()
        {
            ListaEncadeadaDisciplina lista = new ListaEncadeadaDisciplina();

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
                lista.InserirFinal(new Disciplina(int.Parse(dados[0]), dados[1], int.Parse(dados[2])));
            }
            leitor.Close();

            return lista;
        }

        public void Salvar(ListaEncadeadaDisciplina disciplinas)
        {
            StreamWriter gravador = new StreamWriter(caminhoArquivo);
            NODisciplina no = disciplinas.Cabeca;
            while (no != null)
            {
                Disciplina d = no.Dado;
                gravador.WriteLine(d.Codigo + ";" + d.Nome + ";" + d.NotaMinima);
                no = no.Proximo;
            }
            gravador.Close();
        }
    }
}
