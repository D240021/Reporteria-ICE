using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades; 
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarSupervisorDA : IGestionarSupervisorDA
    {
        private readonly ICE_Context _context;

        public GestionarSupervisorDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarSupervisor(Usuario supervisor)
        {
            var supervisorDA = new UsuarioDA
            {
                NombreUsuario = supervisor.NombreUsuario,
                Contrasenia = supervisor.Contrasenia,
                Nombre = supervisor.Nombre,
                Apellido = supervisor.Apellido,
                Identificador = supervisor.Identificador,
                RollId = supervisor.RollId, 
                SubestacionId = supervisor.SubestacionId
            };

            _context.Usuarios.Add(supervisorDA);
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> ActualizarSupervisor(int id, Usuario supervisor)
        {
            var supervisorBD = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (supervisorBD != null)
            {
                supervisorBD.NombreUsuario = supervisor.NombreUsuario;
                supervisorBD.Contrasenia = supervisor.Contrasenia;
                supervisorBD.Nombre = supervisor.Nombre;
                supervisorBD.Apellido = supervisor.Apellido;
                supervisorBD.Identificador = supervisor.Identificador;
                supervisorBD.RollId = supervisor.RollId;
                supervisorBD.SubestacionId = supervisor.SubestacionId;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<bool> EliminarSupervisor(int id)
        {
            var supervisorBD = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (supervisorBD != null)
            {
                _context.Usuarios.Remove(supervisorBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<Usuario> ObtenerSupervisor(int id)
        {
            var supervisorDA = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id && u.RollId == 3);
            if (supervisorDA == null)
            {
                return null;
            }

            return new Usuario
            {
                Id = supervisorDA.Id,
                NombreUsuario = supervisorDA.NombreUsuario,
                Contrasenia = supervisorDA.Contrasenia,
                Nombre = supervisorDA.Nombre,
                Apellido = supervisorDA.Apellido,
                Identificador = supervisorDA.Identificador,
                RollId = supervisorDA.RollId,
                SubestacionId = supervisorDA.SubestacionId
            };
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosLosSupervisores()
        {
            var supervisoresDA = await _context.Usuarios.Where(u => u.RollId == 3).ToListAsync();

            return supervisoresDA.Select(s => new Usuario
            {
                Id = s.Id,
                NombreUsuario = s.NombreUsuario,
                Contrasenia = s.Contrasenia,
                Nombre = s.Nombre,
                Apellido = s.Apellido,
                Identificador = s.Identificador,
                RollId = s.RollId,
                SubestacionId = s.SubestacionId
            }).ToList();
        }
    }
}
