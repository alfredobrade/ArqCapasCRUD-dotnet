using ProyectoCRUD.DAL.DataContext;
using ProyectoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRUD.DAL.Repository
{
    public class ContactoRepository : IGenericRepository<Contacto>
    {
        private readonly CeCrudArqcapasContext _dbcontext;

        public ContactoRepository(CeCrudArqcapasContext dbContext)
        {
            _dbcontext = dbContext;
        }
       

        public async Task<bool> Delete(int id)
        {
            Contacto model = _dbcontext.Contactos.First(p => p.IdContacto == id);
            _dbcontext.Contactos.Remove(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Contacto> Get(int id)
        {
            return await _dbcontext.Contactos.FindAsync(id);
        }

        public async Task<IQueryable<Contacto>> GetAll()
        {
            IQueryable<Contacto> queryContactoSQL = _dbcontext.Contactos;
            return queryContactoSQL;
        }

        public async Task<bool> Insert(Contacto model)
        {
            _dbcontext.Contactos.Add(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Contacto model)
        {
            _dbcontext.Contactos.Update(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
