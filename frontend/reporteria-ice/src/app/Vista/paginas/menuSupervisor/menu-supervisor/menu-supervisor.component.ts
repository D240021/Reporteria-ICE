import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'menu-supervisor',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, RouterLink],
  templateUrl: './menu-supervisor.component.html',
  styleUrls: ['./menu-supervisor.component.css']
})
export class MenuSupervisorComponent {

  

}
