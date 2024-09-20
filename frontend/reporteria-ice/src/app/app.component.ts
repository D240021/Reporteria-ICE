import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { InicioSesionComponent } from "./paginas/inicioSesion/inicio-sesion/inicio-sesion.component";
import { MenuAdministradorComponent } from "./paginas/menuAdministrador/menu-administrador/menu-administrador.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Reporteria ICE';
}
