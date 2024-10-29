import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SeguridadService {

  constructor() { }

  estaLogeado() : boolean {
    return true;
  }

  obtenerRol() : string {
    return 'admin';
  }
}
