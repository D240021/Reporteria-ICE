import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ambiente } from '../../Ambientes/ambienteDesarrollo';
import { Reporte } from '../../Modelo/Reporte';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReporteService {

  constructor() { }

  private http = inject(HttpClient);
  private urlBase = ambiente.apiURL + '/Reporte';


  public crearReporte(reporte: Reporte, subestacionesId: number[], lineaTransmisionId: number): Observable<any> {
    let parametros = new HttpParams()
      .set('lineaTransmisionId', lineaTransmisionId.toString());


    subestacionesId.forEach(id => {
      parametros = parametros.append('subestacionIds', id.toString());
    });

    return this.http.post(this.urlBase, reporte, { params: parametros });
  }

  public obtenerTodosReportes(): Observable<Reporte[]> {
    return this.http.get<Reporte[]>(this.urlBase);
  }

  public editarReporte(reporte: Reporte) {
    return this.http.put(`${this.urlBase}/${reporte.id}`, reporte);
  }

  obtenerPDFPorReporte(reporteId: number) {
    return this.http.get(`${this.urlBase}/${reporteId}/pdf`, { responseType: 'blob' });
  }
}
