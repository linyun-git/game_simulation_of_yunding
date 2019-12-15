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
import { HeroNameToSrcPipe } from './pipe/heroNameToSrc/hero-name-to-src.pipe';
import { HeroLevelToStringPipe } from './pipe/heroLevelToString/hero-level-to-string.pipe';
import { SetHeroPieceComponent } from './components/set-hero-piece/set-hero-piece.component';
import { IconSrcPipe } from './pipe/iconSrc/icon-src.pipe';
import { IconToButtonComponent } from './components/icon-to-button/icon-to-button.component';
import { TimerComponent } from './components/timer/timer.component';
import { HasHeroStatusToStringPipe } from './pipe/hasHeroStatusToString/has-hero-status-to-string.pipe';
import { StatusEqualsWaitingPipe } from './pipe/statusEqualsWaiting/status-equals-waiting.pipe';
import { HeroFightLogComponent } from './components/hero-fight-log/hero-fight-log.component';
import { StatusToClassPipe } from './pipe/statusToClass/status-to-class.pipe';
import { TipsComponent } from './components/tips/tips.component';

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
    HasHeroStatusToStringPipe,
    StatusEqualsWaitingPipe,
    HeroFightLogComponent,
    StatusToClassPipe,
    TipsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
