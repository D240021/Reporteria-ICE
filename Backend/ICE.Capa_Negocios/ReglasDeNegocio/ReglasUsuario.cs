using ICE.Capa_Dominio.Modelos;


namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasUsuario
    {
        public static (bool esValido, string mensaje) EsUsuarioValido(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.NombreUsuario))
            {
                Console.WriteLine("El nombre de usuario no puede estar vacío.");
                return (false, "El nombre de usuario no puede estar vacío.");
            }

            if (usuario.NombreUsuario.Length > 100)
            {
                Console.WriteLine("El nombre de usuario no puede exceder los 100 caracteres.");
                return (false, "El nombre de usuario no puede exceder los 100 caracteres.");
            }

            if (string.IsNullOrEmpty(usuario.Contrasenia))
            {
                Console.WriteLine("La contraseña no puede estar vacía.");
                return (false, "La contraseña no puede estar vacía.");
            }

            if (usuario.Contrasenia.Length < 8)
            {
                Console.WriteLine("La contraseña debe tener al menos 8 caracteres.");
                return (false, "La contraseña debe tener al menos 8 caracteres.");
            }

            //Se modifica esta relga en especifico, ya que se validaba como int el identificador
            if (string.IsNullOrWhiteSpace(usuario.Identificador))
            {
                Console.WriteLine("El identificador no puede estar vacío o solo contener espacios en blanco.");
                return (false, "El identificador no puede estar vacío o solo contener espacios en blanco.");
            }

            //Se modifica esta relga en especifico, ya que se validaba como int el rol
            if (string.IsNullOrWhiteSpace(usuario.Rol))
            {
                Console.WriteLine("El rol no es válido.");
                return (false, "El rol no es válido.");
            }

            if (usuario.SubestacionId <= 0)
            {
                Console.WriteLine("La subestación no es válida.");
                return (false, "La subestación no es válida.");
            }

            if (!string.IsNullOrEmpty(usuario.Nombre) && usuario.Nombre.Length > 100)
            {
                Console.WriteLine("El nombre no puede exceder los 100 caracteres.");
                return (false, "El nombre no puede exceder los 100 caracteres.");
            }

            if (!string.IsNullOrEmpty(usuario.Apellido) && usuario.Apellido.Length > 100)
            {
                Console.WriteLine("El apellido no puede exceder los 100 caracteres.");
                return (false, "El apellido no puede exceder los 100 caracteres.");
            }

            bool tieneArroba = usuario.Correo.Contains("@");
            bool tienePunto = usuario.Correo.Contains(".");
            bool correoInvalido = !tieneArroba || !tienePunto;

            if (!string.IsNullOrEmpty(usuario.Correo) && correoInvalido)
            {
                Console.WriteLine("El formato del correo es incorrecto.");
                return (false, "El formato del correo es incorrecto.");
            }

            return (true, string.Empty);
        }

        public static (bool esValido, string mensaje) EsIdValido(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("El ID proporcionado no es válido.");
                return (false, "El ID proporcionado no es válido.");
            }

            return (true, string.Empty);
        }
    }
}
