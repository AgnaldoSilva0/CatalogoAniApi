using CatalogoAniApi.Comandos.Requisicoes;
using CatalogoAniApi.Modelo.Entidades;
using MediatR;

namespace CatalogoAniApi.Comandos.Handlers
{
    public class ObterAnimeHandler : IRequestHandler<ObterAnimeRequest, Anime>
    {
        public Task<Anime> Handle(ObterAnimeRequest request, CancellationToken cancellationToken)
        {
            var anime = new Anime
            {
                Id = 1,
                Nome = "Naruto",
                Diretor = "Masashi K"
            };

            return Task.FromResult(anime);
        }
    }
}
