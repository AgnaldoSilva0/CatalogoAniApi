namespace CatalogoAniApi.Servicos.Interfaces
{
    public interface ILogServico
    {
        Task RegistrarLogAsync(string message, Exception? exception = null);
    }
}
