import { Component, Input, Output, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ImageService } from '../services/image.service';
import { image } from '../models/image';

@Component({
    selector: 'images',
    templateUrl: './image.component.html'
})
export class ImageComponent implements OnInit {
    houseId: number;
    private sub: any;
    images: image[];
    selectedImage: image;
    newImage: boolean;
    errorOccurred: boolean;

    constructor(
        private imageService: ImageService,
        private router: Router,
        private route:ActivatedRoute
    ) {

    }

    ngOnInit() {
        this.errorOccurred = false;
        this.newImage = false;
        this.sub = this.route.params.subscribe(params => {
            this.houseId = +params['houseId'];
        });

        this.imageService.GetImagesByHouse(this.houseId)
            .then(imgs => {
                this.images = imgs;
            })
            .catch(error => this.logError(error));
    }

    public onSelect(img: image) {
        this.newImage = false;
        this.selectedImage = img;
    }

    public addImage() {
        this.newImage = true;
        this.selectedImage = new image();
    }

    public onCancelClick() {
        this.selectedImage = null;
        this.newImage = false;
    }

    public onDeleteClick() {
        this.imageService.DeleteImage(this.selectedImage.imageId)
            .then(imageData => {
                let element = this.images.findIndex(img => img.imageId == this.selectedImage.imageId);
                this.images.splice(element);
                this.selectedImage = null;
                this.newImage = false;
            })
            .catch(error => this.logError(error));
    }

    public onSubmit() {
        if (this.newImage) {
            this.selectedImage.houseId = this.houseId;
            this.imageService.CreateImage(this.selectedImage)
                .then(img => {
                    this.images.push(img);
                    this.selectedImage = null;
                })
                .catch(error => this.logError(error));
        }
        else {
            this.imageService.UpdateImage(this.selectedImage)
                .then(img => {
                    this.selectedImage = null;
                })
                .catch(error => this.logError(error));
        }
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    private logError(error: any) {
        this.errorOccurred = true;
        console.log(error);
    }

}