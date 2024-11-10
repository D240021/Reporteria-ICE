import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ambiente } from '../../Ambientes/ambienteDesarrollo';
import { Informe } from '../../Modelo/Informe';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InformeService {

  constructor() { }

  private http = inject(HttpClient);
  private urlBase = ambiente.apiURL + '/Informe';

  public obtenerInformesPendientesPorSubestacion(idSubestacion: number): Observable<Informe[]> {
    return this.http.get<Informe[]>(`${this.urlBase}/pendientes/${idSubestacion}`);
  }


}
