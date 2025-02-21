using CatalogoAniApi.Comandos.Requests;
using CatalogoAniApi.Modelo.Entidades;
using MediatR;

namespace CatalogoAniApi.Comandos.Handlers
{
    public class ObterAnimeHandler : IRequestHandler<ObterAnimeRequest, IEnumerable<Anime>>
    {
        Task<IEnumerable<Anime>> IRequestHandler<ObterAnimeRequest, IEnumerable<Anime>>.Handle(ObterAnimeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
