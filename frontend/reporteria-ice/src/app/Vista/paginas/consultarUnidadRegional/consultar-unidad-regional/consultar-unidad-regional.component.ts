import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { UnidadRegional } from '../../../../Modelo/unidadRegional';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'consultar-unidad-regional',
  standalone: true,
  imports: [MatTableModule, BuscadorComponent, MatInputModule, RouterLink],
  templateUrl: './consultar-unidad-regional.component.html',
  styleUrl: './consultar-unidad-regional.component.css'
})
export class ConsultarUnidadRegionalComponent {


  public unidadesQuemadas : UnidadRegional[] = [
    {
      identificador: 'DFs52',
      nombreUbicacion: 'Daniel',
      subestaciones: ['Orosí', 'Alajuela']
    },
    {
      identificador: 'DFs52',
      nombreUbicacion: 'Daniel',
      subestaciones: ['Orosí', 'Alajuela']
    },
    {
      identificador: 'DFs52',
      nombreUbicacion: 'Daniel',
      subestaciones: ['Orosí', 'Alajuela']
    }
  ]

  public filtros : any[] = [
    {
      nombre : 'Identificador'
    },
    {
      nombre : 'Nombre ubicación'
    },
    {
      nombre : 'Subestación'
    },
    
  ]


  public atributosUnidad = ['IDENTIFICADOR', 'NOMBRE DE UBICACIÓN', 'SUBESTACIONES'];

}
