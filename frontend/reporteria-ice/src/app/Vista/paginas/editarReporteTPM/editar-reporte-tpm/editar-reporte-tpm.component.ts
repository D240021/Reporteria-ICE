import { Component, inject, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CorrientesDeFallaInforme, DatosDeLineaInforme, DatosGeneralesInforme, DistanciaFallaInforme, HoraInforme, Informe, TeleproteccionInforme, TiemposDeDisparoInforme } from '../../../../Modelo/Informe';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormulariosService } from '../../../../Util/Formularios/formularios.service';
import { SubestacionService } from '../../../../Controlador/Subestacion/subestacion.service';
import { Usuario } from '../../../../Modelo/Usuario';
import { SeguridadService } from '../../../../Seguridad/Seguridad/seguridad.service';
import { Subestacion } from '../../../../Modelo/subestacion';
import { AnimacionCargaComponent } from '../../../componentes/animacionCarga/animacion-carga/animacion-carga.component';
import { Reporte } from '../../../../Modelo/Reporte';
import { InformeService } from '../../../../Controlador/Informe/informe.service';

@Component({
  selector: 'app-editar-reporte-tpm',
  standalone: true,
  imports: [RouterLink, AnimacionCargaComponent, ReactiveFormsModule],
  templateUrl: './editar-reporte-tpm.component.html',
  styleUrl: './editar-reporte-tpm.component.css'
})
export class EditarReporteTPMComponent implements OnInit {

  public informeATrabajar !: Informe;
  public subestacionAsociada !: Subestacion;
  public reporteAsociado !: Reporte;

  ngOnInit(): void {
    this.informeATrabajar = history.state.informe;
    console.log(this.informeATrabajar);
    this.usuarioIngresado = this.seguridadService.obtenerInformacionUsuarioLogeado();

    this.subestacionAsociadaId = this.usuarioIngresado.subestacionId || 0;
    const informeId = this.informeATrabajar.id;

    this.subestacionService.obtenerSubestacionPorId(this.subestacionAsociadaId).subscribe(subestacion => {
      this.subestacionAsociada = subestacion;
    });

    // this.informeService.obtenerReportePorInformeId(informeId).subscribe(reporte => {
    //   this.reporteAsociado = reporte;
    //   console.log(this.reporteAsociado);
    // });

  }
  private subestacionAsociadaId !: number;
  private formBuilder = inject(FormBuilder);
  public accionesFormulario = inject(FormulariosService);
  private subestacionService = inject(SubestacionService);
  public usuarioIngresado !: Usuario;
  private seguridadService = inject(SeguridadService);
  private informeService = inject(InformeService);
  public contenedorFormulario = this.formBuilder.group({
    id: [''],
    tipo: ['', {validators: [Validators.required]}],
    evento: [''],
    fecha: [''],
    hora: [''],
    subestacion: [''],
    lt: [''],
    equipo: [''],
    ot: [''],
    aviso: [''],
    sap: [''],
    distancia: [''],
    funcion: [''],
    zona: [''],
    realR: [''],
    realS: [''],
    realT: [''],
    acumuladaR: [''],
    acumuladaS: [''],
    acumuladaT: [''],
    r: [''],
    s: [''],
    t: [''],
    reserva: [''],
    distanciaKm: [''],
    distanciaPor: [''],
    distanciaReportada: [''],
    distanciaDobleTemporal: [''],
    errorDobleTerminal: [''],
    error: [''],
    errorDoble: [''],
    txTel: [''],
    rxTel: [''],
    tiempoMpls: [''],
  });

