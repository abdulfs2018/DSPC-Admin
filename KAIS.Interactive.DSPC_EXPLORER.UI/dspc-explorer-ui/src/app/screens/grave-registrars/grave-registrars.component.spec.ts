import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GraveRegistrarsComponent } from './grave-registrars.component';

describe('GraveRegistrarsComponent', () => {
  let component: GraveRegistrarsComponent;
  let fixture: ComponentFixture<GraveRegistrarsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GraveRegistrarsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GraveRegistrarsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
