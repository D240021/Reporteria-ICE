import { Component } from '@angular/core';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { MatTableModule } from '@angular/material/table';
import { LineaTransmision } from '../../../../Modelo/lineaTransmision';
import { RouterLink } from '@angular/router';
import { MatInputModule } from '@angular/material/input';


@Component({
  selector: 'consultar-linea-transmision',
  standalone: true,
  imports: [BuscadorComponent, MatTableModule, RouterLink, MatInputModule],
  templateUrl: './consultar-linea-transmision.component.html',
  styleUrl: './consultar-linea-transmision.component.css'
})
export class ConsultarLineaTransmisionComponent {

  public lineasQuemadas: LineaTransmision[] = [
    {
      identificador: 'DFs52',
      nombre: 'Orosí',
      
    },
    {
      identificador: 'DFs52',
      nombre: 'Turrialba',
      
    },
    {
      identificador: 'DFs52',
      nombre: 'Desamparados',
      
    }
  ]

  public filtros: any[] = [
    {
      nombre: 'Identificador'
    },
    {
      nombre: 'Nombre de ubicación'
    },
    
  ]


  public atributosLinea = ['IDENTIFICADOR', 'NOMBRE DE UBICACIÓN'];


}
