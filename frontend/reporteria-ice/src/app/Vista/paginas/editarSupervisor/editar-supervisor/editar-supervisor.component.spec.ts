import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarSupervisorComponent } from './editar-supervisor.component';

describe('EditarSupervisorComponent', () => {
  let component: EditarSupervisorComponent;
  let fixture: ComponentFixture<EditarSupervisorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditarSupervisorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditarSupervisorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
