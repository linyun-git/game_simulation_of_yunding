import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroHeadPhotoComponent } from './hero-head-photo.component';

describe('HeroHeadPhotoComponent', () => {
  let component: HeroHeadPhotoComponent;
  let fixture: ComponentFixture<HeroHeadPhotoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeroHeadPhotoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeroHeadPhotoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
