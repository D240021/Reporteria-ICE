import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ambiente } from '../../Ambientes/ambienteDesarrollo';
import { Subestacion } from '../../Modelo/Subestacion';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubestacionService {

  constructor() { }

  private http = inject(HttpClient);
  private urlBase = ambiente.apiURL + '/Subestacion';

  public crearSubestacion(subestacion: Subestacion): Observable<any>{
    return this.http.post(this.urlBase, subestacion);
  }

  public obtenerSubestaciones(){
    return this.http.get<Subestacion[]>(this.urlBase);
  }

  public editarSubestacion(subestacion : Subestacion){
    return this.http.put(`${this.urlBase}/${subestacion.id}`, subestacion);
  }
}
