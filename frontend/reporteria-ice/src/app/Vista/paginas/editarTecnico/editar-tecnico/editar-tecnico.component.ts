import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { RouterLink } from '@angular/router';
import { Tecnico } from '../../../../Modelo/tecnico';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';

@Component({
  selector: 'editar-tecnico',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, BuscadorComponent, RouterLink, ReactiveFormsModule],
  templateUrl: './editar-tecnico.component.html',
  styleUrl: './editar-tecnico.component.css'
})
export class EditarTecnicoComponent {

  public formularioVisible!: boolean;

  public datosQuemados = [
    { nombre: 'D242001'},
    { nombre: 'STF46' },
  ];

  public tecnicosQuemados: Tecnico[] = [
    {
      nombreUsuario : 'D242001',
      contrasenia : '12245sff',
      tipo : 'TPM',
      unidadRegional : 'Desamparados'
    },
    {
      nombreUsuario : 'D242001',
      contrasenia : '12245sff',
      tipo : 'TLT',
      unidadRegional : 'Orosi'
    },
  ]

  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);

  public contenedorFormulario = this.formBuilder.group({
    nombreUsuario: ['', {validators: [Validators.required]}],
    contrasenia: ['', {validators: [Validators.required]}],
    unidadRegional: ['', {validators: [Validators.required]}],
  });


  procesarBusqueda(nombreUsuarioBuscado: string): void {

    const tecnicoEncontrado = this.tecnicosQuemados.find((tecnico) =>
      nombreUsuarioBuscado == tecnico.nombreUsuario);
    tecnicoEncontrado ? this.formularioVisible = true : undefined;
    return;
  }


}
