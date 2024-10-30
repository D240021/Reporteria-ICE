import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ambiente } from '../../Ambientes/ambienteDesarrollo';
import { Usuario } from '../../Modelo/Usuario';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor() { }

  private http = inject(HttpClient);
  private urlBase = ambiente.apiURL + '/Usuario';


  public crearUsuario(usuario: Usuario): Observable<any>{
    return this.http.post(this.urlBase, usuario);
  }

  public obtenerUsuarios(){
    return this.http.get<Usuario[]>(this.urlBase);
  }

}
