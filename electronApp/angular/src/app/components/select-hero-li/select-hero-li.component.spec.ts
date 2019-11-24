import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectHeroLiComponent } from './select-hero-li.component';

describe('SelectHeroLiComponent', () => {
  let component: SelectHeroLiComponent;
  let fixture: ComponentFixture<SelectHeroLiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectHeroLiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectHeroLiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
