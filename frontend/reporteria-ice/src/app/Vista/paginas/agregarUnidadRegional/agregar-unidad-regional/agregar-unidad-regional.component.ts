import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { ValidacionesService } from '../../../../Util/Validaciones/validaciones.service';

@Component({
  selector: 'agregar-unidad-regional',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './agregar-unidad-regional.component.html',
  styleUrl: './agregar-unidad-regional.component.css'
})
export class AgregarUnidadRegionalComponent {

  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);
  private validaciones = inject(ValidacionesService)


  public contenedorFormulario = this.formBuilder.group({
    identificador: ['', {validators: [Validators.required]}],
    nombre: ['', {validators: [Validators.required, this.validaciones.esSoloLetras()]}],
    supervisorAsignado: ['', {validators: [Validators.required]}],
    subestaciones: ['', {validators: [Validators.required]}],
  });

}
