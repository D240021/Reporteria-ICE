import { Component, inject, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { Supervisor } from '../../../../Modelo/supervisor';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Usuario } from '../../../../Modelo/Usuario';
import { UsuarioService } from '../../../../Controlador/Usuario/usuario.service';
import { UnidadRegionalService } from '../../../../Controlador/UnidadRegional/unidad-regional.service';
import { UnidadRegional } from '../../../../Modelo/UnidadRegional';
import { EditarOperarioComponent } from "../../editarOperario/editar-operario/editar-operario.component";
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
@Component({
  selector: 'consultar-operario',
  standalone: true,
  imports: [MatTableModule, MatInputModule, RouterLink,
    ReactiveFormsModule, MatButtonModule, MatIconModule, EditarOperarioComponent,
    MatDialogModule],
  templateUrl: './consultar-operario.component.html',
  styleUrl: './consultar-operario.component.css'
})
export class ConsultarOperarioComponent implements OnInit {

  public usuariosOriginales: Usuario[] = [];
  public usuarios: Usuario[] = this.usuariosOriginales;
  public unidadesRegionales: UnidadRegional[] = [];

  private formBuilder = inject(FormBuilder);
  private usuarioService = inject(UsuarioService);
  private unidadRegionalService = inject(UnidadRegionalService);
  private cuadroDialogo = inject(MatDialog);

  public contenedorFormulario = this.formBuilder.group({
    valor: ['', { validators: [Validators.required] }],
    filtro: ['', { validators: [Validators.required] }]
  });

  ngOnInit(): void {

    this.unidadRegionalService.obtenerUnidadesRegionales().subscribe(unidadesRegionales => {
      this.unidadesRegionales = unidadesRegionales;
    });

    this.usuarioService.obtenerUsuarios().subscribe(usuarios => {
      this.usuariosOriginales = usuarios;
      this.usuarios = usuarios;
    });

    this.contenedorFormulario.valueChanges.subscribe(() => {
      this.filtrarValores();
    });
  }

  public atributosOperador = ['IDENTIFICADOR', 'NOMBRE', 'APELLIDOS', 'NOMBRE DE USUARIO', 'CORREO',
    'UNIDAD REGIONAL', 'OCUPACIÓN', 'GESTIÓN'];


  filtrarValores() {
    const { valor, filtro } = this.contenedorFormulario.value;

    if (!valor) {
      this.usuarios = this.usuariosOriginales;
    } else {
      this.usuarios = this.usuariosOriginales.filter(usuario => {
        let campo = '';

        switch (filtro) {

          case 'identificador':
            campo = 'identificador';
            break;
          case 'nombre':
            campo = 'nombre';
            break;
          case 'apellido':
            campo = 'nombre';
            break;
          case 'nombreUsuario':
            campo = 'nombreUsuario';
            break;
          case 'correo':
            campo = 'correo';
            break;
          case 'unidadRegional':
            campo = 'unidadRegional';
            break;
          case 'rol':
            campo = 'rol';
            break;
        }
        return campo.toLowerCase().includes(valor.toLowerCase());
      });
    }
  }

  abrirEditarOperario(operario: Usuario) {
    const dialogRef = this.cuadroDialogo.open(EditarOperarioComponent, {
      width: '700px', 
      height: '500px',
      data: operario 
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('El diálogo se ha cerrado');
    });
  }


}