  construirObjetoInforme(): Informe {

    const tipoValor = this.contenedorFormulario.value.tipo || '0';
    const lineaTransmisionId = this.informeATrabajar.lineaTransmisionId || 0;
    const datosDelineaId = this.informeATrabajar.datosDeLineaId || 0;
    const datosGeneralesId = this.informeATrabajar.datosGeneralesId || 0;
    const fechaISO = this.contenedorFormulario.value.fecha ? new Date(this.contenedorFormulario.value.fecha) : new Date();
    const teleproteccionId = this.informeATrabajar.teleproteccionId || 0;
    const distanciaDeFallaId = this.informeATrabajar.distanciaDeFallaId || 0;
    const tiemposDeDisparoId = this.informeATrabajar.tiemposDeDisparoId || 0;
    const corrientesDeFallaId = this.informeATrabajar.corrientesDeFallaId || 0;

    const horaObjeto: HoraInforme = {
      ticks: Date.now()
    }

    const datosDeLineaObjeto: DatosDeLineaInforme = {
      id: datosDelineaId,
      ot: this.contenedorFormulario.value.ot || '',
      aviso: this.contenedorFormulario.value.aviso || '',
      sap: this.contenedorFormulario.value.sap || '',
      distancia: this.contenedorFormulario.value.distancia || '',
      funcion: this.contenedorFormulario.value.funcion || '',
      zona: this.contenedorFormulario.value.zona || '',
    }

    const datosGeneralesObjeto: DatosGeneralesInforme = {
      id: datosGeneralesId,
      evento: this.contenedorFormulario.value.evento || '',
      fecha: fechaISO.toISOString(),
      hora: horaObjeto,
      subestacion: this.contenedorFormulario.value.subestacion || '',
      lt: this.contenedorFormulario.value.lt || '',
      equipo: this.contenedorFormulario.value.equipo || ''
    }

    const teleproteccionObjeto: TeleproteccionInforme = {
      id: teleproteccionId,
      tX_TEL: this.contenedorFormulario.value.txTel || '',
      rX_TEL: this.contenedorFormulario.value.rxTel || '',
      tiempoMPLS: this.contenedorFormulario.value.tiempoMpls || ''
    }

    const distanciaFallaObjeto: DistanciaFallaInforme = {
      id: distanciaDeFallaId,
      distanciaKM: this.contenedorFormulario.value.distanciaKm || '',
      distanciaPorcentaje: this.contenedorFormulario.value.distanciaPor || '',
      distanciaReportada: this.contenedorFormulario.value.distanciaReportada || '',
      distanciaDobleTemporal: this.contenedorFormulario.value.distanciaDobleTemporal || '',
      error: this.contenedorFormulario.value.error || '',
      error_Doble: this.contenedorFormulario.value.errorDoble || '',
    }

    const tiempoDeDisparoObjeto: TiemposDeDisparoInforme = {
      id: tiemposDeDisparoId,
      r: this.contenedorFormulario.value.r || '',
      s: this.contenedorFormulario.value.s || '',
      t: this.contenedorFormulario.value.t || '',
      reserva: this.contenedorFormulario.value.reserva || ''
    }

    const corrientesDeFallaObjeto: CorrientesDeFallaInforme = {
      id: corrientesDeFallaId,
      realIR: this.contenedorFormulario.value.realR || '',
      realIS: this.contenedorFormulario.value.realS || '',
      realIT: this.contenedorFormulario.value.realT || '',
      acumuladaR: this.contenedorFormulario.value.acumuladaR || '',
      acumuladaS: this.contenedorFormulario.value.acumuladaS || '',
      acumuladaT: this.contenedorFormulario.value.acumuladaT || ''
    }

    const informeResultado: Informe = {
      id: this.informeATrabajar.id,
      tipo: parseInt(tipoValor, 10),
      subestacionId: this.subestacionAsociadaId,
      lineaTransmisionId: lineaTransmisionId,
      datosDeLineaId: datosDelineaId,
      datosDeLinea: datosDeLineaObjeto,
      datosGeneralesId: datosGeneralesId,
      datosGenerales: datosGeneralesObjeto,
      teleproteccionId: teleproteccionId,
      teleproteccion: teleproteccionObjeto,
      distanciaDeFallaId: distanciaDeFallaId,
      distanciaDeFalla: distanciaFallaObjeto,
      tiemposDeDisparoId: tiemposDeDisparoId,
      tiemposDeDisparo: tiempoDeDisparoObjeto,
      corrientesDeFallaId: corrientesDeFallaId,
      corrientesDeFalla: corrientesDeFallaObjeto,
      estado: 1
    }

    return informeResultado;
  }

  guardarCambios(): void {


  }

}
