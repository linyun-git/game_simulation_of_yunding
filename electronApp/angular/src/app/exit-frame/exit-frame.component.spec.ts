import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExitFrameComponent } from './exit-frame.component';

describe('ExitFrameComponent', () => {
  let component: ExitFrameComponent;
  let fixture: ComponentFixture<ExitFrameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExitFrameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExitFrameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
