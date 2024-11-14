using IntroduccionAEFCore.Entidades;
using IntroduccionAEFCore.Entidades.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IntroduccionAEFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			//Usando Fluent API para configurar las propiedades de la tabla 
			//modelBuilder.Entity<Actor>().Property(a=>a.Fortuna).HasPrecision(18, 2);
			//modelBuilder.Entity<Actor>().Property(a=>a.Fortuna).HasColumType("date");//para colocar manualmentte el tipo
			//modelBuilder.Entity<Actor>().Property(a=>a.Fortuna).HasMaxLenth(150);

   			//esta configuraciones se pueden hacer con Annotations. directo en el modelo, ej:  [Requiered, o maxlenth etc]
  				//se separo esta config en archivos aparte y se aplico con este codigo:
 		       modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            SeedingInicial.Seed(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Actor> Actores => Set<Actor>();
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();
        public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();
    }
}
