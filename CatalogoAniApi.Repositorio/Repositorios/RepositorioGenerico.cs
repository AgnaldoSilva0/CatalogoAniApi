﻿using CatalogoAniApi.Repositorio.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CatalogoAniApi.Repositorio.Repositorios
{
    public class RepositorioGenerico<T> : IRepositorio<T> where T : class
    {
        private readonly Contexto _context;
        private readonly DbSet<T> _dbSet;

        public RepositorioGenerico(Contexto context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AdicionarAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AtualizarAsync(T entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> BuscarTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<IEnumerable<T>> ObterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> ObterPorIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
