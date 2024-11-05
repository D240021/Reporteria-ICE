import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ValidacionesService } from '../../../../Util/Validaciones/validaciones.service';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { SubestacionService } from '../../../../Controlador/Subestacion/subestacion.service';
import { Subestacion } from '../../../../Modelo/Subestacion';
import { UnidadRegionalService } from '../../../../Controlador/UnidadRegional/unidad-regional.service';
import { UnidadRegional } from '../../../../Modelo/unidadRegional';

@Component({
  selector: 'agregar-subestacion',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './agregar-subestacion.component.html',
  styleUrl: './agregar-subestacion.component.css'
})
export class AgregarSubestacionComponent implements OnInit{
  
  ngOnInit(): void {
   
    this.unidadRegionalService.obtenerUnidadesRegionales().subscribe(unidadesRegionales => {
      this.unidadesRegionales = unidadesRegionales;
    });

  }

  private formBuilder = inject(FormBuilder);
  private validaciones = inject(ValidacionesService)
  public accionesFormulario = inject(FormulariosService);
  private subestacionService = inject(SubestacionService);
  private unidadRegionalService = inject(UnidadRegionalService);
  public unidadesRegionales : UnidadRegional[] = [];

  public contenedorFormulario = this.formBuilder.group({
    id: [0],
    nombreUbicacion: ['', { validators: [Validators.required, this.validaciones.esSoloLetras()] }],
    identificador: ['', { validators: [Validators.required] }],
    unidadRegionalId: [0, { validators: [Validators.required] }]
  });

  registrarSubestacion(){
    const valoresFormulario = this.contenedorFormulario.value as Subestacion;

    this.subestacionService.crearSubestacion(valoresFormulario).subscribe( subestacion => {
      this.accionesFormulario.limpiarFormulario(this.contenedorFormulario);
    });
  }

}
