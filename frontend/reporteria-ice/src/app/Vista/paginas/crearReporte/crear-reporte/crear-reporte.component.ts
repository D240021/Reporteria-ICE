import { Component, inject } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'crear-reporte',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './crear-reporte.component.html',
  styleUrl: './crear-reporte.component.css'
})
export class CrearReporteComponent {

  // Inyección de dependencias
  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);

 

}
