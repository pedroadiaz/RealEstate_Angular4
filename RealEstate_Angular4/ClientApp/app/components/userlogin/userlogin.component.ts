import { Component, Input, Output, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { UserLoginService } from '../services/userlogin.service';

import { userlogin } from '../models/userlogin';
import { PermissionType } from '../models/permission.type';

@Component({
    selector: 'userlogin',
    templateUrl: './userlogin.component.html',
    styleUrls: ['./userlogin.component.css']
})


export class UserLoginComponent implements OnInit {
    loading = false;
    model = new userlogin();
    public errorOccurred: boolean;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private userloginService: UserLoginService
    ) {
    }

    ngOnInit() {
        localStorage.removeItem('currentUser');
        this.errorOccurred = false;
    }

    public login() {
        this.errorOccurred = false;
        this.loading = true;
        this.userloginService.login(this.model.username, this.model.password)
            .then(logindata => {
                this.model = logindata
                this.router.navigate(['/listings']);
            })
            .catch(error => this.loginError(error));
    }

    private loginError(error: any) {
        this.errorOccurred = true;
        console.log(error);
    }
}