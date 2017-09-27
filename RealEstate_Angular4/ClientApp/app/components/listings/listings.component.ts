import { Component, Input, Output, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';

import { ListingService } from '../services/listing.service';

import { listing } from '../models/listing';
import { userlogin } from '../models/userlogin';
import { PropertyType } from '../models/property-type.enum';

@Component({
    selector: 'listings',
    templateUrl: './listings.component.html'
})

export class ListingsComponent implements OnInit {
    userinfo: userlogin;
    listings: listing[];
    loading: boolean;
    errorOccurred: boolean;
    selectedListing: listing;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private listingService: ListingService
    ) {

    }

    ngOnInit() {
        this.userinfo = JSON.parse(localStorage.getItem('currentUser'));
        this.loading = true;
        this.listingService.GetListingsAgent(this.userinfo.userLoginId)
            .then(logindata => {
                this.listings = logindata;
            })
            .catch(error => this.loginError(error));

    }

    public onSelect(house: listing) {
        this.selectedListing = house;
    }

    public onCancelClick() {
        this.selectedListing = null;
    }

    private onSubmit() {
        this.listingService.UpdateListing(this.selectedListing)
            .then(listingData => {
                this.selectedListing = null;
            })
            .catch(error => this.loginError(error));
    }

    private loginError(error: any) {
        this.errorOccurred = true;
        console.log(error);
    }

}