import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';

@Component({
  selector: 'no-autorizado',
  standalone: true,
  imports: [MatButtonModule],
  templateUrl: './no-autorizado.component.html',
  styleUrl: './no-autorizado.component.css'
})
export class NoAutorizadoComponent implements OnInit{

  public direccionAnterior: string = '';
  private router = inject(Router);

  constructor() {}
  ngOnInit(): void {
    
  }

}
