using CatalogoAniApi.Modelo.Entidades;
using MediatR;

namespace CatalogoAniApi.Comandos.Requisicoes
{
    public class ObterAnimeRequest : IRequest<Anime>
    {
        public int Id { get; set; }

        public ObterAnimeRequest(int id)
        {
            Id = id;
        }
    }
}
