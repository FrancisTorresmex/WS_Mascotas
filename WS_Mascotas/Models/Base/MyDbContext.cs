using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WS_Mascotas.Models.Base
{
    public class MyDbContext : DbContext
    {       

        //Constructor necesario para firstCode
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }       

        //Tablas a crear
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Mascotas;Trusted_Connection=True;");
            }
        }


        //Agregar aqui el stored procedure
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}

    }

    //Tablas y relaciones
    public class User
    {
        [Key]
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string CellPhone { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Pet> Pets { get; set; } //para indicar que una persona 
    }

    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Birth { get; set; }        

        //Estas dos lineas al crear la base generaran un FK con la tabla User
        public int UserId { get; set; }
        public User User { get; set; }

        //Estas dos lineas al crear la base generaran un FK con la tabla PetType
        public int TypeId { get; set; }
        public PetType PetType { get; set; }
    }

    public class PetType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }    
}
