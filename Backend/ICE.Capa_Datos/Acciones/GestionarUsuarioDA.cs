using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarUsuarioDA : IGestionarUsuarioDA
    {
        private readonly ICE_Context _context;
        private readonly string _encryptionKey = "1234567890123456";
        private readonly string _ivString = "1234567890123456";

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

            var contraseniaEncriptada = EncriptarAES(usuario.Contrasenia, _encryptionKey);

            var usuarioDA = new UsuarioDA
            {
                Contrasenia = contraseniaEncriptada,
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

                usuarioBD.Contrasenia = EncriptarAES(usuario.Contrasenia, _encryptionKey);
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
            var usuariosBD = await _context.Usuarios
                .Where(u => u.Rol != "Administrador")
                .ToListAsync();

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

        public async Task<Usuario> AutenticarUsuario(string nombreUsuario, string contraseniaCifrada)
        {
            var usuarioDA = await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);

            if (usuarioDA == null || usuarioDA.Contrasenia != contraseniaCifrada)
            {
                return null; 
            }

            var usuario = new Usuario
            {
                Id = usuarioDA.Id,
                NombreUsuario = usuarioDA.NombreUsuario,
                Correo = usuarioDA.Correo,
                Nombre = usuarioDA.Nombre,
                Apellido = usuarioDA.Apellido,
                Identificador = usuarioDA.Identificador,
                Rol = usuarioDA.Rol,
                SubestacionId = usuarioDA.SubestacionId,
                UnidadRegionalId = usuarioDA.UnidadRegionalId
            };

            return usuario; 
        }


        private string EncriptarAES(string textoPlano, string clave)
        {

            byte[] keyBytes = Encoding.UTF8.GetBytes(clave);
            byte[] ivBytes = Encoding.UTF8.GetBytes("1234567890123456"); // IV de 16 caracteres

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var writer = new StreamWriter(cs))
                    {
                        writer.Write(textoPlano);
                    }

                    string textoCifrado = Convert.ToBase64String(ms.ToArray());
                    return textoCifrado;
                }
            }
        }


        private string DesencriptarAES(string textoCifrado, string clave)
        {

            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(clave);
                byte[] ivBytes = Encoding.UTF8.GetBytes("1234567890123456"); // IV fijo de 16 caracteres
                byte[] textoCifradoBytes = Convert.FromBase64String(textoCifrado);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Mode = CipherMode.CBC;

                    using (var ms = new MemoryStream(textoCifradoBytes))
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (var reader = new StreamReader(cs))
                    {
                        string textoDesencriptado = reader.ReadToEnd();
                        return textoDesencriptado;
                    }
                }
            }
            catch (CryptographicException ex)
            {
                throw new Exception("Error al desencriptar: asegúrate de que el texto cifrado y la configuración de AES sean correctos. " + ex.Message);
            }
        }





    }
}
