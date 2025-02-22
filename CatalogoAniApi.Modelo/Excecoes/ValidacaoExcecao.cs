namespace CatalogoAniApi.Modelo.Excecoes
{
    public class ValidacaoExcecao : Exception
    {
        public ValidacaoExcecao() { }

        public ValidacaoExcecao(string message)
            : base(message) { }

        public ValidacaoExcecao(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
