namespace ProjetoAnkerN1.Models
{
    public class Matricula
    {
        public int AlunoMatricula { get; set; }
        public int DisciplinaId { get; set; }
        public int Nota1 { get; set; }
        public int Nota2 { get; set; }
        public double Media { get; set; }
        public string Situacao { get; set; } = string.Empty;
        public string NomeAluno { get; set; } = string.Empty;
        public string NomeDisciplina { get; set; } = string.Empty;

        public Matricula(int alunoMatricula, int disciplinaId, int nota1, int nota2)
        {
            AlunoMatricula = alunoMatricula;
            DisciplinaId = disciplinaId;
            Nota1 = nota1;
            Nota2 = nota2;
        }
    }
}
