import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'editar-reporte',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './editar-reporte.component.html',
  styleUrls: ['./editar-reporte.component.css']
})
export class EditarReporteComponent {

  // Inyectamos FormBuilder para crear el formulario reactivo
  private formBuilder = inject(FormBuilder);

  // Creamos el formulario reactivo con validaciones
  public contenedorFormulario: FormGroup = this.formBuilder.group({
    mapaDescargas: [null, Validators.required],
    cuadrilla: ['', Validators.required],
    subestacion: ['', Validators.required],
    observaciones: ['', Validators.required]
  });

  public accionesFormulario = {
    limpiarFormulario: (form: FormGroup) => {
      form.reset();
    }
  };
  
}
