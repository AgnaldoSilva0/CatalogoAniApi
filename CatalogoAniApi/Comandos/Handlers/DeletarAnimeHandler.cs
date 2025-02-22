using CatalogoAniApi.Comandos.Commands;
using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Modelo.Excecoes;
using CatalogoAniApi.Repositorio.Repositorios.Interfaces;
using MediatR;

namespace CatalogoAniApi.Comandos.Handlers
{
    public class DeletarAnimeHandler : IRequestHandler<DeletarAnimeCommand>
    {
        private readonly IRepositorio<Anime> _animeRepository;

        public DeletarAnimeHandler(IRepositorio<Anime> animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task Handle(DeletarAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = await _animeRepository.ObterPorIdAsync(request.Id);

            if (anime == null)
                throw new ValidacaoExcecao("Anime não encontrado");

            await _animeRepository.DeletarAsync(anime.Id);
        }
    }
}
