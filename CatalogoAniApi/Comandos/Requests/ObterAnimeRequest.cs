using CatalogoAniApi.Modelo.Entidades;
using MediatR;

namespace CatalogoAniApi.Comandos.Requests
{
    public class ObterAnimeRequest : IRequest<IEnumerable<Anime>>
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Diretor { get; set; }

        public ObterAnimeRequest() { }

        public ObterAnimeRequest(int id, string nome, string diretor)
        {
            Id = id;
            Nome = nome;
            Diretor = diretor;
        }
    }
}
