import { Component, inject } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'editar-reporte-tlt',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './editar-reporte-tlt.component.html',
  styleUrls: ['./editar-reporte-tlt.component.css']
})
export class EditarReporteTLTComponent {

  // Inyección de dependencias
  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);

  // Definición del formulario reactivo
  public contenedorFormulario = this.formBuilder.group({
    ubicacion: ['', { validators: [Validators.required] }],
    evidencia: ['', { validators: [Validators.required] }],
    subestacion: ['Subestación Rio Macho', { validators: [Validators.required] }],
    causa1: [false],
    fechaHora: ['', { validators: [Validators.required] }],
    observaciones: ['', { validators: [Validators.required] }]
  });
  

  // Método para limpiar el formulario
  limpiarFormulario(): void {
    this.accionesFormulario.limpiarFormulario(this.contenedorFormulario);
  }


}

