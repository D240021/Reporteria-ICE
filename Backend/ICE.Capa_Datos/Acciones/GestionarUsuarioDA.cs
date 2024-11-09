using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarUsuarioDA : IGestionarUsuarioDA
    {
        private readonly ICE_Context _context;
        private readonly string _encryptionKey = "12345678901234567890123456789012"; // 32 caracteres para 256 bits

        public GestionarUsuarioDA(ICE_Context context)
        {
            _context = context;
        }

        public class ConflictException : Exception
        {
            public ConflictException(string message) : base(message)
            {
            }
        }

        public async Task<int> RegistrarUsuario(Usuario usuario)
        {
            var existeUsuario = await _context.Usuarios.AnyAsync(u => u.NombreUsuario == usuario.NombreUsuario || u.Identificador == usuario.Identificador);

            if (existeUsuario)
            {
                // Lanza una excepción personalizada con un código de estado 409 y el mensaje adecuado
                throw new ConflictException("El nombre de usuario o el identificador ya están en uso.");
            }

            // Desencripta la contraseña recibida para verificar el valor original
            var contraseniaDesencriptada = DesencriptarAES(usuario.Contrasenia);

            // Re-encripta la contraseña antes de guardarla en la base de datos
            var contraseniaEncriptada = EncriptarAES(contraseniaDesencriptada);

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
            // Primero obtenemos el usuario
            var usuarioBD = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuarioBD == null) return null;

            // Luego buscamos la unidad regional asociada
            string nombreUnidadRegional = null;
            if (usuarioBD.UnidadRegionalId.HasValue)
            {
                var unidadRegional = await _context.UnidadesRegionales
                    .AsNoTracking()
                    .FirstOrDefaultAsync(ur => ur.Id == usuarioBD.UnidadRegionalId.Value);

                nombreUnidadRegional = unidadRegional?.NombreUbicacion;
            }

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
                UnidadRegionalId = usuarioBD.UnidadRegionalId,
                NombreUnidadRegional = nombreUnidadRegional 
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
                string nombreUnidadRegional = null;

                if (usuarioBD.UnidadRegionalId.HasValue)
                {
                    var unidadRegional = await _context.UnidadesRegionales
                        .AsNoTracking()
                        .FirstOrDefaultAsync(ur => ur.Id == usuarioBD.UnidadRegionalId.Value);

                    nombreUnidadRegional = unidadRegional?.NombreUbicacion; 
                }

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
                    UnidadRegionalId = usuarioBD.UnidadRegionalId,
                    NombreUnidadRegional = nombreUnidadRegional 
                });
            }

            return usuarios;
        }

        public async Task<IEnumerable<Usuario>> obtenerSupervisorPorUnidadRegional(int idUnidadRegional)
        {
            var supervisoresDA = await _context.Usuarios
                .Where(u => u.UnidadRegionalId == idUnidadRegional && u.Rol == "SPRV")
                .ToListAsync();

            var supervisores = supervisoresDA.Select(da => new Usuario
            {
                // Mapea las propiedades necesarias de UsuarioDA a Usuario
                Id = da.Id,
                NombreUsuario = da.NombreUsuario,
                Correo = da.Correo,
                Nombre = da.Nombre,
                Apellido = da.Apellido,
                Identificador = da.Identificador,
                Rol = da.Rol,
                // Mapea otras propiedades según corresponda
            });

            return supervisores;
        }

        public async Task<IEnumerable<Usuario>> obtenerTecnicoTPMPorUnidadRegional(int idUnidadRegional)
        {
            var tecnicosTPMDA = await _context.Usuarios
                .Where(u => u.UnidadRegionalId == idUnidadRegional && u.Rol == "TPM")
                .ToListAsync();

            var tecnicosTPM = tecnicosTPMDA.Select(da => new Usuario
            {
                
                Id = da.Id,
                NombreUsuario = da.NombreUsuario,
                Correo = da.Correo,
                Nombre = da.Nombre,
                Apellido = da.Apellido,
                Identificador = da.Identificador,
                Rol = da.Rol,
                
            });

            return tecnicosTPM;
        }

        public async Task<IEnumerable<Usuario>> obtenerTecnicoTLTPorUnidadRegional(int idUnidadRegional)
        {
            var tecnicosTLTDA = await _context.Usuarios
                .Where(u => u.UnidadRegionalId == idUnidadRegional && u.Rol == "TLT")
                .ToListAsync();

            var tecnicosTLT = tecnicosTLTDA.Select(da => new Usuario
            {

                Id = da.Id,
                NombreUsuario = da.NombreUsuario,
                Correo = da.Correo,
                Nombre = da.Nombre,
                Apellido = da.Apellido,
                Identificador = da.Identificador,
                Rol = da.Rol,

            });

            return tecnicosTLT;
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

            if (usuarioDA == null) return null;

            // Desencripta la contraseña almacenada en la base de datos
            var contraseniaDesencriptadaBD = DesencriptarAES(usuarioDA.Contrasenia);
            // Desencripta la contraseña ingresada
            var contraseniaDesencriptadaIngresada = DesencriptarAES(contraseniaCifrada);

            // Compara las contraseñas desencriptadas
            if (contraseniaDesencriptadaBD != contraseniaDesencriptadaIngresada) return null;

            return new Usuario
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
        }


        private string EncriptarAES(string textoPlano)
        {
            // Convierte la clave de cifrado a bytes usando codificación UTF8
            byte[] claveBytes = Encoding.UTF8.GetBytes(_encryptionKey);

            // Crea una instancia de AES para el cifrado
            using (Aes aes = Aes.Create())
            {
                aes.Key = claveBytes;
                aes.Mode = CipherMode.CBC; // Modo de cifrado CBC
                aes.Padding = PaddingMode.PKCS7; // Padding para completar bloques

                // Genera un IV aleatorio
                aes.GenerateIV();
                byte[] iv = aes.IV;

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var writer = new StreamWriter(cs))
                    {
                        writer.Write(textoPlano); // Escribe y cifra el texto plano en el stream
                    }

                    // Convierte los datos cifrados a un array de bytes
                    byte[] datosCifrados = ms.ToArray();

                    // Convierte el IV y los datos cifrados a Base64 y los concatena con ":" como delimitador
                    string textoCifrado = Convert.ToBase64String(iv) + ":" + Convert.ToBase64String(datosCifrados);
                    return textoCifrado;
                }
            }
        }


        private string DesencriptarAES(string textoCifrado)
        {
            // Divide el texto en IV y texto cifrado usando el delimitador ":"
            var partes = textoCifrado.Split(':');
            if (partes.Length != 2) throw new ArgumentException("El texto cifrado no está en el formato esperado");

            byte[] iv = Convert.FromBase64String(partes[0]);
            byte[] datosCifrados = Convert.FromBase64String(partes[1]);
            byte[] claveBytes = Encoding.UTF8.GetBytes(_encryptionKey);

            using (Aes aes = Aes.Create())
            {
                aes.Key = claveBytes;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream(datosCifrados))
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (var reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        
    }
}
