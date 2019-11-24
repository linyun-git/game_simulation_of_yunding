import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerFrameComponent } from './manager-frame.component';

describe('ManagerFrameComponent', () => {
  let component: ManagerFrameComponent;
  let fixture: ComponentFixture<ManagerFrameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagerFrameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagerFrameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
