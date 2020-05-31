import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GraveDetailsRegistrarsComponent } from './grave-details-registrars.component';

describe('GraveDetailsRegistrarsComponent', () => {
  let component: GraveDetailsRegistrarsComponent;
  let fixture: ComponentFixture<GraveDetailsRegistrarsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GraveDetailsRegistrarsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GraveDetailsRegistrarsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
