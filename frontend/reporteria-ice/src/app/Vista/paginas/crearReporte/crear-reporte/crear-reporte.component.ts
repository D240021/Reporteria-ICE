import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { Router, RouterLink } from '@angular/router';
import { SeguridadService } from '../../../../Seguridad/Seguridad/seguridad.service';
import { LineaTransmisionService } from '../../../../Controlador/LineaTransmision/linea-transmision.service';
import { LineaTransmision } from '../../../../Modelo/LineaTransmision';
import { Usuario } from '../../../../Modelo/Usuario';
import { SubestacionService } from '../../../../Controlador/Subestacion/subestacion.service';
import { Subestacion } from '../../../../Modelo/subestacion';
import { AnimacionCargaComponent } from '../../../componentes/animacionCarga/animacion-carga/animacion-carga.component';
import { UsuarioService } from '../../../../Controlador/Usuario/usuario.service';
import { ReporteService } from '../../../../Controlador/Reporte/reporte.service';
import { Reporte } from '../../../../Modelo/Reporte';

@Component({
  selector: 'crear-reporte',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink, AnimacionCargaComponent],
  templateUrl: './crear-reporte.component.html',
  styleUrl: './crear-reporte.component.css'
})
export class CrearReporteComponent implements OnInit {



  ngOnInit(): void {

    this.usuarioIngresado = this.seguridadService.obtenerInformacionUsuarioLogeado();

    this.lineaTransmisionService.obtenerLineasTransmision().subscribe(lineasTransmision => {
      this.lineasTransmision = lineasTransmision;
    });

    const unidadRegionalId = this.usuarioIngresado.unidadRegionalId || 0;
    this.subestacionService.obtenerSubestacionesPorUnidadRegional(unidadRegionalId).subscribe(subestaciones => {
      this.subestaciones = subestaciones;
    });

    this.usuarioService.obtenerSPRVSegunUnidadRegional(unidadRegionalId).subscribe(supervisores => {
      this.supervisores = supervisores;
    });

    this.usuarioService.obtenerTLTSegunUnidadRegional(unidadRegionalId).subscribe(tecnicosTLT => {
      this.tecnicosTLT = tecnicosTLT;
    });

  }

  public tecnicosTLT: Usuario[] = [];
  public supervisores: Usuario[] = [];
  public usuarioIngresado !: Usuario;
  public lineasTransmision: LineaTransmision[] = [];
  public subestaciones: Subestacion[] = [];
  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);
  public seguridadService = inject(SeguridadService);
  private lineaTransmisionService = inject(LineaTransmisionService);
  private subestacionService = inject(SubestacionService);
  private usuarioService = inject(UsuarioService);
  private reporteService = inject(ReporteService);

  public contenedorFormulario = this.formBuilder.group({
    lineaTransmisionId: ['', { validators: [Validators.required] }],
    subestacionA: ['', { validators: [Validators.required] }],
    subestacionB: ['', { validators: [Validators.required] }],
    usuarioSupervisorId: ['', { validators: [Validators.required] }],
    tecnicoLineaId: ['', { validators: [Validators.required] }]
  });

  generarReporte(): void {

    const subestacionesId: number[] = [
      parseInt(this.contenedorFormulario.value.subestacionA || '0', 10),
      parseInt(this.contenedorFormulario.value.subestacionB || '0', 10),
    ];

    const lineaTransmisionId: number = parseInt(this.contenedorFormulario.value.lineaTransmisionId || '0');

    const datosReporte: Reporte = {
      id: 0,
      mapaDeDescargas: '',
      observaciones: '',
      evidencia: '',
      observacionesTecnicoLinea: '',
      causas: '',
      fechaHora: new Date().toISOString(),
      informeV1Id: 0,
      informeV2Id: 0,
      informeV3Id: 0,
      informeV4Id: 0,
      usuarioSupervisorId: parseInt(this.contenedorFormulario.value.usuarioSupervisorId || '0', 10),
      tecnicoLineaId: parseInt(this.contenedorFormulario.value.tecnicoLineaId || '0', 10),
      estado: 0
    };

    console.log(Object(datosReporte));

    this.reporteService.crearReporte(datosReporte,subestacionesId,lineaTransmisionId).subscribe(respuesta => {

    });

  }


}
