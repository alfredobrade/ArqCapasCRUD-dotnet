using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoCRUD.DAL.DataContext;
using ProyectoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRUD.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _dbcontext;
        protected DbSet<T> _dbSet;
        public GenericRepository(DbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public DbSet<T> DbSet { get
            {
                if(_dbSet is null)
                {
                    _dbSet = _dbcontext.Set<T>();
                }
                return _dbSet;

            }
        }



        public async Task<bool> Delete(int id)
        {
            T model = DbSet.First(p => p.Id == id);
            _dbSet.Remove(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<T> Get(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> queryContactoSQL = DbSet.AsQueryable();
            return queryContactoSQL;
        }

        public async Task<bool> Insert(T model)
        {
            DbSet.Add(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(T model)
        {
            DbSet.Update(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
