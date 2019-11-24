import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoButtonComponent } from './no-button.component';

describe('NoButtonComponent', () => {
  let component: NoButtonComponent;
  let fixture: ComponentFixture<NoButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoButtonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
