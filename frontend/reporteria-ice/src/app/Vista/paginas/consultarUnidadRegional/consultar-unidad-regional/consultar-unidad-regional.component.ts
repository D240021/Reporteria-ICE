import { Component, inject, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { UnidadRegional } from '../../../../Modelo/UnidadRegional';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { UnidadRegionalService } from '../../../../Controlador/UnidadRegional/unidad-regional.service';

@Component({
  selector: 'consultar-unidad-regional',
  standalone: true,
  imports: [MatTableModule, BuscadorComponent, MatInputModule, RouterLink,
     ReactiveFormsModule, MatIconModule, MatButtonModule],
  templateUrl: './consultar-unidad-regional.component.html',
  styleUrl: './consultar-unidad-regional.component.css'
})
export class ConsultarUnidadRegionalComponent implements OnInit{
  
  public unidadesRegionales : UnidadRegional[] = [];

  ngOnInit(): void {

    this.unidadRegionalService.obtenerUnidadesRegionales().subscribe(unidadesRegionales => {
      this.unidadesRegionales = unidadesRegionales;
    })

  }

  public atributosUnidad = ['IDENTIFICADOR', 'NOMBRE DE UBICACIÓN', 'GESTIÓN'];

  private formBuilder = inject(FormBuilder);

  private unidadRegionalService = inject(UnidadRegionalService);


  public contenedorFormulario = this.formBuilder.group({
    valor: ['', {validators: [Validators.required]}],
    filtro: ['', {validators: [Validators.required]}]
  });

}
