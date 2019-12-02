import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IconToButtonComponent } from './icon-to-button.component';

describe('IconToButtonComponent', () => {
  let component: IconToButtonComponent;
  let fixture: ComponentFixture<IconToButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IconToButtonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IconToButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
