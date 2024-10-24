using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarRolDA : IGestionarRolDA
    {
        private readonly ICE_Context _context;

        public GestionarRolDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarRol(Rol rol)
        {
            var rolDA = new RolDA
            {
                Nombre = rol.Nombre
            };

            _context.Roles.Add(rolDA);
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> ActualizarRol(int id, Rol rol)
        {
            var rolBD = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (rolBD != null)
            {
                rolBD.Nombre = rol.Nombre;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<bool> EliminarRol(int id)
        {
            var rolBD = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (rolBD != null)
            {
                _context.Roles.Remove(rolBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<Rol> ObtenerRolPorId(int id)
        {
            var rolBD = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (rolBD == null)
            {
                return null;
            }

            return new Rol
            {
                Id = rolBD.Id,
                Nombre = rolBD.Nombre
            };
        }

        public async Task<IEnumerable<Rol>> ObtenerTodosLosRoles()
        {
            var rolesBD = await _context.Roles.ToListAsync();

            return rolesBD.Select(rolBD => new Rol
            {
                Id = rolBD.Id,
                Nombre = rolBD.Nombre
            }).ToList();
        }
    }
}
