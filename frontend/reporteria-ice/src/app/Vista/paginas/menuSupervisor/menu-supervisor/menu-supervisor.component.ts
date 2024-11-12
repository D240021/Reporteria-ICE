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

@Component({
  selector: 'menu-supervisor',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, RouterLink, CommonModule],
  templateUrl: './menu-supervisor.component.html',
  styleUrls: ['./menu-supervisor.component.css']
})
export class MenuSupervisorComponent implements OnInit {


  ngOnInit(): void {
    this.usuarioIngresado = this.seguridadService.obtenerInformacionUsuarioLogeado();
    this.reporteService.obtenerTodosReportes().subscribe(respuesta => {
      this.reportesTodos = respuesta;
      this.obtenerReportesPendientes();
      console.log(this.reportesPendientes);
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

  //Reportes quemados:
  reportes = [
    { id: '146621F', nombre: 'Guápiles - San José' },
    { id: '9549T', nombre: 'Río Macho - Paraíso' }
  ];

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

  redirigirEdicionReporte(): void {
    this.router.navigate(['/editar-reporte']);
  }

  obtenerReportesPendientes(): void {
    this.reportesPendientes.forEach(reporte => {
      if (reporte.estado === 2) {
        this.reportesPendientes.push(reporte);
      }
    });
  }

}
