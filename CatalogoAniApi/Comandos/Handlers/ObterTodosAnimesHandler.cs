using CatalogoAniApi.Comandos.Requests;
using CatalogoAniApi.Modelo.Entidades;
using MediatR;

namespace CatalogoAniApi.Comandos.Handlers
{
    public class ObterTodosAnimesHandler : IRequestHandler<ObterTodosAnimesRequest, IEnumerable<Anime>>
    {
        public Task<IEnumerable<Anime>> Handle(ObterTodosAnimesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
