import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { RouterLink } from '@angular/router';
import { Usuario } from '../../../../Modelo/Usuario';
import { SeguridadService } from '../../../../Seguridad/Seguridad/seguridad.service';
import { Reporte } from '../../../../Modelo/Reporte';

@Component({
  selector: 'editar-reporte-tlt',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './editar-reporte-tlt.component.html',
  styleUrls: ['./editar-reporte-tlt.component.css']
})
export class EditarReporteTLTComponent implements OnInit {

  public reporteATrabajar !: Reporte;

  ngOnInit(): void {

    this.reporteATrabajar = history.state.reporte;
    this.usuarioIngresado = this.seguridadService.obtenerInformacionUsuarioLogeado();
    console.log(this.reporteATrabajar);

  }


  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);
  public usuarioIngresado !: Usuario;
  private seguridadService = inject(SeguridadService);
  public contenedorFormulario = this.formBuilder.group({
    ubicacion: ['', { validators: [Validators.required] }],
    evidencia: ['', { validators: [Validators.required] }],
    subestacion: ['Subestación Rio Macho', { validators: [Validators.required] }],
    causa1: [false],
    fechaHora: ['', { validators: [Validators.required] }],
    observaciones: ['', { validators: [Validators.required] }]
  });





}

