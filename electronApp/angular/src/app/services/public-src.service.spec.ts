import { TestBed } from '@angular/core/testing';

import { PublicSrcService } from './public-src.service';

describe('PublicSrcService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PublicSrcService = TestBed.get(PublicSrcService);
    expect(service).toBeTruthy();
  });
});
