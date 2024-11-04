import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { ValidacionesService } from '../../../../Util/Validaciones/validaciones.service';
import { LineaTransmisionService } from '../../../../Controlador/LineaTransmision/linea-transmision.service';
import { LineaTransmision } from '../../../../Modelo/LineaTransmision';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'agregar-linea-transmision',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule, MatInputModule],
  templateUrl: './agregar-linea-transmision.component.html',
  styleUrl: './agregar-linea-transmision.component.css'
})
export class AgregarLineaTransmisionComponent {

  private formBuilder = inject(FormBuilder);
  private validaciones = inject(ValidacionesService)
  public accionesFormulario = inject(FormulariosService);
  private lineaTransmision = inject(LineaTransmisionService);

  public contenedorFormulario = this.formBuilder.group({
    id: [0],
    nombreUbicacion: ['', { validators: [Validators.required, this.validaciones.esSoloLetras()] }],
    identificador: ['', { validators: [Validators.required] }]
  });

  registrarLineaTransmision(){
    const valoresFormulario = this.contenedorFormulario.value as LineaTransmision;

    this.lineaTransmision.crearLineaTransmision(valoresFormulario).subscribe( lineaTransmision => {
      this.accionesFormulario.limpiarFormulario(this.contenedorFormulario);
    });
  }

}
