import { Component } from '@angular/core';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { MatInputModule } from '@angular/material/input';
import { Supervisor } from '../../../../Modelo/supervisor';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'editar-supervisor',
  standalone: true,
  imports: [BuscadorComponent, RouterLink],
  templateUrl: './editar-supervisor.component.html',
  styleUrl: './editar-supervisor.component.css'
})
export class EditarSupervisorComponent {


  formularioVisible!: boolean;

  datosQuemados = [
    { identificador: 'SWFR945', nombre: 'Saúl'},
    { identificador: 'ST49987', nombre: 'Daniel' },
  ];

  tecnicosQuemados: any[] = [
    {
      nombreUsuario : 'D242001',
      contrasenia : '12245sff',
      nombre : 'Daniel',
      apellidos: 'Barrantes',
      identificador: 'ST49987'
      
    },
    {
      nombreUsuario : 'D242001',
      contrasenia : '12245sff',
      nombre : 'Saúl',
      apellidos: 'Madrigal',
      identificador: 'SWFR945'
      
    }
  ]


  procesarBusqueda(identificadorBuscado: string): void {

    const identificadorEncontrado = this.tecnicosQuemados.find((supervisor) =>
      identificadorBuscado == supervisor.identificador);
    identificadorEncontrado ? this.formularioVisible = true : undefined;
    return;
  }


}
