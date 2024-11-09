import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SeguridadService } from '../../../../Seguridad/Seguridad/seguridad.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogoConfirmacionComponent } from '../../../componentes/dialogoConfirmacion/dialogo-confirmacion/dialogo-confirmacion.component';
import { datosCerrarSesion } from '../../../../Modelo/DatosDialogoConfirmacion';

@Component({
  selector: 'menu-supervisor',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, RouterLink, CommonModule],
  templateUrl: './menu-supervisor.component.html',
  styleUrls: ['./menu-supervisor.component.css']
})
export class MenuSupervisorComponent {
  constructor() { };

  private router = inject(Router);
  public seguridadService = inject(SeguridadService);
  private modalAbierto: boolean = false;
  private cuadroDialogo = inject(MatDialog);

  irAEditar(id: string) {    
    this.router.navigate(['/editar-reporte', id]);
  }

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



}
