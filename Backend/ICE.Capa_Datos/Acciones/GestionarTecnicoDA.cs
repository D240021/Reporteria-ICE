using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarTecnicoDA : IGestionarTecnicoDA
    {
        private readonly ICE_Context _context;

        public GestionarTecnicoDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarTecnico(Usuario tecnico)
        {
            var tecnicoDA = new UsuarioDA
            {
                NombreUsuario = tecnico.NombreUsuario,
                Contrasenia = tecnico.Contrasenia,
                RollId = tecnico.RollId,
                SubestacionId = tecnico.SubestacionId
            };

            _context.Usuarios.Add(tecnicoDA);
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> ActualizarTecnico(int id, Usuario tecnico)
        {
            var tecnicoBD = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (tecnicoBD != null)
            {
                tecnicoBD.NombreUsuario = tecnico.NombreUsuario;
                tecnicoBD.Contrasenia = tecnico.Contrasenia;
                tecnicoBD.RollId = tecnico.RollId;
                tecnicoBD.SubestacionId = tecnico.SubestacionId;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<bool> EliminarTecnico(int id)
        {
            var tecnicoBD = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (tecnicoBD != null)
            {
                _context.Usuarios.Remove(tecnicoBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<Usuario> ObtenerTecnico(int id)
        {
            var tecnicoDA = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id && (u.RollId == 1 || u.RollId == 2));
            if (tecnicoDA == null)
            {
                return null;
            }

            return new Usuario
            {
                Id = tecnicoDA.Id,
                NombreUsuario = tecnicoDA.NombreUsuario,
                Contrasenia = tecnicoDA.Contrasenia,
                RollId = tecnicoDA.RollId,
                SubestacionId = tecnicoDA.SubestacionId
            };
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosLosTecnicos()
        {
            var tecnicosDA = await _context.Usuarios.Where(u => u.RollId == 1 || u.RollId == 2).ToListAsync();

            return tecnicosDA.Select(t => new Usuario
            {
                Id = t.Id,
                NombreUsuario = t.NombreUsuario,
                Contrasenia = t.Contrasenia,
                RollId = t.RollId,
                SubestacionId = t.SubestacionId
            }).ToList();
        }
    }
}
