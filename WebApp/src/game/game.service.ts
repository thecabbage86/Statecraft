import { IGameResponse } from './models/game-response';
import { IGame } from './models/game';

import { Http, Response, RequestOptions, Headers } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import "rxjs/add/operator/do";
import "rxjs/add/operator/catch";

@Injectable()
export class GameService {
    private _url = "http://localhost:64660/games";

    constructor(private _http: Http){ }

    getGamesByPlayerId(playerId: string): Observable<IGameResponse> {
        let headers = new Headers({ 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        
        return this._http.get(this._url + "?playerId=" + playerId, options)
            .map((response: Response) => <IGameResponse>response.json())
            .do(data => console.log("All: " + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || "A server error has occurred");
    }
}