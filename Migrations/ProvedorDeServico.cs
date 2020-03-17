namespace Migrations
{
    public interface IProvedorDeServico
    {
        string BancoDeDados { get; }
    }

    public class ProvedorDeServico : IProvedorDeServico
    {
        public string BancoDeDados { get; set; }

    }
}
