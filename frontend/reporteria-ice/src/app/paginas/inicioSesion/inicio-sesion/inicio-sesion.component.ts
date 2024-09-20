import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { Router } from '@angular/router';

@Component({
  selector: 'inicio-sesion',
  standalone: true,
  imports: [MatInputModule, MatFormFieldModule, MatButtonModule],
  templateUrl: './inicio-sesion.component.html',
  styleUrl: './inicio-sesion.component.css'
})
export class InicioSesionComponent {

  private router = inject(Router);

  enviarAdmin(){
    this.router.navigate(['/menu-administrador']);
  }

}
