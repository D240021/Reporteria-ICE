import { Routes } from '@angular/router';
import { InicioSesionComponent } from './Vista/paginas/inicioSesion/inicio-sesion/inicio-sesion.component';
import { MenuAdministradorComponent } from './Vista/paginas/menuAdministrador/menu-administrador/menu-administrador.component';
import { EditarTecnicoComponent } from './Vista/paginas/editarTecnico/editar-tecnico/editar-tecnico.component';
import { AgregarTecnicoComponent } from './Vista/paginas/agregarTecnico/agregar-tecnico/agregar-tecnico.component';
import { AgregarSupervisorComponent } from './Vista/paginas/agregarSupervisor/agregar-supervisor/agregar-supervisor.component';
import { AgregarUnidadRegionalComponent } from './Vista/paginas/agregarUnidadRegional/agregar-unidad-regional/agregar-unidad-regional.component';
import { AgregarSubestacionComponent } from './Vista/paginas/agregarSubestacion/agregar-subestacion/agregar-subestacion.component';
import { AgregarLineaTransmisionComponent } from './Vista/paginas/agregarLineaTransmision/agregar-linea-transmision/agregar-linea-transmision.component';
import { ConsultarSupervisorComponent } from './Vista/paginas/consultarSupervisor/consultar-supervisor/consultar-supervisor.component';
import { ConsultarReporteComponent } from './Vista/paginas/consultarReporte/consultar-reporte/consultar-reporte.component';
import { ConsultarUnidadRegionalComponent } from './Vista/paginas/consultarUnidadRegional/consultar-unidad-regional/consultar-unidad-regional.component';
import { EditarLineaTransmisionComponent } from './Vista/paginas/editarLineaTransmision/editar-linea-transmision/editar-linea-transmision.component';
import { ConsultarLineaTransmisionComponent } from './Vista/paginas/consultarLineaTransmision/consultar-linea-transmision/consultar-linea-transmision.component';
import { EditarSupervisorComponent } from './Vista/paginas/editarSupervisor/editar-supervisor/editar-supervisor.component';
import { EditarSubestacionComponent } from './Vista/paginas/editarSubestacion/editar-subestacion/editar-subestacion.component';
import { CrearReporteComponent } from './Vista/paginas/crearReporte/crear-reporte/crear-reporte.component';
import { MenuSupervisorComponent } from './Vista/paginas/menuSupervisor/menu-supervisor/menu-supervisor.component';
import { EditarReporteComponent } from './Vista/paginas/editarReporte/editar-reporte/editar-reporte.component';
import { EditarReporteTLTComponent } from './Vista/paginas/editarReporteTLT/editar-reporte-tlt/editar-reporte-tlt.component';
import { RegistrarOperarioComponent } from './Vista/paginas/registrarOperario/registrar-operario/registrar-operario.component';
import { ConsultarOperarioComponent } from './Vista/paginas/consultar-operario/consultar-operario/consultar-operario.component';

export const routes: Routes = [
    {
        path: 'inicio-sesion', component: InicioSesionComponent
    },
    {
        path: '', redirectTo: 'inicio-sesion', pathMatch: 'full'
    },
    {
        path: 'menu-administrador', component: MenuAdministradorComponent
    },
    {
        path: 'editar-tecnico', component: EditarTecnicoComponent
    },
    {
        path: 'agregar-tecnico', component: AgregarTecnicoComponent
    },
    {
        path: 'agregar-supervisor', component: AgregarSupervisorComponent
    },
    {
        path: 'agregar-unidad-regional', component: AgregarUnidadRegionalComponent
    },
    {
        path: 'agregar-subestacion', component: AgregarSubestacionComponent
    },
    {
        path: 'agregar-linea-transmision', component: AgregarLineaTransmisionComponent
    },
    {
        path: 'consultar-supervisor', component: ConsultarSupervisorComponent
    },
    {
        path: 'consultar-unidad-regional', component: ConsultarUnidadRegionalComponent
    },
    {
        path: 'consultar-reporte', component: ConsultarReporteComponent
    },
    {
        path: 'editar-linea-transmision', component: EditarLineaTransmisionComponent
    },
    {
        path: 'consultar-linea-transmision', component: ConsultarLineaTransmisionComponent
    },
    {
        path: 'editar-supervisor', component: EditarSupervisorComponent
    },
    {
        path: 'editar-subestacion', component: EditarSubestacionComponent
    },
    {
        path: 'crear-reporte', component: CrearReporteComponent
    },
    {
        path: 'menu-supervisor', component: MenuSupervisorComponent
    },
    {
        path: 'editar-reporte', component: EditarReporteComponent

    },
    {
        path: 'editar-reporte-tlt', component: EditarReporteTLTComponent
    },
    {
        path: 'registrar-operario', component: RegistrarOperarioComponent
    },
    {
        path: 'consultar-operario', component: ConsultarOperarioComponent
    }

];
