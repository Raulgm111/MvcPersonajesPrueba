using Microsoft.EntityFrameworkCore;
using MvcPersonajesPrueba.Data;
using MvcPersonajesPrueba.Models;

namespace MvcPersonajesPrueba.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await
                this.context.Personajes
                .FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        private int GetMaxIdPersonaje()
        {
            return this.context.Personajes.Max(z => z.IdPersonaje) + 1;
        }

        public async Task CreatePersonaje(string nombre, string imagen)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = this.GetMaxIdPersonaje();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonaje(int id, string nombre, string imagen)
        {
            Personaje personaje = await this.context.Personajes.FindAsync(id);

            if (personaje != null)
            {
                personaje.Nombre = nombre;
                personaje.Imagen = imagen;

                await this.context.SaveChangesAsync();
            }
        }

        public async Task DeletePersonaje(int id)
        {
            Personaje personaje = await this.context.Personajes.FindAsync(id);

            if (personaje != null)
            {
                this.context.Personajes.Remove(personaje);
                await this.context.SaveChangesAsync();
            }
        }


    }
}
