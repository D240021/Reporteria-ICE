import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class FormulariosService {

  constructor() { }

  limpiarFormulario( formGroup: FormGroup ) {
    formGroup.reset();
    return;
  }

  esFormularioVacio(valores: any): boolean {
    return Object.values(valores).every((valor) => valor === null || valor === '');
  }

  obtenerErroresNombre(contenedorFormulario : FormGroup) : string {
    const campo = contenedorFormulario.controls['nombre']  || contenedorFormulario.controls['nombreUbicacion'];

    if(campo.hasError('required') && campo.touched){
      return 'El campo nombre es requerido';
    }

    if(campo.hasError('esCaracterEspecial') && campo.touched){
      return 'No se permiten caracteres especiales';
    }

    if(campo.hasError('esSoloLetras') && campo.touched){
      return 'El campo nombre no debe llevar números';
    }

    

    return '';
  }

  obtenerErroresIdentificador(contenedorFormulario : FormGroup) : string {
    const campo = contenedorFormulario.controls['identificador'];

    if(campo.hasError('required') && campo.touched){
      return 'El campo identificador es requerido';
    }

    return '';
  }

  obtenerErroresNombreUsuario(contenedorFormulario : FormGroup) : string {
    const campo = contenedorFormulario.controls['nombreUsuario'];

    if(campo.hasError('required') && campo.touched){
      return 'El nombre de usuario es requerido';
    }
    
    return '';
  }

  obtenerErroresContrasenia(contenedorFormulario : FormGroup) : string {
    const campo = contenedorFormulario.controls['contrasenia'];

    if(campo.hasError('required') && campo.touched){
      return 'La contraseña es requerida';
    }

    if(campo.hasError('esContraseniaSegura') && campo.touched){
      
      return 'La contraseña debe de ser segura';
    }
    
    return '';
  }

  obtenerErroresCorreo(contenedorFormulario : FormGroup) : string {
    const campo = contenedorFormulario.controls['correo'];

    if(campo.hasError('required') && campo.touched){
      return 'El correo es requerido';
    }

    if(campo.hasError('email') && campo.touched){
      return 'Inserte un correo válido';
    }

    
    return '';
  }

  obtenerErroresApellidos(contenedorFormulario : FormGroup) : string {
    const campo = contenedorFormulario.controls['apellido'];

    if(campo.hasError('required') && campo.touched){
      return 'Los apellidos son requeridos';
    }

    if(campo.hasError('esCaracterEspecial') && campo.touched){
      return 'No se permiten caracteres especiales';
    }

    if(campo.hasError('esSoloLetras') && campo.touched){
      return 'El campo nombre no debe llevar números';
    }

    return '';
  }

  obtenerErroresUnidadRegionalId(contenedorFormulario : FormGroup) : string {
    const campo = contenedorFormulario.controls['unidadRegionalId'];

    if(campo.hasError('required') && campo.touched){
      return 'La Unidad Regional es requerida';
    }


    return '';
  }

  

  obtenerErroresRol(contenedorFormulario : FormGroup) : string {
    const campo = contenedorFormulario.controls['rol'];

    if(campo.hasError('required') && campo.touched){
      return 'La ocupación es requerida';
    }

    return '';
  }
  


 
}
