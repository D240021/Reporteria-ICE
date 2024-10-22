import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { RouterLink } from '@angular/router';
import { LineaTransmision } from '../../../../Modelo/lineaTransmision';

@Component({
  selector: 'editar-linea-transmision',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, BuscadorComponent, RouterLink],
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


  procesarBusqueda(identificadorBuscado: string): void {

    const lineaEncontrada = this.lineasQuemadas.find((linea) =>
      identificadorBuscado == linea.identificador);
    lineaEncontrada ? this.formularioVisible = true : undefined;
    return;
  }

}
