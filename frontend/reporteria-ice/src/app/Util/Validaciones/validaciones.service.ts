import { Injectable } from '@angular/core';
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidacionesService {

  constructor() { }

  // esSoloLetras(): ValidatorFn {
  //   return (control: AbstractControl): ValidationErrors | null => {
  //     const valor = control.value;
  //     const esSoloLetras = /^[a-zA-Z]+$/.test(valor);
  //     return esSoloLetras ? null : { esSoloLetras: true };
  //   };
  // }

  esSoloLetras(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const valor = control.value;
      const esSoloLetras = /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/.test(valor);
      return esSoloLetras ? null : { esSoloLetras: true };
    };
  }
}
