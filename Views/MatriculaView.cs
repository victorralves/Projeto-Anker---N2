namespace ProjetoAnkerN1.Views
{
    public class MatriculaView
    {
        public void AtribuirNotaView(out int nota1, out int nota2)
        {
            Console.WriteLine("Digite a Nota 1:");
            nota1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Nota 2:");
            nota2 = int.Parse(Console.ReadLine());
        }
    }
}
