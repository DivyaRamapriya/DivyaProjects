import {Injectable}    from "@angular/core";
import {Http} from "@angular/http";

declare var JSON: any;


export class UserService {
    private apiUrl = "/api/v1/";

    constructor(private http: Http) { }
    /*

    gettable(): Promise<any> {
        const url = `${this.apiUrl}table`;
        return this.http.get(url, { body: "" })
            .toPromise()
            .then(response => JSON.parseWithDate(response.text()));
    }
        */
}