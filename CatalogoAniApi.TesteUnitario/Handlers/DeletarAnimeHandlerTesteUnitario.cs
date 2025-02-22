using CatalogoAniApi.Comandos.Commands;
using CatalogoAniApi.Comandos.Handlers;
using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Modelo.Excecoes;
using CatalogoAniApi.RegraNegocio.Interfaces;
using CatalogoAniApi.Repositorio.Repositorios.Interfaces;
using CatalogoAniApi.TesteUnitario.Builders;
using Moq;

namespace CatalogoAniApi.TesteUnitario.Handlers
{
    public class DeletarAnimeHandlerTesteUnitario
    {
        private readonly AnimeBuilder _animeBuilder;

        private readonly Mock<IRepositorio<Anime>> _repositorioAnimeMock;

        private readonly DeletarAnimeHandler _deletarAnimeHandler;

        public DeletarAnimeHandlerTesteUnitario()
        {
            _animeBuilder = new AnimeBuilder();

            _repositorioAnimeMock = new Mock<IRepositorio<Anime>>();

            _deletarAnimeHandler = new DeletarAnimeHandler(_repositorioAnimeMock.Object);
        }

        [Fact(DisplayName = "Quando tentar deletar um anime válido, deve chamar o método de exclusão do repositório")]
        public async void QuandoTentarDeletarUmAnimeValidoDeveChamarOMetodoDeExclusaoDoRepositorio()
        {
            // Arrange
            var anime = new AnimeBuilder().ComId(1).ComNome("Anime Teste").Build();
            _repositorioAnimeMock.Setup(x => x.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(anime);

            // Act
            await _deletarAnimeHandler.Handle(new DeletarAnimeCommand(), new CancellationToken());

            // Assert
            _repositorioAnimeMock.Verify(x => x.DeletarAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact(DisplayName = "Não deve ser válida a exclusão de um anime caso ele não exista")]
        public async void NaoDeveSerValidaAExclusaoDeUmAnimeCasoEleNaoExista()
        {
            // Arrange
            var mensagemDeExcecaoEsperada = "Anime não encontrado";

            // Act
            var excecaoLancada = await Assert.ThrowsAsync<ValidacaoExcecao>(async () =>
            {
                await _deletarAnimeHandler.Handle(new DeletarAnimeCommand(), new CancellationToken());
            });

            // Assert
            Assert.Contains(mensagemDeExcecaoEsperada, excecaoLancada.Message);
        }
    }
}
