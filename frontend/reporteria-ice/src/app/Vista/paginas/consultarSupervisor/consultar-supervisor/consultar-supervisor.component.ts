import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { Supervisor } from '../../../../Modelo/supervisor';
import { MatInputModule } from '@angular/material/input';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { RouterLink } from '@angular/router';




@Component({
  selector: 'consultar-supervisor',
  standalone: true,
  imports: [MatTableModule, MatInputModule, BuscadorComponent, RouterLink],
  templateUrl: './consultar-supervisor.component.html',
  styleUrl: './consultar-supervisor.component.css'
})
export class ConsultarSupervisorComponent {

  public supervisoresQuemados : Supervisor[] = [
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

  public filtros : any[] = [
    {
      nombre : 'Identificador'
    },
    {
      nombre : 'Nombre'
    },
    {
      nombre : 'Apellidos'
    },
    {
      nombre : 'Unidad Regional'
    },
  ]


  public atributosSupervisor = ['IDENTIFICADOR', 'NOMBRE', 'APELLIDOS', 'UNIDAD REGIONAL'];

}
