import { Component, inject } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { UnidadRegional } from '../../../../Modelo/unidadRegional';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'consultar-unidad-regional',
  standalone: true,
  imports: [MatTableModule, BuscadorComponent, MatInputModule, RouterLink, ReactiveFormsModule],
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

  private formBuilder = inject(FormBuilder);


  public contenedorFormulario = this.formBuilder.group({
    valor: ['', {validators: [Validators.required]}],
    filtro: ['', {validators: [Validators.required]}]
  });

}
