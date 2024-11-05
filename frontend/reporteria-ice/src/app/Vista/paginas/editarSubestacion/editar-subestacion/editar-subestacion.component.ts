import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { BuscadorComponent } from '../../../componentes/buscador/buscador/buscador.component';
import { Subestacion } from '../../../../Modelo/Subestacion';
import { RouterLink } from '@angular/router';
@Component({
  selector: 'editar-subestacion',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, BuscadorComponent, RouterLink],
  templateUrl: './editar-subestacion.component.html',
  styleUrl: './editar-subestacion.component.css'
})
export class EditarSubestacionComponent {

  


}
