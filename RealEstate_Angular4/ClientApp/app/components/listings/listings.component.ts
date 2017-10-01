import { Component, Input, Output, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ListingService } from '../services/listing.service';

import { listing } from '../models/listing';
import { userlogin } from '../models/userlogin';
import { PropertyType } from '../models/property-type.enum';

import { stateObject } from '../shared/state';
import { bathrooms } from '../shared/bathrooms';
import { bedrooms } from '../shared/bedrooms';

@Component({
    selector: 'listings',
    templateUrl: './listings.component.html',
    styleUrls: ['./listings.component.css']
})

export class ListingsComponent implements OnInit {
    userinfo: userlogin;
    listings: listing[];
    agentId: number;
    loading: boolean;
    errorOccurred: boolean;
    selectedListing: listing;
    newListing: boolean;
    propertypeVals: string[];
    propertypeNums: string[];
    stateList: stateObject;
    baths: bathrooms;
    beds: bedrooms;


    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private listingService: ListingService
    ) {
    }

    ngOnInit() {
        this.propertypeNums = Object.keys(PropertyType).filter(Number);
        this.propertypeVals = Object.keys(PropertyType).filter(f => isNaN(Number.parseInt(f)));

        this.stateList = new stateObject();
        this.baths = new bathrooms();
        this.beds = new bedrooms();

        this.userinfo = JSON.parse(localStorage.getItem('currentUser'));
        this.loading = true;
        this.newListing = false;
        this.listingService.GetListingsAgent(this.userinfo.userLoginId)
            .then(logindata => {
                this.listings = logindata;
            })
            .catch(error => this.loginError(error));
        this.assignAgentId();
    }

    public onSelect(house: listing) {
        this.newListing = false;
        this.selectedListing = house;
    }

    public addListing() {
        if (!this.agentId) {
            this.assignAgentId();
        }
        this.newListing = true;
        this.selectedListing = new listing();
    }

    public onCancelClick() {
        this.selectedListing = null;
        this.newListing = false;
    }

    public onDeleteClick() {
        this.listingService.DeleteListing(this.selectedListing)
            .then(listingData => {
                let element = this.listings.findIndex(listing => listing.houseid == this.selectedListing.houseid);
                this.listings.splice(element);
                this.selectedListing = null;
                this.newListing = false;
            })
            .catch(error => this.loginError(error));
    }

    private onSubmit() {
        if (this.newListing) {
            this.selectedListing.agentId = this.agentId;
            this.listingService.CreateListing(this.selectedListing)
                .then(listingData => {
                    this.listings.push(listingData);
                    this.selectedListing = null;
                })
                .catch(error => this.loginError(error));
        }
        else {
            this.listingService.UpdateListing(this.selectedListing)
                .then(listingData => {
                    this.selectedListing = null;
                })
                .catch(error => this.loginError(error));
        }
    }

    private loginError(error: any) {
        this.errorOccurred = true;
        console.log(error);
    }

    private assignAgentId() {
        if (this.listings && this.listings.length > 0) {
            this.agentId = this.listings[0].agentId;
        } 

    }

}