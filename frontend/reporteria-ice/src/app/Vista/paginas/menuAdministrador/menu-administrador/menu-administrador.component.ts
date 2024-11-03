import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCard, MatCardModule } from '@angular/material/card';
import { RouterLink } from '@angular/router';
import { SeguridadService } from '../../../../Seguridad/Seguridad/seguridad.service';

@Component({
  selector: 'menu-administrador',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, RouterLink],
  templateUrl: './menu-administrador.component.html',
  styleUrl: './menu-administrador.component.css'
})
export class MenuAdministradorComponent {

  public seguridadService = inject(SeguridadService);
  
}
