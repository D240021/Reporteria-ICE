import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SeguridadService } from '../../../../Seguridad/Seguridad/seguridad.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogoConfirmacionComponent } from '../../../componentes/dialogoConfirmacion/dialogo-confirmacion/dialogo-confirmacion.component';
import { datosCerrarSesion } from '../../../../Modelo/DatosDialogoConfirmacion';
import { Usuario } from '../../../../Modelo/Usuario';
import { ReporteService } from '../../../../Controlador/Reporte/reporte.service';
import { Reporte } from '../../../../Modelo/Reporte';
import { AnimacionCargaComponent } from '../../../componentes/animacionCarga/animacion-carga/animacion-carga.component';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'menu-supervisor',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, CommonModule, AnimacionCargaComponent, MatIcon],
  templateUrl: './menu-supervisor.component.html',
  styleUrls: ['./menu-supervisor.component.css']
})
export class MenuSupervisorComponent implements OnInit {


  ngOnInit(): void {
    this.usuarioIngresado = this.seguridadService.obtenerInformacionUsuarioLogeado();
    this.reporteService.obtenerTodosReportes().subscribe(respuesta => {
      this.reportesTodos = respuesta;
      this.obtenerReportesPendientes();
      this.obtenerReportesPasados();
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
  public reportesPasados: Reporte[] = [];
  

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
    this.router.navigate(['/editar-reporte'], { state: { reporte: reporte } });
  }

  obtenerReportesPendientes(): void {
    this.reportesTodos.forEach(reporte => {
      if (reporte.estado === 2 && this.usuarioIngresado.id === reporte.usuarioSupervisorId) {
        this.reportesPendientes.push(reporte);
      }
    });
  }

  obtenerReportesPasados(): void {
    this.reportesTodos.forEach(reporte => {
      if (reporte.estado === 4 && this.usuarioIngresado.id === reporte.usuarioSupervisorId) {
        this.reportesPasados.push(reporte);
      }
    });
  }

  descargarPDF(reporteId: number): void {
    this.reporteService.obtenerPDFPorReporte(reporteId).subscribe(
      respuesta => {
        console.log(respuesta);
        const blob = new Blob([respuesta], { type: 'application/pdf' });
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = `reporte_${reporteId}.pdf`;
        a.click();
        window.URL.revokeObjectURL(url);
      },
      error => {
        console.error('Error al descargar el PDF:', error);
      }
    );
  }

}
