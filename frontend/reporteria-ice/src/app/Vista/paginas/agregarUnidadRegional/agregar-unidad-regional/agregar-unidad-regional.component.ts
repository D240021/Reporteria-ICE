import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { ValidacionesService } from '../../../../Util/Validaciones/validaciones.service';
import { UnidadRegionalService } from '../../../../Controlador/UnidadRegional/unidad-regional.service';
import { UnidadRegional } from '../../../../Modelo/UnidadRegional';

@Component({
  selector: 'agregar-unidad-regional',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './agregar-unidad-regional.component.html',
  styleUrl: './agregar-unidad-regional.component.css'
})
export class AgregarUnidadRegionalComponent {

  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);
  private validaciones = inject(ValidacionesService)
  private unidadRegionalService = inject(UnidadRegionalService);


  public contenedorFormulario = this.formBuilder.group({
    id: [0],
    identificador: ['', {validators: [Validators.required]}],
    nombreUbicacion: ['', {validators: [Validators.required, this.validaciones.esSoloLetras()]}],
  });

  registrarNuevaUnidadRegional(){
    const valoresFormulario = this.contenedorFormulario.value as UnidadRegional;

    this.unidadRegionalService.crearUnidadRegional(valoresFormulario).subscribe( unidadRegional => {
      this.accionesFormulario.limpiarFormulario(this.contenedorFormulario);
    });
  }

}
