import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SeguridadService {

  constructor() { }
  
  private router = inject(Router);

  establecerRol(rol : string) : void {
    localStorage.setItem('rol', rol);
  }

  estaLogeado() : boolean {
    return true;
  }

  obtenerRol() : string {
    return localStorage.getItem('rol') || '';
  }

  limpiarRol() : void {
    localStorage.removeItem('rol');
  }

  cerrarSesion() : void{
    this.limpiarRol();
    this.router.navigate(['/inicio-sesion']);
  }
}
