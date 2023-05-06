using ProyectoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRUD.BLL.Services
{
    public interface IContactoService
    {
        Task<bool> Insert(Contacto model);
        Task<bool> Update(Contacto model);
        //Task<bool> Delete(Contacto model);
        Task<bool> Delete(int id);
        Task<Contacto> Get(int id);
        Task<IQueryable<Contacto>> GetAll(); //usamos IQuerable porque usamos recursos de base de datos


        Task<Contacto> GetByName(string name);

    }
}
