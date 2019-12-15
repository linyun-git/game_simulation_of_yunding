import { HasHeroStatusToStringPipe } from './has-hero-status-to-string.pipe';

describe('HasHeroStatusToStringPipe', () => {
  it('create an instance', () => {
    const pipe = new HasHeroStatusToStringPipe();
    expect(pipe).toBeTruthy();
  });
});
