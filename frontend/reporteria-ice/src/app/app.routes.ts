import { Routes } from '@angular/router';
import { InicioSesionComponent } from './paginas/inicioSesion/inicio-sesion/inicio-sesion.component';
import { MenuAdministradorComponent } from './paginas/menuAdministrador/menu-administrador/menu-administrador.component';
import { EditarTecnicoComponent } from './paginas/editarTecnico/editar-tecnico/editar-tecnico.component';
import { AgregarTecnicoComponent } from './paginas/agregarTecnico/agregar-tecnico/agregar-tecnico.component';
import { AgregarSupervisorComponent } from './paginas/agregarSupervisor/agregar-supervisor/agregar-supervisor.component';
import { AgregarUnidadRegionalComponent } from './paginas/agregarUnidadRegional/agregar-unidad-regional/agregar-unidad-regional.component';
import { AgregarSubestacionComponent } from './paginas/agregarSubestacion/agregar-subestacion/agregar-subestacion.component';
import { AgregarLineaTransmisionComponent } from './paginas/agregarLineaTransmision/agregar-linea-transmision/agregar-linea-transmision.component';
import { ConsultarSupervisorComponent } from './paginas/consultarSupervisor/consultar-supervisor/consultar-supervisor.component';
import { ConsultarUnidadRegionalComponent } from './paginas/consultarUnidadRegional/consultar-unidad-regional/consultar-unidad-regional.component';
import { EditarLineaTransmisionComponent } from './paginas/editarLineaTransmision/editar-linea-transmision/editar-linea-transmision.component';
import { ConsultarLineaTransmisionComponent } from './paginas/consultarLineaTransmision/consultar-linea-transmision/consultar-linea-transmision.component';
import { EditarSupervisorComponent } from './paginas/editarSupervisor/editar-supervisor/editar-supervisor.component';
import { EditarSubestacionComponent } from './paginas/editarSubestacion/editar-subestacion/editar-subestacion.component';
import { CrearReporteComponent } from './paginas/crearReporte/crear-reporte/crear-reporte.component';
import { MenuSupervisorComponent } from './paginas/menuSupervisor/menu-supervisor/menu-supervisor.component';
import { EditarReporteTLTComponent } from './paginas/editarReporteTLT/editar-reporte-tlt/editar-reporte-tlt.component';

export const routes: Routes = [
    {
        path: 'inicio-sesion', component:InicioSesionComponent
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
        path: 'editar-reporte-tlt', component: EditarReporteTLTComponent
    },
];
