using Microsoft.AspNetCore.Mvc;
using ProyectoCRUD.BLL.Services;
using ProyectoCRUD.Models;
using ProyectoCRUD.WebApplication.Models;
using ProyectoCRUD.WebApplication.Models.ViewModels;
using System.Diagnostics;
using System.Globalization;

namespace ProyectoCRUD.WebApplication.Controllers
{
    //[Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IContactoService _contacto;

        public HomeController(IContactoService contacto)
        {
            _contacto = contacto;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetListContactos()
        {
            IQueryable<Contacto> queryContactoSQL = await _contacto.GetAll();
            List<VMContacto> list = queryContactoSQL
                .Select(c => new VMContacto()
                {
                    IdContacto = c.IdContacto,
                    Nombre = c.Nombre,
                    Telefono = c.Telefono,
                    FechaNacimiento = c.FechaNacimiento.Value.ToString("dd/MM/yyy")
                }).ToList();

            return StatusCode(StatusCodes.Status200OK,list);
        }

        [HttpPost]
        //[Route("/InsertContacto")]
        public async Task<IActionResult> InsertContacto([FromBody] VMContacto modelo)
        {
            Contacto NewModel = new Contacto()
            {
                Nombre = modelo.Nombre,
                Telefono = modelo.Telefono,
                FechaNacimiento = DateTime.ParseExact(modelo.FechaNacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-AR")) //buscar lista de culturas en documentacion de MS
            };

            bool response = await _contacto.Insert(NewModel);

            return StatusCode(StatusCodes.Status200OK, new {value = response});
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContacto([FromBody] VMContacto modelo)
        {
            Contacto NewModel = new Contacto()
            {
                IdContacto = modelo.IdContacto,
                Nombre = modelo.Nombre,
                Telefono = modelo.Telefono,
                FechaNacimiento = DateTime.ParseExact(modelo.FechaNacimiento, "dd/mm/yyyy", CultureInfo.CreateSpecificCulture("es-AR")) //buscar lista de culturas en documentacion de MS
            };

            bool response = await _contacto.Update(NewModel);

            return StatusCode(StatusCodes.Status200OK, new { value = response });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContacto(int id)
        {


            bool response = await _contacto.Delete(id);

            return StatusCode(StatusCodes.Status200OK, new { value = response });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}