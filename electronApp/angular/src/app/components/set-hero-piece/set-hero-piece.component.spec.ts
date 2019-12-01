import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SetHeroPieceComponent } from './set-hero-piece.component';

describe('SetHeroPieceComponent', () => {
  let component: SetHeroPieceComponent;
  let fixture: ComponentFixture<SetHeroPieceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SetHeroPieceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SetHeroPieceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
