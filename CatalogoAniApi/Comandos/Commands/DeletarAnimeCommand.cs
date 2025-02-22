using MediatR;

namespace CatalogoAniApi.Comandos.Commands
{
    public class DeletarAnimeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
