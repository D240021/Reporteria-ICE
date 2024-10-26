import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { RouterLink } from '@angular/router';
import { LineaTransmision } from '../../../../Modelo/lineaTransmision';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ValidacionesService } from '../../../../Util/Validaciones/validaciones.service';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';

@Component({
  selector: 'editar-linea-transmision',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, BuscadorComponent, RouterLink, ReactiveFormsModule],
  templateUrl: './editar-linea-transmision.component.html',
  styleUrl: './editar-linea-transmision.component.css'
})
export class EditarLineaTransmisionComponent {


  formularioVisible!: boolean;

  datosQuemados = [
    { nombre: 'Orosí', identificador: 'S7492' },
    { nombre: 'Turrialba', identificador: 'S7T92' },
  ];

  lineasQuemadas: LineaTransmision[] = [
    {
      identificador: 'S7492',
      nombre: 'Turrialba'
    },
    {
      identificador: 'S7T92',
      nombre: 'San José'
    },
  ]

  private formBuilder = inject(FormBuilder);
  private validaciones = inject(ValidacionesService)
  public accionesFormulario = inject(FormulariosService)
  public contenedorFormulario = this.formBuilder.group({
    nombreUbicacion: ['', { validators: [Validators.required, this.validaciones.esSoloLetras()] }]
  });


  procesarBusqueda(identificadorBuscado: string): void {

    const lineaEncontrada = this.lineasQuemadas.find((linea) =>
      identificadorBuscado == linea.identificador);
    lineaEncontrada ? this.formularioVisible = true : undefined;
    return;
  }

}
