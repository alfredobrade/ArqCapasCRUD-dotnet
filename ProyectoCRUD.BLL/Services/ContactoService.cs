﻿using Microsoft.EntityFrameworkCore;
using ProyectoCRUD.DAL.Repository;
using ProyectoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRUD.BLL.Services
{
    public class ContactoService : IContactoService
    {
        private readonly IGenericRepository<Contacto> _contactRepo;


        public ContactoService(IGenericRepository<Contacto> contactRepo)
        {
            _contactRepo = contactRepo;   
        }
        public async Task<bool> Delete(int id)
        {
            return await _contactRepo.Delete(id); 
        }

        public async Task<Contacto> Get(int id)
        {
            return await _contactRepo.Get(id);
        }

        public async Task<IEnumerable<Contacto>> GetAll()
        {
            return await _contactRepo.GetAll().ToListAsync();
        }
        //este es el unico metodo que no esta en la capa de repository
        public async Task<Contacto> GetByName(string name)
        {
            IQueryable<Contacto> queryContactoSQL = _contactRepo.GetAll();
            Contacto contacto = await queryContactoSQL.FirstOrDefaultAsync(p => p.Nombre == name);
            return contacto;
        }

        public async Task<bool> Insert(Contacto model)
        {
            return await _contactRepo.Insert(model);
        }

        public async Task<bool> Update(Contacto model)
        {
            return await _contactRepo.Update(model);
        }
    }
}
