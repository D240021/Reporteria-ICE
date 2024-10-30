import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'menu-supervisor',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, RouterLink, CommonModule],
  templateUrl: './menu-supervisor.component.html',
  styleUrls: ['./menu-supervisor.component.css']
})
export class MenuSupervisorComponent {
  constructor(private router: Router) { };

  irAEditar(id: string) {    
    this.router.navigate(['/editar-reporte', id]);
  }

  //Reportes quemados:
  reportes = [
    { id: '146621F', nombre: 'Guápiles - San José' },
    { id: '9549T', nombre: 'Río Macho - Paraíso' }
  ];



  

}
