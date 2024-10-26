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

 
}
