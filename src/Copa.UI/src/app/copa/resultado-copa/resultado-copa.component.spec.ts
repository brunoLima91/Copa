import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultadoCopaComponent } from './resultado-copa.component';

describe('ResultadoCopaComponent', () => {
  let component: ResultadoCopaComponent;
  let fixture: ComponentFixture<ResultadoCopaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResultadoCopaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultadoCopaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
