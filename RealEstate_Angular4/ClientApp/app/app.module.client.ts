import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { sharedConfig } from './app.module.shared';

import { UserLoginService } from './components/services/userlogin.service';
import { ListingService } from './components/services/listing.service';

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        FormsModule,
        BrowserModule,
        HttpModule,
        ...sharedConfig.imports
    ],
    providers: [
        UserLoginService,
        ListingService,
        { provide: 'ORIGIN_URL', useValue: location.origin }
    ]
})
export class AppModule {
}
