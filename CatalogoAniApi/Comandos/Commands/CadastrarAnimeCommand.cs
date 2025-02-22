using CatalogoAniApi.Modelo.Entidades;
using MediatR;

namespace CatalogoAniApi.Comandos.Commands
{
    public class CadastrarAnimeCommand : IRequest<Anime>
    {
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public string Resumo { get; set; }
    }
}
