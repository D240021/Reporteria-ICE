import { Component, inject } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';


@Component({
  selector: 'agregar-supervisor',
  standalone: true,
  imports: [RouterLink, MatButtonModule, ReactiveFormsModule],
  templateUrl: './agregar-supervisor.component.html',
  styleUrl: './agregar-supervisor.component.css'
})
export class AgregarSupervisorComponent {

  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);

  public contenedorFormulario = this.formBuilder.group({
    identificador: ['', {validators: [Validators.required]}],
    nombreUsuario: ['', {validators: [Validators.required]}],
    contrasenia: ['', {validators: [Validators.required]}],
    nombre: ['', {validators: [Validators.required]}],
    apellidos: ['', {validators: [Validators.required]}],
    correo:  ['', {validators: [Validators.required]}]
  });



}
