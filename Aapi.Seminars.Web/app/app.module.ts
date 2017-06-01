import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { MaterialRootModule } from '@angular/material';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { SeminarsComponent } from './seminars/seminars.component';
import { SeminarsService } from './seminars/seminars.service';
import { SeminarDetailComponent } from './seminars/seminarDetail.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'seminars', component: SeminarsComponent },
    { path: 'seminars/:id', component: SeminarDetailComponent }
];

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot(appRoutes),
        MaterialRootModule
    ],
    declarations: [
        AppComponent,
        HeaderComponent,
        FooterComponent,
        HomeComponent,
        SeminarsComponent,
        SeminarDetailComponent
    ],
    providers: [
        SeminarsService
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }