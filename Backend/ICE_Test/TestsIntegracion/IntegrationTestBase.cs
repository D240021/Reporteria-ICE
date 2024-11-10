using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ICE_Test.TestsIntegracion
{

    [SetUpFixture]
    public class IntegrationTestBase
    {
        protected IServiceProvider Services { get; private set; }

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            var configuracionPruebas = new ConfiguracionPruebas();
            Services = configuracionPruebas.ProveedorServicios;
        }
    }

    /*
    [SetUpFixture]
    public class IntegrationTestBase
    {
        protected IServiceProvider Services { get; private set; }

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Console.WriteLine("Inicializando Configuración de Pruebas");
            var configuracionPruebas = new ConfiguracionPruebas();
            Services = configuracionPruebas.ProveedorServicios;
        }
    }
    */
}