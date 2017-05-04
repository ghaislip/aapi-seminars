import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { MaterialRootModule } from '@angular/material';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        MaterialRootModule
    ],
    declarations: [
        AppComponent,
        HeaderComponent,
        FooterComponent
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }