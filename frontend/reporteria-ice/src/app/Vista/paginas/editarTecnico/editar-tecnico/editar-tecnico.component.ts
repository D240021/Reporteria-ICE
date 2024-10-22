import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { RouterLink } from '@angular/router';
import { Tecnico } from '../../../../Modelo/tecnico';

@Component({
  selector: 'editar-tecnico',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, BuscadorComponent, RouterLink],
  templateUrl: './editar-tecnico.component.html',
  styleUrl: './editar-tecnico.component.css'
})
export class EditarTecnicoComponent {

  formularioVisible!: boolean;

  datosQuemados = [
    { nombre: 'D242001'},
    { nombre: 'STF46' },
  ];

  tecnicosQuemados: Tecnico[] = [
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


  procesarBusqueda(nombreUsuarioBuscado: string): void {

    const tecnicoEncontrado = this.tecnicosQuemados.find((tecnico) =>
      nombreUsuarioBuscado == tecnico.nombreUsuario);
    tecnicoEncontrado ? this.formularioVisible = true : undefined;
    return;
  }


}
