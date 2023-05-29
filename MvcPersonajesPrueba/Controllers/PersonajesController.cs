using Microsoft.AspNetCore.Mvc;
using MvcPersonajesPrueba.Models;
using MvcPersonajesPrueba.Repositories;

namespace MvcPersonajesPrueba.Controllers
{
    public class PersonajesController : Controller
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> GetPersonajes()
        {
            List<Personaje> personajes = await this.repo.GetPersonajesAsync();
            return View(personajes);
        }


        [HttpGet]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            Personaje personaje = await this.repo.FindPersonajeAsync(id);
            return View(personaje);
        }
        public IActionResult CreatePersonaje()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonaje(Personaje personaje)
        {
            await this.repo.CreatePersonaje(personaje.Nombre, personaje.Imagen);
            return RedirectToAction("GetPersonajes");
        }

        public async Task<ActionResult<Personaje>> UpdatePersonaje(int id)
        {
            Personaje personaje = await this.repo.FindPersonajeAsync(id);
            return View(personaje);
        }

        [HttpPost]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonaje(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen);
            return RedirectToAction("GetPersonajes");
        }

        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonaje(id);
            return RedirectToAction("GetPersonajes");
        }




    }
}
