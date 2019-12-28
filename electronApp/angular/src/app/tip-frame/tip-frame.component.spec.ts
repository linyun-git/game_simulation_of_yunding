import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TipFrameComponent } from './tip-frame.component';

describe('TipFrameComponent', () => {
  let component: TipFrameComponent;
  let fixture: ComponentFixture<TipFrameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TipFrameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TipFrameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
