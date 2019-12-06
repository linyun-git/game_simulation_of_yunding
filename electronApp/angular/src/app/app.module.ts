import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OkButtonComponent } from './components/ok-button/ok-button.component';
import { NoButtonComponent } from './components/no-button/no-button.component';
import { ExitFrameComponent } from './exit-frame/exit-frame.component';
import { MainFrameComponent } from './main-frame/main-frame.component';
import { ManagerFrameComponent } from './manager-frame/manager-frame.component';
import { HeroSquareComponent } from './components/hero-square/hero-square.component';
import { SelectHeroLiComponent } from './components/select-hero-li/select-hero-li.component';
import { SelectHeroUlComponent } from './components/select-hero-ul/select-hero-ul.component';

//管道
import { HeroNameToSrcPipe } from './pipe/hero-name-to-src.pipe';
import { HeroLevelToStringPipe } from './pipe/hero-level-to-string.pipe';
import { SetHeroPieceComponent } from './components/set-hero-piece/set-hero-piece.component';
import { IconSrcPipe } from './pipe/icon-src.pipe';
import { IconToButtonComponent } from './components/icon-to-button/icon-to-button.component';
import { TimerComponent } from './components/timer/timer.component';
import { TimerPipe } from './pipe/timer.pipe';
import { HasHeroStatusToStringPipe } from './pipe/has-hero-status-to-string.pipe';

@NgModule({
  declarations: [
    AppComponent,
    OkButtonComponent,
    NoButtonComponent,
    ExitFrameComponent,
    MainFrameComponent,
    ManagerFrameComponent,
    HeroSquareComponent,
    HeroNameToSrcPipe,
    SelectHeroLiComponent,
    SelectHeroUlComponent,
    HeroLevelToStringPipe,
    SetHeroPieceComponent,
    IconSrcPipe,
    IconToButtonComponent,
    TimerComponent,
    TimerPipe,
    HasHeroStatusToStringPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
