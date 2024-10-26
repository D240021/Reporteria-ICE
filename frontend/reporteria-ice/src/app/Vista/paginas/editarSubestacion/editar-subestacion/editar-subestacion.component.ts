import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { Subestacion } from '../../../../Modelo/subestacion';
import { RouterLink } from '@angular/router';
@Component({
  selector: 'editar-subestacion',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, BuscadorComponent, RouterLink],
  templateUrl: './editar-subestacion.component.html',
  styleUrl: './editar-subestacion.component.css'
})
export class EditarSubestacionComponent {

  formularioVisible!: boolean;

  datosQuemados = [
    { nombre: 'Orosí', identificador: 'S7492' },
    { nombre: 'Turrialba', identificador: 'S7T92' },
  ];

  subestacionesQuemadas: Subestacion[] = [
    {
      identificador: 'S7492',
      unidadRegional: 'Cartago',
      nombre: 'Turrialba'
    },
    {
      identificador: 'S7T92',
      unidadRegional: 'Desamparados',
      nombre: 'San José'
    },
  ]


  procesarBusqueda(identificadorBuscado: string): void {

    const subestacionEncontrada = this.subestacionesQuemadas.find((subestacion) =>
      identificadorBuscado == subestacion.identificador);
    subestacionEncontrada ? this.formularioVisible = true : undefined;
    return;
  }


}
