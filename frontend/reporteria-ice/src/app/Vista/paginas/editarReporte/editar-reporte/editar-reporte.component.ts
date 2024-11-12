import { Component, inject, OnInit } from '@angular/core';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { RouterLink } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { ReporteService } from '../../../../Controlador/Reporte/reporte.service';
import { Reporte } from '../../../../Modelo/Reporte';

@Component({
  selector: 'editar-reporte',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './editar-reporte.component.html',
  styleUrls: ['./editar-reporte.component.css']
})
export class EditarReporteComponent implements OnInit {

  ngOnInit(): void {
    
  }

  formularioVisible!: boolean;

  // Datos quemados de ejemplo
  datosQuemados = [
    { identificador: 'RPT001', nombre: 'Falla Rio Macho' },
    { identificador: 'RPT002', nombre: 'Falla Orosi' },
  ];

  reportesQuemados: any[] = [
    {
      mapaDescargas: 'descarga_rio_macho.png',
      cuadrilla: 'Cuadrilla 1',
      subestacion: 'Subestación Rio Macho',
      observaciones: 'Reparación de línea.',
      identificador: 'RPT001'
    },
    {
      mapaDescargas: 'descarga_orosi.png',
      cuadrilla: 'Cuadrilla 2',
      subestacion: 'Subestación Orosi',
      observaciones: 'Mantenimiento preventivo.',
      identificador: 'RPT002'
    }
  ];

  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);
  
  public contenedorFormulario = this.formBuilder.group({
    mapaDescargas: [null, Validators.required],
    cuadrilla: ['', Validators.required],
    subestacion: ['', Validators.required],
    observaciones: ['', Validators.required]
  });

  // Procesar búsqueda para mostrar el formulario
  procesarBusqueda(identificadorBuscado: string): void {
    const reporteEncontrado = this.reportesQuemados.find((reporte) =>
      identificadorBuscado === reporte.identificador);
    if (reporteEncontrado) {
      this.formularioVisible = true;
      this.contenedorFormulario.patchValue({
        mapaDescargas: reporteEncontrado.mapaDescargas,
        cuadrilla: reporteEncontrado.cuadrilla,
        subestacion: reporteEncontrado.subestacion,
        observaciones: reporteEncontrado.observaciones
      });
    } else {
      this.formularioVisible = false;
    }
  }

  
}
