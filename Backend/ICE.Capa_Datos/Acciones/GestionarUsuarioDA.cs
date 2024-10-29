using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarUsuarioDA : IGestionarUsuarioDA
    {
        private readonly ICE_Context _context;

        public GestionarUsuarioDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<int> RegistrarUsuario(Usuario usuario)
        {
            var existeUsuario = await _context.Usuarios.AnyAsync(u => u.NombreUsuario == usuario.NombreUsuario || u.Identificador == usuario.Identificador);
            if (existeUsuario)
            {
                throw new Exception("El nombre de usuario o el identificador ya están en uso.");
            }

            var usuarioDA = new UsuarioDA
            {
                Contrasenia = usuario.Contrasenia,
                NombreUsuario = usuario.NombreUsuario,
                Correo = usuario.Correo,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Identificador = usuario.Identificador,
                Rol = usuario.Rol,
                SubestacionId = usuario.SubestacionId == 0 ? (int?)null : usuario.SubestacionId,
                UnidadRegionalId = usuario.UnidadRegionalId == 0 ? (int?)null : usuario.UnidadRegionalId
            };

            _context.Usuarios.Add(usuarioDA);
            await _context.SaveChangesAsync();
            return usuarioDA.Id;
        }


        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            var usuarioBD = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuarioBD == null) return null;

            return new Usuario
            {
                Id = usuarioBD.Id,
                Contrasenia = usuarioBD.Contrasenia,
                NombreUsuario = usuarioBD.NombreUsuario,
                Correo = usuarioBD.Correo,
                Nombre = usuarioBD.Nombre,
                Apellido = usuarioBD.Apellido,
                Identificador = usuarioBD.Identificador,
                Rol = usuarioBD.Rol,
                SubestacionId = usuarioBD.SubestacionId,
                UnidadRegionalId = usuarioBD.UnidadRegionalId
            };
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosLosUsuarios()
        {
            var usuariosBD = await _context.Usuarios.ToListAsync();
            var usuarios = new List<Usuario>();

            foreach (var usuarioBD in usuariosBD)
            {
                usuarios.Add(new Usuario
                {
                    Id = usuarioBD.Id,
                    Contrasenia = usuarioBD.Contrasenia,
                    NombreUsuario = usuarioBD.NombreUsuario,
                    Correo = usuarioBD.Correo,
                    Nombre = usuarioBD.Nombre,
                    Apellido = usuarioBD.Apellido,
                    Identificador = usuarioBD.Identificador,
                    Rol = usuarioBD.Rol,
                    SubestacionId = usuarioBD.SubestacionId,
                    UnidadRegionalId = usuarioBD.UnidadRegionalId
                });
            }

            return usuarios;
        }

        public async Task<bool> ActualizarUsuario(int id, Usuario usuario)
        {
            var usuarioBD = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (usuarioBD != null)
            {
                var existeUsuario = await _context.Usuarios.AnyAsync(u => (u.NombreUsuario == usuario.NombreUsuario || u.Identificador == usuario.Identificador) && u.Id != id);
                if (existeUsuario)
                {
                    throw new Exception("El nombre de usuario o el identificador ya están en uso por otro usuario.");
                }

                usuarioBD.Contrasenia = usuario.Contrasenia;
                usuarioBD.NombreUsuario = usuario.NombreUsuario;
                usuarioBD.Correo = usuario.Correo;
                usuarioBD.Nombre = usuario.Nombre;
                usuarioBD.Apellido = usuario.Apellido;
                usuarioBD.Identificador = usuario.Identificador;
                usuarioBD.Rol = usuario.Rol;
                usuarioBD.SubestacionId = usuario.SubestacionId == 0 ? (int?)null : usuario.SubestacionId;
                usuarioBD.UnidadRegionalId = usuario.UnidadRegionalId == 0 ? (int?)null : usuario.UnidadRegionalId;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }


        public async Task<bool> EliminarUsuario(int id)
        {
            var usuarioBD = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (usuarioBD != null)
            {
                _context.Usuarios.Remove(usuarioBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }
    }
}
