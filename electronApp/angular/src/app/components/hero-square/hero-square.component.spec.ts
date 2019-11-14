import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroSquareComponent } from './hero-square.component';

describe('HeroSquareComponent', () => {
  let component: HeroSquareComponent;
  let fixture: ComponentFixture<HeroSquareComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeroSquareComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeroSquareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
