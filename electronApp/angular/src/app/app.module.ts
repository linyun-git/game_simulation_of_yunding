import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OkComponent } from './components/ok/ok.component';
import { NoComponent } from './components/no/no.component';
import { HeroSquareComponent } from './components/hero-square/hero-square.component';
import { TipsComponent } from './components/tips/tips.component';
import { HeroHeadPhotoComponent } from './components/hero-head-photo/hero-head-photo.component';
import { OptionComponent } from './components/option/option.component';

@NgModule({
  declarations: [
    AppComponent,
    OkComponent,
    NoComponent,
    HeroSquareComponent,
    TipsComponent,
    HeroHeadPhotoComponent,
    OptionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
