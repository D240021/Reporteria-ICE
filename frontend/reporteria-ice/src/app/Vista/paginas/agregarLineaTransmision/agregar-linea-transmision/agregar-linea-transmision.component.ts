import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { ValidacionesService } from '../../../../Util/Validaciones/validaciones.service';

@Component({
  selector: 'agregar-linea-transmision',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './agregar-linea-transmision.component.html',
  styleUrl: './agregar-linea-transmision.component.css'
})
export class AgregarLineaTransmisionComponent {

  private formBuilder = inject(FormBuilder);
  private validaciones = inject(ValidacionesService)
  public accionesFormulario = inject(FormulariosService);

  public contenedorFormulario = this.formBuilder.group({
    identificador: ['', { validators: [Validators.required] }],
    nombreUbicacion: ['', { validators: [Validators.required, this.validaciones.esSoloLetras()] }]
  });

}
