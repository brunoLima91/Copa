import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarEquipeComponent } from './listar-equipe.component';

describe('ListarEquipeComponent', () => {
  let component: ListarEquipeComponent;
  let fixture: ComponentFixture<ListarEquipeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListarEquipeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarEquipeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
