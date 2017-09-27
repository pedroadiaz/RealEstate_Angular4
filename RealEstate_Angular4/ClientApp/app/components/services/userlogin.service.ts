import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import 'rxjs/Rx';
import 'rxjs/add/operator/toPromise';

import { userlogin } from '../models/userlogin';
import { PermissionType } from '../models/permission.type';

@Injectable() 
export class UserLoginService {
    public loginData: userlogin;

    constructor(private http: Http) {
        this.loginData = { userLoginId: 1, username: "hello", password: "goodbye", permissionLevel: PermissionType.Customer };
    }


    public login(username: string, password: string): Promise<userlogin> {
        localStorage.removeItem('currentUser');
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post('/api/UserLogin/CheckCredentials', JSON.stringify({ username: username, password: password }), options)
            .toPromise()
            .then(response => {
                if (response.ok) {
                    let user = response.json() as userlogin;
                    if (user) {
                        this.loginData = user;
                        localStorage.setItem('currentUser', JSON.stringify(user))
                    }
                    return user;
                }
                else {
                    return this.loginData;
                }
            })
            .catch(this.handleError);

    }

    public logout() {
        localStorage.removeItem('currentUser');
    }

    private handleError(error: any) {
        console.log('An error occurred');
        return Promise.reject(error.message || error);
    }


}
