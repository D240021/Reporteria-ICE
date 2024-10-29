import { Component, inject } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { Supervisor } from '../../../../Modelo/supervisor';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'consultar-operario',
  standalone: true,
  imports: [MatTableModule, MatInputModule, RouterLink, ReactiveFormsModule, MatButtonModule, MatIconModule],
  templateUrl: './consultar-operario.component.html',
  styleUrl: './consultar-operario.component.css'
})
export class ConsultarOperarioComponent {

  public supervisoresQuemados: Supervisor[] = [
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

  public filtros: any[] = [
    {
      nombre: 'Identificador'
    },
    {
      nombre: 'Nombre'
    },
    {
      nombre: 'Apellidos'
    },
    {
      nombre: 'Unidad Regional'
    },
  ]


  public atributosOperador = ['IDENTIFICADOR','NOMBRE', 'APELLIDOS', 'NOMBRE DE USUARIO', 'CORREO',
    'UNIDAD REGIONAL', 'OCUPACIÓN', 'GESTIÓN'];

  private formBuilder = inject(FormBuilder);


  public contenedorFormulario = this.formBuilder.group({
    valor: ['', { validators: [Validators.required] }],
    filtro: ['', { validators: [Validators.required] }]
  });

}
