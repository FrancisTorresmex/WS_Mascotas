using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WS_Mascotas.Models.Base;
using WS_Mascotas.Models.Request;

namespace WS_Mascotas.Services
{
    public class UsuarioService : IUsuarioService
    {
        private MyDbContext _context;
        public UsuarioService(MyDbContext context)
        {
            _context = context;
        }

        //Agregar usuario        
        public void Add(Agregar model)
        {
            using (_context)
            {
                try
                {
                    //Se ejecuta el stored procedure el cual es para insertar un nuevo usuario, siempr ey cuando el telefono no este en la base
                    _context.Database.ExecuteSqlRaw("spRegisterUser {0}, {1}, {2}, {3}", @model.FirstName, @model.lastName, @model.CellPhone, @model.Date);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }                
            }
        }
    }
}
