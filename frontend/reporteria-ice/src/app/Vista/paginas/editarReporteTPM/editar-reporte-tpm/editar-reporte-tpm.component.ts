import { Component, inject, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Informe } from '../../../../Modelo/Informe';
import { FormBuilder, Validators } from '@angular/forms';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { SubestacionService } from '../../../../Controlador/Subestacion/subestacion.service';
import { Usuario } from '../../../../Modelo/Usuario';
import { SeguridadService } from '../../../../Seguridad/Seguridad/seguridad.service';
import { Subestacion } from '../../../../Modelo/subestacion';
import { AnimacionCargaComponent } from '../../../componentes/animacionCarga/animacion-carga/animacion-carga.component';

@Component({
  selector: 'app-editar-reporte-tpm',
  standalone: true,
  imports: [RouterLink, AnimacionCargaComponent],
  templateUrl: './editar-reporte-tpm.component.html',
  styleUrl: './editar-reporte-tpm.component.css'
})
export class EditarReporteTPMComponent implements OnInit{
  
  public informe !: Informe;
  public subestacionAsociada !: Subestacion;

  ngOnInit(): void {
    this.informe = history.state.informe;
    console.log(this.informe);
    this.usuarioIngresado = this.seguridadService.obtenerInformacionUsuarioLogeado();

    const subestacionId = this.usuarioIngresado.subestacionId || 0;

    this.subestacionService.obtenerSubestacionPorId(subestacionId).subscribe(subestacion => {
      this.subestacionAsociada = subestacion;
    });
    
  }

  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);
  private subestacionService = inject(SubestacionService);
  public usuarioIngresado !: Usuario;
  private seguridadService = inject(SeguridadService);
  public contenedorFormulario = this.formBuilder.group({
    lineaTransmisionId: ['', { validators: [Validators.required] }],
    subestacionA: ['', { validators: [Validators.required] }],
    subestacionB: ['', { validators: [Validators.required] }],
    usuarioSupervisorId: ['', { validators: [Validators.required] }],
    tecnicoLineaId: ['', { validators: [Validators.required] }]
  });

}
