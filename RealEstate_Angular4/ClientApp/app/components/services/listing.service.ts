import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import 'rxjs/Rx';
import 'rxjs/add/operator/toPromise';

import { listing } from '../models/listing';
import { PropertyType } from '../models/property-type.enum';

@Injectable()
export class ListingService {
    public listings: listing[];

    constructor(private http: Http) {
        
    }


    public GetListingsAgent(userLoginId: number): Promise<listing[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let url = '/api/Agent/' + userLoginId + '/GetHouses';
        let options = new RequestOptions({ headers: headers });

        return this.http.get(url, options)
            .toPromise()
            .then(response => {
                if (response.ok) {
                    let listingArray = response.json() as listing[];
                    if (listingArray) {
                        this.listings = listingArray;
                    }
                    return listingArray;
                }
                else {
                    return this.listings;
                }
            })
            .catch(this.handleError);

    }

    public UpdateListing(updatedListing: listing): Promise<listing> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let url = '/api/House/' + updatedListing.houseid;
        let options = new RequestOptions({ headers: headers });

        return this.http.put(url, JSON.stringify(updatedListing), options)
            .toPromise()
            .then(response => {
                if (response.ok) {
                    return response.json() as listing;
                }
                else {
                    return null;
                }
            })
            .catch(this.handleError);

    }

    private handleError(error: any) {
        console.log('An error occurred');
        return Promise.reject(error.message || error);
    }


}
