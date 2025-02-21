using System.Linq.Expressions;

namespace CatalogoAniApi.Repositorio.Repositorios.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<IEnumerable<T>> BuscarTodosAsync();
        Task<T> ObterPorIdAsync(int id);
        Task<IEnumerable<T>> ObterAsync(Expression<Func<T, bool>> predicate);
        Task AdicionarAsync(T entity);
        Task AtualizarAsync(T entity);
        Task DeletarAsync(int id);
    }
}
