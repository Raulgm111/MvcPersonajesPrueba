using Microsoft.EntityFrameworkCore;
using MvcPersonajesPrueba.Models;
using System.Collections.Generic;

namespace MvcPersonajesPrueba.Data
{
    public class PersonajesContext : DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options)
            : base(options) { }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
