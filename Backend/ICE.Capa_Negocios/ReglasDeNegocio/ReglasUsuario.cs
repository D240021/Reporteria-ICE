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

            if (usuario.Identificador <= 0)
            {
                Console.WriteLine("El identificador debe ser mayor que cero.");
                return (false, "El identificador debe ser mayor que cero.");
            }

            if (usuario.RollId <= 0)
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

            if (!string.IsNullOrEmpty(usuario.Correo) && !usuario.Correo.Contains("@"))
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
