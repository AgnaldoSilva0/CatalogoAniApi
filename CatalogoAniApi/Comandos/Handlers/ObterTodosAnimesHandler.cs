using CatalogoAniApi.Comandos.Requests;
using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Repositorio.Repositorios.Interfaces;
using MediatR;

namespace CatalogoAniApi.Comandos.Handlers
{
    public class ObterTodosAnimesHandler : IRequestHandler<ObterTodosAnimesRequest, IEnumerable<Anime>>
    {
        private readonly IRepositorio<Anime> _repositorioAnime;

        public ObterTodosAnimesHandler(IRepositorio<Anime> repositorioAnime)
        {
            _repositorioAnime = repositorioAnime;
        }

        public async Task<IEnumerable<Anime>> Handle(ObterTodosAnimesRequest request, CancellationToken cancellationToken)
        {
            var animes = await _repositorioAnime.ObterTodosAsync();

            return animes;
        }
    }
}
