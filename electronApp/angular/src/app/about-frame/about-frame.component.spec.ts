import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutFrameComponent } from './about-frame.component';

describe('AboutFrameComponent', () => {
  let component: AboutFrameComponent;
  let fixture: ComponentFixture<AboutFrameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AboutFrameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutFrameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
