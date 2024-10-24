import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'agregar-tecnico',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule, MatButtonModule],
  templateUrl: './agregar-tecnico.component.html',
  styleUrl: './agregar-tecnico.component.css'
})
export class AgregarTecnicoComponent {

  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);

  public contenedorFormulario = this.formBuilder.group({
    nombreUsuario: ['', {validators: [Validators.required]}],
    contrasenia: ['', {validators: [Validators.required]}],
    tipo: ['', {validators: [Validators.required]}],
    unidadRegional: ['', {validators: [Validators.required]}],
  });



}
