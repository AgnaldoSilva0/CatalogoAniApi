using CatalogoAniApi.Modelo.Entidades;
using MediatR;

namespace CatalogoAniApi.Comandos.Requests
{
    public class ObterTodosAnimesRequest : IRequest<IEnumerable<Anime>>
    {
        
    }
}
