import { Component, inject } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { Supervisor } from '../../../../Modelo/supervisor';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';




@Component({
  selector: 'consultar-supervisor',
  standalone: true,
  imports: [MatTableModule, MatInputModule, RouterLink, ReactiveFormsModule],
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
  
  private formBuilder = inject(FormBuilder);


  public contenedorFormulario = this.formBuilder.group({
    valor: ['', {validators: [Validators.required]}],
    filtro: ['', {validators: [Validators.required]}]
  });
}
