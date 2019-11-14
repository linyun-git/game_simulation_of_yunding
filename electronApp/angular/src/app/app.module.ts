import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OkComponent } from './components/ok/ok.component';
import { NoComponent } from './components/no/no.component';

@NgModule({
  declarations: [
    AppComponent,
    OkComponent,
    NoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
