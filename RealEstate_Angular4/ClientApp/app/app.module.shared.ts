import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { UserLoginComponent } from './components/userlogin/userlogin.component';
import { ListingsComponent } from './components/listings/listings.component';
import { ImageComponent } from './components/images/image.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        UserLoginComponent,
        ListingsComponent,
        ImageComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'user-login', component: UserLoginComponent },
            { path: 'listings', component: ListingsComponent },
            { path: 'images/:houseId', component: ImageComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
};
