import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroFightLogComponent } from './hero-fight-log.component';

describe('HeroFightLogComponent', () => {
  let component: HeroFightLogComponent;
  let fixture: ComponentFixture<HeroFightLogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeroFightLogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeroFightLogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
