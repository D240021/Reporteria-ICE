import { Component, inject } from '@angular/core';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { RouterLink } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';

@Component({
  selector: 'editar-reporte',
  standalone: true,
  imports: [BuscadorComponent, RouterLink, ReactiveFormsModule],
  templateUrl: './editar-reporte.component.html',
  styleUrls: ['./editar-reporte.component.css']
})
export class EditarReporteComponent {

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

  // FormBuilder y FormulariosService inyectados
  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);

  // Definir el formulario con validaciones
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
