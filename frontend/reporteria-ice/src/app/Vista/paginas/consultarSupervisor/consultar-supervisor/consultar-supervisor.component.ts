import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { Supervisor } from '../../../../Modelo/supervisor';
import { MatInputModule } from '@angular/material/input';

//Componentes
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';




@Component({
  selector: 'consultar-supervisor',
  standalone: true,
  imports: [MatTableModule, MatInputModule, BuscadorComponent],
  templateUrl: './consultar-supervisor.component.html',
  styleUrl: './consultar-supervisor.component.css'
})
export class ConsultarSupervisorComponent {

  supervisoresQuemados : Supervisor[] = [
    {
      identificador: 'DFs52',
      nombre: 'Daniel',
      apellidos: 'Barrantes Quirós',
      unidadRegional: 'Guápiles'
    },
    {
      identificador: 'DFs52',
      nombre: 'Daniel',
      apellidos: 'Barrantes Quirós',
      unidadRegional: 'Guápiles'
    },
    {
      identificador: 'DFs52',
      nombre: 'Daniel',
      apellidos: 'Barrantes Quirós',
      unidadRegional: 'Guápiles'
    }
  ]

  columnasTabla = ['IDENTIFICADOR', 'NOMBRE', 'APELLIDOS', 'UNIDAD REGIONAL'];

}
