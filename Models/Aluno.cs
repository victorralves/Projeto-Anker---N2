namespace ProjetoAnkerN1.Models
{
    public class Aluno
    {
        public int Matricula { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }

        public Aluno() { }
        public Aluno(int matricula, string nome, int idade)
        {
            Matricula = matricula;
            Nome = nome;
            Idade = idade;
        }
    }
}
