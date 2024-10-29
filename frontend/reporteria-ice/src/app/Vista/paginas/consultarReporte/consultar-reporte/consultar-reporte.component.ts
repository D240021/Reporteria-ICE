import { Component, inject } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

// Definimos la estructura de los reportes
interface Reporte {
  identificador: string;
  fecha: string;
  subestaciones: string;
  lineaTransmision: string;
}

@Component({
  selector: 'consultar-reporte',
  standalone: true,
  imports: [MatTableModule, MatInputModule, RouterLink, ReactiveFormsModule],
  templateUrl: './consultar-reporte.component.html',
  styleUrls: ['./consultar-reporte.component.css']
})
export class ConsultarReporteComponent {

  // Datos quemados de ejemplo para los reportes
  public reportesQuemados: Reporte[] = [
    {
      identificador: 'RPT001',
      fecha: '2023-10-01',
      subestaciones: 'Subestación A',
      lineaTransmision: 'Línea 1'
    },
    {
      identificador: 'RPT002',
      fecha: '2023-10-02',
      subestaciones: 'Subestación B',
      lineaTransmision: 'Línea 2'
    },
    {
      identificador: 'RPT003',
      fecha: '2023-10-03',
      subestaciones: 'Subestación C',
      lineaTransmision: 'Línea 3'
    }
  ];


  public atributosReporte = ['IDENTIFICADOR', 'FECHA', 'SUBESTACIONES', 'LÍNEA DE TRANSMISIÓN'];


  private formBuilder = inject(FormBuilder);


  public contenedorFormulario = this.formBuilder.group({
    valor: ['', { validators: [Validators.required] }],
    filtro: ['', { validators: [Validators.required] }]
  });

}
