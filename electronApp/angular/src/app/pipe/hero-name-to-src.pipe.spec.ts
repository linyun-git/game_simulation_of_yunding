import { HeroNameToSrcPipe } from './hero-name-to-src.pipe';

describe('HeroNameToSrcPipe', () => {
  it('create an instance', () => {
    const pipe = new HeroNameToSrcPipe();
    expect(pipe).toBeTruthy();
  });
});
