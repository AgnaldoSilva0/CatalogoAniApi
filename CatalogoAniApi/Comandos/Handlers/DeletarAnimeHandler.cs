using CatalogoAniApi.Comandos.Commands;
using MediatR;

namespace CatalogoAniApi.Comandos.Handlers
{
    public class DeletarAnimeHandler : IRequestHandler<DeletarAnimeCommand>
    {
        public Task Handle(DeletarAnimeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
