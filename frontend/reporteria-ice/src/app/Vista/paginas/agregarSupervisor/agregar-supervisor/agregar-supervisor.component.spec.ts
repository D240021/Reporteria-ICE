import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarSupervisorComponent } from './agregar-supervisor.component';

describe('AgregarSupervisorComponent', () => {
  let component: AgregarSupervisorComponent;
  let fixture: ComponentFixture<AgregarSupervisorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AgregarSupervisorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgregarSupervisorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
