import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { AESService } from '../../../../Util/Encriptacion/AES/aes.service';
import { usuarioRoles } from '../../../../Util/Enum/Roles';

@Component({
  selector: 'inicio-sesion',
  standalone: true,
  imports: [MatInputModule, MatFormFieldModule, MatButtonModule, ReactiveFormsModule],
  templateUrl: './inicio-sesion.component.html',
  styleUrl: './inicio-sesion.component.css'
})
export class InicioSesionComponent {


  private router = inject(Router);
  private formBuilder = inject(FormBuilder);
  private encriptacion = inject(AESService);

  public contenedorFormulario = this.formBuilder.group({
    nombreUsuario: ['', { validators: [Validators.required] }],
    contrasenia: ['']
  });




  redireccionarUsuario() {

    const tipoUsuario = this.contenedorFormulario.value?.nombreUsuario?.toLocaleLowerCase();
    if (tipoUsuario === usuarioRoles.ADMIN.toLocaleLowerCase()) {
      this.router.navigate(['/menu-administrador']);
    }else if(tipoUsuario === usuarioRoles.TPM.toLocaleLowerCase()){
      this.router.navigate(['/crear-reporte']);
    }else if(tipoUsuario === usuarioRoles.SPRV.toLocaleLowerCase()){
      this.router.navigate(['/menu-supervisor']);
    }else if(tipoUsuario === usuarioRoles.TLT.toLocaleLowerCase()){
      this.router.navigate(['/editar-reporte-tlt']);
    }
    // const valor = this.contenedorFormulario.value.nombreUsuario || '';
    // console.log(this.encriptacion.encriptarAES(valor));
  }

}
