import { Component, inject, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Usuario } from '../../../../Modelo/Usuario';
import { UsuarioService } from '../../../../Controlador/Usuario/usuario.service';
import { UnidadRegionalService } from '../../../../Controlador/UnidadRegional/unidad-regional.service';
import { UnidadRegional } from '../../../../Modelo/unidadRegional';
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

  private formBuilder = inject(FormBuilder);
  private usuarioService = inject(UsuarioService);
  private cuadroDialogo = inject(MatDialog);

  public contenedorFormulario = this.formBuilder.group({
    valor: ['', { validators: [Validators.required] }],
    filtro: ['', { validators: [Validators.required] }]
  });

  private modalAbierto: boolean = false;

  public atributosOperador = ['IDENTIFICADOR', 'NOMBRE', 'APELLIDOS', 'NOMBRE DE USUARIO', 'CORREO',
    'UNIDAD REGIONAL', 'OCUPACIÓN', 'GESTIÓN'];

  ngOnInit(): void {

    this.cargarDatos();

    this.contenedorFormulario.valueChanges.subscribe(() => {
      this.filtrarValores();
    });
  }


  cargarDatos(): void {

    this.usuarioService.obtenerUsuarios().subscribe(usuarios => {
      this.usuariosOriginales = usuarios;
      this.usuarios = usuarios;
      
    });

    return;
  }


  filtrarValores(): void {
    const { valor, filtro } = this.contenedorFormulario.value;

    if (!valor) {
      this.usuarios = this.usuariosOriginales;
    } else {
      this.usuarios = this.usuariosOriginales.filter(usuario => {
        let campo = '';

        switch (filtro) {
          case 'identificador':
            campo = usuario.identificador;
            break;
          case 'nombre':
            campo = usuario.nombre;
            break;
          case 'apellido':
            campo = usuario.apellido;
            break;
          case 'nombreUsuario':
            campo = usuario.nombreUsuario;
            break;
          case 'correo':
            campo = usuario.correo;
            break;
          case 'unidadRegional':
            campo = usuario.nombreUnidadRegional || '';
            break;
          case 'rol':
            campo = usuario.rol;
            break;
        }

        return campo && campo.toLowerCase().includes(valor.toLowerCase());
      });
    }
  }

  abrirEditarOperario(operario: Usuario): void {
    if (!this.modalAbierto) {
      this.modalAbierto = true;
      const dialogRef = this.cuadroDialogo.open(EditarOperarioComponent, {
        width: '700px',
        height: '500px',
        data: operario
      });
      dialogRef.afterClosed().subscribe(result => {
        this.modalAbierto = false;
        this.cargarDatos();
      });
    }

  }


}
