import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';

@Injectable({
  providedIn: 'root'
})
export class AESService {

  constructor() { }

  private llavePrivada = 'tu_clave_secreta';

  
  encriptarAES(datos: string): string {
    return CryptoJS.AES.encrypt(datos, this.llavePrivada).toString();
  }


  desencriptarAES(datosCrifrados: string): string {
    const bytes = CryptoJS.AES.decrypt(datosCrifrados, this.llavePrivada);
    return bytes.toString(CryptoJS.enc.Utf8);
  }
}
