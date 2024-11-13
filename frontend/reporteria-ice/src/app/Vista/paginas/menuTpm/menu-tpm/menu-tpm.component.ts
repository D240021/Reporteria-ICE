import { Component, inject, OnInit } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';
import { CrearReporteComponent } from "../../crearReporte/crear-reporte/crear-reporte.component";
import { Usuario } from '../../../../Modelo/Usuario';
import { SeguridadService } from '../../../../Seguridad/Seguridad/seguridad.service';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { DialogoConfirmacionComponent } from '../../../componentes/dialogoConfirmacion/dialogo-confirmacion/dialogo-confirmacion.component';
import { datosConfirmacionSesionSinGuardar } from '../../../../Modelo/DatosDialogoConfirmacion';
import { InformeService } from '../../../../Controlador/Informe/informe.service';
import { Informe } from '../../../../Modelo/Informe';
import { MatCardModule } from '@angular/material/card';
import { AnimacionCargaComponent } from "../../../componentes/animacionCarga/animacion-carga/animacion-carga.component";
import { MatIconModule } from '@angular/material/icon';
import { NavigationEnd, Router } from '@angular/router';
import { formatearFechaHora } from '../../../../Util/Formatos/fechas';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'menu-tpm',
  standalone: true,
  imports: [MatTabsModule, CrearReporteComponent, MatButtonModule, MatCardModule, AnimacionCargaComponent, MatIconModule],
  templateUrl: './menu-tpm.component.html',
  styleUrl: './menu-tpm.component.css'
})
export class MenuTpmComponent implements OnInit {

  ngOnInit(): void {
    this.cargarInformacionGeneral();

    this.router.events //Verifica cuando el usuario se redirige a esta página
    .pipe(
      filter(event => event instanceof NavigationEnd),
      filter((event: NavigationEnd) => event.urlAfterRedirects === '/crear-reporte') 
    )
    .subscribe(() => {
      this.cargarInformacionGeneral();
    });
  }


  public seguridadService = inject(SeguridadService);
  public usuarioIngresado !: Usuario;
  private cuadroDialogo = inject(MatDialog);
  private modalAbierto: boolean = false;
  private informeService = inject(InformeService);
  public informes: any[] = [];
  private router = inject(Router);

  cargarInformacionGeneral(): void {
    console.log("ENTRA AL METODO");
    this.usuarioIngresado = this.seguridadService.obtenerInformacionUsuarioLogeado();
    const subestacionId = this.usuarioIngresado.subestacionId || 0;


    this.informeService.obtenerInformesPendientesPorSubestacion(subestacionId).subscribe(informes => {
      this.informes = informes;
      this.informes.forEach(informe => {

        this.informeService.obtenerReportePorInformeId(informe.id).subscribe(reporte => {
          informe.reporteAsociado = reporte;
          informe.reporteAsociado.fechaHora = formatearFechaHora(informe.reporteAsociado.fechaHora);
        });
      });
    });
  }

  abrirCuadroDialogo(): void {


    if (!this.modalAbierto) {
      this.modalAbierto = true;
      const dialogRef = this.cuadroDialogo.open(DialogoConfirmacionComponent, {
        width: '400px',
        height: '200px',
        data: datosConfirmacionSesionSinGuardar
      });
      dialogRef.afterClosed().subscribe(result => {
        this.modalAbierto = false;
        if(result === 'Confirmacion'){
          this.cargarInformacionGeneral();
        }
      });
    }
  }

  abrirEditarInforme(informe: Informe): void {
    this.router.navigate(['/editar-reporte-tpm'], { state: { informe: informe } });
    return;
  }


}
