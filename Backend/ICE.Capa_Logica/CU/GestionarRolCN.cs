using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarRolCN : IGestionarRolCN
    {
        private readonly IGestionarRolDA _gestionarRolDA;

        public GestionarRolCN(IGestionarRolDA gestionarRolDA)
        {
            _gestionarRolDA = gestionarRolDA;
        }

        // M�todo para registrar un nuevo rol
        public async Task<bool> RegistrarRol(Rol rol)
        {
            return await _gestionarRolDA.RegistrarRol(rol);
        }

        // M�todo para obtener un rol por su ID
        public async Task<Rol> ObtenerRolPorId(int id)
        {
            return await _gestionarRolDA.ObtenerRolPorId(id);
        }

        // M�todo para actualizar un rol
        public async Task<bool> ActualizarRol(int id, Rol rol)
        {
            return await _gestionarRolDA.ActualizarRol(id, rol);
        }

        // M�todo para eliminar un rol
        public async Task<bool> EliminarRol(int id)
        {
            return await _gestionarRolDA.EliminarRol(id);
        }

        // M�todo para obtener todos los roles
        public async Task<IEnumerable<Rol>> ObtenerTodosLosRoles()
        {
            return await _gestionarRolDA.ObtenerTodosLosRoles();
        }
    }
}
