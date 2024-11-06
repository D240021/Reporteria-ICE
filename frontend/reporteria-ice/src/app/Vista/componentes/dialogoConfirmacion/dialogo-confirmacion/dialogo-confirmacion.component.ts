import { Component, inject, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { RouterLink } from '@angular/router';
import { DatosConfirmacion } from '../../../../Modelo/DatosDialogoConfirmacion';
import { SeguridadService } from '../../../../Seguridad/Seguridad/seguridad.service';

@Component({
  selector: 'dialogo-confirmacion',
  standalone: true,
  imports: [RouterLink, MatDialogModule],
  templateUrl: './dialogo-confirmacion.component.html',
  styleUrl: './dialogo-confirmacion.component.css'
})
export class DialogoConfirmacionComponent {

  public datosComponente : DatosConfirmacion;
  public seguridadService = inject(SeguridadService);

  constructor(public referenciaDialogo: MatDialogRef<DialogoConfirmacionComponent>,
    @Inject(MAT_DIALOG_DATA) public datos: DatosConfirmacion
  ) {
    this.datosComponente = datos;
  }

  cerrarCuadroDialogo() {
    this.referenciaDialogo.close();
  }

  salirCuadroDialogo(){
    this.seguridadService.cerrarSesion();
    this.cerrarCuadroDialogo();
  }
}
