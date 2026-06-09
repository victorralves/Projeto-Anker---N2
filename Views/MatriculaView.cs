namespace ProjetoAnkerN1.Views
{
    public class MatriculaView
    {
        public void AtribuirNotaView(out int nota1, out int nota2)
        {
            nota1 = LerNota("Digite a Nota 1:");
            nota2 = LerNota("Digite a Nota 2:");
        }

        private int LerNota(string mensagem)
        {
            Console.WriteLine(mensagem);
            if (!int.TryParse(Console.ReadLine(), out int nota) || nota < 0 || nota > 10)
            {
                Console.WriteLine("Nota invalida! Digite um valor entre 0 e 10.");
                return LerNota(mensagem);
            }
            return nota;
        }
    }
}
