import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectHeroUlComponent } from './select-hero-ul.component';

describe('SelectHeroUlComponent', () => {
  let component: SelectHeroUlComponent;
  let fixture: ComponentFixture<SelectHeroUlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectHeroUlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectHeroUlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
