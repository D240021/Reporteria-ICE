import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MultiSelectorCheckbox } from '../../../componentes-globales/multiselector-checkbox/multiselector-checkbox';





@Component({
  selector: 'app-agregar-subestacion',
  standalone: true,
  templateUrl: './agregar-subestacion.component.html',
  styleUrls: ['./agregar-subestacion.component.css'],
  imports: [ReactiveFormsModule, CommonModule, MultiSelectorCheckbox]
})

export class AgregarSubestacionComponent implements OnInit {
  formularioSubestacion!: FormGroup;  // Declaras la propiedad sin inicializarla aquí

  lineasTransmision: string[] = ['Desamparados', 'Turrialba'];  // Líneas de transmisión disponibles

  listaCheckbox: any[] = [
    { nombre: 'Desamparados', seleccionado: false },
    { nombre: 'Turrialba', seleccionado: false }
  ]; // Lista para el MultiSelectorCheckbox

  constructor(private fb: FormBuilder) {
    // Inicialización del formulario en el constructor
    this.formularioSubestacion = this.fb.group({
      identificador: [''],
      nombreUbicacion: [''],
      lineasSeleccionadas: this.fb.array([])  // Para manejar las líneas seleccionadas
    });
  }

  ngOnInit(): void {    
  }

  actualizarSeleccionLinea(event: any) {
    const lineasSeleccionadas = this.formularioSubestacion.get('lineasSeleccionadas') as FormArray;
    if (event.target.checked) {
      lineasSeleccionadas.push(this.fb.control(event.target.value));
    } else {
      const index = lineasSeleccionadas.controls.findIndex(x => x.value === event.target.value);
      lineasSeleccionadas.removeAt(index);
    }
  }


  //Gestion del Multiselector:  
  compartirListaSeleccionada(listaSeleccionada: string[]) {
    console.log('Lista seleccionada:', listaSeleccionada);
  }

  compartirSeleccionIndividual(seleccionIndividual: any) {
    console.log('Selección individual:', seleccionIndividual);
  }

  limpiarFormulario(): void {
    this.formularioSubestacion.reset(); // Limpiar el formulario
  }

  enviarFormulario(): void {
    if (this.formularioSubestacion.valid) {
      console.log(this.formularioSubestacion.value); // Aquí manejas el envío del formulario
    }
  }


}
