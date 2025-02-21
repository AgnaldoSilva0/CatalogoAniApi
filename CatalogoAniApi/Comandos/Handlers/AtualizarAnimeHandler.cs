using CatalogoAniApi.Comandos.Commands;
using CatalogoAniApi.Modelo.Entidades;
using MediatR;

namespace CatalogoAniApi.Comandos.Handlers
{
    public class AtualizarAnimeHandler : IRequestHandler<AtualizarAnimeCommand, Anime>
    {
        public Task<Anime> Handle(AtualizarAnimeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
