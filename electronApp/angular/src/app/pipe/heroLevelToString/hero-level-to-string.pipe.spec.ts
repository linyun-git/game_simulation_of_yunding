import { HeroLevelToStringPipe } from './hero-level-to-string.pipe';

describe('HeroLevelToStringPipe', () => {
  it('create an instance', () => {
    const pipe = new HeroLevelToStringPipe();
    expect(pipe).toBeTruthy();
  });
});
