import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { ValidacionesService } from '../../../../Util/Validaciones/validaciones.service';

@Component({
  selector: 'registrar-operario',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './registrar-operario.component.html',
  styleUrl: './registrar-operario.component.css'
})
export class RegistrarOperarioComponent {

  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);
  private validaciones = inject(ValidacionesService);

  public contenedorFormulario = this.formBuilder.group({
    identificador: ['', {validators: [Validators.required]}],
    nombreUsuario: ['', {validators: [Validators.required]}],
    contrasenia: ['', {validators: [Validators.required]}],
    correo: ['', {validators: [Validators.required]}],
    nombre: ['', {validators: [Validators.required, this.validaciones.esSoloLetras()]}],
    apellidos: ['', {validators: [Validators.required, this.validaciones.esSoloLetras()]}],
    tipo: ['', {validators: [Validators.required]}],
    unidadRegional : ['', {validators: [Validators.required]}]
  });

}
