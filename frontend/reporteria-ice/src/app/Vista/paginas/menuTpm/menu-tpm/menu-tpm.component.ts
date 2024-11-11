import { Component, inject, OnInit } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';
import { CrearReporteComponent } from "../../crearReporte/crear-reporte/crear-reporte.component";
import { Usuario } from '../../../../Modelo/Usuario';
import { SeguridadService } from '../../../../Seguridad/Seguridad/seguridad.service';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { DialogoConfirmacionComponent } from '../../../componentes/dialogoConfirmacion/dialogo-confirmacion/dialogo-confirmacion.component';
import { datosCerrarSesion, datosConfirmacionSesionSinGuardar } from '../../../../Modelo/DatosDialogoConfirmacion';
import { InformeService } from '../../../../Controlador/Informe/informe.service';
import { Informe } from '../../../../Modelo/Informe';
import { MatCardModule } from '@angular/material/card';
import { AnimacionCargaComponent } from "../../../componentes/animacionCarga/animacion-carga/animacion-carga.component";
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';

@Component({
  selector: 'menu-tpm',
  standalone: true,
  imports: [MatTabsModule, CrearReporteComponent, MatButtonModule, MatCardModule, AnimacionCargaComponent, MatIconModule],
  templateUrl: './menu-tpm.component.html',
  styleUrl: './menu-tpm.component.css'
})
export class MenuTpmComponent implements OnInit {

  ngOnInit(): void {
    this.usuarioIngresado = this.seguridadService.obtenerInformacionUsuarioLogeado();

    const subestacionId = this.usuarioIngresado.subestacionId || 0;

    this.informeService.obtenerInformesPendientesPorSubestacion(subestacionId).subscribe(informes => {
      this.informes = informes;
    });

  }

  public seguridadService = inject(SeguridadService);
  public usuarioIngresado !: Usuario
  private cuadroDialogo = inject(MatDialog);
  private modalAbierto: boolean = false;
  private informeService = inject(InformeService);
  public informes: Informe[] = [];
  private router = inject(Router);


  abrirCuadroDialogo(): void {


    if (!this.modalAbierto) {
      this.modalAbierto = true;
      const dialogRef = this.cuadroDialogo.open(DialogoConfirmacionComponent, {
        width: '400px',
        height: '200px',
        data: datosConfirmacionSesionSinGuardar
      });
      dialogRef.afterClosed().subscribe(result => {
        this.modalAbierto = false;
      });
    }
  }

  abrirEditarInforme(informe : Informe) : void {
    this.router.navigate(['/editar-reporte-tpm'], { state: { informe: informe } });
    return;
  }
}
