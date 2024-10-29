import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { ValidacionesService } from '../../../../Util/Validaciones/validaciones.service';
import { UsuarioService } from '../../../../Controlador/Usuario/usuario.service';
import { UnidadRegionalService } from '../../../../Controlador/UnidadRegional/unidad-regional.service';
import { UnidadRegional } from '../../../../Modelo/UnidadRegional';
import { Usuario } from '../../../../Modelo/Usuario';

@Component({
  selector: 'registrar-operario',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './registrar-operario.component.html',
  styleUrl: './registrar-operario.component.css'
})
export class RegistrarOperarioComponent implements OnInit {
  
  
  ngOnInit(): void {

    this.unidadRegionalService.obtenerUnidadesRegionales().subscribe(unidadesRegionales => {
      this.unidadesRegionales = unidadesRegionales;
    });

  }

  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);
  private validaciones = inject(ValidacionesService);
  private usuarioService = inject(UsuarioService);
  private unidadRegionalService = inject(UnidadRegionalService);
  public unidadesRegionales : UnidadRegional[] = [];

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
    unidadRegionalId: [0, {validators: [Validators.required]}]
  });

  registrarNuevoUsuario() {
    const valoresFormulario: Usuario = {
      id: Number(this.contenedorFormulario.value.id) || 0,
      contrasenia: this.contenedorFormulario.value.contrasenia || '',
      nombreUsuario: this.contenedorFormulario.value.nombreUsuario || '',
      correo: this.contenedorFormulario.value.correo || '',
      nombre: this.contenedorFormulario.value.nombre || '',
      apellido: this.contenedorFormulario.value.apellido || '',
      identificador: this.contenedorFormulario.value.identificador || '',
      rol: this.contenedorFormulario.value.rol || '',
      subestacionId: Number(this.contenedorFormulario.value.subestacionId) || 0,
      unidadRegionalId: Number(this.contenedorFormulario.value.unidadRegionalId) || 0
    };
  
    this.usuarioService.crearUsuario(valoresFormulario).subscribe(usuario => {
      this.accionesFormulario.limpiarFormulario(this.contenedorFormulario);
    });
  }
  

}
