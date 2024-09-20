import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultarSupervisorComponent } from './consultar-supervisor.component';

describe('ConsultarSupervisorComponent', () => {
  let component: ConsultarSupervisorComponent;
  let fixture: ComponentFixture<ConsultarSupervisorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConsultarSupervisorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConsultarSupervisorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
