import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { ValidacionesService } from '../../../../Util/Validaciones/validaciones.service';
import { UsuarioService } from '../../../../Controlador/Usuario/usuario.service';

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
  private usuarioService = inject(UsuarioService);

  public contenedorFormulario = this.formBuilder.group({
    id: [0],
    contrasenia: ['', {validators: [Validators.required]}],
    nombreUsuario: ['', {validators: [Validators.required]}],
    correo: ['', {validators: [Validators.required, Validators.email]}],
    nombre: ['', {validators: [Validators.required, this.validaciones.esSoloLetras()]}],
    apellido: ['', {validators: [Validators.required, this.validaciones.esSoloLetras()]}],
    identificador: ['', {validators: [Validators.required]}],
    rol: ['', {validators: [Validators.required]}],
    subestacionId: [0],
    unidadRegional : ['', {validators: [Validators.required]}]
  });

  registrarNuevoUsuario(){

    const valoresFormulario = this.contenedorFormulario.value;
    // this.usuarioService.crearUsuario(valoresFormulario).subscribe( usuario => {

    // });
  }

}
