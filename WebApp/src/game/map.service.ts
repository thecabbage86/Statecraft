import { Http, Response, RequestOptions, Headers } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import "rxjs/add/operator/do";
import "rxjs/add/operator/catch";

@Injectable()
export class MapService{
    private _url = "../assets/dipmapempty.json";

    constructor(private _http: Http){}

    getMap(){
        return this._http.get(this._url)
            .map((response: Response) => response.json())
            .do(data => data)
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || "A server error has occurred");
    }
}