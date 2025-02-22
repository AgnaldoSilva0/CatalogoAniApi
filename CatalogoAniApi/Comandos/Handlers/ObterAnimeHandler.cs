using CatalogoAniApi.Comandos.Requests;
using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Repositorio.Repositorios.Interfaces;
using MediatR;

namespace CatalogoAniApi.Comandos.Handlers
{
    public class ObterAnimeHandler : IRequestHandler<ObterAnimeRequest, IEnumerable<Anime>>
    {
        private readonly IRepositorio<Anime> _repositorioAnime;

        public ObterAnimeHandler(IRepositorio<Anime> repositorioAnime)
        {
            _repositorioAnime = repositorioAnime;
        }

        public async Task<IEnumerable<Anime>> Handle(ObterAnimeRequest request, CancellationToken cancellationToken)
        {
            var animes = await _repositorioAnime.ObterTodosAsync() ?? Enumerable.Empty<Anime>();

            if (request.Id != default)
            {
                animes = animes.Where(a => a.Id == request.Id);
            }

            if (!string.IsNullOrWhiteSpace(request.Nome))
            {
                animes = animes.Where(a => a.Nome.Contains(request.Nome, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(request.Diretor))
            {
                animes = animes.Where(a => a.Diretor.Contains(request.Diretor, StringComparison.OrdinalIgnoreCase));
            }

            return animes;
        }
    }
}
