import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import 'rxjs/Rx';
import 'rxjs/add/operator/toPromise';

import { image } from '../models/image';

@Injectable() 
export class ImageService {
    images: image[];

    constructor(private http: Http) {
    }

    public GetImagesByHouse(houseId: number): Promise<image[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let url = `/api/Image/${houseId}/ByHouseId`;
        let options = new RequestOptions({ headers: headers });
        return this.http.get(url, options)
            .toPromise()
            .then(response => {
                if (response.ok) {
                    let imageArray = response.json() as image[];
                    if (imageArray) {

                        this.images = imageArray.sort((a, b) => {
                                    if (a.sortOrder < b.sortOrder) {
                                        return -1;
                                    }
                                    if (a.sortOrder > b.sortOrder) {
                                        return 1;
                                    }
                                    return 0;
                                });
                    }
                    return imageArray;
                }
                else {
                    return this.images;
                }

            })
            .catch(this.handleError);
    }

    public UpdateImage(img: image): Promise<image> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let url = `/api/Image/${img.imageId}`;
        let options = new RequestOptions({ headers: headers });

        return this.http.put(url, JSON.stringify(img), options)
            .toPromise()
            .then(response => {
                if (response.ok) {
                    return response.json() as image;
                }
                else {
                    return null;
                }

            })
            .catch(this.handleError);

    }

    public CreateImage(img: image): Promise<image> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let url = '/api/Image/';
        let options = new RequestOptions({ headers: headers });

        return this.http.post(url, JSON.stringify(img), options)
            .toPromise()
            .then(response => {
                if (response.ok) {
                    return response.json() as image;
                }
                else {
                    return null;
                }

            })
            .catch(this.handleError);

    }

    public DeleteImage(imageId: number) {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let url = `/api/Image/${imageId}`;
        let options = new RequestOptions({ headers: headers });

        return this.http.delete(url, options)
            .toPromise()
            .then(response => {
                return null;
            })
            .catch(this.handleError);

    }

    private handleError(error: any) {
        console.log('An error occurred');
        return Promise.reject(error.message || error);
    } 
}