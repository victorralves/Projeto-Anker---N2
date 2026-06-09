namespace ProjetoAnkerN1.Models
{
    public class Disciplina
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int NotaMinima { get; set; }

        public Disciplina() { }
        public Disciplina(int codigo, string nome, int notaMinima)
        {
            Codigo = codigo;
            Nome = nome;
            NotaMinima = notaMinima;
        }
    }
}
