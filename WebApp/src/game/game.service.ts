import { IPlayer } from 'player/models/player';
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
    private _url = "http://localhost:64660/";
    private _gameUrl = "http://localhost:64660/games";

    constructor(private _http: Http){ }

    getGamesByPlayerId(playerId: string): Observable<IGameResponse> {
        let headers = new Headers({ 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        
        return this._http.get(this._gameUrl + "?playerId=" + playerId, options)
            .map((response: Response) => <IGameResponse>response.json())
            .do(data => console.log("All: " + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getGameById(gameId: AAGUID): Observable<IGameResponse> {
        let headers = new Headers({ 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        
        return this._http.get(this._gameUrl + "/" + gameId, options)
            .map((response: Response) => <IGameResponse>response.json())
            .do(data => console.log("All: " + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getPlayerById(playerId: string) : Observable<IPlayer> {
        let headers = new Headers({ 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.get(this._url + "players/" + playerId, options)
            .map((response: Response) => <IPlayer>response.json())
            .do(data => console.log("Player: " + JSON.stringify(data)))
            .catch(this.handleError);
    }

    createPlayer(player: IPlayer) : Observable<IPlayer> {
        let headers = new Headers({ 'Accept': 'application/json', 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.post(this._url + "players", JSON.stringify(player), options)
            .map((response: Response) => <IPlayer>response.json())
            .do(data => console.log("Player: " + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || "A server error has occurred");
    }
}