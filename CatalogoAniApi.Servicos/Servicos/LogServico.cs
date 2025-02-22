using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Repositorio.Repositorios.Interfaces;
using CatalogoAniApi.Servicos.Interfaces;

namespace CatalogoAniApi.Servico.Servicos
{
    public class LogServico : ILogServico
    {
        private readonly IRepositorio<Log> _repositorioLog;

        public LogServico(IRepositorio<Log> repositorioLog)
        {
            _repositorioLog = repositorioLog;
        }

        public async Task RegistrarLogAsync(string menssagem, Exception? Excecao = null)
        {
            var log = ObterLog(menssagem, Excecao);

            await _repositorioLog.AdicionarAsync(log);
        }

        private Log ObterLog(string menssagem, Exception? exception = null)
        {
            var log = new Log
            {
                Menssagem = menssagem,
                Excecao = exception?.ToString(),
                MensagemExcecao = exception?.Message,
                DataDeLancamento = DateTime.UtcNow
            };

            return log;
        }
    }
}
