using CatalogoAniApi.Comandos.Commands;
using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Modelo.Enumeradores;
using CatalogoAniApi.RegraNegocio.Interfaces;
using CatalogoAniApi.Repositorio.Repositorios.Interfaces;
using MediatR;

namespace CatalogoAniApi.Comandos.Handlers
{
    public class AtualizarAnimeHandler : IRequestHandler<AtualizarAnimeCommand, Anime>
    {
        private readonly IRepositorio<Anime> _animeRepositorio;
        private readonly IValidarAnime _validarAnime;

        public AtualizarAnimeHandler(IRepositorio<Anime> animeRepositorio, IValidarAnime validarAnime)
        {
            _animeRepositorio = animeRepositorio;
            _validarAnime = validarAnime;
        }

        public async Task<Anime> Handle(AtualizarAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = await _animeRepositorio.ObterPorIdAsync(request.Id);

            if (anime == null)
                throw new NullReferenceException("Anime não encontrado");

            anime.Nome = request.Nome;
            anime.Diretor = request.Diretor;
            anime.Resumo = request.Resumo;

            _validarAnime.Validar(TipoOperacao.Atualizar, anime);

            await _animeRepositorio.AtualizarAsync(anime);

            return anime;
        }
    }
}
