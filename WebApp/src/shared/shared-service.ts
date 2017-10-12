import { Observable } from 'rxjs/Observable';
import { GameService } from 'game/game.service';
import { Injectable } from '@angular/core';
import { IPlayer } from "player/models/player";
import { Observer } from "rxjs/Observer";

@Injectable()
export class SharedService {
    player: IPlayer;
    errorMessage: string;
    playerId: AAGUID = "AB858B6C-3D5E-4388-A49E-10ED3115800C"; //TODO: handle playerId properly
    playerObservable: Observable<any>;
    playerObserver: Observer<any>;

    //constructor(private _gameService: GameService){
        // this.playerObservable = new Observable((observer: Observer) {
        //     this.playerObserver = observer;
        // });
        // this._gameService.getPlayerById(this.playerId)
        //     .subscribe(player => this.player = player, error => this.errorMessage = <any>error);
    //}

    setPlayer(player: IPlayer){
        //this.player = player;
        //this.playerObserver.next(this.player);
        this.player = player;
    }
}