using CatalogoAniApi.Modelo.Entidades;
using CatalogoAniApi.Modelo.Enumeradores;

namespace CatalogoAniApi.TesteUnitario.RegraNegocio.Validadores.DadosParaTeste
{
    public static class ValidarAnimeDadosParaTeste
    {
        public static IEnumerable<object[]> ObterOperacaoEAnimeComNomeInvalido
        {
            get
            {
                yield return new object[] { TipoOperacao.Adicionar, new Anime { Nome = string.Empty} };
                yield return new object[] { TipoOperacao.Adicionar, new Anime { Nome = null } };
                yield return new object[] { TipoOperacao.Atualizar, new Anime { Nome = string.Empty } };
                yield return new object[] { TipoOperacao.Atualizar, new Anime { Nome = null } };
            }
        }

        public static IEnumerable<object[]> ObterOperacaoEAnimeComQuantidadeDeCaracteresInsuficiente
        {
            get
            {
                yield return new object[] { TipoOperacao.Adicionar, new Anime { Nome = "A" } };
                yield return new object[] { TipoOperacao.Atualizar, new Anime { Nome = "A" } };
            }
        }

        public static IEnumerable<object[]> ObterOperacaoEAnimeComDiretorInvalido
        {
            get
            {
                yield return new object[] { TipoOperacao.Adicionar, new Anime { Nome = "Teste", Diretor = string.Empty } };
                yield return new object[] { TipoOperacao.Adicionar, new Anime { Nome = "Teste", Diretor = null } };
                yield return new object[] { TipoOperacao.Atualizar, new Anime { Nome = "Teste", Diretor = string.Empty } };
                yield return new object[] { TipoOperacao.Atualizar, new Anime { Nome = "Teste", Diretor = null } };
            }
        }

        public static IEnumerable<object[]> ObterOperacaoEAnimeComResumoInvalido
        {
            get
            {
                yield return new object[] { TipoOperacao.Adicionar, new Anime { Nome = "Teste", Diretor = "Diretor", Resumo = string.Empty } };
                yield return new object[] { TipoOperacao.Adicionar, new Anime { Nome = "Teste", Diretor = "Diretor", Resumo = null } };
                yield return new object[] { TipoOperacao.Atualizar, new Anime { Nome = "Teste", Diretor = "Diretor", Resumo = string.Empty } };
                yield return new object[] { TipoOperacao.Atualizar, new Anime { Nome = "Teste", Diretor = "Diretor", Resumo = null } };
            }
        }

        public static IEnumerable<object[]> ObterOperacaoEAnimeComResumoComQuantidadeDeCaracteresInvalido
        {
            get
            {
                yield return new object[] { TipoOperacao.Adicionar, new Anime { Nome = "Teste", Diretor = "Diretor", Resumo = "123456789" } };
                yield return new object[] { TipoOperacao.Atualizar, new Anime { Nome = "Teste", Diretor = "Diretor", Resumo = "123456789" } };
            }
        }
    }
}
