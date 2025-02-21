using CatalogoAniApi.Comandos.Commands;
using CatalogoAniApi.Modelo.Entidades;
using MediatR;

namespace CatalogoAniApi.Comandos.Handlers
{
    public class CadastrarAnimeHandler : IRequestHandler<CadastrarAnimeCommand, Anime>
    {
        public Task<Anime> Handle(CadastrarAnimeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
