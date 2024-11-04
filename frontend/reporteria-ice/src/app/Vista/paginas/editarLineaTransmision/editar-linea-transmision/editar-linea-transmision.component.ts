import { Component, Inject, inject } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { LineaTransmision } from '../../../../Modelo/LineaTransmision';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ValidacionesService } from '../../../../Util/Validaciones/validaciones.service';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { LineaTransmisionService } from '../../../../Controlador/LineaTransmision/linea-transmision.service';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'editar-linea-transmision',
  standalone: true,
  imports: [RouterLink, MatInputModule, ReactiveFormsModule, MatDialogModule],
  templateUrl: './editar-linea-transmision.component.html',
  styleUrl: './editar-linea-transmision.component.css'
})
export class EditarLineaTransmisionComponent {


  lineaTransmision: any;

  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);
  private validaciones = inject(ValidacionesService);
  public contenedorFormulario = this.formBuilder.group({
    id: [0],
    identificador: ['', {validators: [Validators.required]}],
    nombreUbicacion: ['', {validators: [Validators.required, this.validaciones.esSoloLetras()]}],
  });
  private lineaTransmisionService = inject(LineaTransmisionService);

  constructor(
    public referenciaDialogo: MatDialogRef<EditarLineaTransmisionComponent>,
    @Inject(MAT_DIALOG_DATA) public datos: { linea: LineaTransmision }
  ) {
    this.lineaTransmision = datos;
    this.contenedorFormulario.patchValue(this.lineaTransmision);
  }

  cerrarCuadroDialogo() {
    this.referenciaDialogo.close();
  }

  guardarCambios() {

    const nuevosDatosLineaTransmision = this.contenedorFormulario.value as LineaTransmision;

    this.lineaTransmisionService.editarLineaTransmision(nuevosDatosLineaTransmision).subscribe(respuesta => {
      this.cerrarCuadroDialogo();
    });

  }

}
