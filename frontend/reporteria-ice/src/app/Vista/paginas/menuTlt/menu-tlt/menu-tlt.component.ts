import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SeguridadService } from '../../../../Seguridad/Seguridad/seguridad.service';
import { MatDialog } from '@angular/material/dialog';
import { Usuario } from '../../../../Modelo/Usuario';
import { Reporte } from '../../../../Modelo/Reporte';
import { ReporteService } from '../../../../Controlador/Reporte/reporte.service';
import { DialogoConfirmacionComponent } from '../../../componentes/dialogoConfirmacion/dialogo-confirmacion/dialogo-confirmacion.component';
import { datosCerrarSesion } from '../../../../Modelo/DatosDialogoConfirmacion';
import { AnimacionCargaComponent } from '../../../componentes/animacionCarga/animacion-carga/animacion-carga.component';

@Component({
  selector: 'menu-tlt',
  standalone: true,
  imports: [AnimacionCargaComponent],
  templateUrl: './menu-tlt.component.html',
  styleUrl: './menu-tlt.component.css'
})
export class MenuTltComponent implements OnInit{

  ngOnInit(): void {
    this.usuarioIngresado = this.seguridadService.obtenerInformacionUsuarioLogeado();
    this.reporteService.obtenerTodosReportes().subscribe(respuesta => {
      this.reportesTodos = respuesta;
      this.obtenerReportesPendientes();
    });

  }


  private router = inject(Router);
  public seguridadService = inject(SeguridadService);
  private modalAbierto: boolean = false;
  private cuadroDialogo = inject(MatDialog);
  public usuarioIngresado !: Usuario;
  public reportesTodos: Reporte[] = [];
  public reportesPendientes: Reporte[] = [];
  private reporteService = inject(ReporteService);


  abrirCuadroDialogo(): void {


    if (!this.modalAbierto) {
      this.modalAbierto = true;
      const dialogRef = this.cuadroDialogo.open(DialogoConfirmacionComponent, {
        width: '400px',
        height: '200px',
        data: datosCerrarSesion
      });
      dialogRef.afterClosed().subscribe(result => {
        this.modalAbierto = false;
      });
    }

  }

  redirigirEdicionReporte(reporte : Reporte): void {
    this.router.navigate(['/editar-reporte-tlt'], { state: { reporte: reporte } });
  }

  obtenerReportesPendientes(): void {
    this.reportesTodos.forEach(reporte => {
      if (reporte.estado === 3 && this.usuarioIngresado.id === reporte.tecnicoLineaId) {
        this.reportesPendientes.push(reporte);
      }
    });
  }
}
