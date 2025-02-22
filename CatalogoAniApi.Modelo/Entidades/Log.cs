namespace CatalogoAniApi.Modelo.Entidades
{
    public class Log
    {
        public int Id { get; set; }
        public string? Menssagem { get; set; }
        public string? Excecao { get; set; }
        public string? MensagemExcecao { get; set; }
        public DateTime DataDeLancamento { get; set; }
    }
}
