using CatalogoAniApi.Comandos.Commands;
using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Modelo.Enumeradores;
using CatalogoAniApi.RegraNegocio.Interfaces;
using CatalogoAniApi.Repositorio.Repositorios.Interfaces;
using MediatR;

namespace CatalogoAniApi.Comandos.Handlers
{
    public class CadastrarAnimeHandler : IRequestHandler<CadastrarAnimeCommand, Anime>
    {
        private readonly IRepositorio<Anime> _animeRepositorio;
        private readonly IValidarAnime _validarAnime;

        public CadastrarAnimeHandler(IRepositorio<Anime> animeRepositorio, IValidarAnime validarAnime)
        {
            _animeRepositorio = animeRepositorio;
            _validarAnime = validarAnime;
        }

        public async Task<Anime> Handle(CadastrarAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = ObterAnime(request);

            _validarAnime.Validar(TipoOperacao.Adicionar, anime);

            await _animeRepositorio.AdicionarAsync(anime);

            return anime;
        }

        private Anime ObterAnime(CadastrarAnimeCommand request)
        {
            var anime = new Anime
            {
                Nome = request.Nome,
                Diretor = request.Diretor,
                Resumo = request.Resumo
            };

            return anime;
        }
    }
}
